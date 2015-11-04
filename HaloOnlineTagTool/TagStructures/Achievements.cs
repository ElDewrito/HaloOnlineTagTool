using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "achi", Size = 0x18)]
	public class Achievements
	{
		public List<AchievementInformationBlock> AchievementInformation;
		public float Unknown;
		public float Unknown2;
		public float Unknown3;

		[TagStructure(Size = 0x18)]
		public class AchievementInformationBlock
		{
			public int Unknown;
			public int Unknown2;
			public StringId LevelName;
			public int Unknown3;
			public int Unknown4;
			public int Unknown5;
		}
	}
}
