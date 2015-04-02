using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	class ImportCommand : Command
	{
		public ImportCommand() : base(
			"import",
			"Import a tag from a file",
			
			"import <tag index> <filename>",
			
			"The data must have been previously extracted with the \"extract\" command.\n" +
			"If the data is too large, the tag will be expanded as necessary.")
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

			byte[] data;
			using (var inStream = File.OpenRead(file))
			{
				data = new byte[inStream.Length];
				inStream.Read(data, 0, data.Length);
			}
			cache.OverwriteTag(stream, tag, data);
			Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
			return true;
		}
	}
}
