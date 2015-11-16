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
	[TagStructure(Class = "effe", Size = 0x68)]
	public class Effect
	{
		public uint Flags;
		public int Unknown;
		public float Unknown2;
		public uint Unknown3;
		public float Unknown4;
		public sbyte Unknown5;
		public sbyte Unknown6;
		public sbyte Unknown7;
		public sbyte Unknown8;
		public short LoopStartEvent;
		public short Unknown9;
		public uint Unknown10;
		public List<Location> Locations;
		public List<Event> Events;
		public HaloTag LoopingSound;
		public sbyte LocationIndex;
		public sbyte EventIndex;
		public short Unknown11;
		public float AlwaysPlayDistance;
		public float NeverPlayDistance;
		public float Unknown12;
		public float Unknown13;
		public List<UnknownBlock> Unknown14;

		[TagStructure(Size = 0xC)]
		public class Location
		{
			public StringId MarkerName;
			public int Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public sbyte Unknown5;
		}

		[TagStructure(Size = 0x44)]
		public class Event
		{
			public StringId Name;
			public int Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public float SkipFraction;
			public float DelayBoundsMin;
			public float DelayBoundsMax;
			public float DurationBoundsMin;
			public float DurationBoundsMax;
			public List<Part> Parts;
			public List<Acceleration> Accelerations;
			public List<ParticleSystem> ParticleSystems;

			[TagStructure(Size = 0x60)]
			public class Part
			{
				public CreateInEnvironmentValue CreateInEnvironment;
				public CreateInDispositionValue CreateInDisposition;
				public short LocationIndex;
				public short Unknown;
				public short Unknown2;
				public sbyte Unknown3;
				public CameraModeValue CameraMode;
				[TagField(Length = 4)] public string AnticipatedTagClass;
				public HaloTag SpawnedTag;
				public float VelocityBoundsMin;
				public float VelocityBoundsMax;
				public uint Unknown4;
				public uint Unknown5;
				public Angle VelocityConeAngle;
				public Angle AngularVelocityBoundsMin;
				public Angle AngularVelocityBoundsMax;
				public float RadiusModifierBoundsMin;
				public float RadiusModifierBoundsMax;
				public float OriginOffsetX;
				public float OriginOffsetY;
				public float OriginOffsetZ;
				public Angle OriginRotationI;
				public Angle OriginRotationJ;
				public uint AScalesValues;
				public uint BScalesValues;

				public enum CreateInEnvironmentValue : short
				{
					AnyEnvironment,
					AirOnly,
					WaterOnly,
					SpaceOnly,
				}

				public enum CreateInDispositionValue : short
				{
					EitherMode,
					ViolentModeOnly,
					NonviolentModeOnly,
				}

				public enum CameraModeValue : sbyte
				{
					IndependentOfCameraMode,
					FirstPersonOnly,
					ThirdPersonOnly,
					BothFirstAndThird,
				}
			}

			[TagStructure(Size = 0x14)]
			public class Acceleration
			{
				public CreateInEnvironmentValue CreateInEnvironment;
				public CreateInDispositionValue CreateInDisposition;
				public short LocationIndex;
				public short Unknown;
				public float Acceleration2;
				public float InnerConeAngle;
				public float OuterConeAngle;

				public enum CreateInEnvironmentValue : short
				{
					AnyEnvironment,
					AirOnly,
					WaterOnly,
					SpaceOnly,
				}

				public enum CreateInDispositionValue : short
				{
					EitherMode,
					ViolentModeOnly,
					NonviolentModeOnly,
				}
			}

			[TagStructure(Size = 0x5C)]
			public class ParticleSystem
			{
				public sbyte Unknown;
				public sbyte Unknown2;
				public sbyte Unknown3;
				public sbyte Unknown4;
				public HaloTag Particle;
				public short Unknown5;
				public short LocationIndex;
				public CoordinateSystemValue CoordinateSystem;
				public EnvironmentValue Environment;
				public DispositionValue Disposition;
				public CameraModeValue CameraMode;
				public short SortBias;
				public ushort Flags;
				public float Unknown6;
				public float Unknown7;
				public float Unknown8;
				public float Unknown9;
				public uint Unknown10;
				public float Unknown11;
				public float AmountSize;
				public float Unknown12;
				public float LodInDistance;
				public float LodFeatherInDelta;
				public List<Emitter> Emitters;
				public uint Unknown13;

				public enum CoordinateSystemValue : short
				{
					World,
					Local,
					Parent,
				}

				public enum EnvironmentValue : short
				{
					AnyEnvironment,
					AirOnly,
					WaterOnly,
					SpaceOnly,
				}

				public enum DispositionValue : short
				{
					EitherMode,
					ViolentModeOnly,
					NonviolentModeOnly,
				}

				public enum CameraModeValue : short
				{
					IndependentOfCameraMode,
					FirstPersonOnly,
					ThirdPersonOnly,
					BothFirstAndThird,
				}

				[TagStructure(Size = 0x300)]
				public class Emitter
				{
					public StringId Name;
					public ushort Unknown;
					public short Unknown2;
					public HaloTag CustomEmitterPoints;
					public uint Unknown3;
					public uint Unknown4;
					public uint Unknown5;
					public uint Unknown6;
					public sbyte Input;
					public sbyte InputRange;
					public OutputKindValue OutputKind;
					public sbyte Output;
					public byte[] Unknown7;
					public uint Unknown8;
					public uint Unknown9;
					public uint Unknown10;
					public uint Unknown11;
					public uint Unknown12;
					public uint Unknown13;
					public uint Unknown14;
					public uint Unknown15;
					public sbyte Input2;
					public sbyte InputRange2;
					public OutputKindValue2 OutputKind2;
					public sbyte Output2;
					public byte[] Unknown16;
					public uint Unknown17;
					public uint Unknown18;
					public uint Unknown19;
					public uint Unknown20;
					public uint Unknown21;
					public uint Unknown22;
					public uint Unknown23;
					public uint Unknown24;
					public sbyte Input3;
					public sbyte InputRange3;
					public OutputKindValue3 OutputKind3;
					public sbyte Output3;
					public byte[] Unknown25;
					public uint Unknown26;
					public uint Unknown27;
					public sbyte Input4;
					public sbyte InputRange4;
					public OutputKindValue4 OutputKind4;
					public sbyte Output4;
					public byte[] Unknown28;
					public uint Unknown29;
					public uint Unknown30;
					public sbyte Input5;
					public sbyte InputRange5;
					public OutputKindValue5 OutputKind5;
					public sbyte Output5;
					public byte[] Unknown31;
					public uint Unknown32;
					public uint Unknown33;
					public sbyte Input6;
					public sbyte InputRange6;
					public OutputKindValue6 OutputKind6;
					public sbyte Output6;
					public byte[] Unknown34;
					public uint Unknown35;
					public uint Unknown36;
					public sbyte Input7;
					public sbyte InputRange7;
					public OutputKindValue7 OutputKind7;
					public sbyte Output7;
					public byte[] Unknown37;
					public uint Unknown38;
					public uint Unknown39;
					public sbyte Input8;
					public sbyte InputRange8;
					public OutputKindValue8 OutputKind8;
					public sbyte Output8;
					public byte[] Unknown40;
					public uint Unknown41;
					public uint Unknown42;
					public sbyte Input9;
					public sbyte InputRange9;
					public OutputKindValue9 OutputKind9;
					public sbyte Output9;
					public byte[] Unknown43;
					public uint Unknown44;
					public uint Unknown45;
					public HaloTag ParticlePhysics;
					public uint Unknown46;
					public List<UnknownBlock> Unknown47;
					public sbyte Input10;
					public sbyte InputRange10;
					public OutputKindValue10 OutputKind10;
					public sbyte Output10;
					public byte[] Unknown48;
					public uint Unknown49;
					public uint Unknown50;
					public uint Unknown51;
					public uint Unknown52;
					public uint Unknown53;
					public uint Unknown54;
					public uint Unknown55;
					public uint Unknown56;
					public sbyte Input11;
					public sbyte InputRange11;
					public OutputKindValue11 OutputKind11;
					public sbyte Output11;
					public byte[] Unknown57;
					public uint Unknown58;
					public uint Unknown59;
					public sbyte Input12;
					public sbyte InputRange12;
					public OutputKindValue12 OutputKind12;
					public sbyte Output12;
					public byte[] Unknown60;
					public uint Unknown61;
					public uint Unknown62;
					public sbyte Input13;
					public sbyte InputRange13;
					public OutputKindValue13 OutputKind13;
					public sbyte Output13;
					public byte[] Unknown63;
					public uint Unknown64;
					public uint Unknown65;
					public sbyte Input14;
					public sbyte InputRange14;
					public OutputKindValue14 OutputKind14;
					public sbyte Output14;
					public byte[] Unknown66;
					public uint Unknown67;
					public uint Unknown68;
					public sbyte Input15;
					public sbyte InputRange15;
					public OutputKindValue15 OutputKind15;
					public sbyte Output15;
					public byte[] ParticleScale;
					public uint Unknown69;
					public uint Unknown70;
					public sbyte Input16;
					public sbyte InputRange16;
					public OutputKindValue16 OutputKind16;
					public sbyte Output16;
					public byte[] ParticleTint;
					public uint Unknown71;
					public uint Unknown72;
					public sbyte Input17;
					public sbyte InputRange17;
					public OutputKindValue17 OutputKind17;
					public sbyte Output17;
					public byte[] ParticleAlpha;
					public uint Unknown73;
					public uint Unknown74;
					public sbyte Input18;
					public sbyte InputRange18;
					public OutputKindValue18 OutputKind18;
					public sbyte Output18;
					public byte[] ParticleAlphaBlackPoint;
					public uint Unknown75;
					public uint Unknown76;
					public int Unknown77;
					public int Unknown78;
					public int Unknown79;
					public List<UnknownBlock2> Unknown80;
					public List<CompiledFunction> CompiledFunctions;
					public List<CompiledColorValue> CompiledColorValues;

					public enum OutputKindValue : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue2 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue3 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue4 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue5 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue6 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue7 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue8 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue9 : sbyte
					{
						None,
						Plus,
						Times,
					}

					[TagStructure(Size = 0x18)]
					public class UnknownBlock
					{
						public uint Unknown;
						public List<UnknownBlock2> Unknown2;
						public uint Unknown3;
						public uint Unknown4;

						[TagStructure(Size = 0x24)]
						public class UnknownBlock2
						{
							public uint Unknown;
							public sbyte Input;
							public sbyte InputRange;
							public OutputKindValue OutputKind;
							public sbyte Output;
							public byte[] Unknown2;
							public uint Unknown3;
							public uint Unknown4;

							public enum OutputKindValue : sbyte
							{
								None,
								Plus,
								Times,
							}
						}
					}

					public enum OutputKindValue10 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue11 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue12 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue13 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue14 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue15 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue16 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue17 : sbyte
					{
						None,
						Plus,
						Times,
					}

					public enum OutputKindValue18 : sbyte
					{
						None,
						Plus,
						Times,
					}

					[TagStructure(Size = 0x10)]
					public class UnknownBlock2
					{
						public uint Unknown;
						public uint Unknown2;
						public uint Unknown3;
						public uint Unknown4;
					}

					[TagStructure(Size = 0x40)]
					public class CompiledFunction
					{
						public uint Unknown;
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
						public uint Unknown13;
						public uint Unknown14;
						public uint Unknown15;
						public uint Unknown16;
					}

					[TagStructure(Size = 0x10)]
					public class CompiledColorValue
					{
						public float Red;
						public float Green;
						public float Blue;
						public float Magnitude;
					}
				}
			}
		}

		[TagStructure(Size = 0xC)]
		public class UnknownBlock
		{
			public uint Unknown;
			public uint Unknown2;
			public uint Unknown3;
		}
	}
}
