using System;
using System.CodeDom;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Tags
{
	// TODO: This code is shit, clean it up
	class MatchTagsCommand : Command
	{
		private static readonly int[] MapIdsToCompare = { 320, 340 }; // 320 = guardian, 340 = riverworld

		private readonly OpenTagCache _info;

		public MatchTagsCommand(OpenTagCache info) : base(
			CommandFlags.None,

			"matchtags",
			"Find equivalent tags in different engine versions",

			"matchtags <output csv> <tags.dat...>",

			"The tags in the current tag cache will be compared with the tags in each of the\n" +
			"listed tags.dat files to find tags that are the same in all of them. Results\n" +
			"will be written to a CSV which can be used to convert tags between the\n" +
			"different versions.")
		{
			_info = info;
		}

		public override bool Execute(List<string> args)
		{
			if (args.Count < 2)
				return false;
			var outputPath = args[0];

			// Load each file and do version detection
			var infos = new List<OpenTagCache>();
			foreach (var path in args.Skip(1))
			{
				Console.WriteLine("Loading {0}...", path);

				// Load the cache file
				var info = new OpenTagCache {CacheFile = new FileInfo(path)};
				using (var stream = info.OpenCacheRead())
					info.Cache = new TagCache(stream);

				// Do version detection, and don't accept the closest version
				// because that might not work
				EngineVersion closestVersion;
				info.Version = VersionDetection.DetectVersion(info.Cache, out closestVersion);
				if (info.Version == EngineVersion.Unknown)
				{
					Console.WriteLine("- Unrecognized version! Ignoring.");
					continue;
				}
				info.Deserializer = new TagDeserializer(info.Version);
				infos.Add(info);
			}

			var result = new TagVersionMap();
			using (var baseStream = _info.OpenCacheRead())
			{
				// Get the scenario tags for this cache
				Console.WriteLine("Finding base scenario tags...");
				var baseScenarios = FindScenarios(_info, baseStream);
				var baseVersion = _info.Version;
				var baseTagData = new Dictionary<int, object>();
				foreach (var scenario in baseScenarios)
					baseTagData[scenario.Tag.Index] = scenario.Data;

				// Now compare with each of the other caches
				foreach (var info in infos)
				{
					using (var stream = info.OpenCacheRead())
					{
						Console.WriteLine("Finding scenario tags in {0}...", info.CacheFile.FullName);

						// Get the scenario tags and connect them to the base tags
						var scenarios = FindScenarios(info, stream);
						var tagsToCompare = new Queue<QueuedTag>();
						for (var i = 0; i < scenarios.Count; i++)
						{
							tagsToCompare.Enqueue(scenarios[i]);
							result.Add(baseVersion, baseScenarios[i].Tag.Index, info.Version, scenarios[i].Tag.Index);
						}

						// Process each tag in the queue, enqueuing all of its dependencies as well
						while (tagsToCompare.Count > 0)
						{
							// Get the tag and its data
							var tag = tagsToCompare.Dequeue();
							TagPrinter.PrintTagShort(tag.Tag);
							var data = tag.Data;
							if (data == null)
							{
								// No data yet - deserialize it
								var context = new TagSerializationContext(stream, info.Cache, tag.Tag);
								var type = TagStructureTypes.FindByGroupTag(tag.Tag.GroupTag);
								data = info.Deserializer.Deserialize(context, type);
							}

							// Now get the data for the base tag
							var baseTag = result.Translate(info.Version, tag.Tag.Index, baseVersion);
							if (baseTag == -1 || _info.Cache.Tags[baseTag].GroupTag != tag.Tag.GroupTag)
								continue;
							object baseData;
							if (!baseTagData.TryGetValue(baseTag, out baseData))
							{
								// No data yet - deserialize it
								var context = new TagSerializationContext(baseStream, _info.Cache, _info.Cache.Tags[baseTag]);
								var type = TagStructureTypes.FindByGroupTag(tag.Tag.GroupTag);
								baseData = _info.Deserializer.Deserialize(context, type);
								baseTagData[baseTag] = baseData;
							}

							// Compare the two blocks
							CompareBlocks(baseData, baseVersion, data, info.Version, result, tagsToCompare);
						}
					}
				}
			}

			// Write out the CSV
			Console.WriteLine("Writing results...");
			using (var writer = new StreamWriter(File.Open(outputPath, FileMode.Create, FileAccess.Write)))
				result.WriteCsv(writer);

			Console.WriteLine("Done!");
			return true;
		}

		private static void CompareBlocks(object leftData, EngineVersion leftVersion, object rightData, EngineVersion rightVersion, TagVersionMap result, Queue<QueuedTag> tagQueue)
		{
			if (leftData == null || rightData == null)
				return;
			var type = leftData.GetType();
			if (type == typeof(HaloTag))
			{
				// If the objects are tags, then we've found a match
				var leftTag = (HaloTag)leftData;
				var rightTag = (HaloTag)rightData;
				if (leftTag.GroupTag != rightTag.GroupTag || result.Translate(leftVersion, leftTag.Index, rightVersion) >= 0)
					return;
				result.Add(leftVersion, leftTag.Index, rightVersion, rightTag.Index);
				tagQueue.Enqueue(new QueuedTag { Tag = rightTag });
			}
			else if (type.IsArray)
			{
				// If the objects are arrays, then loop through each element
				var leftArray = (Array)leftData;
				var rightArray = (Array)rightData;
				if (leftArray.Length != rightArray.Length)
					return; // If the sizes are different, we probably can't compare them
				for (var i = 0; i < leftArray.Length; i++)
					CompareBlocks(leftArray.GetValue(i), leftVersion, rightArray.GetValue(i), rightVersion, result, tagQueue);
			}
			else if (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(List<>))
			{
				// If the objects are lists, then loop through each element
				var countProperty = type.GetProperty("Count");
				var leftCount = (int)countProperty.GetValue(leftData);
				var rightCount = (int)countProperty.GetValue(rightData);
				if (leftCount != rightCount)
					return; // If the sizes are different, we probably can't compare them
				var getItem = type.GetMethod("get_Item");
				for (var i = 0; i < leftCount; i++)
				{
					var leftItem = getItem.Invoke(leftData, new object[]{ i });
					var rightItem = getItem.Invoke(rightData, new object[] { i });
					CompareBlocks(leftItem, leftVersion, rightItem, rightVersion, result, tagQueue);
				}
			}
			else if (type.GetCustomAttributes(typeof(TagStructureAttribute), false).Length > 0)
			{
				// The objects are structures
				var left = new TagFieldEnumerator(new TagStructureInfo(leftData.GetType(), leftVersion));
				var right = new TagFieldEnumerator(new TagStructureInfo(rightData.GetType(), rightVersion));
				while (left.Next() && right.Next())
				{
					// Keep going on the left until the field is on the right
					while (!VersionDetection.IsBetween(rightVersion, left.MinVersion, left.MaxVersion))
					{
						if (!left.Next())
							return;
					}

					// Keep going on the right until the field is on the left
					while (!VersionDetection.IsBetween(leftVersion, right.MinVersion, right.MaxVersion))
					{
						if (!right.Next())
							return;
					}
					if (left.Field.MetadataToken != right.Field.MetadataToken)
						throw new InvalidOperationException("WTF, left and right fields don't match!");

					// Process the fields
					var leftFieldData = left.Field.GetValue(leftData);
					var rightFieldData = right.Field.GetValue(rightData);
					CompareBlocks(leftFieldData, leftVersion, rightFieldData, rightVersion, result, tagQueue);
				}
			}
		}

		private static List<QueuedTag> FindScenarios(OpenTagCache info, Stream stream)
		{
			// Get a dictionary of scenarios by map ID
			var scenarios = new Dictionary<int, QueuedTag>();
			foreach (var scenarioTag in info.Cache.Tags.FindAllInGroup("scnr"))
			{
				var context = new TagSerializationContext(stream, info.Cache, scenarioTag);
				var scenario = info.Deserializer.Deserialize<Scenario>(context);
				scenarios[scenario.MapId] = new QueuedTag { Tag = scenarioTag, Data = scenario };
			}

			// Get the ones to actually compare
			return MapIdsToCompare.Select(id => scenarios[id]).ToList();
		}

		private class QueuedTag
		{
			public HaloTag Tag { get; set; }

			public object Data { get; set; }
		}
	}
}
