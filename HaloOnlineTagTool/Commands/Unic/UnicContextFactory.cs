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
		public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, MultilingualUnicodeStringList unic)
		{
			var context = new CommandContext(parent, string.Format("{0:X8}.unic", tag.Index));
			if (info.StringIds != null)
			{
				context.AddCommand(new UnicListCommand(info, unic));
				context.AddCommand(new UnicSetCommand(info, tag, unic));
			}
			return context;
		}
	}
}
