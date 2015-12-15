using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Unic
{
    static class UnicContextFactory
    {
        public static void Populate(CommandContext context, OpenTagCache info, HaloTag tag, MultilingualUnicodeStringList unic)
        {
            if (info.StringIds == null)
                return;

            context.AddCommand(new UnicListCommand(info, unic));
            context.AddCommand(new UnicSetCommand(info, tag, unic));
        }
    }
}
