using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;

namespace HaloOnlineTagTool.Commands.Tags
{
	class InsertCommand : Command
	{
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public InsertCommand(OpenTagCache info) : base(
			CommandFlags.None,

			"insert",
			"Insert data into a tag",
			
			"insert <tag index> <offset> <size> [after]",
			
			"The tag will be resized and zeroes will be inserted into the tag at the given\n" +
			"offset.\n" +
			"\n" +
			"If \"after\" is not specified, then any pointers to the insertion offset will be\n" +
			"adjusted. Useful for inserting data at the end of a tag or tag block.\n" +
			"\n" +
			"If \"after\" is specified, then any pointers to the insertion offset will NOT be\n" +
			"adjusted. Useful for inserting data at the beginning of a tag or tag block.")
		{
			_cache = info.Cache;
			_fileInfo = info.CacheFile;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 3 && args.Count != 4)
				return false;

			uint offset, size;
			var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
			if (tag == null)
				return false;
			if (!uint.TryParse(args[1], NumberStyles.HexNumber, null, out offset))
				return false;
			if (!uint.TryParse(args[2], NumberStyles.HexNumber, null, out size))
				return false;
			var type = InsertOrigin.Before;
			if (args.Count == 4)
			{
				if (args[3] == "after")
					type = InsertOrigin.After;
				else
					return false;
			}
			if (offset > tag.Size)
			{
				Console.Error.WriteLine("Offset cannot be greater than tag size (0x{0:X}).", tag.Size);
				return true;
			}
			using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				_cache.InsertTagData(stream, tag, offset, (int)size, type);
			Console.WriteLine("Inserted 0x{0:X} bytes at offset 0x{1:X}.", size, offset);
			return true;
		}
	}
}
