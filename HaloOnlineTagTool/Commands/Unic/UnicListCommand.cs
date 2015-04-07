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

		public UnicListCommand(MultilingualUnicodeStringList unic) : base(
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
					StringId = localizedString.StringId,
					StringIdDisplay = string.Format("0x{0:X}", localizedString.StringId),
					StringIdStr = localizedString.StringIdStr,
					String = str,
				});
			}
			if (strings.Count == 0)
			{
				Console.WriteLine("No strings found.");
				return true;
			}
			strings.Sort((a, b) => a.StringId.CompareTo(b.StringId));

			var stringIdWidth = strings.Max(s => s.StringIdDisplay.Length);
			var stringIdStrWidth = strings.Max(s => s.StringIdStr.Length);
			if (stringIdStrWidth > 0)
			{
				// Three column format
				var format = string.Format("{{0,-{0}}}  {{1,-{1}}}  {{2}}", stringIdWidth, stringIdStrWidth);
				foreach (var str in strings)
					Console.WriteLine(format, str.StringIdDisplay, str.StringIdStr, str.String);
			}
			else
			{
				// Two column format
				var format = string.Format("{{0,-{0}}}  {{1}}", stringIdWidth);
				foreach (var str in strings)
					Console.Write(format, str.StringIdDisplay, str.String);
			}
			return true;
		}

		private class DisplayString
		{
			public int StringId { get; set; }

			public string StringIdDisplay { get; set; }

			public string StringIdStr { get; set; }

			public string String { get; set; }
		}
	}
}
