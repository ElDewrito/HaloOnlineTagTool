using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Vfsl
{
	class VfslExtractAllCommand : Command
	{
		private readonly VFilesList _list;

		public VfslExtractAllCommand(VFilesList list) : base(
			CommandFlags.Inherit,

			"extractall",
			"Extract all files from the tag",

			"extractall [output path]",

			"If not output path is specified, files will be extracted to the current\n" +
			"directory.")
		{
			_list = list;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count > 1)
				return false;
			var baseDir = (args.Count == 1) ? args[0] : Directory.GetCurrentDirectory();
			foreach (var file in _list.Files)
			{
				var outDir = Path.Combine(baseDir, file.Folder);
				Directory.CreateDirectory(outDir);
				var outPath = Path.Combine(outDir, file.Name);
				var data = _list.Extract(file);
				File.WriteAllBytes(outPath, data);
			}
			Console.WriteLine("Extracted {0} files.", _list.Files.Count);
			return true;
		}
	}
}
