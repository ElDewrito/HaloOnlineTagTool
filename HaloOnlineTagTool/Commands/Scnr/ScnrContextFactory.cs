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
        public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, Scenario scenario)
        {
            var context = new CommandContext(parent, string.Format("{0:X8}.scnr", tag.Index));
            context.AddCommand(new ScnrCopyForgePaletteCommand(info, scenario));
            return context;
        }
    }
}

