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
	class VfslImportAllCommand : Command
	{
		private readonly FileInfo _fileInfo;
		private readonly TagCache _cache;
		private readonly HaloTag _tag;
		private readonly VFilesList _list;

		public VfslImportAllCommand(FileInfo fileInfo, TagCache cache, HaloTag tag, VFilesList list) : base(
			CommandFlags.None,
			
			"importall",
			"Replace all files stored in the tag",

			"importall [directory]",
			
			"Replaces all file stored in the tag. The tag will be resized as necessary.\n" +
			"If no directory is specified, files will be loaded from the current directory.")
		{
			_fileInfo = fileInfo;
			_cache = cache;
			_tag = tag;
			_list = list;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count > 1)
				return false;
			var baseDir = (args.Count == 1) ? args[0] : Directory.GetCurrentDirectory();
			var imported = 0;
			foreach (var file in _list.Files)
			{
				var inputPath = Path.Combine(baseDir, file.Folder, file.Name);
				byte[] data;
				try
				{
					data = File.ReadAllBytes(inputPath);
				}
				catch (IOException)
				{
					Console.Error.WriteLine("Unable to read from {0}!", inputPath);
					continue;
				}
				_list.Replace(file, data);
				imported++;
			}
			using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				TagSerializer.Serialize(new TagSerializationContext(stream, _cache, _tag), _list);
			Console.WriteLine("Imported {0} files.", imported);
			return true;
		}
	}
}
