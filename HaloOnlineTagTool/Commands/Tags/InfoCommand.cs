using System;
using System.Collections.Generic;

namespace HaloOnlineTagTool.Commands.Tags
{
    class InfoCommand : Command
    {
        private readonly TagCache _cache;

        public InfoCommand(OpenTagCache info) : base(
            CommandFlags.Inherit,

            "info",
            "Get information about a tag",

            "info <tag index>",

            "Displays detailed information about a tag.")
        {
            _cache = info.Cache;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;
            var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);
            if (tag == null)
                return false;

            Console.WriteLine("Information for tag {0:X8}:", tag.Index);
            Console.Write("- Groups: {0}", tag.GroupTag);
            if (tag.ParentGroupTag.Value != -1)
                Console.Write(" -> {0}", tag.ParentGroupTag);
            if (tag.GrandparentGroupTag.Value != -1)
                Console.Write(" -> {0}", tag.GrandparentGroupTag);
            Console.WriteLine();
            Console.WriteLine("- Header offset: 0x{0:X}", tag.HeaderOffset);
            Console.WriteLine("- Data offset:   0x{0:X}", tag.DataOffset);
            Console.WriteLine("- Data size:     0x{0:X}", tag.DataSize);
            Console.WriteLine("- Total size:    0x{0:X}", tag.TotalSize);
            Console.WriteLine("- Main struct offset (relative to data offset): 0x{0:X}", tag.MainStructOffset);
            Console.WriteLine();
            Console.WriteLine("Use \"dep list {0:X}\" to list this tag's dependencies.", tag.Index);
            return true;
        }
    }
}
