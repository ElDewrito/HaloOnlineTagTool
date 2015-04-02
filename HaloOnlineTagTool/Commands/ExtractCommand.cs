using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	class ExtractCommand : Command
	{
		public ExtractCommand() : base(
			"extract",
			"Extract a tag to a file",
			
			"extract <tag index> <filename>",
			
			"Use the \"import\" command to re-import the tag's data.\n" +
			"Note that the tag's header will not be extracted.\n" +
			"Use other commands to manipulate the tag's header in a safe manner.")
		{
		}

		public override bool Execute(TagCache cache, Stream stream, List<string> args)
		{
			if (args.Count != 2)
				return false;
			var tag = ArgumentParser.ParseTagIndex(cache, args[0]);
			if (tag == null)
				return false;
			var file = args[1];

			var data = cache.ExtractTag(stream, tag);
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
