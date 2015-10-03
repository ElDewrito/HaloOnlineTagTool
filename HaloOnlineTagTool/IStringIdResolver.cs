using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
	/// <summary>
	/// Interface for an object which converts stringID values to and from string list indices.
	/// </summary>
	public interface IStringIdResolver
	{
		/// <summary>
		/// Converts a stringID value to a string list index.
		/// </summary>
		/// <param name="stringId">The stringID.</param>
		/// <returns>The string list index, or -1 if none.</returns>
		int StringIdToIndex(StringId stringId);

		/// <summary>
		/// Converts a string list index to a stringID value.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The stringID value, or <see cref="StringId.Null"/> if none.</returns>
		StringId IndexToStringId(int index);
	}
}
