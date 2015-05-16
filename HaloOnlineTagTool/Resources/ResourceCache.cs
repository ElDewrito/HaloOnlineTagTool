using System;
using System.Collections.Generic;
using System.IO;
using LZ4;

namespace HaloOnlineTagTool.Resources
{
	// TODO: Come up with a common class for managing .dat files

	/// <summary>
	/// A .dat file containing resource data (e.g. resources.dat).
	/// </summary>
	public class ResourceCache
	{
		private const int ChunkHeaderSize = 0x8;

		private readonly List<Resource> _resources = new List<Resource>();

		/// <summary>
		/// Loads a resource cache from a stream.
		/// </summary>
		/// <param name="stream">The stream to read from.</param>
		public ResourceCache(Stream stream)
		{
			Load(stream);
		}

		/// <summary>
		/// Gets the number of resources in the archive.
		/// </summary>
		public int Count
		{
			get { return _resources.Count; }
		}

		/// <summary>
		/// Decompresses a resource.
		/// </summary>
		/// <param name="inStream">The stream open on the resource cache.</param>
		/// <param name="resourceIndex">The index of the resource to decompress.</param>
		/// <param name="decompressedSize">Total size of the decompressed resource.</param>
		/// <param name="outStream">The stream to write the decompressed resource data to.</param>
		public void Decompress(Stream inStream, int resourceIndex, uint decompressedSize, Stream outStream)
		{
			if (resourceIndex < 0 || resourceIndex > _resources.Count)
				throw new ArgumentOutOfRangeException("resourceIndex");
			
			var reader = new BinaryReader(inStream);
			reader.BaseStream.Position = _resources[resourceIndex].Offset;

			// Compressed resources are split into chunks, so decompress each chunk until the complete data is decompressed
			uint totalDecompressed = 0;
			while (totalDecompressed < decompressedSize)
			{
				// Each chunk begins with a 32-bit decompressed size followed by a 32-bit compressed size
				var chunkDecompressedSize = reader.ReadInt32();
				var chunkCompressedSize = reader.ReadInt32();

				// Decompress the chunk and write it to the output stream
				var compressedData = new byte[chunkCompressedSize];
				reader.Read(compressedData, 0, chunkCompressedSize);
				var decompressedData = LZ4Codec.Decode(compressedData, 0, chunkCompressedSize, chunkDecompressedSize);
				outStream.Write(decompressedData, 0, chunkDecompressedSize);
				totalDecompressed += (uint)chunkDecompressedSize;
			}
		}

		/// <summary>
		/// Compresses and saves data for a resource.
		/// </summary>
		/// <param name="inStream">The stream open on the resource data. It must have read/write access.</param>
		/// <param name="resourceIndex">The index of the resource to edit.</param>
		/// <param name="data">The data to compress.</param>
		/// <returns>The total size of the compressed resource in bytes.</returns>
		public uint Compress(Stream inStream, int resourceIndex, byte[] data)
		{
			if (resourceIndex < 0 || resourceIndex > _resources.Count)
				throw new ArgumentOutOfRangeException("resourceIndex");

			// Compress the data (just use a single chunk)
			var compressed = LZ4Codec.EncodeHC(data, 0, data.Length);

			// Resize the resource's data so that the chunk can fit
			var resource = _resources[resourceIndex];
			var newSize = (uint)compressed.Length + ChunkHeaderSize;
			newSize = (newSize + 0xF) & ~0xFU; // Round up to a multiple of 0x10
			var sizeDelta = (int)(newSize - resource.Size);
			if (sizeDelta > 0)
			{
				// Resource needs to grow
				inStream.Position = resource.Offset + resource.Size;
				StreamUtil.Insert(inStream, sizeDelta, 0);
			}
			else
			{
				// Resource needs to shrink
				inStream.Position = resource.Offset + newSize;
				StreamUtil.Remove(inStream, -sizeDelta);
			}

			// Write the chunk in
			inStream.Position = resource.Offset;
			var writer = new BinaryWriter(inStream);
			writer.Write(data.Length);
			writer.Write(compressed.Length);
			writer.Write(compressed, 0, compressed.Length);

			// Adjust resource offsets
			for (var i = resourceIndex + 1; i < _resources.Count; i++)
				_resources[i].Offset = (uint)(_resources[i].Offset + sizeDelta);
			UpdateResourceTable(writer);
			return (uint)compressed.Length + ChunkHeaderSize;
		}

		private void Load(Stream stream)
		{
			// Read the file header
			var reader = new BinaryReader(stream);
			reader.BaseStream.Position = 0x4;
			var tableOffset = reader.ReadUInt32();
			var resourceCount = reader.ReadInt32();

			// Read each resource pointer
			reader.BaseStream.Position = tableOffset;
			for (var i = 0; i < resourceCount; i++)
			{
				// Read offset
				_resources.Add(new Resource { Offset = reader.ReadUInt32() });

				// Compute size of previous resource
				if (i > 0)
					_resources[i - 1].Size = _resources[i].Offset - _resources[i - 1].Offset;
			}

			// Compute size of last resource
			_resources[resourceCount - 1].Size = tableOffset - _resources[resourceCount - 1].Offset;
		}

		private void UpdateResourceTable(BinaryWriter writer)
		{
			// Assume the table is past the last resource
			var lastResource = _resources[_resources.Count - 1];
			var tableOffset = lastResource.Offset + lastResource.Size;
			writer.BaseStream.Position = tableOffset;

			// Write each resource offset
			foreach (var resource in _resources)
				writer.Write(resource.Offset);

			// Update the file header
			writer.BaseStream.Position = 0x4;
			writer.Write(tableOffset);
			writer.Write(_resources.Count);
		}

		private class Resource
		{
			public uint Offset { get; set; }

			public uint Size { get; set; }
		}
	}
}
