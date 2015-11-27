using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Bitm
{
	static class BitmapContextFactory
	{
		public static CommandContext Create(CommandContext parent, OpenTagCache info, HaloTag tag, TagStructures.Bitmap bitmap)
        {
            var groupName = info.StringIds.GetString(tag.GroupName);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));
            
			context.AddCommand(new BitmImportCommand(info, tag, bitmap));
			return context;
		}
	}
}
