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
    class RmshSpecifyBitmapsCommand : Command
    {
        public OpenTagCache Info { get; }
        public HaloTag Tag { get; }
        public Shader SourceShader { get; }

        public RmshSpecifyBitmapsCommand(OpenTagCache info, HaloTag tag, Shader sourceShader)
            : base(CommandFlags.Inherit,
                 "SpecifyBitmaps",
                 "Allows the bitmaps of the rmsh to be respecified.",
                 "SpecifyBitmaps",
                 "Allows the bitmaps of the rmsh to be respecified.")
        {
            Info = info;
            SourceShader = sourceShader;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 0)
                return false;

            var shaderMaps = new Dictionary<StringId, HaloTag>();

            foreach (var property in SourceShader.ShaderProperties)
            {
                RenderMethodTemplate template = null;

                using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.Read))
                {
                    var context = new TagSerializationContext(cacheStream, Info.Cache, property.Template);
                    template = Info.Deserializer.Deserialize<RenderMethodTemplate>(context);
                }

                for (var i = 0; i < template.ShaderMaps.Count; i++)
                {
                    var mapTemplate = template.ShaderMaps[i];

                    Console.Write($"Please enter the {Info.StringIds.GetString(mapTemplate.Name)} index: ");
                    shaderMaps[mapTemplate.Name] = ArgumentParser.ParseTagIndex(Info.Cache, Console.ReadLine());
                    property.ShaderMaps[i].Bitmap = shaderMaps[mapTemplate.Name];
                }
            }

            foreach (var import in SourceShader.ImportData)
                if (shaderMaps.ContainsKey(import.MaterialType))
                    import.Bitmap = shaderMaps[import.MaterialType];

            using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var context = new TagSerializationContext(cacheStream, Info.Cache, Tag);
                Info.Serializer.Serialize(context, SourceShader);
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}
