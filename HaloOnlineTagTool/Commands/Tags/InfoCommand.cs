using System;
using System.Collections.Generic;

namespace HaloOnlineTagTool.Commands.Tags
{
	class InfoCommand : Command
	{
		private readonly TagCache _cache;

		public InfoCommand(TagCache cache) : base(
			CommandFlags.Inherit,

			"info",
			"Get information about a tag",

			"info <tag index>",

			"Displays detailed information about a tag.")
		{
			_cache = cache;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1)
				return false;
			var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
			if (tag == null)
				return false;

			Console.WriteLine("Information for tag {0:X8}:", tag.Index);
			Console.Write("- Classes: {0}", tag.Class);
			if (tag.ParentClass.Value != -1)
				Console.Write(" -> {0}", tag.ParentClass);
			if (tag.GrandparentClass.Value != -1)
				Console.Write(" -> {0}", tag.GrandparentClass);
			Console.WriteLine();
			Console.WriteLine("- Data offset (after header): 0x{0:X}", tag.Offset);
			Console.WriteLine("- Data size (without header): 0x{0:X}", tag.Size);
			Console.WriteLine("- Main struct offset (relative to data offset): 0x{0:X}", tag.MainStructOffset);
			Console.WriteLine();
			Console.WriteLine("Use \"dep list {0:X}\" to list this tag's dependencies.", tag.Index);
			return true;
		}
	}
}
