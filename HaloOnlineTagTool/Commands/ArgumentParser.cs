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
	}
}
