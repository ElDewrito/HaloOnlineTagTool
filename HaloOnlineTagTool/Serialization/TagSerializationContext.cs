using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;

namespace HaloOnlineTagTool.Serialization
{
    /// <summary>
    /// A serialization context for serializing and deserializing tags.
    /// </summary>
    public class TagSerializationContext : ISerializationContext
    {
        private const int DefaultBlockAlign = 4;

        private readonly Stream _stream;
        private readonly TagCache _cache;
        private readonly StringIdCache _stringIds;
        private TagData _data;

        /// <summary>
        /// Creates a tag serialization context which serializes data into a tag.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="cache">The cache file to write to.</param>
        /// <param name="stringIds">The stringID source to use.</param>
        /// <param name="tag">The tag to overwrite.</param>
        public TagSerializationContext(Stream stream, TagCache cache, StringIdCache stringIds, TagInstance tag)
        {
            _stream = stream;
            _cache = cache;
            _stringIds = stringIds;
            Tag = tag;
        }

        /// <summary>
        /// Gets the tag that the context is operating on.
        /// </summary>
        public TagInstance Tag { get; }

        public void BeginSerialize(TagStructureInfo info)
        {
            _data = new TagData
            {
                Group = new TagGroup
                (
                    tag: info.GroupTag,
                    parentTag: info.ParentGroupTag,
                    grandparentTag: info.GrandparentGroupTag,
                    name: (info.Structure.Name != null) ? _stringIds.GetStringId(info.Structure.Name) : StringId.Null
                ),
            };
        }

        public void EndSerialize(TagStructureInfo info, byte[] data, uint mainStructOffset)
        {
            _data.MainStructOffset = mainStructOffset;
            _data.Data = data;
            _cache.SetTagData(_stream, Tag, _data);
            _data = null;
        }

        public BinaryReader BeginDeserialize(TagStructureInfo info)
        {
            var data = _cache.ExtractTagRaw(_stream, Tag);
            var reader = new BinaryReader(new MemoryStream(data));
            reader.BaseStream.Position = Tag.MainStructOffset;
            return reader;
        }

        public void EndDeserialize(TagStructureInfo info, object obj)
        {
        }

        public uint AddressToOffset(uint currentOffset, uint address)
        {
            return Tag.PointerToOffset(address);
        }

        public TagInstance GetTagByIndex(int index)
        {
            return (index >= 0 && index < _cache.Tags.Count) ? _cache.Tags[index] : null;
        }

        public IDataBlock CreateBlock()
        {
            return new TagDataBlock(this);
        }

        private class TagDataBlock : IDataBlock
        {
            private readonly TagSerializationContext _context;
            private readonly List<TagPointerFixup> _fixups = new List<TagPointerFixup>();
            private readonly List<uint> _resourceOffsets = new List<uint>();
            private uint _align = DefaultBlockAlign;

            public TagDataBlock(TagSerializationContext context)
            {
                _context = context;
                Stream = new MemoryStream();
                Writer = new BinaryWriter(Stream);
            }

            public MemoryStream Stream { get; private set; }

            public BinaryWriter Writer { get; private set; }

            public void WritePointer(uint targetOffset, Type type)
            {
                // Add a data fixup for the pointer
                var fixup = MakeFixup(targetOffset);
                _fixups.Add(fixup);

                // Add a resource fixup if this is a resource reference
                if (type == typeof(ResourceReference))
                    _resourceOffsets.Add(fixup.WriteOffset);

                // Write the address
                Writer.Write(_context.Tag.OffsetToPointer(targetOffset));
            }

            public object PreSerialize(TagFieldAttribute info, object obj)
            {
                if (obj == null)
                    return null;

                // Get the object type and make sure it's supported
                var type = obj.GetType();
                if (type == typeof(ResourceDataReference) ||
                    (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(D3DPointer<>)))
                    throw new InvalidOperationException(type + " cannot be serialized as tag data");

                // HACK: If the object is a ResourceReference, fix the Owner property
                var resource = obj as ResourceReference;
                if (resource != null)
                    resource.Owner = _context.Tag;

                if (type == typeof(TagInstance))
                {
                    // Object is a tag reference - add it as a dependency
                    var referencedTag = obj as TagInstance;
                    if (referencedTag != null && referencedTag != _context.Tag)
                        _context._data.Dependencies.Add(referencedTag.Index);
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

                // Adjust fixups and add them to the tag
                _context._data.PointerFixups.AddRange(_fixups.Select(f => FinalizeFixup(f, dataOffset)));
                _context._data.ResourcePointerOffsets.AddRange(_resourceOffsets.Select(o => o + dataOffset));

                // Free the block data
                Writer.Close();
                Stream = null;
                Writer = null;
                return dataOffset;
            }

            private TagPointerFixup MakeFixup(uint targetOffset)
            {
                return new TagPointerFixup
                {
                    TargetOffset = targetOffset,
                    WriteOffset = (uint)Stream.Position
                };
            }

            private static TagPointerFixup FinalizeFixup(TagPointerFixup fixup, uint dataOffset)
            {
                return new TagPointerFixup
                {
                    TargetOffset = fixup.TargetOffset,
                    WriteOffset = dataOffset + fixup.WriteOffset
                };
            }
        }
    }
}
