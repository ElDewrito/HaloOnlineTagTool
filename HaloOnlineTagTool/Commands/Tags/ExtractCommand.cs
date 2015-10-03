using System;
using System.Collections.Generic;
using System.IO;

namespace HaloOnlineTagTool.Commands.Tags
{
	class ExtractCommand : Command
	{
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public ExtractCommand(OpenTagCache info) : base(
			CommandFlags.Inherit,

			"extract",
			"Extract a tag to a file",
			
			"extract <tag index> <filename> [full]",
			
			"Use the \"import\" command to re-import the tag's data.\n" +
			"\n" +
			"If the \"full\" option is specified, the tag's header will be included.\n" +
			"To import a full tag, you must pass \"full\" when you re-import the tag.")
		{
			_cache = info.Cache;
			_fileInfo = info.CacheFile;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 2 && args.Count != 3)
				return false;
			var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
			if (tag == null)
				return false;
			var file = args[1];
			var full = false;
			if (args.Count == 3)
			{
				if (args[2] == "full")
					full = true;
				else
					return false;
			}

			byte[] data;
			using (var stream = _fileInfo.OpenRead())
				data = full ? _cache.ExtractTagWithHeader(stream, tag) : _cache.ExtractTag(stream, tag);
			using (var outStream = File.Open(file, FileMode.Create, FileAccess.Write))
			{
				outStream.Write(data, 0, data.Length);
				Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", outStream.Position, file);
				Console.WriteLine("The tag's main struct will be at offset 0x{0:X}.", tag.MainStructOffset);
			}
			return true;
		}
	}
}
