using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "chmt", Size = 0xC)]
	public class ChocolateMountainNew
	{
		[TagElement]
		public List<TagBlock0> Unknown0 { get; set; }

		[TagStructure(Size = 0x4)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
		}
	}
}
