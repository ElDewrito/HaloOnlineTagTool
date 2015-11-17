using System;
using System.Collections.Generic;
using System.IO;

namespace HaloOnlineTagTool.Resources
{
	/// <summary>
	/// Manages resource caches and extracting/injecting resource data.
	/// </summary>
	public class ResourceDataManager
	{
		private readonly Dictionary<ResourceLocation, string> _cacheNames = new Dictionary<ResourceLocation, string>()
		{
			{ ResourceLocation.Resources, "resources.dat" },
			{ ResourceLocation.Textures, "textures.dat" },
			{ ResourceLocation.TexturesB, "textures_b.dat" },
			{ ResourceLocation.Audio, "audio.dat" },
			{ ResourceLocation.Video, "video.dat" },
			{ ResourceLocation.RenderModels, "render_models.dat" },
			{ ResourceLocation.Lightmaps, "lightmaps.dat" },
		};

		private readonly Dictionary<ResourceLocation, LoadedCache> _loadedCaches = new Dictionary<ResourceLocation, LoadedCache>();

		/// <summary>
		/// Loads a resource cache from a file.
		/// </summary>
		/// <param name="location">The resource cache type.</param>
		/// <param name="path">The path to the .dat file to read.</param>
		/// <exception cref="System.InvalidOperationException">Thrown if the cache is already loaded.</exception>
		public void LoadCache(ResourceLocation location, string path)
		{
			if (_loadedCaches.ContainsKey(location))
				throw new InvalidOperationException("A resource cache for the " + location + " location has already been loaded.");

			var file = new FileInfo(path);
			using (var stream = file.OpenRead())
			{
				_loadedCaches[location] = new LoadedCache
				{
					Cache = new ResourceCache(stream),
					File = file
				};
			}
		}

		/// <summary>
		/// Loads a resource cache from a directory using its default name.
		/// </summary>
		/// <param name="directory">The directory to find the cache in.</param>
		/// <param name="cache">The type of cache to load.</param>
		public void LoadCacheFromDirectory(string directory, ResourceLocation cache)
		{
			var path = Path.Combine(directory, _cacheNames[cache]);
			LoadCache(cache, path);
		}

		/// <summary>
		/// Loads resource caches from a directory using their default filenames.
		/// </summary>
		/// <param name="directory">The directory to find files in.</param>
		public void LoadCachesFromDirectory(string directory)
		{
			foreach (var cache in _cacheNames)
			{
				var path = Path.Combine(directory, cache.Value);
				if (File.Exists(path))
					LoadCache(cache.Key, path);
			}
		}

		/// <summary>
		/// Adds a new resource to a cache.
		/// </summary>
		/// <param name="resource">The resource reference to initialize.</param>
		/// <param name="location">The location where the resource should be stored.</param>
		/// <param name="dataStream">The stream to read the resource data from.</param>
		/// <exception cref="System.ArgumentNullException">resource</exception>
		/// <exception cref="System.ArgumentException">The input stream is not open for reading;dataStream</exception>
		public void Add(ResourceReference resource, ResourceLocation location, Stream dataStream)
		{
			if (resource == null)
				throw new ArgumentNullException("resource");
			if (!dataStream.CanRead)
				throw new ArgumentException("The input stream is not open for reading", "dataStream");
	
			resource.ChangeLocation(location);
			var cache = GetCache(resource);
			using (var stream = cache.File.Open(FileMode.Open, FileAccess.ReadWrite))
			{
				var dataSize = (int)(dataStream.Length - dataStream.Position);
				var data = new byte[dataSize];
				dataStream.Read(data, 0, dataSize);
				uint compressedSize;
				resource.Index = cache.Cache.Add(stream, data, out compressedSize);
				resource.CompressedSize = compressedSize;
				resource.DecompressedSize = (uint)dataSize;
				resource.DisableChecksum();
			}
		}

		/// <summary>
		/// Extracts the raw data for a resource.
		/// </summary>
		/// <param name="resource">The resource.</param>
		/// <param name="outStream">The stream to write the extracted data to.</param>
		/// <exception cref="System.ArgumentException">Thrown if the output stream is not open for writing.</exception>
		/// <exception cref="System.InvalidOperationException">Thrown if the file containing the resource has not been loaded.</exception>
		public void Extract(ResourceReference resource, Stream outStream)
		{
			if (resource == null)
				throw new ArgumentNullException("resource");
			if (!outStream.CanWrite)
				throw new ArgumentException("The output stream is not open for writing", "outStream");

			var cache = GetCache(resource);
			using (var stream = cache.File.OpenRead())
				cache.Cache.Decompress(stream, resource.Index, resource.CompressedSize, outStream);
		}

		/// <summary>
		/// Replaces the raw data for a resource.
		/// </summary>
		/// <param name="resource">The resource whose data should be replaced. On success, the reference will be adjusted to account for the new data.</param>
		/// <param name="dataStream">The stream to read the new data from.</param>
		/// <exception cref="System.ArgumentException">Thrown if the input stream is not open for reading.</exception>
		public void Replace(ResourceReference resource, Stream dataStream)
		{
			if (resource == null)
				throw new ArgumentNullException("resource");
			if (!dataStream.CanRead)
				throw new ArgumentException("The input stream is not open for reading", "dataStream");

			var cache = GetCache(resource);
			using (var stream = cache.File.Open(FileMode.Open, FileAccess.ReadWrite))
			{
				var dataSize = (int)(dataStream.Length - dataStream.Position);
				var data = new byte[dataSize];
				dataStream.Read(data, 0, dataSize);
				var compressedSize = cache.Cache.Compress(stream, resource.Index, data);
				resource.CompressedSize = compressedSize;
				resource.DecompressedSize = (uint)dataSize;
				resource.DisableChecksum();
			}
		}

		private LoadedCache GetCache(ResourceReference resource)
		{
			LoadedCache cache;
			if (!_loadedCaches.TryGetValue(resource.GetLocation(), out cache))
				throw new InvalidOperationException("The requested resource is located in " + resource.GetLocation() + ", but the corresponding cache file has not been loaded.");
			return cache;
		}

		private class LoadedCache
		{
			public ResourceCache Cache { get; set; }

			public FileInfo File { get; set; }
		}
	}
}
