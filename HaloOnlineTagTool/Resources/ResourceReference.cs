using System;
using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources
{
    /// <summary>
    /// A reference to a resource used by a tag.
    /// This is treated by the serialization system as a special type of tag element.
    /// </summary>
    [TagStructure(MaxVersion = EngineVersion.V1_106708_cert_ms23, Size = 0x6C)]
    [TagStructure(Size = 0x70)]
    public class ResourceReference
    {
        public sbyte Unknown0;

        public sbyte Unknown1;

        /// <summary>
        /// Gets or sets flags containing information about where the resource is located.
        /// </summary>
        [MaxVersion(EngineVersion.V1_106708_cert_ms23)]
        public OldResourceLocationFlags OldLocationFlags;

        /// <summary>
        /// Gets or sets flags containing information about where the resource is located.
        /// </summary>
        [MinVersion(EngineVersion.V1_235640_cert_ms25)]
        public NewResourceLocationFlags NewLocationFlags;

        // Not 100% sure on this
        // -1 = uncompressed?
        public sbyte CompressionType;

        [MinVersion(EngineVersion.V1_235640_cert_ms25)]
        public int Unknown4;

        /// <summary>
        /// Gets or sets the index of the resource within its .dat file.
        /// </summary>
        public int Index;

        /// <summary>
        /// Gets or sets the total size of the compressed resource data, including chunk headers.
        /// </summary>
        public uint CompressedSize;

        /// <summary>
        /// Gets or sets the size of the decompressed resource data.
        /// </summary>
        public uint DecompressedSize;

        /// <summary>
        /// Gets or sets the checksum of the resource data.
        /// Only used if <see cref="OldResourceLocationFlags.UseChecksum"/> or <see cref="OldResourceLocationFlags.UseChecksum2"/> are set.
        /// </summary>
        public uint Checksum;

        // Not 100% sure on this...if this is nonzero, the resource is decompressed and this is the size
        public uint RawSize;

        public uint Unknown18;

        public uint Unknown1C;

        public uint Unknown20;

        /// <summary>
        /// Gets or sets the tag that owns the resource.
        /// </summary>
        public TagInstance Owner;

        public ushort Salt;

        public sbyte Type;

        public byte Unknown37;

        /// <summary>
        /// Gets or sets the buffer containing the resource's definition data.
        /// </summary>
        public byte[] DefinitionData;

        /// <summary>
        /// Gets or sets the address of the resource's definition structure within its definition data.
        /// </summary>
        public ResourceAddress DefinitionAddress;

        /// <summary>
        /// Gets or sets the fixups to apply to the definition data.
        /// </summary>
        public List<ResourceDefinitionFixup> DefinitionFixups;

        /// <summary>
        /// Gets or sets the D3D object fixups to apply to the definition data.
        /// </summary>
        public List<D3DObjectFixup> D3DObjectFixups;

        public int Unknown68;

        /// <summary>
        /// Gets the location of the resource by checking its location flags.
        /// </summary>
        /// <returns>The resource's location.</returns>
        /// <exception cref="InvalidOperationException">The resource does not have a location flag set</exception>
        public ResourceLocation GetLocation()
        {
            if (OldLocationFlags != 0)
            {
                if ((OldLocationFlags & OldResourceLocationFlags.InResources) != 0)
                    return ResourceLocation.Resources;
                if ((OldLocationFlags & OldResourceLocationFlags.InTextures) != 0)
                    return ResourceLocation.Textures;
                if ((OldLocationFlags & OldResourceLocationFlags.InTexturesB) != 0)
                    return ResourceLocation.TexturesB;
                if ((OldLocationFlags & OldResourceLocationFlags.InAudio) != 0)
                    return ResourceLocation.Audio;
                if ((OldLocationFlags & OldResourceLocationFlags.InVideo) != 0)
                    return ResourceLocation.Video;
            }
            else if (NewLocationFlags != 0)
            {
                // FIXME: haxhaxhax, maybe we should just have separate types for the old and new reference layouts?
                if ((NewLocationFlags & NewResourceLocationFlags.InResources) != 0)
                    return ResourceLocation.Resources;
                if ((NewLocationFlags & NewResourceLocationFlags.InTextures) != 0)
                    return ResourceLocation.Textures;
                if ((NewLocationFlags & NewResourceLocationFlags.InTexturesB) != 0)
                    return ResourceLocation.TexturesB;
                if ((NewLocationFlags & NewResourceLocationFlags.InAudio) != 0)
                    return ResourceLocation.Audio;
                if ((NewLocationFlags & NewResourceLocationFlags.InVideo) != 0)
                    return ResourceLocation.Video;
                if ((NewLocationFlags & NewResourceLocationFlags.InRenderModels) != 0)
                    return ResourceLocation.RenderModels;
                if ((NewLocationFlags & NewResourceLocationFlags.InLightmaps) != 0)
                    return ResourceLocation.Lightmaps;
            }
            throw new InvalidOperationException("The resource does not have a location flag set");
        }

        /// <summary>
        /// Changes the location of the resource by changing its location flags.
        /// </summary>
        /// <param name="newLocation">The new location.</param>
        /// <exception cref="System.ArgumentException">Unsupported resource location</exception>
        public void ChangeLocation(ResourceLocation newLocation)
        {
            OldLocationFlags &= ~OldResourceLocationFlags.LocationMask;
            NewLocationFlags &= ~NewResourceLocationFlags.LocationMask;
            switch (newLocation)
            {
                case ResourceLocation.Resources:
                    OldLocationFlags |= OldResourceLocationFlags.InResources;
                    NewLocationFlags |= NewResourceLocationFlags.InResources;
                    break;
                case ResourceLocation.Textures:
                    OldLocationFlags |= OldResourceLocationFlags.InTextures;
                    NewLocationFlags |= NewResourceLocationFlags.InTextures;
                    break;
                case ResourceLocation.TexturesB:
                    OldLocationFlags |= OldResourceLocationFlags.InTexturesB;
                    NewLocationFlags |= NewResourceLocationFlags.InTexturesB;
                    break;
                case ResourceLocation.Audio:
                    OldLocationFlags |= OldResourceLocationFlags.InAudio;
                    NewLocationFlags |= NewResourceLocationFlags.InAudio;
                    break;
                case ResourceLocation.Video:
                    OldLocationFlags |= OldResourceLocationFlags.InVideo;
                    NewLocationFlags |= NewResourceLocationFlags.InVideo;
                    break;
                case ResourceLocation.RenderModels:
                    NewLocationFlags |= NewResourceLocationFlags.InRenderModels;
                    break;
                case ResourceLocation.Lightmaps:
                    NewLocationFlags |= NewResourceLocationFlags.InLightmaps;
                    break;
                default:
                    throw new ArgumentException("Unsupported resource location");
            }
        }

        /// <summary>
        /// Disables the resource's checksum by changing its location flags.
        /// </summary>
        public void DisableChecksum()
        {
            OldLocationFlags &= ~(OldResourceLocationFlags.UseChecksum | OldResourceLocationFlags.UseChecksum2);
            NewLocationFlags &= ~NewResourceLocationFlags.UseChecksum;
        }
    }

    /// <summary>
    /// A fixup which is applied to a resource's definition data.
    /// </summary>
    [TagStructure(Size = 0x8)]
    public class ResourceDefinitionFixup
    {
        /// <summary>
        /// Gets or sets the offset from the start of the definition data where the address should be written.
        /// </summary>
        public uint DefinitionDataOffset;

        /// <summary>
        /// Gets or sets the address which the value in the definition data should point to.
        /// </summary>
        public ResourceAddress Address;
    }

    /// <summary>
    /// A fixup applied to a resource definition's data which indicates to load a D3D object.
    /// </summary>
    [TagStructure(Size = 0x8)]
    public class D3DObjectFixup
    {
        /// <summary>
        /// Gets or sets the address of the object's definition.
        /// </summary>
        public ResourceAddress Address;

        /// <summary>
        /// Gets or sets the type of object to load.
        /// </summary>
        public D3DObjectType Type;
    }

    /// <summary>
    /// Flags related to the location and storage of the resource data.
    /// Only for 1.106708.
    /// </summary>
    [Flags]
    public enum OldResourceLocationFlags : byte
    {
        /// <summary>
        /// Indicates that the resource's checksum should be validated.
        /// </summary>
        UseChecksum = 1 << 0,

        /// <summary>
        /// Indicates that the resource is in resources.dat.
        /// </summary>
        InResources = 1 << 1,

        /// <summary>
        /// Indicates that the resource is in textures.dat.
        /// </summary>
        InTextures = 1 << 2,

        /// <summary>
        /// Indicates that the resource is in textures_b.dat.
        /// </summary>
        InTexturesB = 1 << 3,

        /// <summary>
        /// Indicates that the resource is in audio.dat.
        /// </summary>
        InAudio = 1 << 4,

        /// <summary>
        /// Indicates that the resource is in video.dat.
        /// </summary>
        InVideo = 1 << 5,

        Unknown6 = 1 << 6,

        /// <summary>
        /// Indicates that the resource's checksum should be validated.
        /// Alternate flag for <see cref="UseChecksum"/>.
        /// </summary>
        UseChecksum2 = 1 << 7,

        /// <summary>
        /// Mask for the location part of the flags.
        /// </summary>
        LocationMask = 0x3E,
    }

    /// <summary>
    /// Flags related to the location and storage of the resource data.
    /// Only for versions 1.235640 and newer.
    /// </summary>
    [Flags]
    public enum NewResourceLocationFlags : byte
    {
        /// <summary>
        /// Indicates that the resource's checksum should be validated.
        /// </summary>
        UseChecksum = 1 << 0,

        /// <summary>
        /// Indicates that the resource is in resources.dat.
        /// </summary>
        InResources = 1 << 1,

        /// <summary>
        /// Indicates that the resource is in textures.dat.
        /// </summary>
        InTextures = 1 << 2,

        /// <summary>
        /// Indicates that the resource is in textures_b.dat.
        /// </summary>
        InTexturesB = 1 << 3,

        /// <summary>
        /// Indicates that the resource is in audio.dat.
        /// </summary>
        InAudio = 1 << 4,

        /// <summary>
        /// Indicates that the resource is in video.dat.
        /// </summary>
        InVideo = 1 << 5,

        /// <summary>
        /// Indicates that the resource is in render_models.dat.
        /// </summary>
        InRenderModels = 1 << 6,

        /// <summary>
        /// Indicates that the resource is in lightmaps.dat.
        /// </summary>
        InLightmaps = 1 << 7,

        /// <summary>
        /// Mask for the location part of the flags.
        /// </summary>
        LocationMask = 0xFE,
    }

    /// <summary>
    /// Resource location constants used by <see cref="ResourceReference.GetLocation"/>.
    /// </summary>
    public enum ResourceLocation
    {
        /// <summary>
        /// The resource is in resources.dat.
        /// </summary>
        Resources,

        /// <summary>
        /// The resource is in textures.dat.
        /// </summary>
        Textures,

        /// <summary>
        /// The resource is in textures_b.dat.
        /// </summary>
        TexturesB,

        /// <summary>
        /// The resource is in audio.dat.
        /// </summary>
        Audio,

        /// <summary>
        /// The resource is in video.dat.
        /// </summary>
        Video,

        /// <summary>
        /// The resource is in render_models.dat.
        /// </summary>
        RenderModels,

        /// <summary>
        /// The resource is in lightmaps.dat.
        /// </summary>
        Lightmaps,
    }

    /// <summary>
    /// D3D object types.
    /// </summary>
    public enum D3DObjectType : int
    {
        VertexBuffer,      // s_tag_d3d_vertex_buffer
        IndexBuffer,       // s_tag_d3d_index_buffer
        Texture,           // s_tag_d3d_texture
        InterleavedTexture // s_tag_d3d_texture_interleaved
    }
}
