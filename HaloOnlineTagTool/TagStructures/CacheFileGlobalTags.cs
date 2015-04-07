using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	/// <summary>
	/// Contains a list of global tags in the cache file.
	/// </summary>
	[TagStructure(Class = "cfgt", Size = 0x10)]
	public class CacheFileGlobalTags
	{
		/// <summary>
		/// Gets or sets the list of global tags.
		/// </summary>
		[TagElement]
		public List<HaloTag> Tags { get; set; }

		/// <summary>
		/// Finds a global tag by its class identifier.
		/// </summary>
		/// <param name="tagClass">The tag class identifier.</param>
		/// <returns>The global tag if found, or <c>null</c> otherwise.</returns>
		public HaloTag FindTag(MagicNumber tagClass)
		{
			return Tags.FirstOrDefault(t => t.IsClass(tagClass));
		}

		/// <summary>
		/// Finds a global tag by its class name.
		/// </summary>
		/// <param name="className">A 4-character string representing the tag class.</param>
		/// <returns></returns>
		public HaloTag FindTag(string className)
		{
			return FindTag(new MagicNumber(className));
		}
	}
}
