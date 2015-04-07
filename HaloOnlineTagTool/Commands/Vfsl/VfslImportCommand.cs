using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Vfsl
{
	class VfslImportCommand : Command
	{
		private readonly Stream _stream;
		private readonly TagSerializer _serializer;
		private readonly HaloTag _tag;
		private readonly VFilesList _list;

		public VfslImportCommand(Stream stream, TagSerializer serializer, HaloTag tag, VFilesList list) : base(
			CommandFlags.None,
			
			"import",
			"Replace a file stored in the tag",

			"import <virtual path> [filename]",
			
			"Replaces a file stored in the tag. The tag will be resized as necessary.")
		{
			_stream = stream;
			_serializer = serializer;
			_tag = tag;
			_list = list;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1 && args.Count != 2)
				return false;
			var virtualPath = args[0];
			var inputPath = (args.Count == 2) ? args[1] : virtualPath;
			var file = _list.Find(virtualPath);
			if (file == null)
			{
				Console.Error.WriteLine("Unable to find file {0}.", virtualPath);
				return true;
			}
			byte[] data;
			try
			{
				data = File.ReadAllBytes(inputPath);
			}
			catch (IOException)
			{
				Console.Error.WriteLine("Unable to read from {0}.", inputPath);
				return true;
			}
			_list.Replace(file, data);
			_serializer.Serialize(_stream, _tag, _list);
			Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
			return true;
		}
	}
}
