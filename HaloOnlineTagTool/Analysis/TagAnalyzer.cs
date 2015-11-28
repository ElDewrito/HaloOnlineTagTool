using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
	public class TagAnalyzer
	{
		private readonly TagCache _cache;
		private readonly HaloTag _tag;
		private readonly MemoryMap _tagMap;
		private readonly Dictionary<uint, TagFixup> _dataFixupsByWriteOffset;
		private readonly Dictionary<uint, TagFixup> _resourceFixupsByWriteOffset;

		public TagAnalyzer(TagCache cache, HaloTag tag)
		{
			_cache = cache;
			_tag = tag;
			_tagMap = BuildTagMap(tag);
			_dataFixupsByWriteOffset = _tag.DataFixups.ToDictionary(f => f.WriteOffset);
			_resourceFixupsByWriteOffset = _tag.ResourceFixups.ToDictionary(f => f.WriteOffset);
		}

		public TagLayoutGuess Analyze(byte[] tagData)
		{
			using (var reader = new BinaryReader(new MemoryStream(tagData)))
			{
				reader.BaseStream.Position = _tag.MainStructOffset;
				return AnalyzeStructure(reader, 1);
			}
		}

		public TagLayoutGuess AnalyzeStructure(BinaryReader reader, uint count)
		{
			if (count == 0)
				throw new ArgumentException("count is 0", "count");
			var startOffset = (uint)reader.BaseStream.Position;
			if (!_tagMap.IsBoundary(startOffset))
				throw new InvalidOperationException("Cannot analyze a structure which does not start on a boundary");
			var endOffset = _tagMap.GetNextBoundary(startOffset);
			if (startOffset == endOffset)
				throw new InvalidOperationException("Structure is empty");
			var offset = startOffset;
			var elementSize = (endOffset - startOffset) / count;
			var result = new TagLayoutGuess(elementSize);
			for (var i = 0; i < count; i++)
			{
				AnalyzeStructure(reader, offset, elementSize, result);
				offset += elementSize;
				reader.BaseStream.Position = offset;
			}
			return result;
		}

		private void AnalyzeStructure(BinaryReader reader, uint baseOffset, uint size, TagLayoutGuess result)
		{
			var lookBehind = new uint[4];
			TagFixup potentialGuess = null;
			for (uint offset = 0; offset < size; offset += 4)
			{
				var val = reader.ReadUInt32();
				TagFixup fixup;
				if (_resourceFixupsByWriteOffset.TryGetValue(baseOffset + offset, out fixup))
				{
					// Value is a resource reference
					result.Add(offset, new ResourceReferenceGuess());
				}
				else if (_dataFixupsByWriteOffset.TryGetValue(baseOffset + offset, out fixup))
				{
					// Value is a pointer
					if (offset >= 0x4)
					{
						// Tag block or data reference - need another padding value to confirm it
						potentialGuess = fixup;
					}
				}
				else if (offset >= 0xC && lookBehind[0] == 0 && lookBehind[1] == 0 && _cache.Tags.FindFirstInGroup(new MagicNumber((int)lookBehind[2])) != null)
				{
					// Tag reference
					if (val != 0xFFFFFFFF && val < _cache.Tags.Count)
					{
						var referencedTag = _cache.Tags[(int)val];
						if (referencedTag != null && referencedTag.GroupTag.Value == (int)lookBehind[2])
							result.Add(offset - 0xC, new TagReferenceGuess());
					}
				}
				else if (val == 0 && potentialGuess != null)
				{
					// Found a potential padding value - check if we can confirm the potential guess's type
					if (lookBehind[1] != 0)
					{
						// Tag block - seek to it and analyze it
						reader.BaseStream.Position = potentialGuess.TargetOffset;
						var elementLayout = AnalyzeStructure(reader, lookBehind[1]);
						reader.BaseStream.Position = baseOffset + offset + 4;
						result.Add(offset - 0x8, new TagBlockGuess(elementLayout));
					}
					else if (offset >= 0x10 && lookBehind[1] == 0 && lookBehind[2] == 0 && lookBehind[3] != 0)
					{
						// Data reference
						result.Add(offset - 0x10, new DataReferenceGuess());
					}
					potentialGuess = null;
				}
				else
				{
					// Tag block and data reference guesses must be followed by padding
					potentialGuess = null;
				}
				for (var i = 3; i > 0; i--)
					lookBehind[i] = lookBehind[i - 1];
				lookBehind[0] = val;
			}
		}

		/// <summary>
		/// Builds a memory map for a tag.
		/// </summary>
		/// <param name="tag">The tag to build a memory map for.</param>
		/// <returns>The built map.</returns>
		private static MemoryMap BuildTagMap(HaloTag tag)
		{
			// Create a memory map with a boundary at each fixup target
			// and at the main structure
			var result = new MemoryMap(0, (uint)tag.DataSize);
			result.AddBoundary(tag.MainStructOffset);
			result.AddBoundaries(tag.DataFixups.Select(f => f.TargetOffset));
			return result;
		}
	}
}
