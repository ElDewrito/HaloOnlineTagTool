using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	static class ArgumentParser
	{
		public static List<string> ParseCommand(string command, out string redirectFile)
		{
			var results = new List<string>();
			var currentArg = new StringBuilder();
			var partStart = -1;
			var quoted = false;
			var escape = false;
			var redirectStart = -1;
			redirectFile = null;
			for (var i = 0; i < command.Length; i++)
			{
				if (escape)
				{
					char ch;
					switch (command[i])
					{
						case 'n':
							ch = '\n';
							break;
						case 'r':
							ch = '\r';
							break;
						case 't':
							ch = '\t';
							break;
						default:
							ch = command[i];
							break;
					}
					if (partStart != -1)
						currentArg.Append(command.Substring(partStart, i - partStart - 1));
					currentArg.Append(ch);
					partStart = -1;
					escape = false;
					continue;
				}
				switch (command[i])
				{
					case '\\':
						escape = true;
						break;
					case '>':
						if (quoted)
							goto default; // Treat like a normal char when quoted
						redirectStart = (partStart != -1) ? results.Count + 1 : results.Count;
						goto case ' '; // Treat like a space
					case ' ':
						if (quoted)
							goto default; // Treat like a normal char when quoted
						if (partStart != -1)
							currentArg.Append(command.Substring(partStart, i - partStart));
						if (currentArg.Length > 0)
							results.Add(currentArg.ToString());
						currentArg.Clear();
						partStart = -1;
						break;
					case '"':
						quoted = !quoted;
						if (partStart != -1)
							currentArg.Append(command.Substring(partStart, i - partStart));
						partStart = -1;
						break;
					default:
						if (partStart == -1)
							partStart = i;
						break;
				}
			}
			if (partStart != -1)
				currentArg.Append(command.Substring(partStart));
			if (currentArg.Length > 0)
				results.Add(currentArg.ToString());
			if (redirectStart >= 0 && redirectStart < results.Count)
			{
				redirectFile = string.Join(" ", results.Skip(redirectStart));
				results.RemoveRange(redirectStart, results.Count - redirectStart);
			}
			return results;
		}

		public static HaloTag ParseTagIndex(TagCache cache, string arg)
		{
			int tagIndex;
			if (!int.TryParse(arg, NumberStyles.HexNumber, null, out tagIndex))
				return null;
			if (!cache.Tags.Contains(tagIndex))
			{
				Console.Error.WriteLine("Unable to find tag {0:X8}.", tagIndex);
				return null;
			}
			return cache.Tags[tagIndex];
		}

		public static MagicNumber ParseTagClass(TagCache cache, string className)
		{
			if (className.Length == 4)
				return new MagicNumber(className);
			Console.Error.WriteLine("Invalid tag class: {0}", className);
			return new MagicNumber(-1);
		}

		public static List<MagicNumber> ParseTagClasses(TagCache cache, IEnumerable<string> classNames)
		{
			var searchClasses = classNames.Select(a => ParseTagClass(cache, a)).ToList();
			return (searchClasses.Any(c => c.Value == -1)) ? null : searchClasses;
		}

		public static bool ParseLanguage(string name, out GameLanguage result)
		{
			return _languages.TryGetValue(name, out result);
		}

		private static readonly Dictionary<string, GameLanguage> _languages = new Dictionary<string, GameLanguage>
		{
			{"english", GameLanguage.English},
			{"japanese", GameLanguage.Japanese},
			{"german", GameLanguage.German},
			{"french", GameLanguage.French},
			{"spanish", GameLanguage.Spanish},
			{"mexican", GameLanguage.Mexican},
			{"italian", GameLanguage.Italian},
			{"korean", GameLanguage.Korean},
			{"chinese-trad", GameLanguage.ChineseTraditional},
			{"chinese-simp", GameLanguage.ChineseSimplified},
			{"portuguese", GameLanguage.Portuguese},
			{"russian", GameLanguage.Russian}
		};
	}
}
