using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Attribute for a serializable structure in a tag.
	/// </summary>
	[AttributeUsage(AttributeTargets.Class)]
	public class TagStructureAttribute : Attribute
	{
		/// <summary>
		/// Gets or sets the name of the tag class that the structure applies to.
		/// </summary>
		public string Class { get; set; }

		/// <summary>
		/// Gets or sets the size of the structure in bytes.
		/// If this is zero, then the size will be calculated automatically.
		/// </summary>
		public uint Size { get; set; }
	}
}
