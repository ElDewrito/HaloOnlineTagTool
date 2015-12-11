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
	static class MultilingualUnicodeStringListContextFactory
	{
		public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, MultilingualUnicodeStringList unic)
        {
            var groupName = info.StringIds.GetString(tag.GroupName);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            if (info.StringIds != null)
			{
				context.AddCommand(new UnicListCommand(info, unic));
				context.AddCommand(new UnicSetCommand(info, tag, unic));
			}
			return context;
		}
	}
}
