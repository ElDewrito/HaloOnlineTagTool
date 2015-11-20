using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
	/// <summary>
	/// A lookup table which can be used to find a tag's equivalents in different game versions.
	/// </summary>
	public class TagVersionMap
	{
		private readonly Dictionary<EngineVersion, VersionMap> _versionMaps = new Dictionary<EngineVersion, VersionMap>();
		private int _nextGlobalTagIndex = 0;

		/// <summary>
		/// Connects a tag index to a tag in another version.
		/// </summary>
		/// <param name="version1">The first version.</param>
		/// <param name="index1">The tag index in the first version.</param>
		/// <param name="version2">The second version.</param>
		/// <param name="index2">The tag index in the second version.</param>
		public void Add(EngineVersion version1, int index1, EngineVersion version2, int index2)
		{
			// Get both version maps, creating them if they don't exist
			VersionMap map1, map2;
			if (!_versionMaps.TryGetValue(version1, out map1))
			{
				map1 = new VersionMap();
				_versionMaps[version1] = map1;
			}
			if (!_versionMaps.TryGetValue(version2, out map2))
			{
				map2 = new VersionMap();
				_versionMaps[version2] = map2;
			}

			// Check if the first index is in the map for the first version.
			// If it is, then we'll get a "global index" which can be used to look it up in other versions.
			// If it isn't, then we need to make a new global index for it.
			var globalIndex = map1.GetGlobalTagIndex(index1);
			if (globalIndex < 0)
			{
				globalIndex = _nextGlobalTagIndex;
				_nextGlobalTagIndex++;
				map1.Add(globalIndex, index1);
			}

			// Connect the global index to the second index in the second version
			map2.Add(globalIndex, index2);
		}

		/// <summary>
		/// Translates a tag index between two versions.
		/// </summary>
		/// <param name="version1">The version of the index to translate.</param>
		/// <param name="index1">The tag index.</param>
		/// <param name="version2">The version to get the equivalent tag index in.</param>
		/// <returns>The equivalent tag index if found, or -1 otherwise.</returns>
		public int Translate(EngineVersion version1, int index1, EngineVersion version2)
		{
			// Get both version maps and fail if one doesn't exist
			VersionMap map1, map2;
			if (!_versionMaps.TryGetValue(version1, out map1))
				return -1;
			if (!_versionMaps.TryGetValue(version2, out map2))
				return -1;

			// Get the global index from the first map, then look up that index in the second one
			var globalIndex = map1.GetGlobalTagIndex(index1);
			if (globalIndex < 0)
				return -1;
			return map2.GetVersionedTagIndex(globalIndex);
		}

		/// <summary>
		/// Writes the map out to a CSV.
		/// </summary>
		/// <param name="writer">The writer to write to.</param>
		public void WriteCsv(TextWriter writer)
		{
			// Write a list of versions being represented
			writer.WriteLine(string.Join(",", _versionMaps.Keys.Select(VersionDetection.GetVersionString)));

			// Write a list of timestamps for the versions
			writer.WriteLine(string.Join(",", _versionMaps.Keys.Select(v => VersionDetection.GetTimestamp(v).ToString("X16"))));

			// Now write out each tag
			for (var i = 0; i < _nextGlobalTagIndex; i++)
			{
				var globalIndex = i;
				writer.WriteLine(string.Join(",", _versionMaps.Keys.Select(v => _versionMaps[v].GetVersionedTagIndex(globalIndex).ToString("X4"))));
			}
		}

		private class VersionMap
		{
			private readonly List<int> _localIndexes = new List<int>();
			private readonly Dictionary<int, int> _globalIndexes = new Dictionary<int, int>();

			/// <summary>
			/// Converts a tag to a global tag index which can be used to look up the tag in another version.
			/// </summary>
			/// <param name="tag">The index of the tag for this version.</param>
			/// <returns>An index which can be passed to <see cref="GetVersionedTagIndex"/> for any version, or -1 if the tag was not found.</returns>
			public int GetGlobalTagIndex(int tag)
			{
				int result;
				if (_globalIndexes.TryGetValue(tag, out result))
					return result;
				return -1;
			}

			/// <summary>
			/// Converts a global tag index to a tag index for this version.
			/// </summary>
			/// <param name="globalIndex">The global tag index returned by <see cref="GetGlobalTagIndex"/> for this version.</param>
			/// <returns>The tag's index in this version, or -1 if not found.</returns>
			public int GetVersionedTagIndex(int globalIndex)
			{
				if (globalIndex < 0 || globalIndex >= _localIndexes.Count)
					return -1;
				return _localIndexes[globalIndex];
			}

			/// <summary>
			/// Adds a mapping between a global tag index and a versioned tag index.
			/// </summary>
			/// <param name="globalIndex">The global tag index.</param>
			/// <param name="versionedIndex">The tag's index in this version.</param>
			public void Add(int globalIndex, int versionedIndex)
			{
				_globalIndexes[versionedIndex] = globalIndex;
				while (globalIndex >= _localIndexes.Count)
					_localIndexes.Add(-1);
				_localIndexes[globalIndex] = versionedIndex;
			}
		}
	}
}
