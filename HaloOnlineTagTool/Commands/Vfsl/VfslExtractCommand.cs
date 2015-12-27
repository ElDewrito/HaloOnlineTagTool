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
    class VfslExtractCommand : Command
    {
        private readonly VFilesList _list;

        public VfslExtractCommand(VFilesList list) : base(
            CommandFlags.Inherit,

            "extract",
            "Extract a file from the tag",

            "extract <virtual path> [output path]",

            "Extracts a file stored in the tag. If the output path is not specified, it will\n" +
            "be the same as the file's virtual path.\n" +
            "\n" +
            "Use \"list\" to find files in the tag.")
        {
            _list = list;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1 && args.Count != 2)
                return false;
            var virtualPath = args[0];
            var outputPath = (args.Count == 2) ? args[1] : virtualPath;
            var file = _list.Find(virtualPath);
            if (file == null)
            {
                Console.Error.WriteLine("Unable to find file {0}.", virtualPath);
                return true;
            }
            var outDir = Path.GetDirectoryName(outputPath);
            if (!string.IsNullOrEmpty(outDir))
                Directory.CreateDirectory(outDir);
            var data = _list.Extract(file);
            File.WriteAllBytes(outputPath, data);
            Console.WriteLine("Wrote 0x{0:X} bytes to {1}.", data.Length, outputPath);
            return true;
        }
    }
}
