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
        private List<string> _strings;

        /// <summary>
        /// Loads a stringID cache from a string_ids.dat file.
        /// </summary>
        /// <param name="stream">The stream to read from.</param>
        /// <param name="resolver">The stringID resolver to use.</param>
        public StringIdCache(Stream stream, StringIdResolverBase resolver)
        {
            Resolver = resolver;

            if (stream.Length != 0)
                Load(stream);
            else
                _strings = new List<string>();
        }

        /// <summary>
        /// Gets the strings in the file.
        /// Note that strings can be <c>null</c>.
        /// </summary>
        public IList<string> Strings { get; private set; }

        /// <summary>
        /// Gets the stringID resolver that the cache is using.
        /// </summary>
        public StringIdResolverBase Resolver { get; private set; }

        /// <summary>
        /// Adds a string to the cache.
        /// </summary>
        /// <param name="str">The string to add.</param>
        /// <returns>The stringID corresponding to the string that was added.</returns>
        public StringId Add(string str)
        {
            var strIndex = _strings.Count;
            _strings.Add(str);
            return GetStringId(strIndex);
        }

        /// <summary>
        /// Gets the string corresponding to a stringID.
        /// </summary>
        /// <param name="stringId">The stringID.</param>
        /// <returns>The string corresponding to the stringID, or <c>null</c> if not found.</returns>
        public string GetString(StringId stringId)
        {
            var strIndex = Resolver.StringIdToIndex(stringId);
            if (strIndex < 0 || strIndex >= _strings.Count)
                return null;
            return _strings[strIndex];
        }

        /// <summary>
        /// Gets the stringID corresponding to a string list index.
        /// </summary>
        /// <param name="strIndex">The string list index to convert.</param>
        /// <returns>The corresponding stringID.</returns>
        public StringId GetStringId(int strIndex)
        {
            if (strIndex < 0 || strIndex >= _strings.Count)
                return StringId.Null;
            return Resolver.IndexToStringId(strIndex);
        }

        /// <summary>
        /// Gets the stringID corresponding to a string in the list.
        /// </summary>
        /// <param name="str">The string to search for.</param>
        /// <returns>The corresponding stringID, or <see cref="StringId.Null"/> if not found.</returns>
        public StringId GetStringId(string str)
        {
            return GetStringId(_strings.IndexOf(str));
        }

        /// <summary>
        /// Saves the string data back to the file.
        /// </summary>
        /// <param name="stream">The stream to write to.</param>
        public void Save(Stream stream)
        {
            var writer = new BinaryWriter(stream);

            // Write the string count and then skip over the offset table, because it will be filled in last
            writer.Write(_strings.Count);
            writer.BaseStream.Position += 4 + _strings.Count * 4; // 4 byte data size + 4 bytes per string offset
            
            // Write string data and keep track of offsets
            var stringOffsets = new int[_strings.Count];
            var dataOffset = (int)writer.BaseStream.Position;
            var currentOffset = 0;
            for (var i = 0; i < _strings.Count; i++)
            {
                var str = _strings[i];
                if (str == null)
                {
                    // Null string - set offset to -1
                    stringOffsets[i] = -1;
                    continue;
                }

                // Write the string as null-terminated ASCII
                stringOffsets[i] = currentOffset;
                var data = Encoding.ASCII.GetBytes(str);
                writer.Write(data, 0, data.Length);
                writer.Write((byte)0);
                currentOffset += data.Length + 1;
            }

            // Now go back and write the string offsets
            writer.BaseStream.Position = 0x4;
            writer.Write(currentOffset); // Data size
            foreach (var offset in stringOffsets)
                writer.Write(offset);
            writer.BaseStream.SetLength(dataOffset + currentOffset);
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

            // Read the string offsets into a list of (index, offset) pairs, and then sort by offset
            // This lets us know the length of each string without scanning for a null terminator
            var stringOffsets = new List<Tuple<int, int>>(stringCount);
            for (var i = 0; i < stringCount; i++)
            {
                var offset = reader.ReadInt32();
                if (offset >= 0 && offset < dataSize)
                    stringOffsets.Add(Tuple.Create(i, offset));
            }
            stringOffsets.Sort((x, y) => x.Item2 - y.Item2);

            // Seek to each offset and read each string
            var dataOffset = reader.BaseStream.Position;
            var strings = new string[stringCount];
            for (var i = 0; i < stringOffsets.Count; i++)
            {
                var index = stringOffsets[i].Item1;
                var offset = stringOffsets[i].Item2;
                var nextOffset = (i < stringOffsets.Count - 1) ? stringOffsets[i + 1].Item2 : dataSize;
                var length = Math.Max(0, nextOffset - offset - 1); // Subtract 1 for null terminator
                reader.BaseStream.Position = dataOffset + offset;
                strings[index] = Encoding.ASCII.GetString(reader.ReadBytes(length));
            }
            _strings = strings.ToList();
            Strings = _strings.AsReadOnly();
        }
    }
}
