using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Resources.Bitmaps;
using HaloOnlineTagTool.Resources.Geometry;

namespace HaloOnlineTagTool.Serialization
{
    /// <summary>
    /// A serialization context for serializing and deserializing resource definition structures.
    /// </summary>
    public class ResourceSerializationContext : ISerializationContext
    {
        private const int DefaultBlockAlign = 0x10;

        private readonly ResourceReference _resource;

        private readonly List<ResourceDefinitionFixup> _fixups = new List<ResourceDefinitionFixup>();
        private readonly List<D3DObjectFixup> _d3dFixups = new List<D3DObjectFixup>();

        public ResourceSerializationContext(ResourceReference resource)
        {
            _resource = resource;
        }

        public void BeginSerialize(TagStructureInfo info)
        {
            _fixups.Clear();
            _d3dFixups.Clear();
        }

        public void EndSerialize(TagStructureInfo info, byte[] data, uint mainStructOffset)
        {
            _resource.DefinitionFixups.Clear();
            _resource.D3DObjectFixups.Clear();
            _resource.DefinitionFixups.AddRange(_fixups);
            _resource.D3DObjectFixups.AddRange(_d3dFixups);
            _resource.DefinitionData = data;
            _resource.DefinitionAddress = new ResourceAddress(ResourceAddressType.Definition, (int)mainStructOffset);
        }

        public BinaryReader BeginDeserialize(TagStructureInfo info)
        {
            if (_resource.DefinitionAddress.Value == 0 || _resource.DefinitionAddress.Type != ResourceAddressType.Definition)
                throw new InvalidOperationException("Invalid resource definition address");

            // Create a stream with a copy of the resource definition data
            var stream = new MemoryStream(_resource.DefinitionData.Length);
            stream.Write(_resource.DefinitionData, 0, _resource.DefinitionData.Length);
            
            // Apply fixups
            var writer = new BinaryWriter(stream);
            foreach (var fixup in _resource.DefinitionFixups)
            {
                stream.Position = fixup.DefinitionDataOffset;
                writer.Write(fixup.Address.Value);
            }
            stream.Position = _resource.DefinitionAddress.Offset;
            return new BinaryReader(stream);
        }

        public void EndDeserialize(TagStructureInfo info, object obj)
        {
        }

        public uint AddressToOffset(uint currentOffset, uint address)
        {
            var resourceAddress = new ResourceAddress(address);
            if (resourceAddress.Type != ResourceAddressType.Definition)
                throw new InvalidOperationException("Cannot dereference a resource address of type " + resourceAddress.Type);
            return (uint)resourceAddress.Offset;
        }

        public TagInstance GetTagByIndex(int index)
        {
            throw new InvalidOperationException("Resource definitions cannot contain tag references");
        }

        public IDataBlock CreateBlock()
        {
            return new ResourceDataBlock(this);
        }

        private class ResourceDataBlock : IDataBlock
        {
            private readonly ResourceSerializationContext _context;
            private readonly List<ResourceDefinitionFixup> _fixups = new List<ResourceDefinitionFixup>();
            private readonly List<D3DObjectFixup> _d3dFixups = new List<D3DObjectFixup>();
            private uint _align = DefaultBlockAlign;

            public ResourceDataBlock(ResourceSerializationContext context)
            {
                _context = context;
                Stream = new MemoryStream();
                Writer = new BinaryWriter(Stream);
            }

            public MemoryStream Stream { get; private set; }

            public BinaryWriter Writer { get; private set; }

            public void WritePointer(uint targetOffset, Type type)
            {
                // Add a fixup for the pointer
                _fixups.Add(MakeDefinitionFixup(new ResourceAddress(ResourceAddressType.Definition, (int)targetOffset)));

                // Just write a zero (this is how it's done officially...)
                Writer.Write(0);
            }

            public object PreSerialize(TagFieldAttribute info, object obj)
            {
                if (obj == null)
                    return null;

                // When serializing a resource address, just add a fixup for it and serialize a null pointer
                if (obj is ResourceAddress)
                {
                    _fixups.Add(MakeDefinitionFixup((ResourceAddress)obj));
                    return 0U;
                }

                var type = obj.GetType();
                if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(D3DPointer<>))
                {
                    // Add a D3D fixup for D3DPointers based on the type of object being pointed to
                    var d3dType = GetD3DObjectType(type.GenericTypeArguments[0]);
                    _d3dFixups.Add(MakeD3DFixup((uint)Stream.Position, d3dType));
                }
                return obj;
            }

            public void SuggestAlignment(uint align)
            {
                _align = Math.Max(_align, align);
            }

            public uint Finalize(Stream outStream)
            {
                // Write the data out, aligning the offset and size
                StreamUtil.Align(outStream, (int)_align);
                var dataOffset = (uint)outStream.Position;
                outStream.Write(Stream.GetBuffer(), 0, (int)Stream.Length);
                StreamUtil.Align(outStream, DefaultBlockAlign);

                // Adjust fixups and add them to the resource
                _context._fixups.AddRange(_fixups.Select(f => FinalizeDefinitionFixup(f, dataOffset)));
                _context._d3dFixups.AddRange(_d3dFixups.Select(f => FinalizeD3DFixup(f, dataOffset)));

                // Free the block data
                Writer.Close();
                Stream = null;
                Writer = null;
                return dataOffset;
            }

            private ResourceDefinitionFixup MakeDefinitionFixup(ResourceAddress address)
            {
                return new ResourceDefinitionFixup
                {
                    Address = address,
                    DefinitionDataOffset = (uint)Stream.Position
                };
            }

            private D3DObjectFixup MakeD3DFixup(uint offset, D3DObjectType type)
            {
                return new D3DObjectFixup
                {
                    Type = type,
                    Address = new ResourceAddress(ResourceAddressType.Definition, (int)offset)
                };
            }

            private static D3DObjectType GetD3DObjectType(Type type)
            {
                if (type == typeof(VertexBufferDefinition))
                    return D3DObjectType.VertexBuffer;
                if (type == typeof(IndexBufferDefinition))
                    return D3DObjectType.IndexBuffer;
                if (type == typeof(BitmapTextureResourceDefinition.BitmapDefinition))
                    return D3DObjectType.Texture;
                // TODO: interleaved textures
                throw new InvalidOperationException("Invalid D3D object type: " + type);
            }

            private static ResourceDefinitionFixup FinalizeDefinitionFixup(ResourceDefinitionFixup fixup, uint dataOffset)
            {
                return new ResourceDefinitionFixup
                {
                    Address = fixup.Address,
                    DefinitionDataOffset = dataOffset + fixup.DefinitionDataOffset
                };
            }

            private static D3DObjectFixup FinalizeD3DFixup(D3DObjectFixup fixup, uint dataOffset)
            {
                return new D3DObjectFixup
                {
                    Type = fixup.Type,
                    Address = new ResourceAddress(fixup.Address.Type, fixup.Address.Offset + (int)dataOffset)
                };
            }
        }
    }
}
