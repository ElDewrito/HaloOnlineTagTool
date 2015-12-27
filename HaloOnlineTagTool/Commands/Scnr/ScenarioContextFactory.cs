using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Scnr
{
    static class ScnrContextFactory
    {
        public static void Populate(CommandContext context, OpenTagCache info, HaloTag tag, Scenario scenario)
        {
            context.AddCommand(new CopyForgePaletteCommand(info, scenario));
        }
    }
}

