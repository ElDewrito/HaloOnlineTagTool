using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Attribute for automatically-serializable values in a tag.
	/// </summary>
	[AttributeUsage(AttributeTargets.Property)]
	class TagElementAttribute : Attribute
	{
		public TagElementAttribute()
		{
			Offset = -1;
		}

		/// <summary>
		/// Gets or sets the offset of the value from the beginning of the structure.
		/// If this is -1 (default), then the current stream position will be used.
		/// </summary>
		public int Offset { get; set; }

		/// <summary>
		/// Gets or sets the size of the value in bytes.
		/// If this is 0 (default), then the size will be inferred from the value type.
		/// </summary>
		public uint Size { get; set; }
	}
}
