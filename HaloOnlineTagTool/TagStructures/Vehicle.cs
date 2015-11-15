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
	[TagStructure(Class = "vehi", Size = 0x148)]
	public class Vehicle : Unit
	{
		public uint Flags5;
		public List<TankEngineMotionProperty> TankEngineMotionProperties;
		public List<EngineMotionProperty> EngineMotionProperties;
		public List<DropshipMotionProperty> DropshipMotionProperties;
		public List<AntigravityMotionProperty> AntigravityMotionProperties;
		public List<JetEngineMotionProperty> JetEngineMotionProperties;
		public List<TurretProperty> TurretProperties;
		public uint Unknown20;
		public uint Unknown21;
		public uint Unknown22;
		public List<HelicopterMotionProperty> HelicopterMotionProperties;
		public List<AntigravityEngineMotionProperty> AntigravityEngineMotionProperties;
		public List<AutoturretEquipmentBlock> AutoturretEquipment;
		public uint Flags6;
		public float GroundFriction;
		public float GroundDepth;
		public float GroundDampFactor;
		public float GroundMovingFriction;
		public float GroundMaximumSlope0;
		public float GroundMaximumSlope1LessThanSlope0;
		public uint Unknown23;
		public float AntiGravityBankLift;
		public float SteeringBankReactionScale;
		public float GravityScale;
		public float Radius;
		public uint Unknown24;
		public uint Unknown25;
		public uint Unknown26;
		public List<AntiGravityPoint> AntiGravityPoints;
		public List<FrictionPoint> FrictionPoints;
		public List<PhantomShape> PhantomShapes;
		public PlayerTrainingVehicleTypeValue PlayerTrainingVehicleType;
		public VehicleSizeValue VehicleSize;
		public sbyte Unknown27;
		public sbyte Unknown28;
		public float MinimumFlippingAngularVelocity;
		public float MaximumFlippingAngularVelocity;
		public uint Unknown29;
		public uint Unknown30;
		public float SeatEntranceAccelerationScale;
		public float SeatExitAccelerationScale;
		public float FlipTime;
		public StringId FlipOverMessage;
		public HaloTag SuspensionSound;
		public HaloTag RunningEffect;
		public HaloTag UnknownResponse;
		public HaloTag UnknownResponse2;
		public uint Unknown31;
		public uint Unknown32;

		[TagStructure(Size = 0x58)]
		public class TankEngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public uint Unknown;
			public float SpeedLeft;
			public float SpeedRight;
			public float TurningSpeedLeft;
			public float TurningSpeedRight;
			public float SpeedLeft2;
			public float SpeedRight2;
			public float TurningSpeedLeft2;
			public float TurningSpeedRight2;
			public float EngineMomentum;
			public float EngineMaximumAngularVelocity;
			public List<Gear> Gears;
			public HaloTag ChangeGearSound;
			public uint Unknown2;
			public uint Unknown3;

			[TagStructure(Size = 0x44)]
			public class Gear
			{
				public float MinTorque;
				public float MaxTorque;
				public float PeakTorqueScale;
				public float PastPeakTorqueExponent;
				public float TorqueAtMaxAngularVelovity;
				public float TorqueAt2xMaxAngularVelocity;
				public float MinTorque2;
				public float MaxTorque2;
				public float PeakTorqueScale2;
				public float PastPeakTorqueExponent2;
				public float TorqueAtMaxAngularVelovity2;
				public float TorqueAt2xMaxAngularVelocity2;
				public float MinTimeToUpshift;
				public float EngineUpshiftScale;
				public float GearRatio;
				public float MinTimeToDownshift;
				public float EngineDownshiftScale;
			}
		}

		[TagStructure(Size = 0x40)]
		public class EngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle TurnRate;
			public float EngineMomentum;
			public float EngineMaximumAngularVelocity;
			public List<Gear> Gears;
			public HaloTag ChangeGearSound;
			public uint Unknown;
			public uint Unknown2;

			[TagStructure(Size = 0x44)]
			public class Gear
			{
				public float MinTorque;
				public float MaxTorque;
				public float PeakTorqueScale;
				public float PastPeakTorqueExponent;
				public float TorqueAtMaxAngularVelovity;
				public float TorqueAt2xMaxAngularVelocity;
				public float MinTorque2;
				public float MaxTorque2;
				public float PeakTorqueScale2;
				public float PastPeakTorqueExponent2;
				public float TorqueAtMaxAngularVelovity2;
				public float TorqueAt2xMaxAngularVelocity2;
				public float MinTimeToUpshift;
				public float EngineUpshiftScale;
				public float GearRatio;
				public float MinTimeToDownshift;
				public float EngineDownshiftScale;
			}
		}

		[TagStructure(Size = 0x4C)]
		public class DropshipMotionProperty
		{
			public float ForwardAcceleration;
			public float BackwardAcceleration;
			public uint Unknown;
			public uint Unknown2;
			public float LeftStrafeAcceleration;
			public float RightStrafeAcceleration;
			public uint Unknown3;
			public uint Unknown4;
			public float LiftAcceleration;
			public float DropAcceleration;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public Angle Unknown11;
			public uint Unknown12;
			public Angle Unknown13;
		}

		[TagStructure(Size = 0x70)]
		public class AntigravityMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public float MaximumForwardSpeed;
			public float MaximumReverseSpeed;
			public float SpeedAcceleration;
			public float SpeedDeceleration;
			public float MaximumLeftSlide;
			public float MaximumRightSlide;
			public float SlideAcceleration;
			public float SlideDeceleration;
			public sbyte Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public float Traction;
			public uint Unknown5;
			public float TurningRate;
			public StringId Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public StringId Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public uint Unknown18;
			public Angle Unknown19;
		}

		[TagStructure(Size = 0x68)]
		public class JetEngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle TurnRate;
			public float FlyingSpeed;
			public float Acceleration;
			public float SpeedAcceleration;
			public float SpeedDeceleration;
			public float PitchLeftSpeed;
			public float PitchRightSpeed;
			public float PitchRate;
			public float UnpitchRate;
			public float FlightStability;
			public uint Unknown;
			public float NoseAngle;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public float FallingSpeed;
			public float FallingSpeed2;
			public uint Unknown5;
			public uint Unknown6;
			public float IdleRise;
			public float IdleForward;
			public uint Unknown7;
		}

		[TagStructure(Size = 0x8)]
		public class TurretProperty
		{
			public uint Unknown;
			public uint Unknown2;
		}

		[TagStructure(Size = 0x74)]
		public class HelicopterMotionProperty
		{
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle Unknown;
			public StringId ThrustFrontLeft;
			public StringId ThrustFrontRight;
			public StringId Thrust;
			public Angle Unknown2;
			public Angle Unknown3;
			public Angle Unknown4;
			public Angle Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public uint Unknown18;
			public uint Unknown19;
			public uint Unknown20;
			public Angle Unknown21;
			public Angle Unknown22;
			public uint Unknown23;
			public uint Unknown24;
		}

		[TagStructure(Size = 0x70)]
		public class AntigravityEngineMotionProperty
		{
			public Angle SteeringOverdampenCuspAngle;
			public float SteeringOverdamenExponent;
			public Angle MaximumLeftTurn;
			public Angle MaximumRightTurnNegative;
			public Angle TurnRate;
			public float EngineMomentum;
			public float EngineMaximumAngularVelocity;
			public List<Gear> Gears;
			public HaloTag ChangeGearSound;
			public uint Unknown;
			public StringId Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public Angle Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;

			[TagStructure(Size = 0x44)]
			public class Gear
			{
				public float MinTorque;
				public float MaxTorque;
				public float PeakTorqueScale;
				public float PastPeakTorqueExponent;
				public float TorqueAtMaxAngularVelovity;
				public float TorqueAt2xMaxAngularVelocity;
				public float MinTorque2;
				public float MaxTorque2;
				public float PeakTorqueScale2;
				public float PastPeakTorqueExponent2;
				public float TorqueAtMaxAngularVelovity2;
				public float TorqueAt2xMaxAngularVelocity2;
				public float MinTimeToUpshift;
				public float EngineUpshiftScale;
				public float GearRatio;
				public float MinTimeToDownshift;
				public float EngineDownshiftScale;
			}
		}

		[TagStructure(Size = 0x30)]
		public class AutoturretEquipmentBlock
		{
			public Angle Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
		}

		[TagStructure(Size = 0x4C)]
		public class AntiGravityPoint
		{
			public StringId MarkerName;
			public uint Flags;
			public float AntigravStrength;
			public float AntigravOffset;
			public float AntigravHeight;
			public float AntigravDumpFactor;
			public float AntigravNormalK1;
			public float AntigravNormalK0;
			public float Radius;
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
			public short Unknown4;
			public short DamageSourceRegionIndex;
			public StringId DamageSourceRegionName;
			public float DefaultStateError;
			public float MinorDamageError;
			public float MediumDamageError;
			public float MajorDamageError;
			public float DestroyedStateError;
		}

		[TagStructure(Size = 0x4C)]
		public class FrictionPoint
		{
			public StringId MarkerName;
			public uint Flags;
			public float FractionOfTotalMass;
			public float Radius;
			public float DamagedRadius;
			public FrictionTypeValue FrictionType;
			public short Unknown;
			public float MovingFrictionVelocityDiff;
			public float EBrakeMovingFriction;
			public float EBrakeFriction;
			public float EBrakeMovingFrictionVelocityDiff;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public uint Unknown5;
			public uint Unknown6;
			public StringId CollisionMaterialName;
			public short CollisionGlobalMaterialIndex;
			public ModelStateDestroyedValue ModelStateDestroyed;
			public StringId RegionName;
			public int RegionIndex;

			public enum FrictionTypeValue : short
			{
				Point,
				Forward,
			}

			public enum ModelStateDestroyedValue : short
			{
				Default,
				MinorDamage,
				MediumDamage,
				MajorDamage,
				Destroyed,
			}
		}

		[TagStructure(Size = 0x330)]
		public class PhantomShape
		{
			public int Unknown;
			public short Size;
			public short Count;
			public int OverallShapeIndex;
			public int Offset;
			public uint Unknown2;
			public uint Unknown3;
			public uint Unknown4;
			public int Unknown5;
			public uint Unknown6;
			public uint Unknown7;
			public uint Unknown8;
			public uint Unknown9;
			public uint Unknown10;
			public uint Unknown11;
			public uint Unknown12;
			public uint Unknown13;
			public uint Unknown14;
			public uint Unknown15;
			public uint Unknown16;
			public uint Unknown17;
			public int MultisphereCount;
			public uint Flags;
			public float X0;
			public float X1;
			public float Y0;
			public float Y1;
			public float Z0;
			public float Z1;
			public int Unknown18;
			public short Size2;
			public short Count2;
			public int OverallShapeIndex2;
			public int Offset2;
			public int NumberOfSpheres;
			public uint Unknown19;
			public uint Unknown20;
			public uint Unknown21;
			public float Sphere0X;
			public float Sphere0Y;
			public float Sphere0Z;
			public float Sphere0Radius;
			public float Sphere1X;
			public float Sphere1Y;
			public float Sphere1Z;
			public float Sphere1Radius;
			public float Sphere2X;
			public float Sphere2Y;
			public float Sphere2Z;
			public float Sphere2Radius;
			public float Sphere3X;
			public float Sphere3Y;
			public float Sphere3Z;
			public float Sphere3Radius;
			public float Sphere4X;
			public float Sphere4Y;
			public float Sphere4Z;
			public float Sphere4Radius;
			public float Sphere5X;
			public float Sphere5Y;
			public float Sphere5Z;
			public float Sphere5Radius;
			public float Sphere6X;
			public float Sphere6Y;
			public float Sphere6Z;
			public float Sphere6Radius;
			public float Sphere7X;
			public float Sphere7Y;
			public float Sphere7Z;
			public float Sphere7Radius;
			public int Unknown22;
			public short Size3;
			public short Count3;
			public int OverallShapeIndex3;
			public int Offset3;
			public int NumberOfSpheres2;
			public uint Unknown23;
			public uint Unknown24;
			public uint Unknown25;
			public float Sphere0X2;
			public float Sphere0Y2;
			public float Sphere0Z2;
			public float Sphere0Radius2;
			public float Sphere1X2;
			public float Sphere1Y2;
			public float Sphere1Z2;
			public float Sphere1Radius2;
			public float Sphere2X2;
			public float Sphere2Y2;
			public float Sphere2Z2;
			public float Sphere2Radius2;
			public float Sphere3X2;
			public float Sphere3Y2;
			public float Sphere3Z2;
			public float Sphere3Radius2;
			public float Sphere4X2;
			public float Sphere4Y2;
			public float Sphere4Z2;
			public float Sphere4Radius2;
			public float Sphere5X2;
			public float Sphere5Y2;
			public float Sphere5Z2;
			public float Sphere5Radius2;
			public float Sphere6X2;
			public float Sphere6Y2;
			public float Sphere6Z2;
			public float Sphere6Radius2;
			public float Sphere7X2;
			public float Sphere7Y2;
			public float Sphere7Z2;
			public float Sphere7Radius2;
			public int Unknown26;
			public short Size4;
			public short Count4;
			public int OverallShapeIndex4;
			public int Offset4;
			public int NumberOfSpheres3;
			public uint Unknown27;
			public uint Unknown28;
			public uint Unknown29;
			public float Sphere0X3;
			public float Sphere0Y3;
			public float Sphere0Z3;
			public float Sphere0Radius3;
			public float Sphere1X3;
			public float Sphere1Y3;
			public float Sphere1Z3;
			public float Sphere1Radius3;
			public float Sphere2X3;
			public float Sphere2Y3;
			public float Sphere2Z3;
			public float Sphere2Radius3;
			public float Sphere3X3;
			public float Sphere3Y3;
			public float Sphere3Z3;
			public float Sphere3Radius3;
			public float Sphere4X3;
			public float Sphere4Y3;
			public float Sphere4Z3;
			public float Sphere4Radius3;
			public float Sphere5X3;
			public float Sphere5Y3;
			public float Sphere5Z3;
			public float Sphere5Radius3;
			public float Sphere6X3;
			public float Sphere6Y3;
			public float Sphere6Z3;
			public float Sphere6Radius3;
			public float Sphere7X3;
			public float Sphere7Y3;
			public float Sphere7Z3;
			public float Sphere7Radius3;
			public int Unknown30;
			public short Size5;
			public short Count5;
			public int OverallShapeIndex5;
			public int Offset5;
			public int NumberOfSpheres4;
			public uint Unknown31;
			public uint Unknown32;
			public uint Unknown33;
			public float Sphere0X4;
			public float Sphere0Y4;
			public float Sphere0Z4;
			public float Sphere0Radius4;
			public float Sphere1X4;
			public float Sphere1Y4;
			public float Sphere1Z4;
			public float Sphere1Radius4;
			public float Sphere2X4;
			public float Sphere2Y4;
			public float Sphere2Z4;
			public float Sphere2Radius4;
			public float Sphere3X4;
			public float Sphere3Y4;
			public float Sphere3Z4;
			public float Sphere3Radius4;
			public float Sphere4X4;
			public float Sphere4Y4;
			public float Sphere4Z4;
			public float Sphere4Radius4;
			public float Sphere5X4;
			public float Sphere5Y4;
			public float Sphere5Z4;
			public float Sphere5Radius4;
			public float Sphere6X4;
			public float Sphere6Y4;
			public float Sphere6Z4;
			public float Sphere6Radius4;
			public float Sphere7X4;
			public float Sphere7Y4;
			public float Sphere7Z4;
			public float Sphere7Radius4;
			public uint Unknown34;
			public uint Unknown35;
			public uint Unknown36;
			public uint Unknown37;
			public uint Unknown38;
			public uint Unknown39;
			public uint Unknown40;
			public uint Unknown41;
			public uint Unknown42;
			public uint Unknown43;
			public uint Unknown44;
			public uint Unknown45;
			public uint Unknown46;
			public uint Unknown47;
			public uint Unknown48;
			public uint Unknown49;
		}

		public enum PlayerTrainingVehicleTypeValue : sbyte
		{
			None,
			Warthog,
			WarthogTurret,
			Ghost,
			Banshee,
			Tank,
			Wraith,
		}

		public enum VehicleSizeValue : sbyte
		{
			Small,
			Large,
		}
	}
}
