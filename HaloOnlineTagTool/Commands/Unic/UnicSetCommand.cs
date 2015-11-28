using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Unic
{
	class UnicSetCommand : Command
	{
		private readonly OpenTagCache _info;
		private readonly HaloTag _tag;
		private readonly MultilingualUnicodeStringList _unic;

		public UnicSetCommand(OpenTagCache info, HaloTag tag, MultilingualUnicodeStringList unic) : base(
			CommandFlags.None,

			"set",
			"Set the value of a string",

			"set <language> <stringid> <value>",

			"Sets the string associated with a stringID in a language.\n" +
			"Remember to put the string value in quotes if it contains spaces.\n" +
			"If the string does not exist, it will be added.")
		{
			_info = info;
			_tag = tag;
			_unic = unic;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count != 3)
				return false;

			GameLanguage language;
			if (!ArgumentParser.ParseLanguage(args[0], out language))
				return false;

			// Look up the stringID that was passed in
			var stringIdStr = args[1];
			var stringIdIndex = _info.StringIds.Strings.IndexOf(stringIdStr);
			if (stringIdIndex < 0)
			{
				Console.Error.WriteLine("Unable to find stringID \"{0}\".", stringIdStr);
				return true;
			}
			var stringId = _info.StringIds.GetStringId(stringIdIndex);
			if (stringId == StringId.Null)
			{
				Console.Error.WriteLine("Failed to resolve the stringID.");
				return true;
			}
			var newValue = ArgumentParser.Unescape(args[2]);

			// Look up or create a localized string entry
			var localizedStr = _unic.Strings.FirstOrDefault(s => s.StringId == stringId);
			var added = false;
			if (localizedStr == null)
			{
				// Add a new string
				localizedStr = new LocalizedString {StringId = stringId};
				_unic.Strings.Add(localizedStr);
				added = true;
			}

			// Save the tag data
			_unic.SetString(localizedStr, language, newValue);
			using (var stream = _info.OpenCacheReadWrite())
				_info.Serializer.Serialize(new TagSerializationContext(stream, _info.Cache, _info.StringIds, _tag), _unic);

			if (added)
				Console.WriteLine("String added successfully.");
			else
				Console.WriteLine("String changed successfully.");
			return true;
		}
	}
}
