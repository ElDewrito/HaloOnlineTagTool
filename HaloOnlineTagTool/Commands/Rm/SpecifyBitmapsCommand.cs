using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Rmsh
{
    class SpecifyBitmapsCommand : Command
    {
        public OpenTagCache Info { get; private set; }
        public HaloTag SourceTag { get; private set; }
		public RenderMethod SourceRenderMethod { get; private set; }

        public SpecifyBitmapsCommand(OpenTagCache info, HaloTag sourceTag, RenderMethod sourceRenderMethod)
            : base(CommandFlags.Inherit,
                 "SpecifyBitmaps",
                 "Allows the bitmaps of the render_method to be respecified.",
                 "SpecifyBitmaps",
                 "Allows the bitmaps of the render_method to be respecified.")
        {
            Info = info;
            SourceTag = sourceTag;
            SourceRenderMethod = sourceRenderMethod;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 0)
                return false;
            
            var shaderMaps = new Dictionary<StringId, HaloTag>();

            foreach (var property in SourceRenderMethod.ShaderProperties)
            {
                RenderMethodTemplate template = null;

                using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.Read))
                {
                    var context = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, property.Template);
                    template = Info.Deserializer.Deserialize<RenderMethodTemplate>(context);
                }

                for (var i = 0; i < template.ShaderMaps.Count; i++)
                {
                    var mapTemplate = template.ShaderMaps[i];

                    Console.Write(string.Format("Please enter the {0} index: ", Info.StringIds.GetString(mapTemplate.Name)));
                    shaderMaps[mapTemplate.Name] = ArgumentParser.ParseTagIndex(Info.Cache, Console.ReadLine());
                    property.ShaderMaps[i].Bitmap = shaderMaps[mapTemplate.Name];
                }
            }

            foreach (var import in SourceRenderMethod.ImportData)
                if (shaderMaps.ContainsKey(import.MaterialType))
                    import.Bitmap = shaderMaps[import.MaterialType];

            using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, SourceTag);
                Info.Serializer.Serialize(context, SourceRenderMethod);
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}
