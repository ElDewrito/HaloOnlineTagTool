using System;
using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Unicode
{
    class ListCommand : Command
    {
        private OpenTagCache Info { get; }
        private MultilingualUnicodeStringList Definition { get; }

        public ListCommand(OpenTagCache info, MultilingualUnicodeStringList definition) : base(
            CommandFlags.Inherit,

            "list",
            "List strings",

            "list <language> [filter]",

            "Lists the strings belonging to a language.\n" +
            "If a filter is specified, only strings containing the filter will be listed.\n" +
            "\n" +
            "Available languages:\n" +
            "\n" +
            "english, japanese, german, french, spanish, mexican, italian, korean,\n" +
            "chinese-trad, chinese-simp, portuguese, russian")
        {
            // TODO: Can we dynamically generate the language list from the dictionary in ArgumentParser?
            Info = info;
            Definition = definition;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1 && args.Count != 2)
                return false;

            GameLanguage language;
            if (!ArgumentParser.ParseLanguage(args[0], out language))
                return false;

            var filter = (args.Count == 2) ? args[1] : null;
            var strings = LocalizedStringPrinter.PrepareForDisplay(Definition, Info.StringIds, Definition.Strings, language, filter);

            if (strings.Count > 0)
                LocalizedStringPrinter.PrintStrings(strings);
            else
                Console.WriteLine("No strings found.");
            
            return true;
        }
    }
}
