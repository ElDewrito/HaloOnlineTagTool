﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Layouts
{
    /// <summary>
    /// A basic field in a tag layout.
    /// </summary>
    public class BasicTagLayoutField : TagLayoutField
    {
        public BasicTagLayoutField(string name, BasicFieldType type)
            : base(name)
        {
            Type = type;
        }

        /// <summary>
        /// Gets or sets the field's type.
        /// </summary>
        public BasicFieldType Type { get; set; }

        public override void Accept(ITagLayoutFieldVisitor visitor)
        {
            visitor.Visit(this);
        }
    }

    /// <summary>
    /// Basic field types that can appear in tag layouts.
    /// </summary>
    public enum BasicFieldType
    {
        Int8,
        UInt8,
        Int16,
        UInt16,
        Int32,
        UInt32,
        Float32,
        Vector2,
        Vector3,
        Vector4,
        Angle,
        StringId,
        TagReference,
        ShortTagReference, // Tag reference which is just a 4-byte index
        DataReference,
        ResourceReference
    }
}
