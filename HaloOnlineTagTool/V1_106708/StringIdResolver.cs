using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.V1_106708
{
	/// <summary>
	/// String ID resolver for 1.106708.
	/// </summary>
	public class StringIdResolver : IStringIdResolver
	{
		// These values were figured out through trial-and-error
		private static readonly int[] SetOffsets = { 0x90F, 0x1, 0x685, 0x720, 0x7C4, 0x778, 0x7D0, 0x8EA, 0x902 };
		private const int SetMin = 0x1;   // Mininum index that goes in a set
		private const int SetMax = 0xF1E; // Maximum index that goes in a set

		/// <summary>
		/// Converts a stringID value to a string list index.
		/// </summary>
		/// <param name="stringId">The stringID.</param>
		/// <returns>
		/// The string list index, or -1 if none.
		/// </returns>
		public int StringIdToIndex(StringId stringId)
		{
			var set = stringId.Set;
			var index = stringId.Index;
			if (set == 0 && (index < SetMin || index > SetMax))
			{
				// Value does not go into a set, so the index is the same as the ID
				return index;
			}
			if (set < 0 || set >= SetOffsets.Length)
				return -1; // Invalid set number

			// Convert the index part of the ID into a string index based on its set
			if (set == 0)
				index -= SetMin;
			return index + SetOffsets[set];
		}

		/// <summary>
		/// Converts a string list index to a stringID value.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>
		/// The stringID value, or <see cref="StringId.Null"/> if none.
		/// </returns>
		public StringId IndexToStringId(int index)
		{
			if (index < 0)
				return StringId.Null;

			// If the value is outside of a set, just return it
			if (index < SetMin || index > SetMax)
				return new StringId(0, index);

			// Find the set which the index is closest to
			var set = 0;
			var minDistance = int.MaxValue;
			for (var i = 0; i < SetOffsets.Length; i++)
			{
				if (index < SetOffsets[i])
					continue;
				var distance = index - SetOffsets[i];
				if (distance >= minDistance)
					continue;
				set = i;
				minDistance = distance;
			}

			// Compute the index within the set
			var idIndex = index - SetOffsets[set];
			if (set == 0)
				idIndex += SetMin;
			return new StringId(set, idIndex);
		}
	}
}
