using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Tags
{
	class TagBlockCommand : Command
	{
		private readonly OpenTagCache _info;

		public TagBlockCommand(OpenTagCache info) : base(
			CommandFlags.None,

			"tagblock",
			"Quickly resize tag blocks",
			
			"tagblock add <count offset> <element size> <amount>\n" +
			"tagblock remove <count offset> <element size> <amount>\n" +
			"tagblock insertat <count offset> <element size> <index> <amount>\n" +
			"tagblock removeat <count offset> <element size> <index> <amount>",
			
			"Each of the commands requires the file offset of the count value for the tag\n" +
			"block. The tag it belongs to will be determined automatically.\n" +
			"\n" +
			"\"tagblock add\" adds elements to the end of a tag block.\n" +
			"\"tagblock remove\" removes elements from the end of a tag block.\n" +
			"\"tagblock addat\" adds elements in the middle of a tag block.\n" +
			"\"tagblock removeat\" removes elements from the middle of a tag block.\n")
		{
			_info = info;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count < 3)
				return false;

			int offset;
			if (!int.TryParse(args[1], NumberStyles.HexNumber, null, out offset))
				return false;
			int elementSize;
			if (!int.TryParse(args[2], NumberStyles.HexNumber, null, out elementSize))
				return false;

			// Find the tag
			var tag = FindTagWithOffset(offset);
			if (tag == null)
				return false;
			Console.Write("Detected tag: ");
			TagPrinter.PrintTagShort(tag);
			var offsetFromTag = offset - tag.DataOffset;

			using (var stream = _info.OpenCacheReadWrite())
			{
				// Read block info
				stream.Position = offset;
				var reader = new BinaryReader(stream);
				var oldCount = reader.ReadInt32();
				var newCount = oldCount;
				var address = reader.ReadUInt32();
				var fixup = tag.DataFixups.FirstOrDefault(f => f.WriteOffset == offsetFromTag + 4);
				if (fixup == null)
				{
					if (address != 0)
					{
						Console.Error.WriteLine("0x{0:X8} doesn't look like a valid tag block offset!", offset);
						return true;
					}
					
					// Allocate space at the end of the tag
					fixup = new TagFixup
					{
						WriteOffset = (uint)offsetFromTag + 4,
						TargetOffset = (uint)tag.DataSize
					};
				}
				var blockOffset = (int)fixup.TargetOffset;

				// Execute the subcommand
				bool result;
				switch (args[0])
				{
					case "add":
						result = AddSubcommand(stream, tag, blockOffset, elementSize, ref newCount, args);
						break;
					case "remove":
						result = RemoveSubcommand(stream, tag, blockOffset, elementSize, ref newCount, args);
						break;
					case "insertat":
						result = InsertAtSubcommand(stream, tag, blockOffset, elementSize, ref newCount, args);
						break;
					case "removeat":
						result = RemoveAtSubcommand(stream, tag, blockOffset, elementSize, ref newCount, args);
						break;
					default:
						return false;
				}
				if (!result)
					return false;

				// Update the block pointer if necessary
				if (oldCount != newCount)
				{
					stream.Position = tag.DataOffset + fixup.WriteOffset - 4;
					var writer = new BinaryWriter(stream);
					writer.Write(newCount);
					if (newCount > 0)
					{
						fixup.TargetOffset = (uint)blockOffset;
						if (address == 0)
							tag.DataFixups.Add(fixup);
					}
					else
					{
						tag.DataFixups.Remove(fixup);
						writer.Write(0);
					}
					_info.Cache.UpdateTag(stream, tag);
				}
			}

			Console.WriteLine("Done!");
			return true;
		}

		private bool AddSubcommand(Stream stream, HaloTag tag, int offset, int elementSize, ref int count, List<string> args)
		{
			if (args.Count != 4)
				return false;
			int amount;
			if (!int.TryParse(args[3], NumberStyles.HexNumber, null, out amount) || amount < 0)
				return false;
			Console.WriteLine("Inserting {0} elements at index {1}...", amount, count);
			DoAdd(stream, tag, offset, elementSize, count, amount, ref count);
			return true;
		}

		private bool InsertAtSubcommand(Stream stream, HaloTag tag, int offset, int elementSize, ref int count, List<string> args)
		{
			if (args.Count != 5)
				return false;
			int index;
			if (!int.TryParse(args[3], NumberStyles.HexNumber, null, out index) || index < 0)
				return false;
			int amount;
			if (!int.TryParse(args[4], NumberStyles.HexNumber, null, out amount) || amount < 0)
				return false;
			DoAdd(stream, tag, offset, elementSize, index, amount, ref count);
			Console.WriteLine("Inserting {0} elements...", amount);
			return true;
		}

		private bool RemoveSubcommand(Stream stream, HaloTag tag, int offset, int elementSize, ref int count, List<string> args)
		{
			if (args.Count != 4)
				return false;
			int amount;
			if (!int.TryParse(args[3], NumberStyles.HexNumber, null, out amount))
				return false;
			Console.WriteLine("Removing {0} elements...", amount);
			DoRemove(stream, tag, offset, elementSize, count - amount, amount, ref count);
			return true;
		}

		private bool RemoveAtSubcommand(Stream stream, HaloTag tag, int offset, int elementSize, ref int count, List<string> args)
		{
			if (args.Count != 5)
				return false;
			int index;
			if (!int.TryParse(args[3], NumberStyles.HexNumber, null, out index) || index < 0)
				return false;
			int amount;
			if (!int.TryParse(args[4], NumberStyles.HexNumber, null, out amount) || amount < 0)
				return false;
			Console.WriteLine("Removing {0} elements at index {1}...", amount, index);
			DoRemove(stream, tag, offset, elementSize, index, amount, ref count);
			return true;
		}

		private void DoAdd(Stream stream, HaloTag tag, int offset, int elementSize, int index, int amount, ref int count)
		{
			if (amount == 0)
				return;
			index = Math.Max(0, Math.Min(index, count));
			_info.Cache.ResizeTagData(stream, tag, (uint)(offset + index * elementSize), 0, elementSize * amount, ResizeOrigin.End);
			count += amount;
		}

		private void DoRemove(Stream stream, HaloTag tag, int offset, int elementSize, int index, int amount, ref int count)
		{
			index = Math.Max(0, Math.Min(index, count - 1));
			amount = Math.Max(0, Math.Min(amount, count - index));
			if (amount == 0)
				return;
			_info.Cache.ResizeTagData(stream, tag, (uint)(offset + index * elementSize), elementSize * amount, 0, ResizeOrigin.End);
			count = Math.Max(0, count - amount);
		}

		private HaloTag FindTagWithOffset(int offset)
		{
			return _info.Cache.Tags.FirstOrDefault(t => t != null && offset >= t.DataOffset && offset < t.DataOffset + t.DataSize);
		}
	}
}
