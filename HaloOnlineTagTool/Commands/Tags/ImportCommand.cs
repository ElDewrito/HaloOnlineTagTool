using System;
using System.Collections.Generic;
using System.IO;

namespace HaloOnlineTagTool.Commands.Tags
{
	class ImportCommand : Command
	{
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public ImportCommand(TagCache cache, FileInfo _fileInfo) : base(
			CommandFlags.None,

			"import",
			"Import a tag from a file",
			
			"import <tag index> <filename>",
			
			"The data must have been previously extracted with the \"extract\" command.\n" +
			"If the data is too large, the tag will be expanded as necessary.")
		{
			_cache = cache;
			this._fileInfo = _fileInfo;
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
			using (var inStream = File.OpenRead(file))
			{
				data = new byte[inStream.Length];
				inStream.Read(data, 0, data.Length);
			}
			using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				_cache.OverwriteTag(stream, tag, data);
			Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
			return true;
		}
	}
}
