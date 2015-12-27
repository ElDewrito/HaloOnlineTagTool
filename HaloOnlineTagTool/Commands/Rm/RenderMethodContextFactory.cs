using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Rmsh
{
    static class RenderMethodContextFactory
    {
        public static void Populate(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            RenderMethod renderMethod = null;

            using (var cacheStream = info.OpenCacheReadWrite())
            {
                var tagContext = new TagSerializationContext(cacheStream, info.Cache, info.StringIds, tag);

                switch (tag.GroupTag.ToString())
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

            context.AddCommand(new SpecifyBitmapsCommand(info, tag, renderMethod));
        }
    }
}

