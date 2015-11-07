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
	[TagStructure(Class = "bipd", Size = 0x240)]
	public class Biped : Unit
	{
		public Angle MovingTurningSpeed;
		public uint Flags4;
		public Angle StationaryTurningSpeed;
		public float Unknown20;
		public float Unknown21;
		public float JumpVelcoity;
		public float MaximumSoftLandingTime;
		public float MinimumHardLandingTime;
		public float MinimumSoftLandingVelocity;
		public float MinimumHardLandingVelocity;
		public float MaximumHardLandingVelocity;
		public float DeathHardLandingVelocity;
		public float StunDuration;
		public float StationaryStandingCameraHeight;
		public float MovingStandingCameraHeight;
		public float StationaryCrouchingCameraHeight;
		public float MovingCrouchingCameraHeight;
		public float CrouchTransitionTime;
		public byte[] CrouchingCameraFunction;
		public List<WeaponCameraHeightBlock> WeaponCameraHeight;
		public Angle Unknown22;
		public Angle Unknown23;
		public float Unknown24;
		public float Unknown25;
		public float Unknown26;
		public float Unknown27;
		public float Unknown28;
		public short Unknown29;
		public short Unknown30;
		public float Unknown31;
		public short Unknown32;
		public short Unknown33;
		public float Unknown34;
		public float Unknown35;
		public float Unknown36;
		public short Unknown37;
		public short Unknown38;
		public float Unknown39;
		public float HeadshotAccelerationScale;
		public HaloTag AreaDamageEffect;
		public float Unknown40;
		public float Unknown41;
		public float Unknown42;
		public float Unknown43;
		public float Unknown44;
		public float Unknown45;
		public float Unknown46;
		public float Unknown47;
		public float Unknown48;
		public float Unknown49;
		public float Unknown50;
		public float Unknown51;
		public uint Flags5;
		public float HeightStanding;
		public float HeightCrouching;
		public float Radius;
		public float Mass;
		public StringId LivingMaterialName;
		public StringId DeadMaterialName;
		public short LivingMaterialGlobalIndex;
		public short DeadMaterialGlobalIndex;
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
		public float Unknown52;
		public float Unknown53;
		public float Unknown54;
		public float Unknown55;
		public float Unknown56;
		public float Unknown57;
		public float Unknown58;
		public float Unknown59;
		public float Unknown60;
		public float Unknown61;
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
		public List<ContactPoint> ContactPoints;
		public HaloTag ReanimationCharacter;
		public HaloTag TransformationMuffin;
		public HaloTag DeathSpawnCharacter;
		public short DeathSpawnCount;
		public short Unknown62;
		public Angle Unknown63;
		public Angle Unknown64;
		public float Unknown65;
		public float Unknown66;
		public float Unknown67;
		public float Unknown68;
		public float Unknown69;
		public float Unknown70;
		public float Unknown71;
		public float Unknown72;
		public float Unknown73;
		public float Unknown74;
		public float Unknown75;
		public float Unknown76;
		public float Unknown77;
		public float Unknown78;
		public float Unknown79;
		public float Unknown80;
		public float Unknown81;
		public float Unknown82;
		public float Unknown83;
		public float Unknown84;
		public float Unknown85;
		public float Unknown86;
		public float Unknown87;

		[TagStructure(Size = 0x18)]
		public class WeaponCameraHeightBlock
		{
			public StringId Class;
			public float StandingHeightFraction;
			public float CrouchingHeightFraction;
			public float Unknown;
			public float Unknown2;
			public float Unknown3;
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
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
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
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
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
			public float Unknown4;
			public float Unknown5;
			public float Unknown6;
			public int Unknown7;
			public short Size2;
			public short Count2;
			public int Offset2;
			public int Unknown8;
			public float Radius2;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float TranslationI;
			public float TranslationJ;
			public float TranslationK;
			public float TranslationRadius;
		}

		[TagStructure(Size = 0x4)]
		public class ContactPoint
		{
			public StringId MarkerName;
		}
	}
}
