using System;
using System.Collections.Generic;
using System.IO;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.VFiles
{
    class ExtractAllCommand : Command
    {
        private VFilesList Definition { get; }

        public ExtractAllCommand(VFilesList definition) : base(
            CommandFlags.Inherit,

            "extractall",
            "Extract all files from the tag",

            "extractall [output path]",

            "If not output path is specified, files will be extracted to the current\n" +
            "directory.")
        {
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count > 1)
                return false;

            var baseDir = (args.Count == 1) ? args[0] : Directory.GetCurrentDirectory();

            foreach (var file in Definition.Files)
            {
                var outDir = Path.Combine(baseDir, file.Folder);
                Directory.CreateDirectory(outDir);

                var outPath = Path.Combine(outDir, file.Name);
                var data = Definition.Extract(file);
                File.WriteAllBytes(outPath, data);
            }

            Console.WriteLine("Extracted {0} files.", Definition.Files.Count);

            return true;
        }
    }
}
