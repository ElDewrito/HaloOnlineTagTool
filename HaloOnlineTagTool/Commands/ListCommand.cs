using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	class ListCommand : Command
	{
		public ListCommand() : base(
			"list",
			"List tags",
			
			"list [class...]",
			
			"class is a 4-character string identifying the tag class, e.g. \"proj\".\n" +
			"Multiple classes to list tags from can be specified.\n" +
			"Tags which inherit from the given classes will also be printed.\n" +
			"If no class is specified, all tags in the file will be listed.")
		{
		}

		public override bool Execute(TagCache cache, Stream stream, List<string> args)
		{
			var searchClasses = ArgumentParser.ParseTagClasses(cache, args);
			if (searchClasses == null)
				return false;

			HaloTag[] tags;
			if (args.Count > 0)
				tags = cache.Tags.FindAllByClasses(searchClasses).ToArray();
			else
				tags = cache.Tags.Where(t => t != null).ToArray();

			if (tags.Length == 0)
			{
				Console.Error.WriteLine("No tags found.");
				return true;
			}
			TagPrinter.PrintTagsShort(tags);
			return true;
		}
	}
}
