using System;
using System.Collections.Generic;
using System.IO;
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

namespace HaloOnlineTagTool.Commands.Tags
{
	class EditCommand : Command
	{
		private readonly CommandContextStack _stack;
		private readonly TagCache _cache;
		private readonly OpenTagCache _info;

		public EditCommand(CommandContextStack stack, OpenTagCache info) : base(
			CommandFlags.None,

			"edit",
			"Edit tag-specific data",

			"edit <tag index>",

			"If the tag contains data which is supported by this program,\n" +
			"this command will make special tag-specific commands available\n" +
			"which can be used to edit or view the data in the tag.\n" +
			"\n" +
			"Currently-supported tag types: bitm, hlmt, unic, vfsl")
		{
			_stack = stack;
			_cache = info.Cache;
			_info = info;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1)
				return false;

			var tag = ArgumentParser.ParseTagIndex(_cache, args[0]);

			if (tag == null)
				return false;

			var oldContext = _stack.Context;

			switch (tag.GroupTag.ToString())
			{
				case "vfsl": // vfiles_list
					EditVFilesList(tag);
					break;

				case "unic": // multilingual_unicode_string_list
					EditMultilingualUnicodeStringList(tag);
					break;

				case "bitm": // bitmap
					EditBitmap(tag);
					break;

				case "hlmt": // model
					EditModel(tag);
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
                    EditRenderMethod(tag);
                    break;

                case "scnr":
                    EditScenario(tag);
                    break;

				default:
					Console.Error.WriteLine("Tag group " + _info.StringIds.GetString(tag.GroupName) + " (" + tag.GroupTag + ") is not supported.");
					return true;
			}

			Console.WriteLine("Tag {0:X8} has been opened for editing.", tag.Index);
			Console.WriteLine("New commands are now available. Enter \"help\" to view them.");
			Console.WriteLine("Use \"exit\" to return to {0}.", oldContext.Name);

			return true;
		}

		private void EditVFilesList(HaloTag tag)
		{
			VFilesList vfsl;
			using (var stream = _info.OpenCacheRead())
				vfsl = _info.Deserializer.Deserialize<VFilesList>(new TagSerializationContext(stream, _cache, tag));
			var context = VfslContextFactory.Create(_stack.Context, _info, tag, vfsl);
			_stack.Push(context);
		}

		private void EditMultilingualUnicodeStringList(HaloTag tag)
		{
			MultilingualUnicodeStringList unic;
			using (var stream = _info.OpenCacheRead())
				unic = _info.Deserializer.Deserialize<MultilingualUnicodeStringList>(new TagSerializationContext(stream, _cache, tag));
			var context = UnicContextFactory.Create(_stack.Context, _info, tag, unic);
			_stack.Push(context);
		}

		private void EditBitmap(HaloTag tag)
		{
            TagStructures.Bitmap bitmap;
			using (var stream = _info.OpenCacheRead())
				bitmap = _info.Deserializer.Deserialize<TagStructures.Bitmap>(new TagSerializationContext(stream, _cache, tag));
			var context = BitmapContextFactory.Create(_stack.Context, _info, tag, bitmap);
			_stack.Push(context);
		}

        private void EditModel(HaloTag tag)
        {
            TagStructures.Model model;
            using (var stream = _info.OpenCacheRead())
                model = _info.Deserializer.Deserialize<TagStructures.Model>(new TagSerializationContext(stream, _cache, tag));
            var context = HlmtContextFactory.Create(_stack.Context, _info, tag, model);
            _stack.Push(context);
        }

        private void EditRenderMethod(HaloTag tag)
        {
            _stack.Push(RenderMethodContextFactory.Create(_stack.Context, _info, tag));
        }

        private void EditScenario(HaloTag tag)
        {
            Scenario scenario;
            using (var stream = _info.OpenCacheRead())
                scenario = _info.Deserializer.Deserialize<Scenario>(new TagSerializationContext(stream, _cache, tag));
            var context = ScnrContextFactory.Create(_stack.Context, _info, tag, scenario);
            _stack.Push(context);
        }
    }
}
