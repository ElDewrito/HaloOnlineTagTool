using System;
using System.Collections.Generic;
using System.IO;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.VFiles
{
    class ImportAllCommand : Command
    {
        private OpenTagCache Info { get; }
        private TagInstance Tag { get; }
        private VFilesList Definition { get; }

        public ImportAllCommand(OpenTagCache info, TagInstance tag, VFilesList definition) : base(
            CommandFlags.None,
            
            "importall",
            "Replace all files stored in the tag",

            "importall [directory]",
            
            "Replaces all file stored in the tag. The tag will be resized as necessary.\n" +
            "If no directory is specified, files will be loaded from the current directory.")
        {
            Info = info;
            Tag = tag;
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count > 1)
                return false;

            var baseDir = (args.Count == 1) ? args[0] : Directory.GetCurrentDirectory();
            var imported = 0;

            foreach (var file in Definition.Files)
            {
                var inputPath = Path.Combine(baseDir, file.Folder, file.Name);
                byte[] data;

                try
                {
                    data = File.ReadAllBytes(inputPath);
                }
                catch (IOException)
                {
                    Console.WriteLine("Unable to read from {0}!", inputPath);
                    continue;
                }

                Definition.Replace(file, data);
                imported++;
            }
            using (var stream = Info.OpenCacheReadWrite())
                Info.Serializer.Serialize(new TagSerializationContext(stream, Info.Cache, Info.StringIds, Tag), Definition);

            Console.WriteLine("Imported {0} files.", imported);

            return true;
        }
    }
}
