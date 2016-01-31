using System;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.RenderMethods
{
    static class RenderMethodContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, TagInstance tag)
        {
            var groupName = info.StringIds.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(context, info, tag);

            return context;
        }

        public static void Populate(CommandContext context, OpenTagCache info, TagInstance tag)
        {
            RenderMethod renderMethod = null;

            using (var cacheStream = info.OpenCacheReadWrite())
            {
                var tagContext = new TagSerializationContext(cacheStream, info.Cache, info.StringIds, tag);

                switch (tag.Group.Tag.ToString())
                {
                    case "rm  ": // render_method
                        renderMethod = info.Deserializer.Deserialize<RenderMethod>(tagContext);
                        break;

                    case "rmsh": // shader
                        renderMethod = info.Deserializer.Deserialize<Shader>(tagContext);
                        break;

                    case "rmd ": // shader_decal
                        renderMethod = info.Deserializer.Deserialize<ShaderDecal>(tagContext);
                        break;

                    case "rmfl": // shader_foliage
                        renderMethod = info.Deserializer.Deserialize<ShaderFoliage>(tagContext);
                        break;

                    case "rmhg": // shader_halogram
                        renderMethod = info.Deserializer.Deserialize<ShaderHalogram>(tagContext);
                        break;

                    case "rmss": // shader_screen
                        renderMethod = info.Deserializer.Deserialize<ShaderScreen>(tagContext);
                        break;

                    case "rmtr": // shader_terrain
                        renderMethod = info.Deserializer.Deserialize<ShaderTerrain>(tagContext);
                        break;

                    case "rmw ": // shader_water
                        renderMethod = info.Deserializer.Deserialize<ShaderWater>(tagContext);
                        break;

                    case "rmzo": // shader_zonly
                        renderMethod = info.Deserializer.Deserialize<ShaderZonly>(tagContext);
                        break;

                    case "rmcs": // shader_custom
                        renderMethod = info.Deserializer.Deserialize<ShaderCustom>(tagContext);
                        break;

                    default:
                        throw new NotImplementedException();
                }
            }
            
            context.AddCommand(new ListArgumentsCommand(info, tag, renderMethod));
            context.AddCommand(new ListBitmapsCommand(info, tag, renderMethod));
            context.AddCommand(new SpecifyBitmapsCommand(info, tag, renderMethod));
        }
    }
}
