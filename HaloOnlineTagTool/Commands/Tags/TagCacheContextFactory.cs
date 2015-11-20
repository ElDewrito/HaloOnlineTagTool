using System.IO;
using HaloOnlineTagTool.Commands.Core;

namespace HaloOnlineTagTool.Commands.Tags
{
	static class TagCacheContextFactory
	{
		public static CommandContext Create(CommandContextStack stack, OpenTagCache info)
		{
			var context = new CommandContext(null, info.CacheFile.Name);
			context.AddCommand(new HelpCommand(stack));
			context.AddCommand(new DependencyCommand(info));
			context.AddCommand(new FixupCommand(info));
			context.AddCommand(new ExtractCommand(info));
			context.AddCommand(new ImportCommand(info));
			context.AddCommand(new InfoCommand(info));
			context.AddCommand(new InsertCommand(info));
			context.AddCommand(new ListCommand(info));
			context.AddCommand(new MapCommand());
			context.AddCommand(new EditCommand(stack, info));
			context.AddCommand(new DuplicateTagCommand(info));
			context.AddCommand(new AddressCommand());
			context.AddCommand(new ExtractBitmapsCommand(info));
			context.AddCommand(new ResourceDataCommand());
			context.AddCommand(new TagBlockCommand(info));
			context.AddCommand(new ImportBitmapCommand(info));
			context.AddCommand(new PhysicsModelTestCommand(info));
			context.AddCommand(new MatchTagsCommand(info));
			if (info.StringIds != null)
			{
				context.AddCommand(new StringIdCommand(info));
				context.AddCommand(new ListStringsCommand(info));
				context.AddCommand(new GenerateLayoutsCommand(info));
				context.AddCommand(new ModelTestCommand(info));
				context.AddCommand(new ConvertPluginsCommand(info));
			}
			return context;
		}
	}
}
