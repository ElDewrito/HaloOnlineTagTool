// See http://pastebin.com/D3dgTqMR for structure definitions.

using System;
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
        private const uint TagHeaderSize = 0x24;
        private const uint FixupPointerBase = 0x40000000;

        private readonly List<HaloTag> _tags = new List<HaloTag>();

        /// <summary>
        /// Opens a tags.dat file from a stream.
        /// </summary>
        /// <param name="stream">The stream to open.</param>
        public TagCache(Stream stream)
        {
            Tags = new TagList(_tags);
            Load(new BinaryReader(stream));
        }

        /// <summary>
        /// Gets the tags in the file.
        /// </summary>
        public TagList Tags { get; private set; }

        /// <summary>
        /// Gets the timestamp stored in the file (as a FILETIME value).
        /// </summary>
        public long Timestamp { get; private set; }

        /// <summary>
        /// Saves any changes made to a tag's properties.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to update.</param>
        public void UpdateTag(Stream stream, HaloTag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");
            if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");
            var writer = new BinaryWriter(stream);
            UpdateTagHeader(writer, tag);
            UpdateTagFixups(writer, tag);
            UpdateTagOffsets(writer);
        }

        /// <summary>
        /// Reads a tag's data from the file, not including its header.
        /// Any pointers in the tag will be adjusted to be relative to the start of the tag's data.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <returns>The data that was read.</returns>
        public byte[] ExtractTagData(Stream stream, HaloTag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");
            if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");
            stream.Position = tag.DataOffset;
            var result = new byte[tag.DataSize];
            stream.Read(result, 0, result.Length);
            RebasePointers(tag, result, 0);
            return result;
        }

        /// <summary>
        /// Reads a tag's data from the file, including its header.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="tag">The tag to read.</param>
        /// <returns>The data that was read.</returns>
        public byte[] ExtractFullTag(Stream stream, HaloTag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");
            if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");
            stream.Position = tag.HeaderOffset;
            var result = new byte[tag.TotalSize];
            stream.Read(result, 0, result.Length);
            return result;
        }

        /// <summary>
        /// Allocates a new tag at the end of the tag list without updating the file.
        /// You can give the tag data by using one of the overwrite functions.
        /// </summary>
        /// <returns>The allocated tag.</returns>
        public HaloTag AllocateTag()
        {
            var tagIndex = _tags.Count;
            var tag = new HaloTag { Index = tagIndex };
            _tags.Add(tag);
            return tag;
        }

        /// <summary>
        /// Overwrites a tag's data, not including its header.
        /// Any pointers in the data to write will be adjusted to be relative to the start of the tag's header.
        /// Make sure that fixups are set correctly before calling this.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to overwrite.</param>
        /// <param name="data">The data to write.</param>
        public void OverwriteTagData(Stream stream, HaloTag tag, byte[] data)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            // Ensure the data fits
            var newHeaderSize = CalculateNewHeaderSize(tag);
            if (tag.HeaderOffset < 0)
                tag.HeaderOffset = GetNewTagOffset(tag.Index);
            var alignedLength = (data.Length + 0xF) & ~0xF;
            ResizeBlock(stream, tag, tag.HeaderOffset, tag.TotalSize, newHeaderSize + alignedLength);
            tag.DataOffset = tag.HeaderOffset + newHeaderSize;
            tag.DataSize = alignedLength;
                
            // Write it in and then update
            stream.Position = tag.DataOffset;
            stream.Write(data, 0, data.Length);
            StreamUtil.Fill(stream, 0, alignedLength - data.Length);
            UpdateTag(stream, tag);
        }

        /// <summary>
        /// Overwrites a tag's data, including its header.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to overwrite.</param>
        /// <param name="data">The data to overwrite the tag with.</param>
        /// <exception cref="System.ArgumentNullException">tag</exception>
        public void OverwriteFullTag(Stream stream, HaloTag tag, byte[] data)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            // Ensure the data fits
            if (tag.HeaderOffset < 0)
                tag.HeaderOffset = GetNewTagOffset(tag.Index);
            ResizeBlock(stream, tag, tag.HeaderOffset, tag.TotalSize, data.Length);
            
            // Write the data
            stream.Position = tag.HeaderOffset;
            stream.Write(data, 0, data.Length);

            // Re-parse it and update tag offsets
            stream.Position = tag.HeaderOffset;
            ReadTagHeader(new BinaryReader(stream), tag);
            UpdateTagOffsets(new BinaryWriter(stream));
        }

        /// <summary>
        /// Duplicates a tag.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag to duplicate.</param>
        /// <returns>The new tag.</returns>
        public HaloTag DuplicateTag(Stream stream, HaloTag tag)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");

            // Just extract the tag and add it back
            var result = AllocateTag();
            OverwriteFullTag(stream, result, ExtractFullTag(stream, tag));
            return result;
        }

        /// <summary>
        /// Resizes a block of tag data, updating relative pointers which do not point into the block.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        /// <param name="tag">The tag.</param>
        /// <param name="startOffset">The offset, from the start of the tag's data, where the block to resize begins at.</param>
        /// <param name="oldSize">The current size of the block to resize.</param>
        /// <param name="newSize">The new size of the block.</param>
        /// <param name="origin">The origin where data should be inserted or removed.</param>
        public void ResizeTagData(Stream stream, HaloTag tag, long startOffset, long oldSize, long newSize, ResizeOrigin origin)
        {
            if (tag == null)
                throw new ArgumentNullException("tag");
            if (tag.HeaderOffset < 0)
                throw new ArgumentException("The tag is not in the cache file");
            if (oldSize < 0)
                throw new ArgumentException("The old block size cannot be negative");
            if (newSize < 0)
                throw new ArgumentException("Cannot resize a block to a negative size");
            if (newSize == tag.DataSize)
                return;

            // Correct offsets pointing after the block
            var sizeDelta = newSize - oldSize;
            var blockEndOffset = startOffset + oldSize;
            tag.DataSize += sizeDelta;
            foreach (var fixup in tag.DataFixups.Concat(tag.ResourceFixups))
            {
                if (fixup.WriteOffset >= blockEndOffset)
                    fixup.WriteOffset = (uint)(fixup.WriteOffset + sizeDelta);
                if (fixup.TargetOffset >= blockEndOffset)
                    fixup.TargetOffset = (uint)(fixup.TargetOffset + sizeDelta);
            }
            if (tag.MainStructOffset >= blockEndOffset)
                tag.MainStructOffset = (uint)(tag.MainStructOffset + sizeDelta);
            FixTagOffsets(tag.DataOffset + blockEndOffset, sizeDelta, tag);

            // Insert/remove the data
            long editOffset;
            if (origin == ResizeOrigin.Beginning)
                editOffset = startOffset;
            else if (sizeDelta > 0)
                editOffset = blockEndOffset;
            else
                editOffset = blockEndOffset + sizeDelta;
            stream.Position = tag.DataOffset + editOffset;
            if (sizeDelta > 0)
                StreamUtil.Insert(stream, (int)sizeDelta, 0);
            else
                StreamUtil.Remove(stream, (int)-sizeDelta);
            UpdateTag(stream, tag);
        }

        /// <summary>
        /// Resizes a block of data in the file and updates tag offsets.
        /// </summary>
        /// <param name="stream">The stream.</param>
        /// <param name="tag">The tag that the block belongs to, if any.</param>
        /// <param name="startOffset">The offset where the block to resize begins at.</param>
        /// <param name="oldSize">The current size of the block to resize.</param>
        /// <param name="newSize">The new size of the block.</param>
        /// <exception cref="System.ArgumentException">Cannot resize a block to a negative size</exception>
        private void ResizeBlock(Stream stream, HaloTag tag, long startOffset, long oldSize, long newSize)
        {
            if (newSize < 0)
                throw new ArgumentException("Cannot resize a block to a negative size");
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
        private void FixTagOffsets(long startOffset, long sizeDelta, HaloTag ignore)
        {
            foreach (var adjustTag in _tags.Where(t => t != null && t != ignore && t.HeaderOffset >= startOffset))
            {
                adjustTag.HeaderOffset += sizeDelta;
                adjustTag.DataOffset += sizeDelta;
            }
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
                var tag = new HaloTag { Index = i, HeaderOffset = headerOffsets[i] };
                _tags.Add(tag);
                reader.BaseStream.Position = tag.HeaderOffset;
                ReadTagHeader(reader, tag);
            }
        }

        /// <summary>
        /// Reads a tag's header.
        /// </summary>
        /// <param name="reader">The stream to read from.</param>
        /// <param name="resultTag">The tag to update.</param>
        private static void ReadTagHeader(BinaryReader reader, HaloTag resultTag)
        {
            resultTag.Checksum = reader.ReadUInt32();                            // 0x00 uint32 checksum
            var totalSize = reader.ReadUInt32();                                 // 0x04 uint32 total size
            var numDependencies = reader.ReadInt16();                            // 0x08 int16  dependencies count
            var numDataFixups = reader.ReadInt16();                              // 0x0A int16  data fixup count
            var numResourceFixups = reader.ReadInt16();                          // 0x0C int16  resource fixup count
            reader.BaseStream.Position += 2;                                     // 0x0E int16  (padding)
            var mainStructOffset = reader.ReadUInt32();                          // 0x10 uint32 main struct offset
            resultTag.GroupTag = new MagicNumber(reader.ReadInt32());            // 0x14 int32  group tag
            resultTag.ParentGroupTag = new MagicNumber(reader.ReadInt32());      // 0x18 int32  parent group tag
            resultTag.GrandparentGroupTag = new MagicNumber(reader.ReadInt32()); // 0x1C int32  grandparent group tag
            resultTag.GroupName = new StringId(reader.ReadUInt32());             // 0x20 uint32 group name stringid

            // Read dependencies
            resultTag.Dependencies.Clear();
            for (var j = 0; j < numDependencies; j++)
                resultTag.Dependencies.Add(reader.ReadInt32());

            // Read fixup pointers
            resultTag.DataFixups.Clear();
            for (var j = 0; j < numDataFixups; j++)
                resultTag.DataFixups.Add(new TagFixup { WriteOffset = reader.ReadUInt32() - FixupPointerBase });
            resultTag.ResourceFixups.Clear();
            for (var j = 0; j < numResourceFixups; j++)
                resultTag.ResourceFixups.Add(new TagFixup { WriteOffset = reader.ReadUInt32() - FixupPointerBase });

            // Read fixup destinations
            foreach (var fixup in resultTag.DataFixups)
                fixup.TargetOffset = ReadFixupTarget(reader, fixup.WriteOffset, resultTag.HeaderOffset);
            foreach (var fixup in resultTag.ResourceFixups)
                fixup.TargetOffset = ReadFixupTarget(reader, fixup.WriteOffset, resultTag.HeaderOffset);

            // Compute the data offset based on the smallest offset into the tag
            var smallestOffset = mainStructOffset;
            foreach (var fixup in resultTag.DataFixups.Concat(resultTag.ResourceFixups))
            {
                if (fixup.WriteOffset < smallestOffset)
                    smallestOffset = fixup.WriteOffset;
                if (fixup.TargetOffset < smallestOffset)
                    smallestOffset = fixup.TargetOffset;
            }
            resultTag.MainStructOffset = mainStructOffset - smallestOffset;
            resultTag.DataOffset = resultTag.HeaderOffset + smallestOffset;
            resultTag.DataSize = totalSize - smallestOffset;

            // Make fixups relative to the data offset
            foreach (var fixup in resultTag.DataFixups.Concat(resultTag.ResourceFixups))
            {
                fixup.TargetOffset -= smallestOffset;
                fixup.WriteOffset -= smallestOffset;
            }
        }

        /// <summary>
        /// Reads the target offset (relative to the start of the header) of a fixup pointer.
        /// </summary>
        /// <param name="reader">The reader.</param>
        /// <param name="fixupOffset">The offset, relative to the start of the tag's header, of the fixup.</param>
        /// <param name="headerOffset">The offset of the tag's header.</param>
        /// <returns>The read fixup information.</returns>
        private static uint ReadFixupTarget(BinaryReader reader, uint fixupOffset, long headerOffset)
        {
            // Seek to the offset and read and adjust the target
            reader.BaseStream.Position = headerOffset + fixupOffset;
            return reader.ReadUInt32() - FixupPointerBase;
        }

        /// <summary>
        /// Writes a tag's header back to the file, resizing it if necessary.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        /// <param name="tag">The tag.</param>
        private void UpdateTagHeader(BinaryWriter writer, HaloTag tag)
        {
            // Resize the header if necessary
            var newHeaderSize = CalculateNewHeaderSize(tag);
            if (newHeaderSize != tag.HeaderSize)
                ResizeBlock(writer.BaseStream, tag, tag.HeaderOffset, tag.HeaderSize, newHeaderSize);
            tag.DataOffset = tag.HeaderOffset + newHeaderSize;

            // Write the tag header
            writer.BaseStream.Position = tag.HeaderOffset;
            writer.Write(tag.Checksum);
            writer.Write((uint)(tag.DataSize + newHeaderSize));
            writer.Write((short)tag.Dependencies.Count);
            writer.Write((short)tag.DataFixups.Count);
            writer.Write((short)tag.ResourceFixups.Count);
            writer.Write((short)0);
            writer.Write(tag.MainStructOffset + newHeaderSize);
            writer.Write(tag.GroupTag.Value);
            writer.Write(tag.ParentGroupTag.Value);
            writer.Write(tag.GrandparentGroupTag.Value);
            writer.Write(tag.GroupName.Value);

            // Write dependencies
            foreach (var dependency in tag.Dependencies)
                writer.Write(dependency);

            // Write fixup pointers
            foreach (var fixup in tag.DataFixups.Concat(tag.ResourceFixups))
                writer.Write(fixup.WriteOffset + newHeaderSize + FixupPointerBase);

            // Padding
            var paddingSize = (tag.HeaderSize - (writer.BaseStream.Position - tag.HeaderOffset)) & 0xF;
            for (var i = 0; i < paddingSize; i += 4)
                writer.Write(0);
        }

        /// <summary>
        /// Rebases fixup pointers in tag data.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <param name="data">The data.</param>
        /// <param name="newBase">The new base offset to use.</param>
        private static void RebasePointers(HaloTag tag, byte[] data, uint newBase)
        {
            using (var writer = new BinaryWriter(new MemoryStream(data)))
            {
                foreach (var fixup in tag.DataFixups)
                {
                    writer.BaseStream.Position = fixup.WriteOffset;
                    writer.Write(newBase + fixup.TargetOffset + FixupPointerBase);
                }
            }
        }

        /// <summary>
        /// Updates a tag's fixup information.
        /// </summary>
        /// <param name="writer">The stream to write to.</param>
        /// <param name="tag">The tag.</param>
        private static void UpdateTagFixups(BinaryWriter writer, HaloTag tag)
        {
            var totalHeaderSize = CalculateNewHeaderSize(tag);
            foreach (var fixup in tag.DataFixups)
            {
                writer.BaseStream.Position = tag.DataOffset + fixup.WriteOffset;
                writer.Write(fixup.TargetOffset + totalHeaderSize + FixupPointerBase);
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
                if (tag != null && tag.HeaderOffset >= 0 && tag.DataOffset >= 0)
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
        private void UpdateTagOffsets(BinaryWriter writer)
        {
            var offsetTableOffset = GetTagDataEndOffset();
            writer.BaseStream.Position = offsetTableOffset;
            foreach (var tag in _tags)
            {
                if (tag != null && tag.HeaderOffset >= 0 && tag.DataOffset >= 0)
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

        /// <summary>
        /// Calculates the size of a tag's header after it will be updated in the file.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns>The new size of the tag's header.</returns>
        private static uint CalculateNewHeaderSize(HaloTag tag)
        {
            return CalculateHeaderSize(tag.Dependencies.Count, tag.DataFixups.Count, tag.ResourceFixups.Count);
        }

        /// <summary>
        /// Calculates the size of a tag header.
        /// </summary>
        /// <param name="numRequiredTags">The number of required tags.</param>
        /// <param name="numDataFixups">The number of fixups.</param>
        /// <param name="numResourceFixups">The number of resource fixups.</param>
        /// <returns>The size of the tag header.</returns>
        private static uint CalculateHeaderSize(int numRequiredTags, int numDataFixups, int numResourceFixups)
        {
            // After the static header, there's 4 bytes per required tag index and 4 bytes per fixup pointer
            var size = (uint)(TagHeaderSize + numRequiredTags * 4 + numDataFixups * 4 + numResourceFixups * 4);
            size = (size + 0xF) & ~0xFU; // Align the header size to 16 bytes
            return size;
        }
    }

    /// <summary>
    /// Block resizing origins.
    /// </summary>
    public enum ResizeOrigin
    {
        /// <summary>
        /// Data will be added or removed at the beginning of the block.
        /// </summary>
        Beginning,

        /// <summary>
        /// Data will be added or removed at the end of the block.
        /// </summary>
        End
    }
}
