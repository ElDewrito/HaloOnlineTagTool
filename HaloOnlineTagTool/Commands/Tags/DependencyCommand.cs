using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace HaloOnlineTagTool.Commands.Tags
{
    /// <summary>
    /// Command for managing tag dependencies.
    /// </summary>
    class DependencyCommand : Command
    {
        private readonly TagCache _cache;
        private readonly OpenTagCache _info;

        public DependencyCommand(OpenTagCache info) : base(
            CommandFlags.None,

            "dep",
            "Manage tag loading",

            "dep add <tag index> <dependency index...>\n" +
            "dep remove <tag index> <dependency index...>\n" +
            "dep list <tag index>\n" +
            "dep listall <tag index>\n" +
            "dep liston <tag index>",

            "\"dep add\" will cause the first tag to load the other tags.\n" +
            "\"dep remove\" will prevent the first tag from loading the other tags.\n" +
            "\"dep list\" will list all immediate dependencies of a tag.\n" +
            "\"dep listall\" will recursively list all dependencies of a tag.\n" +
            "\"dep liston\" will list all tags that depend on a tag.\n" +
            "\n" +
            "To add dependencies to a map, use the \"map\" command to get its scenario tag\n" +
            "index and then add dependencies to the scenario tag.")
        {
            _cache = info.Cache;
            _info = info;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 2)
                return false;
            var tag = ArgumentParser.ParseTagIndex(_cache, args[1]);
            if (tag == null)
                return false;

            switch (args[0])
            {
                case "add":
                case "remove":
                    return ExecuteAddRemove(tag, args);
                case "list":
                case "listall":
                    return ExecuteList(tag, (args[0] == "listall"));
                case "liston":
                    return ExecuteListDependsOn(tag);
                default:
                    return false;
            }
        }

        private bool ExecuteAddRemove(TagInstance tag, List<string> args)
        {
            if (args.Count < 3)
                return false;
            var dependencies = args.Skip(2).Select(a => ArgumentParser.ParseTagIndex(_cache, a)).ToList();
            if (dependencies.Count == 0 || dependencies.Any(d => d == null))
                return false;
            using (var stream = _info.OpenCacheReadWrite())
            {
                var data = _cache.ExtractTag(stream, tag);
                if (args[0] == "add")
                {
                    foreach (var dependency in dependencies)
                    {
                        if (data.Dependencies.Add(dependency.Index))
                            Console.WriteLine("Added dependency on tag {0:X8}.", dependency.Index);
                        else
                            Console.Error.WriteLine("Tag {0:X8} already depends on tag {1:X8}.", tag.Index,
                                dependency.Index);
                    }
                }
                else
                {
                    foreach (var dependency in dependencies)
                    {
                        if (data.Dependencies.Remove(dependency.Index))
                            Console.WriteLine("Removed dependency on tag {0:X8}.", dependency.Index);
                        else
                            Console.Error.WriteLine("Tag {0:X8} does not depend on tag {1:X8}.", tag.Index,
                                dependency.Index);
                    }
                }
                _cache.SetTagData(stream, tag, data);
            }
            return true;
        }

        private bool ExecuteList(TagInstance tag, bool all)
        {
            if (tag.Dependencies.Count == 0)
            {
                Console.Error.WriteLine("Tag {0:X8} has no dependencies.", tag.Index);
                return true;
            }
            IEnumerable<TagInstance> dependencies;
            if (all)
                dependencies = _cache.Tags.FindDependencies(tag);
            else
                dependencies = tag.Dependencies.Where(i => _cache.Tags.Contains(i)).Select(i => _cache.Tags[i]);
            TagPrinter.PrintTagsShort(dependencies);
            return true;
        }

        private bool ExecuteListDependsOn(TagInstance tag)
        {
            var dependsOn = _cache.Tags.NonNull().Where(t => t.Dependencies.Contains(tag.Index));
            TagPrinter.PrintTagsShort(dependsOn);
            return true;
        }
    }
}
