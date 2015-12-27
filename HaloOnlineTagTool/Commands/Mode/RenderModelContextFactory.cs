using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Mode
{
    static class RenderModelContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, RenderModel renderModel)
        {
            var groupName = info.StringIds.GetString(tag.GroupName);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            context.AddCommand(new SpecifyShadersCommand(info, tag, renderModel));

            return context;
        }
    }
}
