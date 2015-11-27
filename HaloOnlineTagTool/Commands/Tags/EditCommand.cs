using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Commands.Bitm;
using HaloOnlineTagTool.Commands.Hlmt;
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
				case "vfsl":
					EditVfslTag(tag);
					break;
				case "unic":
					EditUnicTag(tag);
					break;
				case "bitm":
					EditBitmTag(tag);
					break;
				case "hlmt":
					EditHlmtTag(tag);
					break;
                case "scnr":
                    EditScnrTag(tag);
                    break;
				default:
					Console.Error.WriteLine("Tag type \"" + tag.GroupTag + "\" is not supported.");
					return true;
			}
			Console.WriteLine("Tag {0:X8}.{1} has been opened for editing.", tag.Index, tag.GroupTag);
			Console.WriteLine("New commands are now available. Enter \"help\" to view them.");
			Console.WriteLine("Use \"exit\" to return to {0}.", oldContext.Name);
			return true;
		}

		private void EditVfslTag(HaloTag tag)
		{
			VFilesList vfsl;
			using (var stream = _info.OpenCacheRead())
				vfsl = _info.Deserializer.Deserialize<VFilesList>(new TagSerializationContext(stream, _cache, tag));
			var context = VfslContextFactory.Create(_stack.Context, _info, tag, vfsl);
			_stack.Push(context);
		}

		private void EditUnicTag(HaloTag tag)
		{
			MultilingualUnicodeStringList unic;
			using (var stream = _info.OpenCacheRead())
				unic = _info.Deserializer.Deserialize<MultilingualUnicodeStringList>(new TagSerializationContext(stream, _cache, tag));
			var context = UnicContextFactory.Create(_stack.Context, _info, tag, unic);
			_stack.Push(context);
		}

		private void EditBitmTag(HaloTag tag)
		{
			Bitmap bitmap;
			using (var stream = _info.OpenCacheRead())
				bitmap = _info.Deserializer.Deserialize<Bitmap>(new TagSerializationContext(stream, _cache, tag));
			var context = BitmContextFactory.Create(_stack.Context, _info, tag, bitmap);
			_stack.Push(context);
		}

        private void EditHlmtTag(HaloTag tag)
        {
            Model model;
            using (var stream = _info.OpenCacheRead())
                model = _info.Deserializer.Deserialize<Model>(new TagSerializationContext(stream, _cache, tag));
            var context = HlmtContextFactory.Create(_stack.Context, _info, tag, model);
            _stack.Push(context);
        }

        private void EditScnrTag(HaloTag tag)
        {
            Scenario scenario;
            using (var stream = _info.OpenCacheRead())
                scenario = _info.Deserializer.Deserialize<Scenario>(new TagSerializationContext(stream, _cache, tag));
            var context = ScnrContextFactory.Create(_stack.Context, _info, tag, scenario);
            _stack.Push(context);
        }
    }
}
