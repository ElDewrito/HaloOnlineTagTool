using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Commands.Bitm;
using HaloOnlineTagTool.Commands.Hlmt;
using HaloOnlineTagTool.Commands.Rmsh;
using HaloOnlineTagTool.Commands.Scnr;
using HaloOnlineTagTool.Commands.Unic;
using HaloOnlineTagTool.Commands.Vfsl;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Editing
{
    static class EditTagContextFactory
    {
        public static CommandContext Create(CommandContextStack stack, OpenTagCache info, HaloTag tag)
        {
            var groupName = info.StringIds.GetString(tag.GroupName);

            var context = new CommandContext(stack.Context,
                string.Format("0x{0:X8}.{1}", tag.Index, groupName));

            switch (tag.GroupTag.ToString())
            {
                case "vfsl": // vfiles_list
                    EditVFilesList(context, info, tag);
                    break;

                case "unic": // multilingual_unicode_string_list
                    EditMultilingualUnicodeStringList(context, info, tag);
                    break;

                case "bitm": // bitmap
                    EditBitmap(context, info, tag);
                    break;

                case "hlmt": // model
                    EditModel(context, info, tag);
                    break;

                case "rm  ": // render_method
                case "rmsh": // shader
                case "rmd ": // shader_decal
                case "rmfl": // shader_foliage
                case "rmhg": // shader_halogram
                case "rmss": // shader_screen
                case "rmtr": // shader_terrain
                case "rmw ": // shader_water
                case "rmzo": // shader_zonly
                case "rmcs": // shader_custom
                    EditRenderMethod(context, info, tag);
                    break;

                case "scnr":
                    EditScenario(context, info, tag);
                    break;
            }

            object value = null;

            using (var stream = info.OpenCacheRead())
                value = info.Deserializer.Deserialize(
                    new TagSerializationContext(stream, info.Cache, info.StringIds, tag),
                    TagStructureTypes.FindByGroupTag(tag.GroupTag));

            var structure = new TagStructureInfo(
                TagStructureTypes.FindByGroupTag(tag.GroupTag));

            context.AddCommand(new ListFieldsCommand(info, structure, value));
            context.AddCommand(new SetFieldCommand(stack, info, tag, structure, value));
            context.AddCommand(new EditBlockCommand(stack, info, tag, value));
            context.AddCommand(new SaveChangesCommand(info, tag, value));

            return context;
        }

        private static void EditVFilesList(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            VFilesList vfsl;

            using (var stream = info.OpenCacheRead())
                vfsl = info.Deserializer.Deserialize<VFilesList>(
                    new TagSerializationContext(stream, info.Cache, info.StringIds, tag));

            VfslContextFactory.Populate(context, info, tag, vfsl);
        }

        private static void EditMultilingualUnicodeStringList(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            MultilingualUnicodeStringList unic;

            using (var stream = info.OpenCacheRead())
                unic = info.Deserializer.Deserialize<MultilingualUnicodeStringList>(
                    new TagSerializationContext(stream, info.Cache, info.StringIds, tag));

            UnicContextFactory.Populate(context, info, tag, unic);
        }

        private static void EditBitmap(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            Bitmap bitmap;

            using (var stream = info.OpenCacheRead())
                bitmap = info.Deserializer.Deserialize<Bitmap>(
                    new TagSerializationContext(stream, info.Cache, info.StringIds, tag));

            BitmapContextFactory.Populate(context, info, tag, bitmap);
        }

        private static void EditModel(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            Model model;

            using (var stream = info.OpenCacheRead())
                model = info.Deserializer.Deserialize<Model>(
                    new TagSerializationContext(stream, info.Cache, info.StringIds, tag));

            HlmtContextFactory.Populate(context, info, tag, model);
        }

        private static void EditRenderMethod(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            RenderMethodContextFactory.Populate(context, info, tag);
        }

        private static void EditScenario(CommandContext context, OpenTagCache info, HaloTag tag)
        {
            Scenario scenario;

            using (var stream = info.OpenCacheRead())
                scenario = info.Deserializer.Deserialize<Scenario>(
                    new TagSerializationContext(stream, info.Cache, info.StringIds, tag));

            ScnrContextFactory.Populate(context, info, tag, scenario);
        }
    }
}
