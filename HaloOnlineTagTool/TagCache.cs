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
		private readonly HashSet<MagicNumber> _groupTags = new HashSet<MagicNumber>(); 
		private readonly List<uint> _headerOffsets = new List<uint>();

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
		/// Gets the group tags in the file.
		/// </summary>
		public IEnumerable<MagicNumber> GroupTags
		{
			get { return _groupTags; }
		}

		/// <summary>
		/// Determines whether or not a tag with the given group tag exists.
		/// </summary>
		/// <param name="tagClass">The group tag.</param>
		/// <returns><c>true</c> if a tag with the given group tag exists.</returns>
		public bool ContainsGroup(MagicNumber tagClass)
		{
			return _groupTags.Contains(tagClass);
		}

		/// <summary>
		/// Saves any changes made to a tag's properties.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag to update.</param>
		public void UpdateTag(Stream stream, HaloTag tag)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
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
		public byte[] ExtractTag(Stream stream, HaloTag tag)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			stream.Position = tag.Offset;
			var result = new byte[tag.Size];
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
		public byte[] ExtractTagWithHeader(Stream stream, HaloTag tag)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			var headerSize = GetHeaderSize(tag);
			stream.Position = tag.Offset - headerSize;
			var result = new byte[tag.Size + headerSize];
			stream.Read(result, 0, result.Length);
			return result;
		}

		/// <summary>
		/// Overwrites a tag's data, not including its header.
		/// Any pointers in the data to write will be adjusted to be relative to the start of the tag's header.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag to overwrite.</param>
		/// <param name="data">The data to write.</param>
		public void OverwriteTag(Stream stream, HaloTag tag, byte[] data)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			
			// Adjust fixups before injecting the data
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				for (var i = 0; i < tag.DataFixups.Count; i++)
				{
					var fixup = tag.DataFixups[i];
					reader.BaseStream.Position = fixup.WriteOffset;
					var newPointer = reader.ReadUInt32();
					if (newPointer == 0)
					{
						// Pointer was nulled - removed it
						tag.DataFixups.RemoveAt(i);
						i--;
						continue;
					}
					fixup.TargetOffset = newPointer - FixupPointerBase;
				}
			}
			RebasePointers(tag, data, GetHeaderSize(tag));

			// Resize the tag and write the data
			ResizeTagData(stream, tag, (uint)data.Length);
			stream.Position = tag.Offset;
			stream.Write(data, 0, data.Length);
		}

		/// <summary>
		/// Overwrites a tag's data, including its header.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag to overwrite.</param>
		/// <param name="data">The data to overwrite the tag with.</param>
		/// <exception cref="System.ArgumentNullException">tag</exception>
		public void OverwriteTagWithHeader(Stream stream, HaloTag tag, byte[] data)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");

			// Ensure the data fits
			var oldHeaderSize = GetHeaderSize(tag);
			var oldTagSize = oldHeaderSize + tag.Size;
			ResizeTag(stream, tag, oldTagSize, (int)(data.Length - oldTagSize), InsertOrigin.Before, ResizeMode.Resize);
			
			// Write the data
			stream.Position = _headerOffsets[tag.Index];
			stream.Write(data, 0, data.Length);

			// Re-parse it and update tag offsets
			stream.Position = _headerOffsets[tag.Index];
			ReadTagHeader(new BinaryReader(stream), tag);
			UpdateTagOffsets(new BinaryWriter(stream));
		}

		/// <summary>
		/// Adds a tag to the file.
		/// Any pointers in the data to write will be adjusted to be relative to the start of the tag's header.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">A description of the tag to create.</param>
		/// <param name="data">The data, not including the header.</param>
		/// <returns>The index of the tag that was added.</returns>
		public int AddTag(Stream stream, HaloTag tag, byte[] data)
		{
			// Reserve space for the tag
			var newTagOffset = GetTagDataEndOffset();
			var headerSize = CalculateHeaderSize(tag.Dependencies.Count, tag.DataFixups.Count, tag.ResourceFixups.Count);
			var totalSize = headerSize + data.Length;
			StreamUtil.Copy(stream, newTagOffset, newTagOffset + totalSize, stream.Length - newTagOffset);
			tag.Size = (uint)data.Length;
			tag.Offset = newTagOffset + headerSize;
			_headerOffsets.Add(newTagOffset);

			// Write the data in
			stream.Position = tag.Offset;
			stream.Write(data, 0, data.Length);

			// Add the tag to the tag list and then update it
			tag.Index = _tags.Count;
			_tags.Add(tag);
			UpdateTag(stream, tag);
			return tag.Index;
		}

		/// <summary>
		/// Adds a tag to the file.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="data">The tag data. Must include the header.</param>
		/// <returns>The new tag.</returns>
		public HaloTag AddTag(Stream stream, byte[] data)
		{
			// Push back the data at the end of the file and write the tag in after the last tag
			var newTagOffset = GetTagDataEndOffset();
			StreamUtil.Copy(stream, newTagOffset, newTagOffset + data.Length, stream.Length - newTagOffset);
			stream.Position = newTagOffset;
			stream.Write(data, 0, data.Length);

			// Create an object for the tag and add it to the tag list
			var tagIndex = _tags.Count;
			var newTag = new HaloTag { Index = tagIndex };
			_headerOffsets.Add(newTagOffset);
			_tags.Add(newTag);

			// Read the tag's header from the stream
			stream.Position = newTagOffset;
			ReadTagHeader(new BinaryReader(stream), newTag);

			// Update the tag offset table
			UpdateTagOffsets(new BinaryWriter(stream));
			return newTag;
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
			return AddTag(stream, ExtractTagWithHeader(stream, tag));
		}

		/// <summary>
		/// Inserts or removes data in a tag and then updates it if necessary.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="insertOffset">The offset, from the start of the tag's data, to insert data at.</param>
		/// <param name="sizeDelta">The size of the data to insert or remove. If positive, data will be inserted. If negative, data will be removed.</param>
		/// <param name="origin">The type of resize to perform. See <see cref="InsertOrigin"/>.</param>
		public void InsertTagData(Stream stream, HaloTag tag, uint insertOffset, int sizeDelta, InsertOrigin origin)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			if (sizeDelta == 0)
				return;
			ResizeTag(stream, tag, insertOffset + GetHeaderSize(tag), sizeDelta, origin, ResizeMode.Insert);
			UpdateTag(stream, tag);
		}

		/// <summary>
		/// Resizes a tag's data.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="newSize">The new size of the tag's data.</param>
		public void ResizeTagData(Stream stream, HaloTag tag, uint newSize)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			if (newSize == tag.Size)
				return;

			// Resize at the end of the tag
			var headerSize = GetHeaderSize(tag);
			ResizeTag(stream, tag, headerSize + tag.Size, (int)(newSize - tag.Size), InsertOrigin.Before, ResizeMode.Resize);

			// Update only the header and tag offset table - a full update isn't needed
			var writer = new BinaryWriter(stream);
			UpdateTagHeader(writer, tag);
			UpdateTagOffsets(writer);
		}

		/// <summary>
		/// Inserts or removes data in a tag.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="insertOffset">The offset, from the start of the tag's header, to insert data at.</param>
		/// <param name="sizeDelta">The size of the data to insert or remove. If positive, data will be inserted. If negative, data will be removed.</param>
		/// <param name="origin">The type of resize to perform. See <see cref="InsertOrigin"/>.</param>
		/// <param name="mode">The resize mode. See <see cref="ResizeMode"/>.</param>
		private void ResizeTag(Stream stream, HaloTag tag, uint insertOffset, int sizeDelta, InsertOrigin origin, ResizeMode mode)
		{
			if (sizeDelta == 0)
				return;

			var headerSize = GetHeaderSize(tag);
			if (sizeDelta < 0 && ((origin == InsertOrigin.Before && -sizeDelta > insertOffset) || (origin == InsertOrigin.After && insertOffset + -sizeDelta > headerSize + tag.Size)))
				throw new ArgumentException("Cannot remove more bytes than there are available in the tag");

			// In insertion mode, correct relative offsets to account for inserted data
			var relativeCompareOffset = (origin == InsertOrigin.Before) ? insertOffset : insertOffset + 1; // hack
			if (headerSize < relativeCompareOffset)
			{
				tag.Size = (uint)(tag.Size + sizeDelta);
				if (mode == ResizeMode.Insert)
				{
					foreach (var fixup in tag.DataFixups.Concat(tag.ResourceFixups))
					{
						if (fixup.WriteOffset + headerSize >= relativeCompareOffset)
							fixup.WriteOffset = (uint)(fixup.WriteOffset + sizeDelta);
						if (fixup.TargetOffset + headerSize >= relativeCompareOffset)
							fixup.TargetOffset = (uint)(fixup.TargetOffset + sizeDelta);
					}
					if (tag.MainStructOffset + headerSize >= relativeCompareOffset)
						tag.MainStructOffset = (uint)(tag.MainStructOffset + sizeDelta);
				}
			}

			// Correct tag offsets
			var absoluteOffset = _headerOffsets[tag.Index] + insertOffset;
			var absoluteCompareOffset = (origin == InsertOrigin.Before) ? absoluteOffset : absoluteOffset + 1; // hack
			for (var i = 0; i < _tags.Count; i++)
			{
				if (_tags[i] == null)
					continue;
				if (_headerOffsets[i] >= absoluteCompareOffset)                // Header offset (absolute)
					_headerOffsets[i] = (uint)(_headerOffsets[i] + sizeDelta);
				if (_tags[i].Offset >= absoluteCompareOffset)                  // Data offset (absolute)
					_tags[i].Offset = (uint)(_tags[i].Offset + sizeDelta);
			}

			// Insert/remove the data
			if (sizeDelta < 0 && origin == InsertOrigin.Before)
				absoluteOffset = (uint)(absoluteOffset + sizeDelta);
			stream.Position = absoluteOffset;
			if (sizeDelta > 0)
				StreamUtil.Insert(stream, sizeDelta, 0);
			else
				StreamUtil.Remove(stream, -sizeDelta);
		}

		/// <summary>
		/// Tag resizing modes.
		/// </summary>
		private enum ResizeMode
		{
			/// <summary>
			/// The tag will only be resized and relative pointers in it will not be adjusted.
			/// </summary>
			Resize,

			/// <summary>
			/// Relative pointers in the tag will be adjusted to account for inserted or removed data.
			/// </summary>
			Insert
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
			reader.BaseStream.Position = tagListOffset;
			for (var i = 0; i < tagCount; i++)
				_headerOffsets.Add(reader.ReadUInt32());

			// Read each tag
			for (var i = 0; i < tagCount; i++)
			{
				if (_headerOffsets[i] == 0)
				{
					// Offset of 0 = null tag
					_tags.Add(null);
					continue;
				}

				reader.BaseStream.Position = _headerOffsets[i];
				var tag = new HaloTag
				{
					Index = i
				};
				_tags.Add(tag);
				ReadTagHeader(reader, tag);
			}
		}

		private void ReadTagHeader(BinaryReader reader, HaloTag resultTag)
		{
			var headerOffset = (uint)reader.BaseStream.Position;
			var checksum = reader.ReadUInt32();                            // 0x00 uint32 checksum
			var totalSize = reader.ReadUInt32();                           // 0x04 uint32 total size
			var numDependencies = reader.ReadInt16();                      // 0x08 int16  dependencies count
			var numDataFixups = reader.ReadInt16();                        // 0x0A int16  data fixup count
			var numResourceFixups = reader.ReadInt16();                    // 0x0C int16  resource fixup count
			reader.BaseStream.Position += 2;                               // 0x0E int16  (padding)
			var mainStructOffset = reader.ReadUInt32();                    // 0x10 uint32 main struct offset
			var groupTag = new MagicNumber(reader.ReadInt32());            // 0x14 int32  group tag
			var parentGroupTag = new MagicNumber(reader.ReadInt32());      // 0x18 int32  parent group tag
			var grandparentGroupTag = new MagicNumber(reader.ReadInt32()); // 0x1C int32  grandparent group tag
			var groupName = new StringId(reader.ReadUInt32());             // 0x20 uint32 group name stringid
			var totalHeaderSize = CalculateHeaderSize(numDependencies, numDataFixups, numResourceFixups);

			// Update the tag object
			_groupTags.Add(groupTag);
			resultTag.GroupTag = groupTag;
			resultTag.ParentGroupTag = parentGroupTag;
			resultTag.GrandparentGroupTag = grandparentGroupTag;
			resultTag.MainStructOffset = mainStructOffset - totalHeaderSize;
			resultTag.Offset = headerOffset + totalHeaderSize;
			resultTag.Size = totalSize - totalHeaderSize;
			resultTag.Checksum = checksum;
			resultTag.GroupName = groupName;

			// Read dependencies
			resultTag.Dependencies.Clear();
			for (var j = 0; j < numDependencies; j++)
				resultTag.Dependencies.Add(reader.ReadInt32());

			// Read fixup pointers
			var dataFixupPointers = new uint[numDataFixups];
			for (var j = 0; j < numDataFixups; j++)
				dataFixupPointers[j] = reader.ReadUInt32();
			var resourceFixupPointers = new uint[numResourceFixups];
			for (var j = 0; j < numResourceFixups; j++)
				resourceFixupPointers[j] = reader.ReadUInt32();

			// Process fixups
			resultTag.DataFixups.Clear();
			resultTag.ResourceFixups.Clear();
			foreach (var fixup in dataFixupPointers)
				resultTag.DataFixups.Add(ReadFixup(reader, fixup, headerOffset, totalHeaderSize));
			foreach (var fixup in resourceFixupPointers)
				resultTag.ResourceFixups.Add(ReadFixup(reader, fixup, headerOffset, totalHeaderSize));
		}

		/// <summary>
		/// Reads fixup information from a fixup pointer.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <param name="pointer">The pointer.</param>
		/// <param name="headerOffset">The offset of the tag's header.</param>
		/// <param name="headerSize">The size of the tag's header.</param>
		/// <returns>The read fixup information.</returns>
		private static TagFixup ReadFixup(BinaryReader reader, uint pointer, uint headerOffset, uint headerSize)
		{
			// Adjust the fixup pointer and then seek to it and read and adjust the target
			var fixupOffset = pointer - FixupPointerBase;
			reader.BaseStream.Position = headerOffset + fixupOffset;
			var targetOffset = reader.ReadUInt32() - FixupPointerBase;

			// Adjust the offsets to be from the start of the tag's data
			return new TagFixup
			{
				WriteOffset = fixupOffset - headerSize,
				TargetOffset = targetOffset - headerSize
			};
		}

		/// <summary>
		/// Writes a tag's header back to the file, resizing it if necessary.
		/// </summary>
		/// <param name="writer">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		private void UpdateTagHeader(BinaryWriter writer, HaloTag tag)
		{
			// Resize the header if necessary
			var newHeaderSize = CalculateHeaderSize(tag.Dependencies.Count, tag.DataFixups.Count, tag.ResourceFixups.Count);
			var oldHeaderSize = GetHeaderSize(tag);
			if (newHeaderSize > oldHeaderSize)
				ResizeTag(writer.BaseStream, tag, 0, (int)newHeaderSize - (int)oldHeaderSize, InsertOrigin.After, ResizeMode.Insert);

			// Write the tag header
			// See TagCacheReader for more info on this layout
			var newHeaderOffset = tag.Offset - newHeaderSize;
			_headerOffsets[tag.Index] = newHeaderOffset;
			writer.BaseStream.Position = newHeaderOffset;
			writer.Write(tag.Checksum);
			writer.Write(tag.Size + newHeaderSize);
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
			var totalHeaderSize = CalculateHeaderSize(tag.Dependencies.Count, tag.DataFixups.Count, tag.ResourceFixups.Count);
			foreach (var fixup in tag.DataFixups)
			{
				writer.BaseStream.Position = tag.Offset + fixup.WriteOffset;
				writer.Write(fixup.TargetOffset + totalHeaderSize + FixupPointerBase);
			}
		}

		/// <summary>
		/// Gets the tag data end offset.
		/// </summary>
		/// <returns>The offset of the first byte past the last tag in the file, or 0 if there are no tags in the file.</returns>
		private uint GetTagDataEndOffset()
		{
			// Assume the tags are sorted by offset
			var lastTag = Tags.LastOrDefault(t => (t != null));
			return (lastTag != null) ? lastTag.Offset + lastTag.Size : 0;
		}

		/// <summary>
		/// Updates the tag offset table in the file.
		/// </summary>
		/// <param name="writer">The stream to write to.</param>
		private void UpdateTagOffsets(BinaryWriter writer)
		{
			var offsetTableOffset = GetTagDataEndOffset();
			if (offsetTableOffset == 0)
			{
				// No tags
				UpdateFileHeader(writer, 0);
				return;
			}
			writer.BaseStream.Position = offsetTableOffset;
			foreach (var offset in _headerOffsets)
				writer.Write(offset);
			writer.BaseStream.SetLength(writer.BaseStream.Position); // Truncate the file to end after the last offset
			UpdateFileHeader(writer, offsetTableOffset);
		}

		/// <summary>
		/// Updates the file header.
		/// </summary>
		/// <param name="writer">The stream to write to.</param>
		/// <param name="offsetTableOffset">The offset table offset.</param>
		private void UpdateFileHeader(BinaryWriter writer, uint offsetTableOffset)
		{
			writer.BaseStream.Position = 0x4;
			writer.Write(offsetTableOffset); // 0x4 uint32 offset table offset
			writer.Write(_tags.Count);       // 0x8 uint32 number of tags
		}

		/// <summary>
		/// Gets the current size of a tag's header.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <returns>The current size of the tag's header in bytes.</returns>
		private uint GetHeaderSize(HaloTag tag)
		{
			return tag.Offset - _headerOffsets[tag.Index];
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
			return (uint)(TagHeaderSize + numRequiredTags * 4 + numDataFixups * 4 + numResourceFixups * 4);
		}
	}

	/// <summary>
	/// Data insertion origins, relative to the insertion/removal offset.
	/// </summary>
	public enum InsertOrigin
	{
		/// <summary>
		/// Any pointers which point to the offset being inserted at will be adjusted.
		/// If removing, data before the given offset will be removed.
		/// </summary>
		Before,

		/// <summary>
		/// Any pointers which point to the offset being pointed at will not be adjusted.
		/// If removing, data starting from the given offset will be removed.
		/// </summary>
		After
	}
}
