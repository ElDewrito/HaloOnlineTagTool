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
		public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, Model model)
		{
			var context = new CommandContext(parent, string.Format("{0:X8}.hlmt", tag.Index));
			context.AddCommand(new HlmtListVariantsCommand(info, model));
			context.AddCommand(new HlmtExtractModeCommand(info, model));
			return context;
		}
	}
}
