﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
    /// <summary>
    /// Provides methods for easily editing tags.dat files.
    /// </summary>
    public class TagCache
    {
        private const uint CacheHeaderSize = 0x20;

        private readonly List<TagInstance> _tags = new List<TagInstance>();

        /// <summary>
        /// Opens a tags.dat file from a stream.
        /// </summary>
        /// <param name="stream">The stream to open.</param>
        public TagCache(Stream stream)
        {
            Tags = new TagList(_tags);

            if (stream.Length != 0)
                Load(new BinaryReader(stream));
        }

        /// <summary>
        /// Gets the tags in the file.
        /// </summary>
        public TagList Tags { get; }

        /// <summary>
        /// Gets the timestamp stored in the file (as a FILETIME value).
        /// </summary>
        public long Timestamp { get; set; }

        /// <summary>
        /// Allocates a new tag at the end of the tag list without updating the file.
        /// The tag's group will be null until it is assigned data.
        /// You can give the tag data by using one of the overwrite functions.
        /// </summary>
        /// <returns>The allocated tag.</returns>
        public TagInstance AllocateTag()
        {
            return AllocateTag(TagGroup.Null);
        }

        /// <summary>
        /// Allocates a new tag at the end of the tag list without updating the file.
        /// You can give the tag data by using one of the overwrite functions.
        /// </summary>
        /// <param name="type">The tag's type information.</param>
        /// <returns>The allocated tag.</returns>
        public TagInstance AllocateTag(TagGroup type)
        {
            var tagIndex = _tags.Count;
            var tag = new TagInstance(tagIndex, type);
            _tags.Add(tag);
            return tag;
        }

        /// <summary>
        /// Reads a tag's raw data from the file, including its header.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <returns>The data that was read.</returns>
        public byte[] ExtractTagRaw(Stream stream, TagInstance tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");
            stream.Position = tag.HeaderOffset;
            var result = new byte[tag.TotalSize];
            stream.Read(result, 0, result.Length);
            return result;
        }

        /// <summary>
        /// Reads a tag's data from the file.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <returns>The data that was read.</returns>
        public TagData ExtractTag(Stream stream, TagInstance tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");

            // Build the description info and get the data offset
            uint dataOffset;
            var data = BuildTagDescription(stream, tag, out dataOffset);

            // Read the tag data
            stream.Position = tag.HeaderOffset + dataOffset;
            data.Data = new byte[tag.TotalSize - dataOffset];
            stream.Read(data.Data, 0, data.Data.Length);

            // Correct pointers
            using (var dataWriter = new BinaryWriter(new MemoryStream(data.Data)))
            {
                foreach (var fixup in data.PointerFixups)
                {
                    dataWriter.BaseStream.Position = fixup.WriteOffset;
                    dataWriter.Write(tag.OffsetToPointer(fixup.TargetOffset));
                }
            }
            return data;
        }

        /// <summary>
        /// Overwrites a tag's raw data, including its header.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to overwrite.</param>
        /// <param name="data">The data to overwrite the tag with.</param>
        /// <exception cref="System.ArgumentNullException">tag</exception>
        public void SetTagDataRaw(Stream stream, TagInstance tag, byte[] data)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            // Ensure the data fits
            if (tag.HeaderOffset < 0)
                tag.HeaderOffset = GetNewTagOffset(tag.Index);
            ResizeBlock(stream, tag, tag.HeaderOffset, tag.TotalSize, data.Length);
            tag.TotalSize = data.Length;

            // Write the data
            stream.Position = tag.HeaderOffset;
            stream.Write(data, 0, data.Length);

            // Re-parse it
            stream.Position = tag.HeaderOffset;
            tag.ReadHeader(new BinaryReader(stream));
            UpdateTagOffsets(new BinaryWriter(stream));
        }

        /// <summary>
        /// Overwrites a tag's data.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to overwrite.</param>
        /// <param name="data">The data to store.</param>
        public void SetTagData(Stream stream, TagInstance tag, TagData data)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));
            if (data == null)
                throw new ArgumentNullException(nameof(data));
            if (data.Group == TagGroup.Null)
                throw new ArgumentException("Cannot assign a tag to a null tag group");
            if (data.Data == null)
                throw new ArgumentException("The tag data buffer is null");

            // Ensure the data fits
            var headerSize = TagInstance.CalculateHeaderSize(data);
            var alignedHeaderSize = (uint)((headerSize + 0xF) & ~0xF);
            if (tag.HeaderOffset < 0)
                tag.HeaderOffset = GetNewTagOffset(tag.Index);
            var alignedLength = (data.Data.Length + 0xF) & ~0xF;
            ResizeBlock(stream, tag, tag.HeaderOffset, tag.TotalSize, alignedHeaderSize + alignedLength);
            tag.TotalSize = alignedHeaderSize + alignedLength;
            tag.Update(data, alignedHeaderSize);

            // Write in the new header and data
            stream.Position = tag.HeaderOffset;
            var writer = new BinaryWriter(stream);
            tag.WriteHeader(writer);
            StreamUtil.Fill(stream, 0, (int)(alignedHeaderSize - headerSize));
            stream.Write(data.Data, 0, data.Data.Length);
            StreamUtil.Fill(stream, 0, alignedLength - data.Data.Length);

            // Correct pointers
            foreach (var fixup in data.PointerFixups)
            {
                writer.BaseStream.Position = tag.HeaderOffset + alignedHeaderSize + fixup.WriteOffset;
                writer.Write(tag.OffsetToPointer(alignedHeaderSize + fixup.TargetOffset));
            }
            UpdateTagOffsets(writer);
        }

        /// <summary>
        /// Duplicates a tag.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to duplicate.</param>
        /// <returns>The new tag.</returns>
        public TagInstance DuplicateTag(Stream stream, TagInstance tag)
        {
            if (tag == null)
                throw new ArgumentNullException(nameof(tag));

            // Just extract the tag and add it back
            var result = AllocateTag();
            SetTagDataRaw(stream, result, ExtractTagRaw(stream, tag));
            return result;
        }

        /// <summary>
        /// Builds a description for a tag's data without extracting anything.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <param name="dataOffset">On return, this will contain the offset of the tag's data relative to its header.</param>
        /// <returns>The description that was built. </returns>
        private static TagData BuildTagDescription(Stream stream, TagInstance tag, out uint dataOffset)
        {
            var data = new TagData
            {
                Group = tag.Group,
                MainStructOffset = tag.MainStructOffset,
            };
            foreach (var dependency in tag.Dependencies)
                data.Dependencies.Add(dependency);

            // Read pointer fixups
            var reader = new BinaryReader(stream);
            foreach (var pointerOffset in tag.PointerOffsets)
            {
                reader.BaseStream.Position = tag.HeaderOffset + pointerOffset;
                data.PointerFixups.Add(new TagPointerFixup
                {
                    WriteOffset = pointerOffset,
                    TargetOffset = tag.PointerToOffset(reader.ReadUInt32()),
                });
            }

            // Find the start of the tag's data by finding the offset of the first block which is pointed to by something
            // We CAN'T just calculate a header size here because we don't know for sure if there's padding and how big it is
            var startOffset = tag.MainStructOffset;
            foreach (var fixup in data.PointerFixups)
                startOffset = Math.Min(startOffset, Math.Min(fixup.WriteOffset, fixup.TargetOffset));

            // Now convert all offsets into relative ones
            foreach (var fixup in data.PointerFixups)
            {
                fixup.WriteOffset -= startOffset;
                fixup.TargetOffset -= startOffset;
            }
            data.ResourcePointerOffsets.AddRange(tag.ResourcePointerOffsets.Select(offset => offset - startOffset));
            data.MainStructOffset -= startOffset;
            dataOffset = startOffset;
            return data;
        }

        /// <summary>
        /// Resizes a block of data in the file.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="tag">The tag that the block belongs to, if any.</param>
        /// <param name="startOffset">The offset where the block to resize begins at.</param>
        /// <param name="oldSize">The current size of the block to resize.</param>
        /// <param name="newSize">The new size of the block.</param>
        /// <exception cref="System.ArgumentException">Cannot resize a block to a negative size</exception>
        private void ResizeBlock(Stream stream, TagInstance tag, long startOffset, long oldSize, long newSize)
        {
            if (newSize < 0)
                throw new ArgumentException("Cannot resize a block to a negative size");
            if (oldSize == newSize)
                return;
            var oldEndOffset = startOffset + oldSize;
            var sizeDelta = newSize - oldSize;
            StreamUtil.Copy(stream, oldEndOffset, oldEndOffset + sizeDelta, stream.Length - oldEndOffset);
            FixTagOffsets(oldEndOffset, sizeDelta, tag);
        }

        /// <summary>
        /// Fixes tag offsets after a resize operation.
        /// </summary>
        /// <param name="startOffset">The offset where the resize operation took place.</param>
        /// <param name="sizeDelta">The amount to add to each tag offset after the start offset.</param>
        /// <param name="ignore">A tag to ignore.</param>
        private void FixTagOffsets(long startOffset, long sizeDelta, TagInstance ignore)
        {
            foreach (var adjustTag in _tags.Where(t => t != null && t != ignore && t.HeaderOffset >= startOffset))
                adjustTag.HeaderOffset += sizeDelta;
        }

        /// <summary>
        /// Reads the tags.dat file.
        /// </summary>
        /// <param name="reader">The stream to read from.</param>
        private void Load(BinaryReader reader)
        {
            // Read file header
            reader.BaseStream.Position = 0x4;
            var tagListOffset = reader.ReadInt32(); // 0x4 uint32 offset table offset
            var tagCount = reader.ReadInt32();      // 0x8 uint32 number of tags
            reader.BaseStream.Position = 0x10;
            Timestamp = reader.ReadInt64();         // 0x10 FILETIME timestamp

            // Read tag offset list
            var headerOffsets = new uint[tagCount];
            reader.BaseStream.Position = tagListOffset;
            for (var i = 0; i < tagCount; i++)
                headerOffsets[i] = reader.ReadUInt32();

            // Read each tag
            for (var i = 0; i < tagCount; i++)
            {
                if (headerOffsets[i] == 0)
                {
                    // Offset of 0 = null tag
                    _tags.Add(null);
                    continue;
                }
                var tag = new TagInstance(i) { HeaderOffset = headerOffsets[i] };
                _tags.Add(tag);
                reader.BaseStream.Position = tag.HeaderOffset;
                tag.ReadHeader(reader);
            }
        }

        /// <summary>
        /// Gets the offset that a new tag should be inserted at so that the tags are stored in order by index.
        /// </summary>
        /// <param name="index">The index of the new tag.</param>
        /// <returns>The offset that the tag data should be written to.</returns>
        private long GetNewTagOffset(int index)
        {
            if (index < 0)
                throw new ArgumentException("Index cannot be negative");
            if (index >= _tags.Count - 1)
                return GetTagDataEndOffset();
            for (var i = index - 1; i >= 0; i--)
            {
                var tag = _tags[i];
                if (tag != null && tag.HeaderOffset >= 0)
                    return tag.HeaderOffset + tag.TotalSize;
            }
            return CacheHeaderSize;
        }

        /// <summary>
        /// Gets the tag data end offset.
        /// </summary>
        /// <returns>The offset of the first byte past the last tag in the file.</returns>
        private long GetTagDataEndOffset()
        {
            long endOffset = CacheHeaderSize;
            foreach (var tag in Tags.NonNull())
                endOffset = Math.Max(endOffset, tag.HeaderOffset + tag.TotalSize);
            return endOffset;
        }

        /// <summary>
        /// Updates the tag offset table in the file.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        public void UpdateTagOffsets(BinaryWriter writer)
        {
            var offsetTableOffset = GetTagDataEndOffset();
            writer.BaseStream.Position = offsetTableOffset;
            foreach (var tag in _tags)
            {
                if (tag != null && tag.HeaderOffset >= 0)
                    writer.Write((uint)tag.HeaderOffset);
                else
                    writer.Write(0);
            }
            writer.BaseStream.SetLength(writer.BaseStream.Position); // Truncate the file to end after the last offset
            UpdateFileHeader(writer, offsetTableOffset);
        }

        /// <summary>
        /// Updates the file header.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        /// <param name="offsetTableOffset">The offset table offset.</param>
        private void UpdateFileHeader(BinaryWriter writer, long offsetTableOffset)
        {
            writer.BaseStream.Position = 0x0;
            writer.Write(0);                       // 0x0  uint32 unknown
            writer.Write((uint)offsetTableOffset); // 0x4  uint32 offset table offset
            writer.Write(_tags.Count);             // 0x8  uint32 number of tags
            writer.Write(0);                       // 0xC  uint32 unknown
            writer.Write(Timestamp);               // 0x10 uint32 timestamp
            writer.Write(0);                       // 0x18 uint32 unknown
            writer.Write(0);                       // 0x1C uint32 unknown
        }
    }
}
