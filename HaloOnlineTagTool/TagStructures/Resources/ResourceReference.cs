using System;
using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures.Resources
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

		[TagElement]
		public byte[] DefinitionData { get; set; }

		[TagElement]
		public ResourceAddress DefinitionAddress { get; set; }

		[TagElement]
		public List<Fixup> Fixups { get; set; }

		[TagElement]
		public List<DefinitionStructureFixup> StructureFixups { get; set; }
			
		[TagElement]
		public int Unknown68 { get; set; }

		/// <summary>
		/// A fixup which is applied to a resource's definition data.
		/// </summary>
		[TagStructure(Size = 0x8)]
		public class Fixup
		{
			/// <summary>
			/// Gets or sets the offset from the start of the definition data where the address should be written.
			/// </summary>
			[TagElement]
			public uint InfoBufferOffset { get; set; }

			/// <summary>
			/// Gets or sets the address which the value in the definition data should point to.
			/// </summary>
			[TagElement]
			public ResourceAddress Address { get; set; }
		}

		[TagStructure(Size = 0x8)]
		public class DefinitionStructureFixup
		{
			[TagElement]
			public ResourceAddress Address { get; set; }

			[TagElement]
			public ResourceStructureType Type { get; set; }
		}

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

		/// <summary>
		/// Indicates that the resource's checksum should be validated.
		/// Alternate flag for <see cref="UseChecksum"/>.
		/// </summary>
		UseChecksum2 = 1 << 7
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
	/// Resource definition struture types.
	/// </summary>
	public enum ResourceStructureType : int
	{
		VertexBuffer,      // s_tag_d3d_vertex_buffer
		IndexBuffer,       // s_tag_d3d_index_buffer
		Texture,           // s_tag_d3d_texture
		InterleavedTexture // s_tag_d3d_texture_interleaved
	}
}
