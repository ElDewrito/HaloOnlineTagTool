﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool
{
    /// <summary>
    /// Describes the type of data in a tag.
    /// </summary>
    public struct TagGroup : IEquatable<TagGroup>
    {
        /// <summary>
        /// Constructs a new tag group description.
        /// </summary>
        /// <param name="tag">The group's tag.</param>
        /// <param name="parentTag">The parent group's tag. Can be -1.</param>
        /// <param name="grandparentTag">The grandparent group's tag. Can be -1.</param>
        /// <param name="name">The group's name stringID.</param>
        public TagGroup(Tag tag, Tag parentTag, Tag grandparentTag, StringId name)
        {
            Tag = tag;
            ParentTag = parentTag;
            GrandparentTag = grandparentTag;
            Name = name;
        }

        /// <summary>
        /// Represents a "null" tag group.
        /// </summary>
        public static readonly TagGroup Null = new TagGroup(new Tag(-1), new Tag(-1), new Tag(-1), StringId.Null);

        /// <summary>
        /// Gets the group's tag. Can be -1.
        /// </summary>
        public readonly Tag Tag;

        /// <summary>
        /// Gets the parent group's tag. Can be -1.
        /// </summary>
        public readonly Tag ParentTag;

        /// <summary>
        /// Gets the grandparent group's tag. Can be -1.
        /// </summary>
        public readonly Tag GrandparentTag;

        /// <summary>
        /// Gets the group's name stringID.
        /// </summary>
        public readonly StringId Name;

        /// <summary>
        /// Determines whether this group is a subgroup of another group.
        /// </summary>
        /// <param name="group">The group to check.</param>
        /// <returns><c>true</c> if this group is a subgroup of the other group.</returns>
        public bool BelongsTo(TagGroup group)
        {
            return BelongsTo(group.Tag);
        }

        /// <summary>
        /// Determines whether this group is a subgroup of another group.
        /// </summary>
        /// <param name="groupTag">The group tag to check, as a 4-character string.</param>
        /// <returns><c>true</c> if this group is a subgroup of the group tag.</returns>
        public bool BelongsTo(string groupTag)
        {
            return BelongsTo(new Tag(groupTag));
        }

        /// <summary>
        /// Determines whether this group is a subgroup of another group.
        /// </summary>
        /// <param name="groupTag">The group tag to check.</param>
        /// <returns><c>true</c> if this group is a subgroup of the group tag.</returns>
        public bool BelongsTo(Tag groupTag)
        {
            return Tag == groupTag || ParentTag == groupTag || GrandparentTag == groupTag;
        }

        public bool Equals(TagGroup other)
        {
            return Tag == other.Tag && ParentTag == other.ParentTag && GrandparentTag == other.GrandparentTag &&
                   Name == other.Name;
        }

        public override bool Equals(object obj)
        {
            return obj is TagGroup && Equals((TagGroup)obj);
        }

        public static bool operator ==(TagGroup lhs, TagGroup rhs)
        {
            return lhs.Equals(rhs);
        }

        public static bool operator !=(TagGroup lhs, TagGroup rhs)
        {
            return !(lhs == rhs);
        }

        public override int GetHashCode()
        {
            var result = 13;
            result = result * 17 + Tag.GetHashCode();
            result = result * 17 + ParentTag.GetHashCode();
            result = result * 17 + GrandparentTag.GetHashCode();
            result = result * 17 + Name.GetHashCode();
            return result;
        }

        public override string ToString() => Tag.ToString();
    }
}
