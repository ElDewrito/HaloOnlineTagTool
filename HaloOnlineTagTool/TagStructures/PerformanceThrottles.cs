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
    [TagStructure(Name = "performance_throttles", Class = "perf", Size = 0x10)]
    public class PerformanceThrottles
    {
        public List<PerformanceBlock> Performance;
        public uint Unknown;

        [TagStructure(Size = 0x38)]
        public class PerformanceBlock
        {
            public uint Flags;
            public float Water;
            public float Decorators;
            public float Effects;
            public float InstancedGeometry;
            public float ObjectFade;
            public float ObjectLod;
            public float Decals;
            public int CpuLightCount;
            public float CpuLightQuality;
            public int GpuLightCount;
            public float GpuLightQuality;
            public int ShadowCount;
            public float ShadowQuality;
        }
    }
}
