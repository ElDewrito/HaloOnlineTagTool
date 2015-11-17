using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// Utility class for analyzing a tag structure type's inheritance hierarchy.
	/// </summary>
	public class TagStructureInfo
	{
		/// <summary>
		/// Constructs a <see cref="TagStructureInfo"/> object which contains info about a tag structure type.
		/// </summary>
		/// <param name="structureType">The tag structure type to analyze.</param>
		public TagStructureInfo(Type structureType)
			: this(structureType, EngineVersion.Unknown)
		{
		}

		/// <summary>
		/// Constructs a <see cref="TagStructureInfo"/> object which contains info about a tag structure type.
		/// </summary>
		/// <param name="structureType">The tag structure type to analyze.</param>
		/// <param name="version">The engine version to compare attributes against.</param>
		public TagStructureInfo(Type structureType, EngineVersion version)
		{
			Version = version;
			GroupTag = new MagicNumber(-1);
			ParentGroupTag = new MagicNumber(-1);
			GrandparentGroupTag = new MagicNumber(-1);
			Analyze(structureType, version);
		}

		/// <summary>
		/// Gets the engine version that was used to construct the info object.
		/// </summary>
		public EngineVersion Version { get; private set; }

		/// <summary>
		/// Gets the structure types in the structure's inheritance hierarchy in order from child to base.
		/// Types which do not have a matching TagStructure attribute will not be included in this list.
		/// </summary>
		public List<Type> Types { get; private set; }

		/// <summary>
		/// Gets the total size of the structure, including parent structures.
		/// </summary>
		public uint TotalSize { get; private set; }

		/// <summary>
		/// Gets the current <see cref="TagStructureAttribute"/>.
		/// </summary>
		public TagStructureAttribute Structure { get; private set; }

		/// <summary>
		/// Gets the group tag for the structure, or -1 if none.
		/// </summary>
		public MagicNumber GroupTag { get; private set; }

		/// <summary>
		/// Gets the parent group tag for the structure, or -1 if none.
		/// </summary>
		public MagicNumber ParentGroupTag { get; private set; }

		/// <summary>
		/// Gets the grandparent group tag for the structure, or -1 if none.
		/// </summary>
		public MagicNumber GrandparentGroupTag { get; private set; }

		private void Analyze(Type mainType, EngineVersion version)
		{
			// Get the attribute for the main structure type
			Structure = GetStructureAttribute(mainType, version);
			if (Structure == null)
				throw new InvalidOperationException("No TagStructure attribute which matches the target version was found on " + mainType.Name);

			// Scan through the type's inheritance hierarchy and analyze each TagStructure attribute
			var currentType = mainType;
			Types = new List<Type>();
			while (currentType != null)
			{
				var attrib = (currentType != mainType) ? GetStructureAttribute(currentType, version) : Structure;
				if (attrib != null)
				{
					Types.Add(currentType);
					TotalSize += attrib.Size;
					if (attrib.Class != null)
					{
						if (GroupTag.Value == -1)
							GroupTag = new MagicNumber(attrib.Class);
						else if (ParentGroupTag.Value == -1)
							ParentGroupTag = new MagicNumber(attrib.Class);
						else if (GrandparentGroupTag.Value == -1)
							GrandparentGroupTag = new MagicNumber(attrib.Class);
					}
				}
				currentType = currentType.BaseType;
			}
		}

		private static TagStructureAttribute GetStructureAttribute(Type type, EngineVersion version)
		{
			// First match against any TagStructureAttributes that have version restrictions
			var attrib = type.GetCustomAttributes(typeof(TagStructureAttribute), false)
				.Cast<TagStructureAttribute>()
				.Where(a => a.MinVersion != EngineVersion.Unknown || a.MaxVersion != EngineVersion.Unknown)
				.FirstOrDefault(a => VersionDetection.IsBetween(version, a.MinVersion, a.MaxVersion));

			// If nothing was found, find the first attribute without any version restrictions
			return attrib ?? type.GetCustomAttributes(typeof(TagStructureAttribute), false)
				.Cast<TagStructureAttribute>()
				.FirstOrDefault(a => a.MinVersion == EngineVersion.Unknown && a.MaxVersion == EngineVersion.Unknown);
		}
	}
}
