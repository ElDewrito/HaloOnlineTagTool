using System.IO;
using HaloOnlineTagTool.Commands.Core;

namespace HaloOnlineTagTool.Commands.Tags
{
	static class TagCacheContextFactory
	{
		public static CommandContext Create(CommandContextStack stack, TagCache cache, Stream stream, string path)
		{
			var context = new CommandContext(null, Path.GetFileName(path));
			context.AddCommand(new HelpCommand(stack));
			context.AddCommand(new DependencyCommand(cache, stream));
			context.AddCommand(new ExtractCommand(cache, stream));
			context.AddCommand(new ImportCommand(cache, stream));
			context.AddCommand(new InfoCommand(cache));
			context.AddCommand(new InsertCommand(cache, stream));
			context.AddCommand(new ListCommand(cache));
			context.AddCommand(new MapCommand());
			return context;
		}
	}
}
