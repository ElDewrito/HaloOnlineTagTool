using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	class InsertCommand : Command
	{
		public InsertCommand() : base(
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
		}

		public override bool Execute(TagCache cache, Stream stream, List<string> args)
		{
			if (args.Count != 3 && args.Count != 4)
				return false;

			uint offset, size;
			var tag = ArgumentParser.ParseTagIndex(cache, args[0]);
			if (tag == null)
				return false;
			if (!uint.TryParse(args[1], NumberStyles.HexNumber, null, out offset))
				return false;
			if (!uint.TryParse(args[2], NumberStyles.HexNumber, null, out size))
				return false;
			var type = InsertType.Before;
			if (args.Count == 4)
			{
				if (args[3] == "after")
					type = InsertType.After;
				else
					return false;
			}
			if (offset > tag.Size)
			{
				Console.Error.WriteLine("Offset cannot be greater than tag size (0x{0:X}).", tag.Size);
				return true;
			}
			cache.ResizeTagData(stream, tag, offset, (int)size, type);
			Console.WriteLine("Inserted 0x{0:X} bytes at offset 0x{1:X}.", size, offset);
			return true;
		}
	}
}
