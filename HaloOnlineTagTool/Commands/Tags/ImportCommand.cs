using System;
using System.Collections.Generic;
using System.IO;

namespace HaloOnlineTagTool.Commands.Tags
{
    class ImportCommand : Command
    {
        private readonly TagCache _cache;
        private readonly FileInfo _fileInfo;

        public ImportCommand(OpenTagCache info) : base(
            CommandFlags.None,

            "import",
            "Import a tag from a file",
            
            "import <tag index> <filename>",
            
            "The data must have been previously extracted with the \"extract\" command.\n" +
            "If the data is too large, the tag will be expanded as necessary.\n")
        {
            _cache = info.Cache;
            _fileInfo = info.CacheFile;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 2 && args.Count != 3)
                return false; // 3 arguments are allowed to prevent breaking old scripts that use "full"
            var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
            if (tag == null)
                return false;
            var file = args[1];

            byte[] data;
            using (var inStream = File.OpenRead(file))
            {
                data = new byte[inStream.Length];
                inStream.Read(data, 0, data.Length);
            }
            using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
                _cache.SetTagDataRaw(stream, tag, data);

            Console.WriteLine("Imported 0x{0:X} bytes.", data.Length);
            return true;
        }
    }
}
