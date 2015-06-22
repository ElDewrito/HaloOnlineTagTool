using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Bitm
{
	static class BitmContextFactory
	{
		public static CommandContext Create(CommandContext parent, FileInfo fileInfo, TagCache cache, HaloTag tag, Bitmap bitmap)
		{
			var context = new CommandContext(parent, string.Format("{0:X8}.bitm", tag.Index));
			context.AddCommand(new BitmImportCommand(fileInfo, cache, tag, bitmap));
			return context;
		}
	}
}
