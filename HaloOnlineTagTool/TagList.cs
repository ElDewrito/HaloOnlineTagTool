using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
	/// <summary>
	/// Wraps a list of tags.
	/// </summary>
	public class TagList : IEnumerable<HaloTag>
	{
		private readonly IList<HaloTag> _tags;

		/// <summary>
		/// Constructs a tag list which wraps a list of tags.
		/// </summary>
		/// <param name="tags">The list of tags to wrap.</param>
		public TagList(IList<HaloTag> tags)
		{
			_tags = tags;
		}

		/// <summary>
		/// Gets the number of tags in the list.
		/// </summary>
		public int Count
		{
			get { return _tags.Count; }
		}

		/// <summary>
		/// Determines whether a tag is in the list.
		/// </summary>
		/// <param name="tag">The tag.</param>
		/// <returns><c>true</c> if the tag is in the list.</returns>
		public bool Contains(HaloTag tag)
		{
			if (tag == null)
				throw new ArgumentNullException("tag");
			return (Contains(tag.Index) && _tags[tag.Index] == tag);
		}

		/// <summary>
		/// Determines whether a tag is in the list.
		/// </summary>
		/// <param name="index">The index of the tag to check.</param>
		/// <returns><c>true</c> if a tag with the given index is in the list.</returns>
		public bool Contains(int index)
		{
			return (index >= 0 && index < _tags.Count && _tags[index] != null);
		}

		/// <summary>
		/// Gets the <see cref="HaloTag"/> with a specified index.
		/// </summary>
		/// <param name="index">The index.</param>
		/// <returns>The corresponding tag. Can be <c>null</c>.</returns>
		public HaloTag this[int index]
		{
			get { return _tags[index]; }
		}

		/// <summary>
		/// Finds the first tag in a given group.
		/// </summary>
		/// <param name="groupTag">The group tag.</param>
		/// <returns>The first tag in the given group, or <c>null</c> otherwise.</returns>
		public HaloTag FindFirstInGroup(MagicNumber groupTag)
		{
			return _tags.FirstOrDefault(t => t != null && (t.GroupTag == groupTag || t.ParentGroupTag == groupTag || t.GrandparentGroupTag == groupTag));
		}

		/// <summary>
		/// Finds the first tag in a given group.
		/// </summary>
		/// <param name="groupTag">The group tag as a string.</param>
		/// <returns>The first tag in the given group, or <c>null</c> otherwise.</returns>
		public HaloTag FindFirstInGroup(string groupTag)
		{
			return FindFirstInGroup(new MagicNumber(groupTag));
		}

		/// <summary>
		/// Finds all tags in a given group.
		/// </summary>
		/// <param name="groupTag">The group tag.</param>
		/// <returns>All tags in the given group.</returns>
		public IEnumerable<HaloTag> FindAllInGroup(MagicNumber groupTag)
		{
			return _tags.Where(t => t != null && (t.GroupTag == groupTag || t.ParentGroupTag == groupTag || t.GrandparentGroupTag == groupTag));
		}

		/// <summary>
		/// Finds all tags in a given group.
		/// </summary>
		/// <param name="groupTag">The group tag as a string.</param>
		/// <returns>All tags in the given group.</returns>
		public IEnumerable<HaloTag> FindAllInGroup(string groupTag)
		{
			return FindAllInGroup(new MagicNumber(groupTag));
		}

		/// <summary>
		/// Finds all tags belonging to at least one group in a collection of groups.
		/// </summary>
		/// <param name="groupTags">The group tags.</param>
		/// <returns>All tags which belong to at least one of the groups.</returns>
		public IEnumerable<HaloTag> FindAllByClasses(ICollection<MagicNumber> groupTags)
		{
			return _tags.Where(t => t != null && (groupTags.Contains(t.GroupTag) || groupTags.Contains(t.ParentGroupTag) || groupTags.Contains(t.GrandparentGroupTag)));
		}

		/// <summary>
		/// Retrieves a set of all tags that a given tag depends on.
		/// </summary>
		/// <param name="tag">The tag to scan.</param>
		/// <returns>A set of all tags that the tag depends on.</returns>
		public HashSet<HaloTag> FindDependencies(HaloTag tag)
		{
			var result = new HashSet<HaloTag>();
			FindDependencies(result, tag);
			return result;
		}

		private void FindDependencies(ISet<HaloTag> results, HaloTag tag)
		{
			foreach (var index in tag.Dependencies)
			{
				if (!Contains(index))
					continue;
				var dependency = this[index];
				if (results.Contains(dependency))
					continue;
				results.Add(dependency);
				FindDependencies(results, dependency);
			}
		}

		public IEnumerator<HaloTag> GetEnumerator()
		{
			return _tags.GetEnumerator();
		}

		System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
		{
			return ((System.Collections.IEnumerable)_tags).GetEnumerator();
		}
	}
}
