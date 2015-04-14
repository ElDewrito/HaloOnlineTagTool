﻿using System;
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
		private readonly FileInfo _fileInfo;
		private readonly TagSerializer _tagSerializer;
		private readonly HaloTag _tag;
		private readonly MultilingualUnicodeStringList _unic;
		private readonly StringIdCache _stringIds;

		public UnicSetCommand(FileInfo fileInfo, TagSerializer serializer, HaloTag tag, MultilingualUnicodeStringList unic, StringIdCache stringIds) : base(
			CommandFlags.None,

			"set",
			"Set the value of a string",

			"set <language> <stringid> <value>",

			"Sets the string associated with a stringID in a language.\n" +
			"Remember to put the string value in quotes if it contains spaces.\n" +
			"If the string does not exist, it will be added.")
		{
			_fileInfo = fileInfo;
			_tagSerializer = serializer;
			_tag = tag;
			_unic = unic;
			_stringIds = stringIds;
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
			var stringIdIndex = _stringIds.Strings.IndexOf(stringIdStr);
			if (stringIdIndex < 0)
			{
				Console.Error.WriteLine("Unable to find stringID \"{0}\".", stringIdStr);
				return true;
			}
			var stringId = _stringIds.GetStringId(stringIdIndex);
			if (stringId == 0)
			{
				Console.Error.WriteLine("Failed to resolve the stringID.");
				return true;
			}

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
			_unic.SetString(localizedStr, language, args[2]);
			using (var stream = _fileInfo.Open(FileMode.Open, FileAccess.ReadWrite))
				_tagSerializer.Serialize(stream, _tag, _unic);

			if (added)
				Console.WriteLine("String added successfully.");
			else
				Console.WriteLine("String changed successfully.");
			return true;
		}
	}
}
