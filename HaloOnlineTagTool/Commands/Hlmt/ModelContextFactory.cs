using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Hlmt
{
    static class ModelContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, TagStructures.Model model)
        {
            var groupName = info.StringIds.GetString(tag.GroupName);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            context.AddCommand(new HlmtListVariantsCommand(info, model));
            context.AddCommand(new HlmtExtractModeCommand(info, model));

            return context;
        }
    }
}
