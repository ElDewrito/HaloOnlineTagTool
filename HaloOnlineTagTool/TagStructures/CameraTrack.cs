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
    [TagStructure(Name = "camera_track", Class = "trak", Size = 0x14)]
    public class CameraTrack
    {
        public uint Unknown;
        public List<CameraPoint> CameraPoints;
        public uint Unknown2;

        [TagStructure(Size = 0x1C)]
        public class CameraPoint
        {
            public float PositionI;
            public float PositionJ;
            public float PositionK;
            public float OrientationI;
            public float OrientationJ;
            public float OrientationK;
            public float OrientationW;
        }
    }
}
