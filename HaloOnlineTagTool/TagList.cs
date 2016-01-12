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
    public class TagList : IEnumerable<TagInstance>
    {
        private readonly IList<TagInstance> _tags;

        /// <summary>
        /// Constructs a tag list which wraps a list of tags.
        /// </summary>
        /// <param name="tags">The list of tags to wrap.</param>
        public TagList(IList<TagInstance> tags)
        {
            _tags = tags;
        }

        /// <summary>
        /// Gets the number of tags in the list.
        /// </summary>
        public int Count => _tags.Count;

        /// <summary>
        /// Determines whether a tag is in the list.
        /// </summary>
        /// <param name="tag">The tag.</param>
        /// <returns><c>true</c> if the tag is in the list.</returns>
        public bool Contains(TagInstance tag)
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
        /// Gets the <see cref="TagInstance"/> with a specified index.
        /// </summary>
        /// <param name="index">The index.</param>
        /// <returns>The corresponding tag. Can be <c>null</c>.</returns>
        public TagInstance this[int index] => _tags[index];

        /// <summary>
        /// Finds the first tag in a given group.
        /// </summary>
        /// <param name="groupTag">The group tag.</param>
        /// <returns>The first tag in the given group, or <c>null</c> otherwise.</returns>
        public TagInstance FindFirstInGroup(Tag groupTag)
        {
            return NonNull().FirstOrDefault(t => t.IsInGroup(groupTag));
        }

        /// <summary>
        /// Finds the first tag in a given group.
        /// </summary>
        /// <param name="groupTag">The group tag as a string.</param>
        /// <returns>The first tag in the given group, or <c>null</c> otherwise.</returns>
        public TagInstance FindFirstInGroup(string groupTag)
        {
            return FindFirstInGroup(new Tag(groupTag));
        }

        /// <summary>
        /// Finds the first tag in a given group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>The first tag in the given group, or <c>null</c> otherwise.</returns>
        public TagInstance FindFirstInGroup(TagGroup group)
        {
            return FindFirstInGroup(group.Tag);
        }

        /// <summary>
        /// Finds all tags in a given group.
        /// </summary>
        /// <param name="groupTag">The group tag.</param>
        /// <returns>All tags in the given group.</returns>
        public IEnumerable<TagInstance> FindAllInGroup(Tag groupTag)
        {
            return NonNull().Where(t => t.IsInGroup(groupTag));
        }

        /// <summary>
        /// Finds all tags in a given group.
        /// </summary>
        /// <param name="groupTag">The group tag as a string.</param>
        /// <returns>All tags in the given group.</returns>
        public IEnumerable<TagInstance> FindAllInGroup(string groupTag)
        {
            return FindAllInGroup(new Tag(groupTag));
        }

        /// <summary>
        /// Finds all tags in a given group.
        /// </summary>
        /// <param name="group">The group.</param>
        /// <returns>All tags in the given group.</returns>
        public IEnumerable<TagInstance> FindAllInGroup(TagGroup group)
        {
            return FindAllInGroup(group.Tag);
        }

        /// <summary>
        /// Finds all tags belonging to at least one group in a collection of groups.
        /// </summary>
        /// <param name="groupTags">The group tags.</param>
        /// <returns>All tags which belong to at least one of the groups.</returns>
        public IEnumerable<TagInstance> FindAllInGroups(ICollection<Tag> groupTags)
        {
            return NonNull().Where(t => groupTags.Contains(t.Group.Tag) || groupTags.Contains(t.Group.ParentTag) || groupTags.Contains(t.Group.GrandparentTag));
        }

        /// <summary>
        /// Retrieves a set of all tags that a given tag depends on.
        /// </summary>
        /// <param name="tag">The tag to scan.</param>
        /// <returns>A set of all tags that the tag depends on.</returns>
        public HashSet<TagInstance> FindDependencies(TagInstance tag)
        {
            var result = new HashSet<TagInstance>();
            FindDependencies(result, tag);
            return result;
        }

        /// <summary>
        /// Retrieves an enumerable collection of tags which are not null.
        /// This should be preferred over doing this manually because it also skips tags that are in the process of being created.
        /// </summary>
        /// <returns>A collection of tags which are not null.</returns>
        public IEnumerable<TagInstance> NonNull()
        {
            return _tags.Where(t => t != null && t.HeaderOffset >= 0);
        }

        private void FindDependencies(ISet<TagInstance> results, TagInstance tag)
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

        public IEnumerator<TagInstance> GetEnumerator()
        {
            return _tags.GetEnumerator();
        }

        System.Collections.IEnumerator System.Collections.IEnumerable.GetEnumerator()
        {
            return ((System.Collections.IEnumerable)_tags).GetEnumerator();
        }
    }
}
