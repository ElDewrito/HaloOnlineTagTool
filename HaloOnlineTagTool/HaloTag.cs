using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
	/// <summary>
	/// Describes a tag in a tag cache.
	/// </summary>
	public class HaloTag
	{
		/// <summary>
		/// Initializes an empty tag description.
		/// </summary>
		public HaloTag()
		{
			Dependencies = new HashSet<int>();
			DataFixups = new List<TagFixup>();
			ResourceFixups = new List<TagFixup>();
			Index = -1;
		}

		/// <summary>
		/// Gets the tag's index, or -1 if it is not in the table.
		/// </summary>
		public int Index { get; internal set; }

		/// <summary>
		/// Gets or sets the tag's group tag.
		/// </summary>
		public MagicNumber GroupTag { get; set; }

		/// <summary>
		/// Gets or sets the tag's parent group tag. Can be -1.
		/// </summary>
		public MagicNumber ParentGroupTag { get; set; }

		/// <summary>
		/// Gets or sets the tag's grandparent group tag. Can be -1.
		/// </summary>
		public MagicNumber GrandparentGroupTag { get; set; }

		/// <summary>
		/// Gets or sets the stringID for the tag's group.
		/// </summary>
		public StringId GroupName { get; set; }

		/// <summary>
		/// Gets the offset of the tag's data (after the header).
		/// </summary>
		public uint Offset { get; internal set; }

		/// <summary>
		/// Gets the size of the tag's data (not including the header).
		/// </summary>
		public uint Size { get; internal set; }

		/// <summary>
		/// Gets or sets the offset of the tag's main structure from the start of its data.
		/// </summary>
		public uint MainStructOffset { get; set; }

		/// <summary>
		/// Checksum (adler32?) of the tag's data. Can set this to 0 if checksum verification is patched out.
		/// </summary>
		public uint Checksum { get; set; }

		/// <summary>
		/// Gets the indexes of tags that this tag depends on.
		/// </summary>
		public HashSet<int> Dependencies { get; private set; }

		/// <summary>
		/// Gets the tag's data fixups.
		/// </summary>
		public List<TagFixup> DataFixups { get; private set; }

		/// <summary>
		/// Gets the tag's resource fixups.
		/// </summary>
		public List<TagFixup> ResourceFixups { get; private set; }

		/// <summary>
		/// Determines whether the tag is an instance of a given tag class identifier.
		/// </summary>
		/// <param name="tagClass">The tag class.</param>
		/// <returns><c>true</c> if the tag is an instance of the given class identifier.</returns>
		public bool IsClass(MagicNumber tagClass)
		{
			if (tagClass.Value == -1)
				return false;
			return (GroupTag == tagClass || ParentGroupTag == tagClass || GrandparentGroupTag == tagClass);
		}

		/// <summary>
		/// Determines whether the tag is an instance of a given tag class identifier.
		/// </summary>
		/// <param name="className">A 4-character string representing the tag class, e.g. "scnr".</param>
		/// <returns><c>true</c> if the tag is an instance of the given class identifier.</returns>
		public bool IsClass(string className)
		{
			return IsClass(new MagicNumber(className));
		}
	}

	/// <summary>
	/// Contains information about a fixup that needs to be performed on the tag data.
	/// </summary>
	public class TagFixup
	{
		/// <summary>
		/// Gets or sets the offset of the pointer to adjust from the start of the tag's data.
		/// </summary>
		public uint WriteOffset { get; set; }

		/// <summary>
		/// Gets or sets the offset that the pointer should point to from the start of the tag's data.
		/// </summary>
		public uint TargetOffset { get; set; }
	}
}
