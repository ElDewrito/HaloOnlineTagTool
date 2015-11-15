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
		public uint Unknown20;
		public StringId Unknown21;
		public float JumpVelocity;
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
		public Angle CameraInterpolationStart;
		public Angle CameraInterpolationEnd;
		public uint Unknown22;
		public uint Unknown23;
		public uint Unknown24;
		public uint Unknown25;
		public float AutoaimWidth;
		public short Unknown26;
		public short Unknown27;
		public uint Unknown28;
		public short PhysicsControlNodeIndex;
		public short Unknown29;
		public uint Unknown30;
		public uint Unknown31;
		public uint Unknown32;
		public short PelvisNodeIndex;
		public short HeadNodeIndex;
		public uint Unknown33;
		public float HeadshotAccelerationScale;
		public HaloTag AreaDamageEffect;
		public List<UnknownBlock3> Unknown34;
		public List<UnknownBlock4> Unknown35;
		public uint Unknown36;
		public uint Unknown37;
		public uint Unknown38;
		public uint Unknown39;
		public uint Unknown40;
		public uint Unknown41;
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
		public uint Unknown42;
		public uint Unknown43;
		public uint Unknown44;
		public uint Unknown45;
		public uint Unknown46;
		public uint Unknown47;
		public uint Unknown48;
		public uint Unknown49;
		public uint Unknown50;
		public uint Unknown51;
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
		public short Unknown52;
		public Angle Unknown53;
		public Angle Unknown54;
		public uint Unknown55;
		public uint Unknown56;
		public uint Unknown57;
		public uint Unknown58;
		public uint Unknown59;
		public uint Unknown60;
		public uint Unknown61;
		public uint Unknown62;
		public uint Unknown63;
		public uint Unknown64;
		public uint Unknown65;
		public uint Unknown66;
		public uint Unknown67;
		public uint Unknown68;
		public uint Unknown69;
		public uint Unknown70;
		public uint Unknown71;
		public uint Unknown72;
		public uint Unknown73;
		public uint Unknown74;
		public uint Unknown75;
		public uint Unknown76;
		public uint Unknown77;

		[TagStructure(Size = 0x18)]
		public class WeaponCameraHeightBlock
		{
			public StringId Class;
			public float StandingHeightFraction;
			public float CrouchingHeightFraction;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}

		[TagStructure(Size = 0x24)]
		public class UnknownBlock3
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public byte[] Function;
		}

		[TagStructure(Size = 0x24)]
		public class UnknownBlock4
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public byte[] Function;
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

		[TagStructure(Size = 0x4)]
		public class ContactPoint
		{
			public StringId MarkerName;
		}
	}
}
