﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.VFiles
{
    class ListCommand : Command
    {
        private readonly VFilesList Definition;

        public ListCommand(VFilesList definition) : base(
            CommandFlags.Inherit,

            "list",
            "List files stored in the tag",

            "list [filter]",

            "If a filter is specified, only files which contain the filter in their path\n" +
            "will be listed.")
        {
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count > 1)
                return false;

            string filter = null;

            if (args.Count == 1)
                filter = args[0];

            // Just sort the paths in alphabetical order
            var paths = Definition.Files
                .Select(f => Path.Combine(f.Folder, f.Name))
                .Where(p => filter == null || p.Contains(filter))
                .OrderBy(p => p)
                .ToList();

            foreach (var path in paths)
                Console.WriteLine(path);

            return true;
        }
    }
}
