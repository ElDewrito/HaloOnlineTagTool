using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "chad", Size = 0x5C)]
	public class ChudAnimationDefinition
	{
		[TagElement]
		public int Unknown0 { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown4 { get; set; }
		[TagElement]
		public List<TagBlock2> Unknown10 { get; set; }
		[TagElement]
		public List<TagBlock4> Unknown1C { get; set; }
		[TagElement]
		public List<TagBlock6> Unknown28 { get; set; }
		[TagElement]
		public List<TagBlock8> Unknown34 { get; set; }
		[TagElement]
		public List<TagBlock10> Unknown40 { get; set; }
		[TagElement]
		public List<TagBlock12> Unknown4C { get; set; }
		[TagElement]
		public int Unknown58 { get; set; }

		[TagStructure(Size = 0x20)]
		public class TagBlock0
		{
			[TagElement]
			public List<TagBlock1> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0x10)]
			public class TagBlock1
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock2
		{
			[TagElement]
			public List<TagBlock3> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0x10)]
			public class TagBlock3
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock4
		{
			[TagElement]
			public List<TagBlock5> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0xC)]
			public class TagBlock5
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock6
		{
			[TagElement]
			public List<TagBlock7> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0x8)]
			public class TagBlock7
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock8
		{
			[TagElement]
			public List<TagBlock9> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0x8)]
			public class TagBlock9
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock10
		{
			[TagElement]
			public List<TagBlock11> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0x8)]
			public class TagBlock11
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
			}
		}

		[TagStructure(Size = 0x20)]
		public class TagBlock12
		{
			[TagElement]
			public List<TagBlock13> Unknown0 { get; set; }
			[TagElement]
			public byte[] UnknownC { get; set; }

			[TagStructure(Size = 0x14)]
			public class TagBlock13
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public int Unknown4 { get; set; }
				[TagElement]
				public int Unknown8 { get; set; }
				[TagElement]
				public int UnknownC { get; set; }
				[TagElement]
				public int Unknown10 { get; set; }
			}
		}
	}
}
