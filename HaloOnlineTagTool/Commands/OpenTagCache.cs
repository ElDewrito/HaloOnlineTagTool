using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	/// <summary>
	/// Holds information about an open tag cache file.
	/// </summary>
	class OpenTagCache
	{
		/// <summary>
		/// Gets or sets the tag cache.
		/// </summary>
		public TagCache Cache { get; set; }

		/// <summary>
		/// Gets or sets the location of the tag cache file.
		/// </summary>
		public FileInfo CacheFile { get; set; }

		/// <summary>
		/// Gets or sets the stringID cache.
		/// Can be <c>null</c>.
		/// </summary>
		public StringIdCache StringIds { get; set; }

		/// <summary>
		/// Gets or sets the location of the stringID cache file.
		/// Can be <c>null</c>.
		/// </summary>
		public FileInfo StringIdsFile { get; set; }

		/// <summary>
		/// Gets or sets the target engine version.
		/// </summary>
		public EngineVersion Version { get; set; }

		/// <summary>
		/// Opens the tag cache file for reading.
		/// </summary>
		/// <returns>The stream that was opened.</returns>
		public Stream OpenCacheRead()
		{
			return CacheFile.OpenRead();
		}

		/// <summary>
		/// Opens the tag cache file for writing.
		/// </summary>
		/// <returns>The stream that was opened.</returns>
		public Stream OpenCacheWrite()
		{
			return CacheFile.Open(FileMode.Open, FileAccess.Write);
		}

		/// <summary>
		/// Opens the tag cache file for reading and writing.
		/// </summary>
		/// <returns>The stream that was opened.</returns>
		public Stream OpenCacheReadWrite()
		{
			return CacheFile.Open(FileMode.Open, FileAccess.ReadWrite);
		}
	}
}
