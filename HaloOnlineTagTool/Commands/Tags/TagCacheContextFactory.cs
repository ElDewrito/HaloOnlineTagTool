using System.IO;
using HaloOnlineTagTool.Commands.Core;

namespace HaloOnlineTagTool.Commands.Tags
{
	static class TagCacheContextFactory
	{
		public static CommandContext Create(CommandContextStack stack, TagCache cache, FileInfo fileInfo)
		{
			var context = new CommandContext(null, fileInfo.Name);
			context.AddCommand(new HelpCommand(stack));
			context.AddCommand(new DependencyCommand(cache, fileInfo));
			context.AddCommand(new FixupCommand(cache, fileInfo));
			context.AddCommand(new ExtractCommand(cache, fileInfo));
			context.AddCommand(new ImportCommand(cache, fileInfo));
			context.AddCommand(new InfoCommand(cache));
			context.AddCommand(new InsertCommand(cache, fileInfo));
			context.AddCommand(new ListCommand(cache));
			context.AddCommand(new MapCommand());
			context.AddCommand(new EditCommand(stack, cache, fileInfo));
			return context;
		}
	}
}
