using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloOnlineTagTool.Commands.Tags
{
    class ListCommand : Command
    {
        private readonly TagCache _cache;

        public ListCommand(OpenTagCache info) : base(
            CommandFlags.Inherit,

            "list",
            "List tags",
            
            "list [class...]",
            
            "class is a 4-character string identifying the tag class, e.g. \"proj\".\n" +
            "Multiple classes to list tags from can be specified.\n" +
            "Tags which inherit from the given classes will also be printed.\n" +
            "If no class is specified, all tags in the file will be listed.")
        {
            _cache = info.Cache;
        }

        public override bool Execute(List<string> args)
        {
            var searchClasses = ArgumentParser.ParseTagClasses(_cache, args);
            if (searchClasses == null)
                return false;

            TagInstance[] tags;
            if (args.Count > 0)
                tags = _cache.Tags.FindAllInGroups(searchClasses).ToArray();
            else
                tags = _cache.Tags.NonNull().ToArray();

            if (tags.Length == 0)
            {
                Console.Error.WriteLine("No tags found.");
                return true;
            }
            TagPrinter.PrintTagsShort(tags);
            return true;
        }
    }
}
