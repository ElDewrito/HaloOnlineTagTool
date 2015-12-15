using System;
using System.CodeDom.Compiler;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    /// <summary>
    /// Contains a list of localized strings.
    /// </summary>
    [TagStructure(Name = "multilingual_unicode_string_list", Class = "unic", Size = 0x5C)]
    public class MultilingualUnicodeStringList
    {
        /// <summary>
        /// Gets or sets the strings in the list.
        /// </summary>
        public List<LocalizedString> Strings;

        /// <summary>
        /// Gets or sets the data block containing every string.
        /// </summary>
        public byte[] Data;

        /// <summary>
        /// Gets the value of a string in a given language.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="language">The language.</param>
        /// <returns>The value of the string, or <c>null</c> if the string is not available.</returns>
        public string GetString(LocalizedString str, GameLanguage language)
        {
            var offset = str.Offsets[(int)language];
            if (offset < 0 || offset >= Data.Length)
                return null; // String not available

            var length = GetStringLength(offset);
            return Encoding.UTF8.GetString(Data, offset, length);
        }

        /// <summary>
        /// Sets the value of a string for a given language.
        /// </summary>
        /// <param name="str">The string.</param>
        /// <param name="language">The language.</param>
        /// <param name="newValue">The new value. Can be <c>null</c>.</param>
        public void SetString(LocalizedString str, GameLanguage language, string newValue)
        {
            // Replace the string
            var offset = str.Offsets[(int)language];
            if (offset < 0 || offset >= Data.Length)
                offset = Data.Length; // Add the string at the end
            var oldLength = GetStringLength(offset);
            var bytes = (newValue != null) ? Encoding.UTF8.GetBytes(newValue) : new byte[0];
            if (bytes.Length > 0 && offset == Data.Length)
            {
                // If it's a new string, null-terminate it
                var nullTerminated = new byte[bytes.Length + 1];
                Buffer.BlockCopy(bytes, 0, nullTerminated, 0, bytes.Length);
                bytes = nullTerminated;
            }
            Data = ArrayUtil.Replace(Data, offset, oldLength, bytes);
            
            // Update string offsets
            str.Offsets[(int)language] = (bytes.Length > 0) ? offset : -1;
            var sizeDelta = bytes.Length - oldLength;
            foreach (var adjustStr in Strings)
            {
                for (var i = 0; i < adjustStr.Offsets.Length; i++)
                {
                    if (adjustStr.Offsets[i] > offset)
                        adjustStr.Offsets[i] += sizeDelta;
                }
            }
        }

        private int GetStringLength(int offset)
        {
            var endOffset = offset;
            while (endOffset < Data.Length && Data[endOffset] != 0)
                endOffset++;
            return endOffset - offset;
        }
    }

    /// <summary>
    /// A localized string.
    /// </summary>
    [TagStructure(Size = 0x54)]
    public class LocalizedString
    {
        public LocalizedString()
        {
            StringId = StringId.Null;
            StringIdStr = "";
            Offsets = new int[12];
            for (var i = 0; i < Offsets.Length; i++)
                Offsets[i] = -1;
        }

        /// <summary>
        /// Gets or sets the string's stringID.
        /// </summary>
        public StringId StringId;

        /// <summary>
        /// Gets or sets the stringID's string value. Can be empty.
        /// </summary>
        [TagField(Length = 0x20)] public string StringIdStr;

        /// <summary>
        /// Gets or sets the array of offsets for each language.
        /// If an offset is -1, then the string is not available.
        /// There must be 12 of these (one offset per language).
        /// </summary>
        [TagField(Count = 12)] public int[] Offsets;
    }
}
