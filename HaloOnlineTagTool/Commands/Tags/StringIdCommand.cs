using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Tags
{
	class StringIdCommand : Command
	{
		private readonly StringIdCache _stringIds;

		public StringIdCommand(StringIdCache stringIds) : base(
			CommandFlags.Inherit,

			"stringid",
			"Look up or find stringID values",

			"stringid get <id>\n" +
			"stringid list [filter]",

			"\"stringid get\" will display the string corresponding to an ID value.\n" +
			"\"stringid list\" will list string IDs, optionally filtering them.")
		{
			_stringIds = stringIds;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count == 0)
				return false;
			switch (args[0])
			{
				case "get":
					return ExecuteGet(args);
				case "list":
					return ExecuteList(args);
			}
			return false;
		}

		private bool ExecuteGet(List<string> args)
		{
			if (args.Count != 2)
				return false;
			uint stringId;
			if (!uint.TryParse(args[1], NumberStyles.HexNumber, null, out stringId))
				return false;
			var str = _stringIds.GetString(new StringId(stringId));
			if (str != null)
				Console.WriteLine(str);
			else
				Console.Error.WriteLine("Unable to find a string with ID 0x{0:X}.", stringId);
			return true;
		}

		private bool ExecuteList(List<string> args)
		{
			if (args.Count > 2)
				return false;
			var filter = (args.Count == 2) ? args[1] : null;

			var strings = new List<FoundStringId>();
			for (var i = 0; i < _stringIds.Strings.Count; i++)
			{
				if (_stringIds.Strings[i] == null)
					continue;
				if (filter != null && !_stringIds.Strings[i].Contains(filter))
					continue;
				var id = _stringIds.GetStringId(i);
				strings.Add(new FoundStringId
				{
					Id = id,
					IdDisplay = id.ToString(),
					Value = _stringIds.Strings[i]
				});
			}
			if (strings.Count == 0)
			{
				Console.Error.WriteLine("No strings found.");
				return true;
			}
			strings.Sort((a, b) => a.Id.CompareTo(b.Id));

			var idWidth = strings.Max(s => s.IdDisplay.Length);
			var formatStr = string.Format("{{0,-{0}}}  {{1}}", idWidth);
			foreach (var str in strings)
				Console.WriteLine(formatStr, str.IdDisplay, str.Value);
			return true;
		}

		private class FoundStringId
		{
			public StringId Id { get; set; }

			public string IdDisplay { get; set; }

			public string Value { get; set; }
		}
	}
}
