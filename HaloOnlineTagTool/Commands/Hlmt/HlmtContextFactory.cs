using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Hlmt
{
	static class HlmtContextFactory
	{
        public static void Populate(CommandContext context, OpenTagCache info, HaloTag tag, Model model)
        {
            context.AddCommand(new HlmtListVariantsCommand(info, model));
            context.AddCommand(new HlmtExtractModeCommand(info, model));
        }
	}
}
