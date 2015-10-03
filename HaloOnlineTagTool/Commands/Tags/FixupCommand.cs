using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Tags
{
	// TODO: Add support for resource fixups

	class FixupCommand : Command
	{
		private readonly TagCache _cache;
		private readonly FileInfo _fileInfo;

		public FixupCommand(OpenTagCache info) : base(
			CommandFlags.None,

			"fixup",
			"Edit tag fixups",

			"fixup add <tag index> <write offset> <target offset>\n" +
			"fixup remove <tag index> <write offset>\n" +
			"fixup list <tag index>",

			"\"fixup add\" will make the first offset point to the second offset.\n" +
			"\"fixup remove\" will remove the fixup at an offset.\n" +
			"\"fixup list\" will list all fixups in a tag.\n" +
			"\n" +
			"Any time you manually add a new tag block or data reference to a tag,\n" +
			"you need a fixup where the game expects a memory address.\n" +
			"\n" +
			"Offsets are relative to the start of the tag data, NOT the header.")
		{
			_cache = info.Cache;
			_fileInfo = info.CacheFile;
		}
		
		public override bool Execute(List<string> args)
		{
			if (args.Count < 2)
				return false;
			var tag = ArgumentParser.ParseTagIndex(_cache, args[1]);
			if (tag == null)
				return false;

			switch (args[0])
			{
				case "add":
					return ExecuteAdd(tag, args);
				case "remove":
					return ExecuteRemove(tag, args);
				case "list":
					return ExecuteList(tag, args);
				default:
					return false;
			}
		}

		private bool ExecuteAdd(HaloTag tag, List<string> args)
		{
			if (args.Count != 4)
				return false;
			uint writeOffset, targetOffset;
			if (!uint.TryParse(args[2], NumberStyles.HexNumber, null, out writeOffset))
				return false;
			if (!uint.TryParse(args[3], NumberStyles.HexNumber, null, out targetOffset))
				return false;
			if (!CheckWriteOffset(tag, writeOffset))
				return true;
			if (!CheckTargetOffset(tag, targetOffset))
				return true;
			
			// Create a new fixup if there isn't one, otherwise overwrite it
			var fixup = tag.DataFixups.FirstOrDefault(f => f.WriteOffset == writeOffset);
			if (fixup == null)
			{
				fixup = new TagFixup();
				tag.DataFixups.Add(fixup);
			}
			fixup.WriteOffset = writeOffset;
			fixup.TargetOffset = targetOffset;

			// Update the tag
			using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				_cache.UpdateTag(stream, tag);

			Console.WriteLine("Added fixup at offset 0x{0:X} to 0x{1:X}.", writeOffset, targetOffset);
			return true;
		}

		private bool ExecuteRemove(HaloTag tag, List<string> args)
		{
			if (args.Count != 3)
				return false;
			uint writeOffset;
			if (!uint.TryParse(args[2], NumberStyles.HexNumber, null, out writeOffset))
				return false;
			if (!CheckWriteOffset(tag, writeOffset))
				return true;

			for (var i = 0; i < tag.DataFixups.Count; i++)
			{
				if (tag.DataFixups[i].WriteOffset != writeOffset)
					continue;

				// Remove the fixup and then open a stream and write a null pointer at the offset
				tag.DataFixups.RemoveAt(i);
				using (var writer = new BinaryWriter(_fileInfo.Open(FileMode.Open, FileAccess.ReadWrite)))
				{
					writer.BaseStream.Position = tag.Offset + writeOffset;
					writer.Write(0);
					_cache.UpdateTag(writer.BaseStream, tag);
				}

				Console.WriteLine("Removed fixup at offset 0x{0:X}.", writeOffset);
				return true;
			}
			Console.Error.WriteLine("No fixup found at offset 0x{0:X}.", writeOffset);
			return true;
		}

		private static bool ExecuteList(HaloTag tag, List<string> args)
		{
			if (args.Count != 2)
				return false;
			var fixups = tag.DataFixups.OrderBy(f => f.WriteOffset);
			foreach (var fixup in fixups)
				Console.WriteLine("0x{0:X} -> 0x{1:X}", fixup.WriteOffset, fixup.TargetOffset);
			return true;
		}

		private static bool CheckWriteOffset(HaloTag tag, uint writeOffset)
		{
			if (writeOffset < tag.Size)
				return true;
			Console.Error.WriteLine("Invalid write offset: cannot write past the end of the tag.");
			return false;
		}

		private static bool CheckTargetOffset(HaloTag tag, uint targetOffset)
		{
			if (targetOffset < tag.Size)
				return true;
			Console.Error.WriteLine("Invalid target offset: cannot point to something outside the tag.");
			return false;
		}
	}
}
