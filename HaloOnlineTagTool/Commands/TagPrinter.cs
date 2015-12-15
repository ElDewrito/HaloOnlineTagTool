using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloOnlineTagTool.Commands
{
    static class TagPrinter
    {
        public static void PrintTagShort(HaloTag tag)
        {
            Console.WriteLine("{0} {1:X8} [Offset = 0x{2:X}, Size = 0x{3:X}]", tag.GroupTag, tag.Index, tag.DataOffset, tag.DataSize);
        }

        public static void PrintTagsShort(IEnumerable<HaloTag> tags)
        {
            var sorted = tags.ToArray();
            Array.Sort(sorted, CompareTags);
            foreach (var tag in sorted)
                PrintTagShort(tag);
        }

        private static int CompareTags(HaloTag lhs, HaloTag rhs)
        {
            var classCompare = lhs.GroupTag.CompareTo(rhs.GroupTag);
            if (classCompare != 0)
                return classCompare;
            return lhs.Index.CompareTo(rhs.Index);
        }
    }
}
