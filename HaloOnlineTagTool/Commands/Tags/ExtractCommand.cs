using System;
using System.Collections.Generic;
using System.IO;

namespace HaloOnlineTagTool.Commands.Tags
{
	class ExtractCommand : Command
	{
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public ExtractCommand(TagCache cache, FileInfo fileInfo) : base(
			CommandFlags.Inherit,

			"extract",
			"Extract a tag to a file",
			
			"extract <tag index> <filename>",
			
			"Use the \"import\" command to re-import the tag's data.\n" +
			"Note that the tag's header will not be extracted.\n" +
			"Use other commands to manipulate the tag's header in a safe manner.")
		{
			_cache = cache;
			_fileInfo = fileInfo;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 2)
				return false;
			var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
			if (tag == null)
				return false;
			var file = args[1];

			byte[] data;
			using (var stream = _fileInfo.OpenRead())
				data = _cache.ExtractTag(stream, tag);
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
