using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
	/// <summary>
	/// A file containing a cache of all of the stringID strings.
	/// </summary>
	public class StringIdCache
	{
		// These values were figured out through trial-and-error
		private static readonly int[] _setOffsets = {0x90F, 0x1, 0x685, 0x720, 0x7C4, 0x778, 0x7D0, 0x8EA, 0x902};
		private const int SetMin = 0x1;   // Mininum index that goes in a set
		private const int SetMax = 0xF1E; // Maximum index that goes in a set

		/// <summary>
		/// Loads a stringID cache from a string_ids.dat file.
		/// </summary>
		/// <param name="stream">The stream to read from.</param>
		public StringIdCache(Stream stream)
		{
			Strings = new List<string>();
			Load(stream);
		}

		/// <summary>
		/// Gets the strings in the file.
		/// Note that strings can be <c>null</c>.
		/// </summary>
		public List<string> Strings { get; private set; }

		/// <summary>
		/// Gets the string corresponding to a stringID value.
		/// </summary>
		/// <param name="stringId">The stringID value.</param>
		/// <returns>The string corresponding to the value, or <c>null</c> if not found.</returns>
		public string GetString(int stringId)
		{
			// Get the set and index
			var set = stringId >> 16;      // Set = upper 16 bits
			var index = stringId & 0xFFFF; // Index = lower 16 bits

			int strIndex;
			if (set == 0 && (index < SetMin || index > SetMax))
			{
				// Value does not go into a set, so the index is the same as the ID
				strIndex = index;
			}
			else
			{
				if (set < 0 || set >= _setOffsets.Length)
					return null; // Invalid set number

				// Convert the index part of the ID into a string index based on its set
				if (set == 0)
					index -= SetMin;
				strIndex = index + _setOffsets[set];
			}
			if (strIndex < 0 || strIndex >= Strings.Count)
				return null;
			return Strings[strIndex];
		}

		public int GetStringId(int strIndex)
		{
			if (strIndex < 0 || strIndex >= Strings.Count)
				return 0;

			// If the value is outside of a set, just return it
			if (strIndex < SetMin || strIndex > SetMax)
				return strIndex;

			// Find the set which the index is closest to
			// TODO: This could probably be more optimized if the set offset list was sorted or something
			var set = 0;
			var minDistance = Strings.Count;
			for (var i = 0; i < _setOffsets.Length; i++)
			{
				if (strIndex < _setOffsets[i])
					continue;
				var distance = strIndex - _setOffsets[i];
				if (distance >= minDistance)
					continue;
				set = i;
				minDistance = distance;
			}

			// Compute the index within the set
			var index = strIndex - _setOffsets[set];
			if (set == 0)
				index += SetMin;

			// Set is the upper 16 bits, index is the lower 16
			return (set << 16) | (index & 0xFFFF);
		}

		/// <summary>
		/// Saves the string data back to the file.
		/// </summary>
		/// <param name="stream">The stream to write to.</param>
		public void Save(Stream stream)
		{
			var writer = new BinaryWriter(stream);

			// Write the string count and then skip over the offset table, because it will be filled in last
			writer.Write(Strings.Count);
			writer.BaseStream.Position += 4 + Strings.Count * 4; // 4 byte data size + 4 bytes per string offset
			
			// Write string data and keep track of offsets
			var stringOffsets = new int[Strings.Count];
			var dataOffset = (int)writer.BaseStream.Position;
			for (var i = 0; i < Strings.Count; i++)
			{
				var str = Strings[i];
				if (str == null)
				{
					// Null string - set offset to -1
					stringOffsets[i] = -1;
					continue;
				}

				// Write the string as null-terminated ASCII
				stringOffsets[i] = (int)writer.BaseStream.Position;
				var data = Encoding.ASCII.GetBytes(str);
				writer.Write(data, 0, data.Length);
				writer.Write((byte)0);
			}
			var dataEndOffset = (int)writer.BaseStream.Position;

			// Now go back and write the string offsets
			writer.BaseStream.Position = 0x4;
			writer.Write(dataEndOffset - dataOffset); // Data size
			foreach (var offset in stringOffsets)
				writer.Write(offset);
			writer.BaseStream.SetLength(writer.BaseStream.Position);
		}

		/// <summary>
		/// Loads the cache from a stream.
		/// </summary>
		/// <param name="stream">The stream to read from.</param>
		private void Load(Stream stream)
		{
			var reader = new BinaryReader(stream);

			// Read the header
			var stringCount = reader.ReadInt32();  // int32 string count
			var dataSize = reader.ReadInt32();     // int32 string data size

			// Read string offsets
			var stringOffsets = new int[stringCount];
			for (var i = 0; i < stringCount; i++)
				stringOffsets[i] = reader.ReadInt32();

			// Seek to each offset and read each string
			var dataOffset = reader.BaseStream.Position;
			foreach (var offset in stringOffsets)
			{
				if (offset == -1 || offset >= dataSize)
				{
					Strings.Add(null);
					continue;
				}
				reader.BaseStream.Position = dataOffset + offset;
				Strings.Add(ReadString(reader));
			}
		}

		/// <summary>
		/// Reads a null-terminated ASCII string from a stream.
		/// </summary>
		/// <param name="reader">The reader.</param>
		/// <returns>The string.</returns>
		private static string ReadString(BinaryReader reader)
		{
			var result = new StringBuilder();
			while (true)
			{
				var ch = reader.ReadByte();
				if (ch == 0)
					break;
				result.Append((char)ch);
			}
			return result.ToString();
		}
	}
}
