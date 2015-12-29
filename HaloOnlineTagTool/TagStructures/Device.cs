using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Class = "devi", Size = 0x98)]
    public class Device : GameObject
    {
        public uint Flags2;
        public float PowerTransitionTime;
        public float PowerAccelerationTime;
        public float PositionTransitionTime;
        public float PositionAccelerationTime;
        public float DepoweredPositionTransitionTime;
        public float DepoweredPositionAccelerationTime;
        public uint LightmapFlags;
        public TagInstance OpenUp;
        public TagInstance CloseDown;
        public TagInstance Opened;
        public TagInstance Closed;
        public TagInstance Depowered;
        public TagInstance Repowered;
        public float DelayTime;
        public TagInstance DelayEffect;
        public float AutomaticActivationRadius;
    }
}
