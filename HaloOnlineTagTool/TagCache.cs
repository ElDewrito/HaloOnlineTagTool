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
		/// Overwrites all of a tag's data, including its header, expanding it as necessary.
		/// Any pointers in the tag will be adjusted automatically.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag to overwrite.</param>
		/// <param name="data">The data to write.</param>
		public void OverwriteTag(Stream stream, HaloTag tag, byte[] data)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			var headerSize = GetHeaderSize(tag);
			if (tag.Size < data.Length)
			{
				// New data is too big - need to resize the tag
				ResizeTag(stream, tag, headerSize + tag.Size, data.Length - (int)tag.Size, InsertType.Before);
				var writer = new BinaryWriter(stream);
				UpdateTagHeader(writer, tag);
				UpdateTagOffsets(writer);
			}
			
			// Adjust fixups before injecting the data
			using (var reader = new BinaryReader(new MemoryStream(data)))
			{
				foreach (var fixup in tag.Fixups)
				{
					reader.BaseStream.Position = fixup.WriteOffset;
					fixup.TargetOffset = reader.ReadUInt32() - FixupPointerBase;
				}
			}
			RebasePointers(tag, data, GetHeaderSize(tag));

			// Write the data
			stream.Position = tag.Offset;
			stream.Write(data, 0, data.Length);
		}

		/// <summary>
		/// Inserts data into a tag and then updates it.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="insertOffset">The offset, from the start of the tag's data, to insert data at.</param>
		/// <param name="sizeDelta">The size of the data to insert (currently must be positive).</param>
		/// <param name="type">The type of resize to perform. See <see cref="InsertType"/>.</param>
		public void ResizeTagData(Stream stream, HaloTag tag, uint insertOffset, int sizeDelta, InsertType type)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			ResizeTag(stream, tag, insertOffset + GetHeaderSize(tag), sizeDelta, type);
			UpdateTag(stream, tag);
		}

		/// <summary>
		/// Inserts data into a tag.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		/// <param name="insertOffset">The offset, from the start of the tag's header, to insert data at.</param>
		/// <param name="sizeDelta">The size of the data to insert (currently must be positive).</param>
		/// <param name="type">The type of resize to perform. See <see cref="InsertType"/>.</param>
		private void ResizeTag(Stream stream, HaloTag tag, uint insertOffset, int sizeDelta, InsertType type)
		{
			if (sizeDelta == 0)
				return;
			if (sizeDelta < 0)
				throw new ArgumentException("sizeDelta must be positive for now"); // i'm lazy

			// If the tag data is being resized, correct relative offsets to account for inserted data
			var headerSize = GetHeaderSize(tag);
			var relativeCompareOffset = (type == InsertType.Before) ? insertOffset : insertOffset + 1; // hack
			if (headerSize < relativeCompareOffset)
			{
				tag.Size = (uint)(tag.Size + sizeDelta);
				foreach (var fixup in tag.Fixups)
				{
					if (fixup.WriteOffset + headerSize >= relativeCompareOffset)
						fixup.WriteOffset = (uint)(fixup.WriteOffset + sizeDelta);
					if (fixup.TargetOffset + headerSize >= relativeCompareOffset)
						fixup.TargetOffset = (uint)(fixup.TargetOffset + sizeDelta);
				}
				if (tag.MainStructOffset + headerSize >= relativeCompareOffset)
					tag.MainStructOffset = (uint)(tag.MainStructOffset + sizeDelta);
			}

			// Correct tag offsets
			var absoluteOffset = _headerOffsets[tag.Index] + insertOffset;
			var absoluteCompareOffset = (type == InsertType.Before) ? absoluteOffset : absoluteOffset + 1; // hack
			for (var i = 0; i < _tags.Count; i++)
			{
				if (_tags[i] == null)
					continue;
				if (_headerOffsets[i] >= absoluteCompareOffset)                // Header offset (absolute)
					_headerOffsets[i] = (uint)(_headerOffsets[i] + sizeDelta);
				if (_tags[i].Offset >= absoluteCompareOffset)                  // Data offset (absolute)
					_tags[i].Offset = (uint)(_tags[i].Offset + sizeDelta);
			}

			// Insert the data
			stream.Position = absoluteOffset;
			StreamUtil.Insert(stream, sizeDelta, 0);
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

				// Read header
				reader.BaseStream.Position = _headerOffsets[i];
				var unknown1 = reader.ReadUInt32();                         // 0x00 uint32 checksum?
				var totalSize = reader.ReadUInt32();                        // 0x04 uint32 total size
				var numDependencies = reader.ReadInt16();                   // 0x08 int16  dependencies count
				var numFixups = reader.ReadInt16();                         // 0x0A int16  fixups count
				var unknown2 = reader.ReadUInt32();                         // 0x0C uint32 unknown
				var mainStructOffset = reader.ReadUInt32();                 // 0x10 uint32 main struct offset
				var tagClass = new MagicNumber(reader.ReadInt32());         // 0x14 int32  class
				var parentClass = new MagicNumber(reader.ReadInt32());      // 0x18 int32  parent class
				var grandparentClass = new MagicNumber(reader.ReadInt32()); // 0x1C int32  grandparent class
				var classId = reader.ReadUInt32();                         // 0x20 uint32 class stringid
				var totalHeaderSize = CalculateHeaderSize(numDependencies, numFixups);

				// Construct the tag object
				var tag = new HaloTag
				{
					Index = i,
					Class = tagClass,
					ParentClass = parentClass,
					GrandparentClass = grandparentClass,
					MainStructOffset = mainStructOffset - totalHeaderSize,
					Offset = _headerOffsets[i] + totalHeaderSize,
					Size = totalSize - totalHeaderSize,
					Checksum = unknown1,
					Unknown2 = unknown2,
					ClassId = classId
				};
				_tags.Add(tag);

				// Read dependencies
				for (var j = 0; j < numDependencies; j++)
					tag.Dependencies.Add(reader.ReadInt32());

				// Read fixup pointers
				var fixupOffsets = new uint[numFixups];
				for (var j = 0; j < numFixups; j++)
					fixupOffsets[j] = reader.ReadUInt32();
				for (var j = 0; j < numFixups; j++)
				{
					// Adjust the fixup offset and then seek to it and read and adjust the target
					var fixupOffset = fixupOffsets[j] - FixupPointerBase;
					reader.BaseStream.Position = _headerOffsets[i] + fixupOffset;
					var targetOffset = reader.ReadUInt32() - FixupPointerBase;

					// Add the fixup with the offsets adjusted to be from the start of the tag's data
					tag.Fixups.Add(new TagFixup
					{
						WriteOffset = fixupOffset - totalHeaderSize,
						TargetOffset = targetOffset - totalHeaderSize
					});
				}
			}
		}

		/// <summary>
		/// Writes a tag's header back to the file, resizing it if necessary.
		/// </summary>
		/// <param name="writer">The stream to write to.</param>
		/// <param name="tag">The tag.</param>
		private void UpdateTagHeader(BinaryWriter writer, HaloTag tag)
		{
			// Resize the header if necessary
			var newHeaderSize = CalculateHeaderSize(tag.Dependencies.Count, tag.Fixups.Count);
			var oldHeaderSize = GetHeaderSize(tag);
			if (newHeaderSize > oldHeaderSize)
				ResizeTag(writer.BaseStream, tag, oldHeaderSize, (int)newHeaderSize - (int)oldHeaderSize, InsertType.Before);

			// Write the tag header
			// See TagCacheReader for more info on this layout
			var newHeaderOffset = tag.Offset - newHeaderSize;
			_headerOffsets[tag.Index] = newHeaderOffset;
			writer.BaseStream.Position = newHeaderOffset;
			writer.Write(tag.Checksum);
			writer.Write(tag.Size + newHeaderSize);
			writer.Write((ushort)tag.Dependencies.Count);
			writer.Write((ushort)tag.Fixups.Count);
			writer.Write(tag.Unknown2);
			writer.Write(tag.MainStructOffset + newHeaderSize);
			writer.Write(tag.Class.Value);
			writer.Write(tag.ParentClass.Value);
			writer.Write(tag.GrandparentClass.Value);
			writer.Write(tag.ClassId);

			// Write dependencies
			foreach (var dependency in tag.Dependencies)
				writer.Write(dependency);

			// Write fixup pointers
			foreach (var fixup in tag.Fixups)
				writer.Write(fixup.WriteOffset + newHeaderSize + FixupPointerBase);
		}

		/// <summary>
		/// Rebases fixup pointers in tag data.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <param name="data">The data.</param>
		/// <param name="newBase">The new base offset to use.</param>
		private void RebasePointers(HaloTag tag, byte[] data, uint newBase)
		{
			using (var writer = new BinaryWriter(new MemoryStream(data)))
			{
				foreach (var fixup in tag.Fixups)
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
			var totalHeaderSize = CalculateHeaderSize(tag.Dependencies.Count, tag.Fixups.Count);
			foreach (var fixup in tag.Fixups)
			{
				writer.BaseStream.Position = tag.Offset + fixup.WriteOffset;
				writer.Write(fixup.TargetOffset + totalHeaderSize + FixupPointerBase);
			}
		}

		/// <summary>
		/// Updates the tag offset table in the file.
		/// </summary>
		/// <param name="writer">The stream to write to.</param>
		private void UpdateTagOffsets(BinaryWriter writer)
		{
			var lastTag = Tags.LastOrDefault(t => (t != null));
			if (lastTag == null)
			{
				// No tags
				UpdateFileHeader(writer, 0);
				return;
			}

			// The offset table always comes after the last tag
			var offsetTableOffset = lastTag.Offset + lastTag.Size;
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
		/// <param name="numFixups">The number of fixups.</param>
		/// <returns></returns>
		private static uint CalculateHeaderSize(int numRequiredTags, int numFixups)
		{
			// After the static header, there's 4 bytes per required tag index and 4 bytes per fixup pointer
			return (uint)(TagHeaderSize + numRequiredTags * 4 + numFixups * 4);
		}
	}

	/// <summary>
	/// Data insertion methods.
	/// </summary>
	public enum InsertType
	{
		/// <summary>
		/// Any pointers which point to the offset being inserted at will be adjusted.
		/// </summary>
		Before,

		/// <summary>
		/// Any pointers which point to the offset being pointed at will not be adjusted.
		/// </summary>
		After
	}
}
