using System;
using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources
{
	/// <summary>
	/// A reference to a resource used by a tag.
	/// This is treated by the serialization system as a special type of tag element.
	/// </summary>
	[TagStructure(Size = 0x6C)]
	public class ResourceReference
	{
		[TagElement]
		public sbyte Unknown0 { get; set; }

		[TagElement]
		public sbyte Unknown1 { get; set; }

		/// <summary>
		/// Gets or sets flags containing information about where the resource is located.
		/// </summary>
		[TagElement]
		public ResourceLocationFlags LocationFlags { get; set; }

		// Not 100% sure on this
		// -1 = uncompressed?
		[TagElement]
		public sbyte CompressionType { get; set; }

		/// <summary>
		/// Gets or sets the index of the resource within its .dat file.
		/// </summary>
		[TagElement]
		public int Index { get; set; }

		/// <summary>
		/// Gets or sets the total size of the compressed resource data, including chunk headers.
		/// </summary>
		[TagElement]
		public uint CompressedSize { get; set; }

		/// <summary>
		/// Gets or sets the size of the decompressed resource data.
		/// </summary>
		[TagElement]
		public uint DecompressedSize { get; set; }

		/// <summary>
		/// Gets or sets the checksum of the resource data.
		/// Only used if <see cref="ResourceLocationFlags.UseChecksum"/> or <see cref="ResourceLocationFlags.UseChecksum2"/> are set.
		/// </summary>
		[TagElement]
		public uint Checksum { get; set; }

		// Not 100% sure on this...if this is nonzero, the resource is decompressed and this is the size
		[TagElement]
		public uint RawSize { get; set; }

		[TagElement]
		public uint Unknown18 { get; set; }

		[TagElement]
		public uint Unknown1C { get; set; }

		[TagElement]
		public uint Unknown20 { get; set; }

		/// <summary>
		/// Gets or sets the tag that owns the resource.
		/// </summary>
		[TagElement]
		public HaloTag Owner { get; set; }

		[TagElement]
		public ushort Salt { get; set; }

		[TagElement]
		public sbyte Type { get; set; }

		[TagElement]
		public byte Unknown37 { get; set; }

		/// <summary>
		/// Gets or sets the buffer containing the resource's definition data.
		/// </summary>
		[TagElement]
		public byte[] DefinitionData { get; set; }

		/// <summary>
		/// Gets or sets the address of the resource's definition structure within its definition data.
		/// </summary>
		[TagElement]
		public ResourceAddress DefinitionAddress { get; set; }

		/// <summary>
		/// Gets or sets the fixups to apply to the definition data.
		/// </summary>
		[TagElement]
		public List<ResourceDefinitionFixup> DefinitionFixups { get; set; }

		/// <summary>
		/// Gets or sets the D3D object fixups to apply to the definition data.
		/// </summary>
		[TagElement]
		public List<D3DObjectFixup> D3DObjectFixups { get; set; }
			
		[TagElement]
		public int Unknown68 { get; set; }

		/// <summary>
		/// Gets the location of the resource by checking its location flags.
		/// </summary>
		/// <returns>The resource's location.</returns>
		/// <exception cref="InvalidOperationException">The resource does not have a location flag set</exception>
		public ResourceLocation GetLocation()
		{
			if ((LocationFlags & ResourceLocationFlags.InResources) != 0)
				return ResourceLocation.Resources;
			if ((LocationFlags & ResourceLocationFlags.InTextures) != 0)
				return ResourceLocation.Textures;
			if ((LocationFlags & ResourceLocationFlags.InTexturesB) != 0)
				return ResourceLocation.TexturesB;
			if ((LocationFlags & ResourceLocationFlags.InAudio) != 0)
				return ResourceLocation.Audio;
			if ((LocationFlags & ResourceLocationFlags.InVideo) != 0)
				return ResourceLocation.Video;
			throw new InvalidOperationException("The resource does not have a location flag set");
		}

		/// <summary>
		/// Changes the location of the resource by changing its location flags.
		/// </summary>
		/// <param name="newLocation">The new location.</param>
		/// <exception cref="System.ArgumentException">Unsupported resource location</exception>
		public void ChangeLocation(ResourceLocation newLocation)
		{
			LocationFlags &= ~ResourceLocationFlags.LocationMask;
			switch (newLocation)
			{
				case ResourceLocation.Resources:
					LocationFlags |= ResourceLocationFlags.InResources;
					break;
				case ResourceLocation.Textures:
					LocationFlags |= ResourceLocationFlags.InTextures;
					break;
				case ResourceLocation.TexturesB:
					LocationFlags |= ResourceLocationFlags.InTexturesB;
					break;
				case ResourceLocation.Audio:
					LocationFlags |= ResourceLocationFlags.InAudio;
					break;
				case ResourceLocation.Video:
					LocationFlags |= ResourceLocationFlags.InVideo;
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
			LocationFlags &= ~(ResourceLocationFlags.UseChecksum | ResourceLocationFlags.UseChecksum2);
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
		[TagElement]
		public uint DefinitionDataOffset { get; set; }

		/// <summary>
		/// Gets or sets the address which the value in the definition data should point to.
		/// </summary>
		[TagElement]
		public ResourceAddress Address { get; set; }
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
		[TagElement]
		public ResourceAddress Address { get; set; }

		/// <summary>
		/// Gets or sets the type of object to load.
		/// </summary>
		[TagElement]
		public D3DObjectType Type { get; set; }
	}

	/// <summary>
	/// Flags related to the location and storage of the resource data.
	/// </summary>
	[Flags]
	public enum ResourceLocationFlags : byte
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
		Video
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
