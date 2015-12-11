using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Rm
{
    class ListArgumentsCommand : Command
    {
        public OpenTagCache Info { get; private set; }
        public HaloTag SourceTag { get; private set; }
        public RenderMethod SourceRenderMethod { get; private set; }

        public ListArgumentsCommand(OpenTagCache info, HaloTag sourceTag, RenderMethod sourceRenderMethod)
            : base(CommandFlags.Inherit,
                 "ListArguments",
                 "Lists the arguments of the render_method.",
                 "ListArguments",
                 "Lists the arguments of the render_method.")
        {
            Info = info;
            SourceTag = sourceTag;
            SourceRenderMethod = sourceRenderMethod;
        }

        public override bool Execute(List<string> args)
        {

            foreach (var property in SourceRenderMethod.ShaderProperties)
            {
                RenderMethodTemplate template = null;

                using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.Read))
                {
                    var context = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, property.Template);
                    template = Info.Deserializer.Deserialize<RenderMethodTemplate>(context);
                }

                for (var i = 0; i < template.Arguments.Count; i++)
                {
                    Console.WriteLine("");

                    var argumentName = Info.StringIds.GetString(template.Arguments[i].Name);
                    var argumentValue = new Vector4(
                        property.Arguments[i].Arg1,
                        property.Arguments[i].Arg2,
                        property.Arguments[i].Arg3,
                        property.Arguments[i].Arg4);

                    Console.WriteLine(string.Format("{0}:", argumentName));

                    if (argumentName.EndsWith("_map"))
                    {
                        Console.WriteLine(string.Format("\tX Scale: {0}", argumentValue.X));
                        Console.WriteLine(string.Format("\tY Scale: {0}", argumentValue.Y));
                        Console.WriteLine(string.Format("\tX Offset: {0}", argumentValue.Z));
                        Console.WriteLine(string.Format("\tY Offset: {0}", argumentValue.W));
                    }
                    else
                    {
                        Console.WriteLine(string.Format("\tX: {0}", argumentValue.X));
                        Console.WriteLine(string.Format("\tY: {0}", argumentValue.Y));
                        Console.WriteLine(string.Format("\tZ: {0}", argumentValue.Z));
                        Console.WriteLine(string.Format("\tW: {0}", argumentValue.W));
                    }
                }
            }

            return true;
        }
    }
}
