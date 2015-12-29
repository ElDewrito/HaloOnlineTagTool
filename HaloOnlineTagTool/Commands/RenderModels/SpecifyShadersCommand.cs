using System;
using System.Collections.Generic;
using System.IO;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.RenderModels
{
    class SpecifyShadersCommand : Command
    {
        private OpenTagCache Info { get; }
        private TagInstance Tag { get; }
        private RenderModel Definition { get; }

        public SpecifyShadersCommand(OpenTagCache info, TagInstance tag, RenderModel definition)
            : base(CommandFlags.Inherit,
                  "SpecifyShaders",
                  "Allows the shaders of a render_model to be respecified.",
                  "SpecifyShaders",
                  "Allows the shaders of a render_model to be respecified.")
        {
            Info = info;
            Tag = tag;
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            foreach (var material in Definition.Materials)
            {
                Console.Write("Please enter the replacement {0:X8} index: ",
                    material.RenderMethod.Index);

                material.RenderMethod = ArgumentParser.ParseTagIndex(Info.Cache, Console.ReadLine());
            }

            using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, Tag);
                Info.Serializer.Serialize(context, Definition);
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}
