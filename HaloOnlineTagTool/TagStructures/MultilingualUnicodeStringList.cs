using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	/// <summary>
	/// Contains a list of localized strings.
	/// </summary>
	[TagStructure(Class = "unic", Size = 0x5C)]
	public class MultilingualUnicodeStringList
	{
		/// <summary>
		/// Gets or sets the strings in the list.
		/// </summary>
		[TagElement]
		public List<LocalizedString> Strings { get; set; }

		/// <summary>
		/// Gets or sets the data block containing every string.
		/// </summary>
		[TagElement]
		public byte[] Data { get; set; }

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

			// Figure out the size of the string in bytes by scanning for a null terminator
			var endOffset = offset;
			while (endOffset < Data.Length && Data[endOffset] != 0)
				endOffset++;
			return Encoding.UTF8.GetString(Data, offset, endOffset - offset);
		}
	}

	/// <summary>
	/// A localized string.
	/// </summary>
	[TagStructure(Size = 0x54)]
	public class LocalizedString
	{
		/// <summary>
		/// Gets or sets the string's stringID.
		/// </summary>
		[TagElement]
		public int StringId { get; set; }

		/// <summary>
		/// Gets or sets the stringID's string value. Can be empty.
		/// </summary>
		[TagElement(Size = 0x20)]
		public string StringIdStr { get; set; }

		/// <summary>
		/// Gets or sets the array of offsets for each language.
		/// If an offset is -1, then the string is not available.
		/// There must be 12 of these (one offset per language).
		/// </summary>
		[TagElement(Count = 12)]
		public int[] Offsets { get; set; }
	}
}
