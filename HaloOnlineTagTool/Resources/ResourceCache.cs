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
            if (stream.Length != 0)
                Load(stream);
            else
                _resources = new List<Resource>();
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
            var resourceIndex = NewResource();
            compressedSize = Compress(inStream, resourceIndex, data);
            return resourceIndex;
        }

        /// <summary>
        /// Adds a raw, pre-compressed resource to the cache.
        /// </summary>
        /// <param name="inStream">The stream open on the resource cache.</param>
        /// <param name="rawData">The raw data to add.</param>
        /// <returns>The index of the resource that was added.</returns>
        public int AddRaw(Stream inStream, byte[] rawData)
        {
            var resourceIndex = NewResource();
            ImportRaw(inStream, resourceIndex, rawData);
            return resourceIndex;
        }

        /// <summary>
        /// Extracts raw, compressed resource data.
        /// </summary>
        /// <param name="inStream">The stream open on the resource cache.</param>
        /// <param name="resourceIndex">The index of the resource to decompress.</param>
        /// <param name="compressedSize">Total size of the compressed data, including chunk headers.</param>
        /// <returns>The raw, compressed resource data.</returns>
        public byte[] ExtractRaw(Stream inStream, int resourceIndex, uint compressedSize)
        {
            if (resourceIndex < 0 || resourceIndex >= _resources.Count)
                throw new ArgumentOutOfRangeException("resourceIndex");

            var resource = _resources[resourceIndex];
            inStream.Position = resource.Offset;
            var result = new byte[compressedSize];
            inStream.Read(result, 0, result.Length);
            return result;
        }

        /// <summary>
        /// Overwrites a resource with raw, pre-compressed data.
        /// </summary>
        /// <param name="inStream">The stream open on the resource cache.</param>
        /// <param name="resourceIndex">The index of the resource to overwrite.</param>
        /// <param name="data">The raw, pre-compressed data to overwrite it with.</param>
        public void ImportRaw(Stream inStream, int resourceIndex, byte[] data)
        {
            if (resourceIndex < 0 || resourceIndex >= _resources.Count)
                throw new ArgumentOutOfRangeException("resourceIndex");

            var roundedSize = ResizeResource(new BinaryWriter(inStream), resourceIndex, (uint)data.Length);
            var resource = _resources[resourceIndex];
            inStream.Position = resource.Offset;
            inStream.Write(data, 0, data.Length);
            StreamUtil.Fill(inStream, 0, (int)(roundedSize - data.Length)); // Padding
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
            if (resourceIndex < 0 || resourceIndex >= _resources.Count)
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
            if (resourceIndex < 0 || resourceIndex >= _resources.Count)
                throw new ArgumentOutOfRangeException("resourceIndex");

            // Divide the data into chunks with decompressed sizes no larger than the maximum allowed size
            var chunks = new List<byte[]>();
            var startOffset = 0;
            uint newSize = 0;
            while (startOffset < data.Length)
            {
                var chunkSize = Math.Min(data.Length - startOffset, MaxDecompressedBlockSize);
                var chunk = LZ4Codec.EncodeHC(data, startOffset, chunkSize);
                chunks.Add(chunk);
                startOffset += chunkSize;
                newSize += (uint)(ChunkHeaderSize + chunk.Length);
            }

            // Write the chunks in
            var writer = new BinaryWriter(inStream);
            var roundedSize = ResizeResource(writer, resourceIndex, newSize);
            var resource = _resources[resourceIndex];
            inStream.Position = resource.Offset;
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
            return newSize;
        }

        private int NewResource()
        {
            var lastResource = (_resources.Count > 0) ? _resources[_resources.Count - 1] : null;
            var resourceIndex = _resources.Count;
            _resources.Add(new Resource
            {
                Offset = (lastResource != null) ? lastResource.Offset + lastResource.Size : 0,
                Size = 0,
            });
            return resourceIndex;
        }

        private uint ResizeResource(BinaryWriter writer, int resourceIndex, uint minSize)
        {
            var resource = _resources[resourceIndex];
            var roundedSize = ((minSize + 0xF) & ~0xFU); // Round up to a multiple of 0x10
            var sizeDelta = (int)(roundedSize - resource.Size);
            var endOffset = resource.Offset + resource.Size;
            StreamUtil.Copy(writer.BaseStream, endOffset, endOffset + sizeDelta, writer.BaseStream.Length - endOffset);
            resource.Size = roundedSize;

            // Update resource offsets
            for (var i = resourceIndex + 1; i < _resources.Count; i++)
                _resources[i].Offset = (uint)(_resources[i].Offset + sizeDelta);
            UpdateResourceTable(writer);
            return roundedSize;
        }

        private void Load(Stream stream)
        {
            // Read the file header
            var reader = new BinaryReader(stream);
            reader.BaseStream.Position = 0x4;
            var tableOffset = reader.ReadUInt32();
            var resourceCount = reader.ReadInt32();

            if (resourceCount == 0)
                return;

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

        public void UpdateResourceTable(BinaryWriter writer)
        {
            // Assume the table is past the last resource
            uint tableOffset = 0xC;

            if (_resources.Count != 0)
            {
                var lastResource = _resources[_resources.Count - 1];
                tableOffset = lastResource.Offset + lastResource.Size;
            }

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
