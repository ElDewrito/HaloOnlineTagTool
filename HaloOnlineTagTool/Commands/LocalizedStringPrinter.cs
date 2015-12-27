using System;
using System.Collections.Generic;
using System.Linq;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands
{
    static class LocalizedStringPrinter
    {
        /// <summary>
        /// Filters a set of localized strings and prepares them for display.
        /// </summary>
        /// <param name="unic">The string list.</param>
        /// <param name="stringIds">The string ID cache to use.</param>
        /// <param name="strings">The strings to display.</param>
        /// <param name="language">The language to display strings from.</param>
        /// <param name="filter">The filter to match strings and stringIDs against. Can be <c>null</c> to display everything.</param>
        /// <returns>The strings to print.</returns>
        public static List<DisplayString> PrepareForDisplay(MultilingualUnicodeStringList unic, StringIdCache stringIds, IEnumerable<LocalizedString> strings, GameLanguage language, string filter)
        {
            // Filter the input strings
            var display = new List<DisplayString>();
            foreach (var localizedString in strings)
            {
                var str = unic.GetString(localizedString, language);
                if (str == null)
                    continue;
                var stringId = stringIds.GetString(localizedString.StringId);
                if (filter != null && !str.Contains(filter) && !stringId.Contains(filter))
                    continue;
                display.Add(new DisplayString
                {
                    StringId = stringId,
                    String = str
                });
            }
            display.Sort((a, b) => String.Compare(a.StringId, b.StringId, StringComparison.Ordinal));
            return display;
        }

        public static void PrintStrings(ICollection<DisplayString> strings)
        {
            var stringIdWidth = strings.Max(s => s.StringId.Length);
            var format = string.Format("{{0,-{0}}}  {{1}}", stringIdWidth);
            foreach (var str in strings)
                Console.WriteLine(format, str.StringId, str.String);
        }

        public class DisplayString
        {
            public string StringId { get; set; }

            public string String { get; set; }
        }
    }
}
