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
			Fixups = new List<TagFixup>();
		}

		/// <summary>
		/// Gets the tag's index.
		/// </summary>
		public int Index { get; internal set; }

		/// <summary>
		/// Gets or sets the tag's class.
		/// </summary>
		public MagicNumber Class { get; set; }

		/// <summary>
		/// Gets or sets the tag's parent class. Can be -1.
		/// </summary>
		public MagicNumber ParentClass { get; set; }

		/// <summary>
		/// Gets or sets the tag's grandparent class. Can be -1.
		/// </summary>
		public MagicNumber GrandparentClass { get; set; }

		/// <summary>
		/// Gets the offset of the tag's data, including its header.
		/// </summary>
		public uint Offset { get; internal set; }

		/// <summary>
		/// Gets the size of the tag's data, including its header.
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
		/// Always zero?
		/// </summary>
		public uint Unknown2 { get; set; }

		public uint Unknown3 { get; set; }

		/// <summary>
		/// Gets the indexes of tags that this tag depends on.
		/// </summary>
		public HashSet<int> Dependencies { get; private set; }

		/// <summary>
		/// Gets the tag's fixups.
		/// </summary>
		public List<TagFixup> Fixups { get; private set; }
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
