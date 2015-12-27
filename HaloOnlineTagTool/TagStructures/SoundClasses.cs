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
    [TagStructure(Name = "sound_classes", Class = "sncl", Size = 0x10)]
    public class SoundClasses
    {
        public List<UnknownBlock> Unknown;
        public uint Unknown2;

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
            public uint Unknown16;
            public uint Unknown17;
            public uint Unknown18;
            public uint Unknown19;
            public uint Unknown20;
            public uint Unknown21;
            public uint Unknown22;
            public uint UnknowndoplerFactor;
            public StereoPlaybackTypeValue StereoPlaybackType;
            public sbyte Unknown23;
            public sbyte Unknown24;
            public sbyte Unknown25;
            public float TransmissionMultiplier;
            public float ObstructionMaxBend;
            public float OcclusionMaxBend;
            public int Unknown26;
            public uint Unknown27;

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
