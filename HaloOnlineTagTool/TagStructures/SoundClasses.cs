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
	[TagStructure(Class = "sncl", Size = 0x10)]
	public class SoundClasses
	{
		public List<UnknownBlock> Unknown;
		public float Unknown2;

		[TagStructure(Size = 0xA0)]
		public class UnknownBlock
		{
			public short MaxSoundsPerTag;
			public short MaxSoundsPerObject;
			public int PreemptionTime;
			public ushort InternalFlags;
			public ushort Flags;
			public short Priority;
			public CacheMissModeValue CacheMissMode;
			public sbyte Unknown;
			public sbyte Unknown2;
			public sbyte Unknown3;
			public sbyte Unknown4;
			public sbyte Unknown5;
			public float ReverbGain;
			public float Unknown6;
			public float Unknown7;
			public float Unknown8;
			public float Unknown9;
			public float Unknown10;
			public float Unknown11;
			public float Unknown12;
			public float Unknown13;
			public float Unknown14;
			public float Unknown15;
			public float DistanceBoundsMin;
			public float DistanceBoundsMax;
			public float GainBoundsMin;
			public float GainBoundsMax;
			public float CutsceneDucking;
			public float CutsceneDuckingFadeInTime;
			public float CutsceneDuckingSustain;
			public float CutsceneDuckingFadeOutTime;
			public float ScriptedDialogDucking;
			public float ScriptedDialogDuckingFadeIn;
			public float Unknown16;
			public float Unknown17;
			public float Unknown18;
			public float Unknown19;
			public float Unknown20;
			public float Unknown21;
			public float Unknown22;
			public float UnknowndoplerFactor;
			public StereoPlaybackTypeValue StereoPlaybackType;
			public sbyte Unknown23;
			public sbyte Unknown24;
			public sbyte Unknown25;
			public float TransmissionMultiplier;
			public float ObstructionMaxBend;
			public float OcclusionMaxBend;
			public int Unknown26;
			public float Unknown27;

			public enum CacheMissModeValue : sbyte
			{
				Discard,
				Postpone,
			}

			public enum StereoPlaybackTypeValue : sbyte
			{
				FirstPerson,
				Ambient,
			}
		}
	}
}
