using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Rmsh
{
    static class RmshContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, Shader shader)
        {
            var context = new CommandContext(parent, string.Format("{0:X8}.scnr", tag.Index));
            context.AddCommand(new RmshSpecifyBitmapsCommand(info, tag, shader));
            return context;
        }
    }
}

