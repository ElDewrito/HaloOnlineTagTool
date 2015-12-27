using System;
using System.Collections.Generic;
using System.IO;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.VFiles
{
    class ImportCommand : Command
    {
        private OpenTagCache Info { get; }
        private TagInstance Tag { get; }
        private VFilesList Definition { get; }

        public ImportCommand(OpenTagCache info, TagInstance tag, VFilesList definition) : base(
            CommandFlags.None,
            
            "import",
            "Replace a file stored in the tag",

            "import <virtual path> [filename]",
            
            "Replaces a file stored in the tag. The tag will be resized as necessary.")
        {
            Info = info;
            Tag = tag;
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1 && args.Count != 2)
                return false;

            var virtualPath = args[0];
            var inputPath = (args.Count == 2) ? args[1] : virtualPath;
            var file = Definition.Find(virtualPath);

            if (file == null)
            {
                Console.WriteLine("Unable to find file {0}.", virtualPath);
                return true;
            }

            byte[] data;

            try
            {
                data = File.ReadAllBytes(inputPath);
            }
            catch (IOException)
            {
                Console.WriteLine("Unable to read from {0}.", inputPath);
                return true;
            }

            Definition.Replace(file, data);

            using (var stream = Info.OpenCacheReadWrite())
                Info.Serializer.Serialize(new TagSerializationContext(stream, Info.Cache, Info.StringIds, Tag), Definition);

            Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);

            return true;
        }
    }
}
