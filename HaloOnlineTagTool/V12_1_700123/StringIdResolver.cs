using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.V12_1_700123
{
    /// <summary>
    /// StringID resolver for 12.1.700123.
    /// </summary>
    public class StringIdResolver : StringIdResolverBase
    {
        // These values were figured out through trial-and-error
        private static readonly int[] SetOffsets = { 0x918, 0x1, 0x685, 0x720, 0x7C4, 0x778, 0x7D0, 0x8F3, 0x90B };
        private const int SetMin = 0x1;   // Mininum index that goes in a set
        private const int SetMax = 0xF27; // Maximum index that goes in a set

        public override int GetMinSetStringIndex()
        {
            return SetMin;
        }

        public override int GetMaxSetStringIndex()
        {
            return SetMax;
        }

        public override int[] GetSetOffsets()
        {
            return SetOffsets;
        }
    }
}
