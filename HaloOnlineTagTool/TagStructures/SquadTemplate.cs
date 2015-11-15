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
	[TagStructure(Class = "sqtm", Size = 0x10)]
	public class SquadTemplate
	{
		public StringId Name;
		public List<SquadBlock> Squad;

		[TagStructure(Size = 0x60)]
		public class SquadBlock
		{
			public StringId Name;
			public ushort Difficulty;
			public short Unknown;
			public short MinimumRound;
			public short MaximumRound;
			public short Unknown2;
			public short Unknown3;
			public short Count;
			public short Unknown4;
			public List<Actor> Actors;
			public List<Weapon> Weapons;
			public List<SecondaryWeapon> SecondaryWeapons;
			public List<EquipmentBlock> Equipment;
			public uint Unknown5;
			public HaloTag Vehicle;
			public StringId VehicleVariant;
			public uint Unknown6;

			[TagStructure(Size = 0x20)]
			public class Actor
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public HaloTag Character;
				public short Probability;
				public short Unknown4;
			}

			[TagStructure(Size = 0x20)]
			public class Weapon
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public HaloTag Weapon2;
				public short Probability;
				public short Unknown4;
			}

			[TagStructure(Size = 0x20)]
			public class SecondaryWeapon
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public HaloTag Weapon;
				public short Probability;
				public short Unknown4;
			}

			[TagStructure(Size = 0x20)]
			public class EquipmentBlock
			{
				public short Unknown;
				public short Unknown2;
				public short MinimumRound;
				public short MaximumRound;
				public uint Unknown3;
				public HaloTag Equipment;
				public short Probability;
				public short Unknown4;
			}
		}
	}
}
