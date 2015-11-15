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
	[TagStructure(Class = "crea", Size = 0x100)]
	public class Creature : GameObject
	{
		public uint Flags2;
		public DefaultTeamValue DefaultTeam;
		public MotionSensorBlipSizeValue MotionSensorBlipSize;
		public Angle TurningVelocityMaximum;
		public Angle TurningAccelerationMaximum;
		public float CasualTuringModifer;
		public float AutoaimWidth;
		public uint Flags3;
		public float HeightStanding;
		public float HeightCrouching;
		public float Radius;
		public float Mass;
		public StringId LivingMaterialName;
		public StringId DeadMaterialName;
		public short LivingGlobalMaterialIndex;
		public short DeadGlobalMaterialIndex;
		public List<DeadSphereShape> DeadSphereShapes;
		public List<PillShape> PillShapes;
		public List<SphereShape> SphereShapes;
		public Angle MaximumSlopeAngle;
		public Angle DownhillFalloffAngle;
		public Angle DownhillCutoffAngle;
		public Angle UphillFalloffAngle;
		public Angle UphillCutoffAngle;
		public float DownhillVelocityScale;
		public float UphillVelocityScale;
		public uint Unknown6;
		public uint Unknown7;
		public uint Unknown8;
		public uint Unknown9;
		public uint Unknown10;
		public uint Unknown11;
		public uint Unknown12;
		public float FallingVelocityScale;
		public uint Unknown13;
		public Angle BankAngle;
		public float BankApplyTime;
		public float BankDecayTime;
		public float PitchRatio;
		public float MaximumVelocity;
		public float MaximumSidestepVelocity;
		public float Acceleration;
		public float Deceleration;
		public Angle AngularVelocityMaximum;
		public Angle AngularAccelerationMaximum;
		public float CrouchVelocityModifier;
		public uint Unknown14;
		public HaloTag ImpactDamage;
		public HaloTag ImpactShieldDamage;
		public List<MetagameProperty> MetagameProperties;
		public float DestroyAfterDeathTimeMin;
		public float DestroyAfterDeathTimeMax;

		public enum DefaultTeamValue : short
		{
			Default,
			Player,
			Human,
			Covenant,
			Flood,
			Sentinel,
			Heretic,
			Prophet,
			Guilty,
			Unused9,
			Unused10,
			Unused11,
			Unused12,
			Unused13,
			Unused14,
			Unused15,
		}

		public enum MotionSensorBlipSizeValue : short
		{
			Medium,
			Small,
			Large,
		}

		[TagStructure(Size = 0x70)]
		public class DeadSphereShape
		{
			public StringId Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public float TranslationI;
			public float TranslationJ;
			public float TranslationK;
			public float TranslationRadius;
		}

		[TagStructure(Size = 0x60)]
		public class PillShape
		{
			public StringId Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short Index;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public float BottomI;
			public float BottomJ;
			public float BottomK;
			public float BottomRadius;
			public float TopI;
			public float TopJ;
			public float TopK;
			public float TopRadius;
		}

		[TagStructure(Size = 0x70)]
		public class SphereShape
		{
			public StringId Name;
			public sbyte MaterialIndex;
			public sbyte Unknown;
			public short GlobalMaterialIndex;
			public float RelativeMassScale;
			public float Friction;
			public float Restitution;
			public float Volume;
			public float Mass;
			public short OverallShapeIndex;
			public sbyte PhantomIndex;
			public sbyte InteractionUnknown;
			public int Unknown2;
			public short Size;
			public short Count;
			public int Offset;
			public int Unknown3;
			public float Radius;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public float TranslationI;
			public float TranslationJ;
			public float TranslationK;
			public float TranslationRadius;
		}

		[TagStructure(Size = 0x8)]
		public class MetagameProperty
		{
			public byte Flags;
			public UnitValue Unit;
			public ClassificationValue Classification;
			public sbyte Unknown;
			public short Points;
			public short Unknown2;

			public enum UnitValue : sbyte
			{
				Brute,
				Grunt,
				Jackal,
				Marine,
				Bugger,
				Hunter,
				FloodInfection,
				FloodCarrier,
				FloodCombat,
				FloodPureform,
				Sentinel,
				Elite,
				Turret,
				Mongoose,
				Warthog,
				Scorpion,
				Hornet,
				Pelican,
				Shade,
				Watchtower,
				Ghost,
				Chopper,
				Mauler,
				Wraith,
				Banshee,
				Phantom,
				Scarab,
				Guntower,
				Engineer,
				EngineerRechargeStation,
			}

			public enum ClassificationValue : sbyte
			{
				Infantry,
				Leader,
				Hero,
				Specialist,
				LightVehicle,
				HeavyVehicle,
				GiantVehicle,
				StandardVehicle,
			}
		}
	}
}
