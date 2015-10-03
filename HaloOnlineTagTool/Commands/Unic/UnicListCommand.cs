using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Unic
{
	class UnicListCommand : Command
	{
		private readonly OpenTagCache _info;
		private readonly MultilingualUnicodeStringList _unic;

		public UnicListCommand(OpenTagCache info, MultilingualUnicodeStringList unic) : base(
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
			_info = info;
			_unic = unic;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1 && args.Count != 2)
				return false;
			GameLanguage language;
			if (!ArgumentParser.ParseLanguage(args[0], out language))
				return false;
			var filter = (args.Count == 2) ? args[1] : null;

			var strings = LocalizedStringPrinter.PrepareForDisplay(_unic, _info.StringIds, _unic.Strings, language, filter);
			if (strings.Count > 0)
				LocalizedStringPrinter.PrintStrings(strings);
			else
				Console.Error.WriteLine("No strings found.");
			
			return true;
		}
	}
}
