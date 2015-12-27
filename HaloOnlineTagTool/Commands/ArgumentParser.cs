using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Text;

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
            var redirectStart = -1;
            redirectFile = null;
            for (var i = 0; i < command.Length; i++)
            {
                switch (command[i])
                {
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

        public static TagInstance ParseTagIndex(TagCache cache, string arg)
        {
            int tagIndex;
            if (!int.TryParse(arg, NumberStyles.HexNumber, null, out tagIndex))
                return null;
            if (!cache.Tags.Contains(tagIndex))
            {
                Console.WriteLine("Unable to find tag {0:X8}.", tagIndex);
                return null;
            }
            return cache.Tags[tagIndex];
        }

        public static Tag ParseTagClass(TagCache cache, string className)
        {
            if (className.Length == 4)
                return new Tag(className);
            Console.WriteLine("Invalid tag class: {0}", className);
            return new Tag(-1);
        }

        public static List<Tag> ParseTagClasses(TagCache cache, IEnumerable<string> classNames)
        {
            var searchClasses = classNames.Select(a => ParseTagClass(cache, a)).ToList();
            return (searchClasses.Any(c => c.Value == -1)) ? null : searchClasses;
        }

        public static bool ParseLanguage(string name, out GameLanguage result)
        {
            return _languages.TryGetValue(name, out result);
        }

        public static string Unescape(string str)
        {
            var result = new StringBuilder();
            var escape = false;
            foreach (var ch in str)
            {
                if (!escape)
                {
                    if (ch == '\\')
                        escape = true;
                    else
                        result.Append(ch);
                    continue;
                }
                escape = false;
                switch (ch)
                {
                    case 'n':
                        result.Append('\n');
                        break;
                    case 'r':
                        result.Append('\r');
                        break;
                    case 't':
                        result.Append('\t');
                        break;
                    case 'q':
                        result.Append('"');
                        break;
                    case '\\':
                        result.Append('\\');
                        break;
                    default:
                        result.Append(ch);
                        break;
                }
            }
            return result.ToString();
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
