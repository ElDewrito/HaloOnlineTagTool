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
		/// Finds the first tag with a given class.
		/// </summary>
		/// <param name="tagClass">The tag class.</param>
		/// <returns>The first tag with the given class, or <c>null</c> otherwise.</returns>
		public HaloTag FindFirstByClass(MagicNumber tagClass)
		{
			return _tags.FirstOrDefault(t => t != null && (t.Class == tagClass || t.ParentClass == tagClass || t.GrandparentClass == tagClass));
		}

		/// <summary>
		/// Finds the first tag with a given class.
		/// </summary>
		/// <param name="tagClass">The tag class as a string.</param>
		/// <returns>The first tag with the given class, or <c>null</c> otherwise.</returns>
		public HaloTag FindFirstByClass(string tagClass)
		{
			return FindFirstByClass(new MagicNumber(tagClass));
		}

		/// <summary>
		/// Finds all tags with a given class.
		/// </summary>
		/// <param name="tagClass">The tag class.</param>
		/// <returns>All tags with the given class.</returns>
		public IEnumerable<HaloTag> FindAllByClass(MagicNumber tagClass)
		{
			return _tags.Where(t => t != null && (t.Class == tagClass || t.ParentClass == tagClass || t.GrandparentClass == tagClass));
		}

		/// <summary>
		/// Finds all tags with a given class.
		/// </summary>
		/// <param name="tagClass">The tag class as a string.</param>
		/// <returns>All tags with the given class.</returns>
		public IEnumerable<HaloTag> FindAllByClass(string tagClass)
		{
			return FindAllByClass(new MagicNumber(tagClass));
		}

		/// <summary>
		/// Finds all tags whose class is in a set of classes.
		/// </summary>
		/// <param name="tagClasses">The tag classes.</param>
		/// <returns>All tags with a matching class.</returns>
		public IEnumerable<HaloTag> FindAllByClasses(ICollection<MagicNumber> tagClasses)
		{
			return _tags.Where(t => t != null && (tagClasses.Contains(t.Class) || tagClasses.Contains(t.ParentClass) || tagClasses.Contains(t.GrandparentClass)));
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
