using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "effe", Size = 0x68)]
	public class Effect
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
		[TagElement]
		public int Unknown14 { get; set; }
		[TagElement]
		public int Unknown18 { get; set; }
		[TagElement]
		public int Unknown1C { get; set; }
		[TagElement]
		public List<TagBlock0> Unknown20 { get; set; }
		[TagElement]
		public List<TagBlock1> Unknown2C { get; set; }
		[TagElement]
		public HaloTag Unknown38 { get; set; }
		[TagElement]
		public int Unknown48 { get; set; }
		[TagElement]
		public int Unknown4C { get; set; }
		[TagElement]
		public int Unknown50 { get; set; }
		[TagElement]
		public int Unknown54 { get; set; }
		[TagElement]
		public int Unknown58 { get; set; }
		[TagElement]
		public List<TagBlock11> Unknown5C { get; set; }

		[TagStructure(Size = 0xC)]
		public class TagBlock0
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
		}

		[TagStructure(Size = 0x44)]
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
			[TagElement]
			public int Unknown10 { get; set; }
			[TagElement]
			public int Unknown14 { get; set; }
			[TagElement]
			public int Unknown18 { get; set; }
			[TagElement]
			public int Unknown1C { get; set; }
			[TagElement]
			public List<TagBlock2> Unknown20 { get; set; }
			[TagElement]
			public List<TagBlock3> Unknown2C { get; set; }
			[TagElement]
			public List<TagBlock4> Unknown38 { get; set; }

			[TagStructure(Size = 0x60)]
			public class TagBlock2
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
				public HaloTag Unknown10 { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public int Unknown2C { get; set; }
				[TagElement]
				public int Unknown30 { get; set; }
				[TagElement]
				public int Unknown34 { get; set; }
				[TagElement]
				public int Unknown38 { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public int Unknown40 { get; set; }
				[TagElement]
				public int Unknown44 { get; set; }
				[TagElement]
				public int Unknown48 { get; set; }
				[TagElement]
				public int Unknown4C { get; set; }
				[TagElement]
				public int Unknown50 { get; set; }
				[TagElement]
				public int Unknown54 { get; set; }
				[TagElement]
				public int Unknown58 { get; set; }
				[TagElement]
				public int Unknown5C { get; set; }
			}

			[TagStructure(Size = 0x14)]
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
				[TagElement]
				public int Unknown10 { get; set; }
			}

			[TagStructure(Size = 0x5C)]
			public class TagBlock4
			{
				[TagElement]
				public int Unknown0 { get; set; }
				[TagElement]
				public HaloTag Unknown4 { get; set; }
				[TagElement]
				public int Unknown14 { get; set; }
				[TagElement]
				public int Unknown18 { get; set; }
				[TagElement]
				public int Unknown1C { get; set; }
				[TagElement]
				public int Unknown20 { get; set; }
				[TagElement]
				public int Unknown24 { get; set; }
				[TagElement]
				public int Unknown28 { get; set; }
				[TagElement]
				public int Unknown2C { get; set; }
				[TagElement]
				public int Unknown30 { get; set; }
				[TagElement]
				public int Unknown34 { get; set; }
				[TagElement]
				public int Unknown38 { get; set; }
				[TagElement]
				public int Unknown3C { get; set; }
				[TagElement]
				public int Unknown40 { get; set; }
				[TagElement]
				public int Unknown44 { get; set; }
				[TagElement]
				public int Unknown48 { get; set; }
				[TagElement]
				public List<TagBlock5> Unknown4C { get; set; }
				[TagElement]
				public int Unknown58 { get; set; }

				[TagStructure(Size = 0x300)]
				public class TagBlock5
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
					[TagElement]
					public int Unknown14 { get; set; }
					[TagElement]
					public int Unknown18 { get; set; }
					[TagElement]
					public int Unknown1C { get; set; }
					[TagElement]
					public int Unknown20 { get; set; }
					[TagElement]
					public int Unknown24 { get; set; }
					[TagElement]
					public int Unknown28 { get; set; }
					[TagElement]
					public byte[] Unknown2C { get; set; }
					[TagElement]
					public int Unknown40 { get; set; }
					[TagElement]
					public int Unknown44 { get; set; }
					[TagElement]
					public int Unknown48 { get; set; }
					[TagElement]
					public int Unknown4C { get; set; }
					[TagElement]
					public int Unknown50 { get; set; }
					[TagElement]
					public int Unknown54 { get; set; }
					[TagElement]
					public int Unknown58 { get; set; }
					[TagElement]
					public int Unknown5C { get; set; }
					[TagElement]
					public int Unknown60 { get; set; }
					[TagElement]
					public byte[] Unknown64 { get; set; }
					[TagElement]
					public int Unknown78 { get; set; }
					[TagElement]
					public int Unknown7C { get; set; }
					[TagElement]
					public int Unknown80 { get; set; }
					[TagElement]
					public int Unknown84 { get; set; }
					[TagElement]
					public int Unknown88 { get; set; }
					[TagElement]
					public int Unknown8C { get; set; }
					[TagElement]
					public int Unknown90 { get; set; }
					[TagElement]
					public int Unknown94 { get; set; }
					[TagElement]
					public int Unknown98 { get; set; }
					[TagElement]
					public byte[] Unknown9C { get; set; }
					[TagElement]
					public int UnknownB0 { get; set; }
					[TagElement]
					public int UnknownB4 { get; set; }
					[TagElement]
					public int UnknownB8 { get; set; }
					[TagElement]
					public byte[] UnknownBC { get; set; }
					[TagElement]
					public int UnknownD0 { get; set; }
					[TagElement]
					public int UnknownD4 { get; set; }
					[TagElement]
					public int UnknownD8 { get; set; }
					[TagElement]
					public byte[] UnknownDC { get; set; }
					[TagElement]
					public int UnknownF0 { get; set; }
					[TagElement]
					public int UnknownF4 { get; set; }
					[TagElement]
					public int UnknownF8 { get; set; }
					[TagElement]
					public byte[] UnknownFC { get; set; }
					[TagElement]
					public int Unknown110 { get; set; }
					[TagElement]
					public int Unknown114 { get; set; }
					[TagElement]
					public int Unknown118 { get; set; }
					[TagElement]
					public byte[] Unknown11C { get; set; }
					[TagElement]
					public int Unknown130 { get; set; }
					[TagElement]
					public int Unknown134 { get; set; }
					[TagElement]
					public int Unknown138 { get; set; }
					[TagElement]
					public byte[] Unknown13C { get; set; }
					[TagElement]
					public int Unknown150 { get; set; }
					[TagElement]
					public int Unknown154 { get; set; }
					[TagElement]
					public int Unknown158 { get; set; }
					[TagElement]
					public byte[] Unknown15C { get; set; }
					[TagElement]
					public int Unknown170 { get; set; }
					[TagElement]
					public int Unknown174 { get; set; }
					[TagElement]
					public HaloTag Unknown178 { get; set; }
					[TagElement]
					public int Unknown188 { get; set; }
					[TagElement]
					public List<TagBlock6> Unknown18C { get; set; }
					[TagElement]
					public int Unknown198 { get; set; }
					[TagElement]
					public byte[] Unknown19C { get; set; }
					[TagElement]
					public int Unknown1B0 { get; set; }
					[TagElement]
					public int Unknown1B4 { get; set; }
					[TagElement]
					public int Unknown1B8 { get; set; }
					[TagElement]
					public int Unknown1BC { get; set; }
					[TagElement]
					public int Unknown1C0 { get; set; }
					[TagElement]
					public int Unknown1C4 { get; set; }
					[TagElement]
					public int Unknown1C8 { get; set; }
					[TagElement]
					public int Unknown1CC { get; set; }
					[TagElement]
					public int Unknown1D0 { get; set; }
					[TagElement]
					public byte[] Unknown1D4 { get; set; }
					[TagElement]
					public int Unknown1E8 { get; set; }
					[TagElement]
					public int Unknown1EC { get; set; }
					[TagElement]
					public int Unknown1F0 { get; set; }
					[TagElement]
					public byte[] Unknown1F4 { get; set; }
					[TagElement]
					public int Unknown208 { get; set; }
					[TagElement]
					public int Unknown20C { get; set; }
					[TagElement]
					public int Unknown210 { get; set; }
					[TagElement]
					public byte[] Unknown214 { get; set; }
					[TagElement]
					public int Unknown228 { get; set; }
					[TagElement]
					public int Unknown22C { get; set; }
					[TagElement]
					public int Unknown230 { get; set; }
					[TagElement]
					public byte[] Unknown234 { get; set; }
					[TagElement]
					public int Unknown248 { get; set; }
					[TagElement]
					public int Unknown24C { get; set; }
					[TagElement]
					public int Unknown250 { get; set; }
					[TagElement]
					public byte[] Unknown254 { get; set; }
					[TagElement]
					public int Unknown268 { get; set; }
					[TagElement]
					public int Unknown26C { get; set; }
					[TagElement]
					public int Unknown270 { get; set; }
					[TagElement]
					public byte[] Unknown274 { get; set; }
					[TagElement]
					public int Unknown288 { get; set; }
					[TagElement]
					public int Unknown28C { get; set; }
					[TagElement]
					public int Unknown290 { get; set; }
					[TagElement]
					public byte[] Unknown294 { get; set; }
					[TagElement]
					public int Unknown2A8 { get; set; }
					[TagElement]
					public int Unknown2AC { get; set; }
					[TagElement]
					public int Unknown2B0 { get; set; }
					[TagElement]
					public byte[] Unknown2B4 { get; set; }
					[TagElement]
					public int Unknown2C8 { get; set; }
					[TagElement]
					public int Unknown2CC { get; set; }
					[TagElement]
					public int Unknown2D0 { get; set; }
					[TagElement]
					public int Unknown2D4 { get; set; }
					[TagElement]
					public int Unknown2D8 { get; set; }
					[TagElement]
					public List<TagBlock8> Unknown2DC { get; set; }
					[TagElement]
					public List<TagBlock9> Unknown2E8 { get; set; }
					[TagElement]
					public List<TagBlock10> Unknown2F4 { get; set; }

					[TagStructure(Size = 0x18)]
					public class TagBlock6
					{
						[TagElement]
						public int Unknown0 { get; set; }
						[TagElement]
						public List<TagBlock7> Unknown4 { get; set; }
						[TagElement]
						public int Unknown10 { get; set; }
						[TagElement]
						public int Unknown14 { get; set; }

						[TagStructure(Size = 0x24)]
						public class TagBlock7
						{
							[TagElement]
							public int Unknown0 { get; set; }
							[TagElement]
							public int Unknown4 { get; set; }
							[TagElement]
							public byte[] Unknown8 { get; set; }
							[TagElement]
							public int Unknown1C { get; set; }
							[TagElement]
							public int Unknown20 { get; set; }
						}
					}

					[TagStructure(Size = 0x10)]
					public class TagBlock8
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

					[TagStructure(Size = 0x40)]
					public class TagBlock9
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
						[TagElement]
						public int Unknown14 { get; set; }
						[TagElement]
						public int Unknown18 { get; set; }
						[TagElement]
						public int Unknown1C { get; set; }
						[TagElement]
						public int Unknown20 { get; set; }
						[TagElement]
						public int Unknown24 { get; set; }
						[TagElement]
						public int Unknown28 { get; set; }
						[TagElement]
						public int Unknown2C { get; set; }
						[TagElement]
						public int Unknown30 { get; set; }
						[TagElement]
						public int Unknown34 { get; set; }
						[TagElement]
						public int Unknown38 { get; set; }
						[TagElement]
						public int Unknown3C { get; set; }
					}

					[TagStructure(Size = 0x10)]
					public class TagBlock10
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
			}
		}

		[TagStructure(Size = 0xC)]
		public class TagBlock11
		{
			[TagElement]
			public int Unknown0 { get; set; }
			[TagElement]
			public int Unknown4 { get; set; }
			[TagElement]
			public int Unknown8 { get; set; }
		}
	}
}
