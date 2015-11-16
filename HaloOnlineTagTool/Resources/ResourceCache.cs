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
		private const int MaxDecompressedBlockSize = 0x7FFF8; // Decompressed chunks cannot exceed this size

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
		/// Adds a resource to the cache.
		/// </summary>
		/// <param name="inStream">The stream open on the resource cache.</param>
		/// <param name="data">The data to compress.</param>
		/// <param name="compressedSize">On return, the size of the compressed data.</param>
		/// <returns>The index of the resource that was added.</returns>
		public int Add(Stream inStream, byte[] data, out uint compressedSize)
		{
			// Add a resource of size 0 to the list
			var lastResource = (_resources.Count > 0) ? _resources[_resources.Count - 1] : null;
			var resourceIndex = _resources.Count;
			_resources.Add(new Resource
			{
				Offset = (lastResource != null) ? lastResource.Offset + lastResource.Size : 0,
				Size = 0,
			});

			// Now "replace" it
			compressedSize = Compress(inStream, resourceIndex, data);
			return resourceIndex;
		}

		/// <summary>
		/// Decompresses a resource.
		/// </summary>
		/// <param name="inStream">The stream open on the resource cache.</param>
		/// <param name="resourceIndex">The index of the resource to decompress.</param>
		/// <param name="compressedSize">Total size of the compressed data, including chunk headers.</param>
		/// <param name="outStream">The stream to write the decompressed resource data to.</param>
		public void Decompress(Stream inStream, int resourceIndex, uint compressedSize, Stream outStream)
		{
			if (resourceIndex < 0 || resourceIndex > _resources.Count)
				throw new ArgumentOutOfRangeException("resourceIndex");
			
			var reader = new BinaryReader(inStream);
			var resource = _resources[resourceIndex];
			reader.BaseStream.Position = resource.Offset;

			// Compressed resources are split into chunks, so decompress each chunk until the complete data is decompressed
			var totalProcessed = 0U;
			compressedSize = Math.Min(compressedSize, resource.Size);
			while (totalProcessed < compressedSize)
			{
				// Each chunk begins with a 32-bit decompressed size followed by a 32-bit compressed size
				var chunkDecompressedSize = reader.ReadInt32();
				var chunkCompressedSize = reader.ReadInt32();
				totalProcessed += 8;
				if (totalProcessed >= compressedSize)
					break;

				// Decompress the chunk and write it to the output stream
				var compressedData = new byte[chunkCompressedSize];
				reader.Read(compressedData, 0, chunkCompressedSize);
				var decompressedData = LZ4Codec.Decode(compressedData, 0, chunkCompressedSize, chunkDecompressedSize);
				outStream.Write(decompressedData, 0, chunkDecompressedSize);
				totalProcessed += (uint)chunkCompressedSize;
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

			// Divide the data into chunks with decompressed sizes no larger than the maximum allowed size
			var chunks = new List<byte[]>();
			var startOffset = 0;
			var newSize = 0;
			while (startOffset < data.Length)
			{
				var chunkSize = Math.Min(data.Length - startOffset, MaxDecompressedBlockSize);
				var chunk = LZ4Codec.EncodeHC(data, startOffset, chunkSize);
				chunks.Add(chunk);
				startOffset += chunkSize;
				newSize += ChunkHeaderSize + chunk.Length;
			}

			// Resize the resource's data so that the chunks can fit
			var resource = _resources[resourceIndex];
			var roundedSize = (newSize + 0xF) & ~0xFU; // Round up to a multiple of 0x10
			var sizeDelta = (int)(roundedSize - resource.Size);
			if (sizeDelta > 0)
			{
				// Resource needs to grow
				inStream.Position = resource.Offset + resource.Size;
				StreamUtil.Insert(inStream, sizeDelta, 0);
			}
			else
			{
				// Resource needs to shrink
				inStream.Position = resource.Offset + roundedSize;
				StreamUtil.Remove(inStream, -sizeDelta);
			}

			// Write the chunks in
			inStream.Position = resource.Offset;
			var writer = new BinaryWriter(inStream);
			var sizeRemaining = data.Length;
			foreach (var chunk in chunks)
			{
				var decompressedSize = Math.Min(sizeRemaining, MaxDecompressedBlockSize);
				writer.Write(decompressedSize);
				writer.Write(chunk.Length);
				writer.Write(chunk);
				sizeRemaining -= decompressedSize;
			}
			StreamUtil.Fill(inStream, 0, (int)(roundedSize - newSize)); // Padding

			// Adjust resource offsets
			resource.Size = (uint)roundedSize;
			for (var i = resourceIndex + 1; i < _resources.Count; i++)
				_resources[i].Offset = (uint)(_resources[i].Offset + sizeDelta);
			UpdateResourceTable(writer);
			return (uint)newSize;
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
