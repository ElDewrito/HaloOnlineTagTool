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
    [TagStructure(Name = "crate", Class = "bloc", Size = 0x14)]
    public class Crate : GameObject
    {
        public ushort Flags2;
        public short Unknown6;
        public List<MetagameProperty> MetagameProperties;
        public sbyte Unknown7;
        public sbyte Unknown8;
        public sbyte Unknown9;
        public sbyte Unknown10;

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
