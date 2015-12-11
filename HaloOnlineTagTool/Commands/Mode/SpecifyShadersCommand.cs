using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Mode
{
    class SpecifyShadersCommand : Command
    {
        public OpenTagCache Info { get; private set; }
        public HaloTag SourceTag { get; private set; }
        public RenderModel SourceRenderModel { get; private set; }

        public SpecifyShadersCommand(OpenTagCache info, HaloTag sourceTag, RenderModel sourceRenderModel)
            : base(CommandFlags.Inherit,
                  "SpecifyShaders",
                  "Allows the shaders of a render_model to be respecified.",
                  "SpecifyShaders",
                  "Allows the shaders of a render_model to be respecified.")
        {
            Info = info;
            SourceTag = sourceTag;
            SourceRenderModel = sourceRenderModel;
        }

        public override bool Execute(List<string> args)
        {
            foreach (var material in SourceRenderModel.Materials)
            {
                Console.Write("Please enter the replacement {0:X8} index: ",
                    material.RenderMethod.Index);

                material.RenderMethod = ArgumentParser.ParseTagIndex(Info.Cache, Console.ReadLine());
            }

            using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, SourceTag);
                Info.Serializer.Serialize(context, SourceRenderModel);
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}
