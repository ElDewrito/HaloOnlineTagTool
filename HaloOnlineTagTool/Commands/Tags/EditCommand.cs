using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Commands.Editing;

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

            _stack.Push(EditTagContextFactory.Create(_stack, _info, tag));

            Console.WriteLine("Tag 0x{0:X8}.{1} has been opened for editing.", tag.Index, _info.StringIds.GetString(tag.Group.Name));
            Console.WriteLine("New commands are now available. Enter \"help\" to view them.");
            Console.WriteLine("Use \"exit\" to return to {0}.", oldContext.Name);

            return true;
        }

    }
}
