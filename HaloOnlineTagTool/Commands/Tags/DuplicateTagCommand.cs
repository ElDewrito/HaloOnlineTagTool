using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Tags
{
	class DuplicateTagCommand : Command
	{
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public DuplicateTagCommand(TagCache cache, FileInfo fileInfo) : base(
			CommandFlags.None,

			"duplicate",
			"Create a copy of a tag",

			"duplicate <tag index>",

			"All of the tag's data, including tag blocks, will be copied into a new tag.\n" +
			"The new tag can then be edited independently of the old tag.")
		{
			_cache = cache;
			_fileInfo = fileInfo;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1)
				return false;
			var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
			if (tag == null)
				return false;

			HaloTag newTag;
			using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				newTag = _cache.DuplicateTag(stream, tag);

			Console.WriteLine("Tag duplicated successfully!");
			Console.Write("New tag: ");
			TagPrinter.PrintTagShort(newTag);
			return true;
		}
	}
}
