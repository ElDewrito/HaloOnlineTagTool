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
		private readonly MultilingualUnicodeStringList _unic;
		private readonly StringIdCache _stringIds;

		public UnicListCommand(MultilingualUnicodeStringList unic, StringIdCache stringIds) : base(
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
			_unic = unic;
			_stringIds = stringIds;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 1 && args.Count != 2)
				return false;
			GameLanguage language;
			if (!ArgumentParser.ParseLanguage(args[0], out language))
				return false;
			var filter = (args.Count == 2) ? args[1] : null;

			// Load each matching string into a list and sort them by stringID
			var strings = new List<DisplayString>();
			foreach (var localizedString in _unic.Strings)
			{
				var str = _unic.GetString(localizedString, language);
				if (str == null)
					continue;
				if (filter != null && !str.Contains(filter))
					continue;
				strings.Add(new DisplayString
				{
					StringId = _stringIds.GetString(localizedString.StringId),
					String = str
				});
			}
			if (strings.Count == 0)
			{
				Console.WriteLine("No strings found.");
				return true;
			}
			strings.Sort((a, b) => String.Compare(a.StringId, b.StringId, StringComparison.Ordinal));

			var stringIdWidth = strings.Max(s => s.StringId.Length);
			var format = string.Format("{{0,-{0}}}  {{1}}", stringIdWidth);
			foreach (var str in strings)
				Console.WriteLine(format, str.StringId, str.String);
			return true;
		}

		private class DisplayString
		{
			public string StringId { get; set; }

			public string String { get; set; }
		}
	}
}
