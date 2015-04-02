using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	/// <summary>
	/// Command for managing tag dependencies.
	/// </summary>
	class DependencyCommand : Command
	{
		public DependencyCommand() : base(
			"dep",
			"Manage tag loading",
			
			"dep add <tag index> <dependency index...>\n" +
			"dep remove <tag index> <dependency index...>\n" +
			"dep list <tag index>\n" +
			"dep listall <tag index>",

			"\"dep add\" will cause the first tag to load the other tags.\n" +
			"\"dep remove\" will prevent the first tag from loading the other tags.\n" +
			"\"dep list\" will list all immediate dependencies of a tag.\n" +
			"\"dep listall\" will recursively list all dependencies of a tag.\n" +
			"\n" +
			"To add dependencies to a map, use the \"map\" command to get its scenario tag\n" +
			"index and then add dependencies to the scenario tag.")
		{
		}

		public override bool Execute(TagCache cache, Stream stream, List<string> args)
		{
			if (args.Count < 2)
				return false;
			var tag = ArgumentParser.ParseTagIndex(cache, args[1]);
			if (tag == null)
				return false;

			switch (args[0])
			{
				case "add":
				case "remove":
					return ExecuteAddRemove(cache, stream, tag, args);
				case "list":
				case "listall":
					return ExecuteList(cache, stream, tag, (args[0] == "listall"));
				default:
					return false;
			}
		}

		private static bool ExecuteAddRemove(TagCache cache, Stream stream, HaloTag tag, List<string> args)
		{
			if (args.Count < 3)
				return false;
			var dependencies = args.Skip(2).Select(a => ArgumentParser.ParseTagIndex(cache, a)).ToList();
			if (dependencies.Count == 0 || dependencies.Any(d => d == null))
				return false;
			if (args[0] == "add")
			{
				foreach (var dependency in dependencies)
				{
					if (tag.Dependencies.Add(dependency.Index))
						Console.WriteLine("Added dependency on tag {0:X8}.", dependency.Index);
					else
						Console.Error.WriteLine("Tag {0:X8} already depends on tag {1:X8}.", tag.Index, dependency.Index);
				}
				cache.UpdateTag(stream, tag);
			}
			else
			{
				foreach (var dependency in dependencies)
				{
					if (tag.Dependencies.Remove(dependency.Index))
						Console.WriteLine("Removed dependency on tag {0:X8}.", dependency.Index);
					else
						Console.Error.WriteLine("Tag {0:X8} does not depend on tag {1:X8}.", tag.Index, dependency.Index);
				}
				cache.UpdateTag(stream, tag);
			}
			return true;
		}

		private static bool ExecuteList(TagCache cache, Stream stream, HaloTag tag, bool all)
		{
			if (tag.Dependencies.Count == 0)
			{
				Console.Error.WriteLine("Tag {0:X8} has no dependencies.", tag.Index);
				return true;
			}
			IEnumerable<HaloTag> dependencies;
			if (all)
				dependencies = cache.Tags.FindDependencies(tag);
			else
				dependencies = tag.Dependencies.Where(i => cache.Tags.Contains(i)).Select(i => cache.Tags[i]);
			TagPrinter.PrintTagsShort(dependencies);
			return true;
		}
	}
}
