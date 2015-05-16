using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Resources;

namespace HaloOnlineTagTool.Serialization
{
	/// <summary>
	/// A serialization context for serializing and deserializing tags.
	/// </summary>
	public class TagSerializationContext : ISerializationContext
	{
		private const uint AddressMagic = 0x40000000;
		private const int DefaultBlockAlign = 4;

		private readonly Stream _stream;
		private readonly TagCache _cache;
		private readonly HaloTag _tag;

		private readonly List<TagFixup> _dataFixups = new List<TagFixup>();
		private readonly List<TagFixup> _resourceFixups = new List<TagFixup>();
		private readonly HashSet<int> _dependencies = new HashSet<int>();

		public TagSerializationContext(Stream stream, TagCache cache, HaloTag tag)
		{
			_stream = stream;
			_cache = cache;
			_tag = tag;
		}

		public void BeginSerialize()
		{
			_dataFixups.Clear();
			_resourceFixups.Clear();
			_dependencies.Clear();
		}

		public void EndSerialize(byte[] data, uint mainStructOffset)
		{
			_tag.DataFixups.Clear();
			_tag.ResourceFixups.Clear();
			_tag.Dependencies.Clear();
			_tag.DataFixups.AddRange(_dataFixups);
			_tag.ResourceFixups.AddRange(_resourceFixups);
			_tag.Dependencies.UnionWith(_dependencies);
			_tag.MainStructOffset = mainStructOffset;
			_cache.OverwriteTag(_stream, _tag, data);
			_cache.UpdateTag(_stream, _tag);
		}

		public BinaryReader BeginDeserialize()
		{
			var data = _cache.ExtractTag(_stream, _tag);
			var reader = new BinaryReader(new MemoryStream(data));
			reader.BaseStream.Position = _tag.MainStructOffset;
			return reader;
		}

		public void EndDeserialize(object obj)
		{
		}

		public uint AddressToOffset(uint currentOffset, uint address)
		{
			// TODO: Actually use the fixup information in the tag
			return address - AddressMagic;
		}

		public HaloTag GetTagByIndex(int index)
		{
			return (index >= 0 && index < _cache.Tags.Count) ? _cache.Tags[index] : null;
		}

		public IDataBlock CreateBlock()
		{
			return new TagDataBlock(this);
		}

		private class TagDataBlock : IDataBlock
		{
			private readonly TagSerializationContext _context;
			private readonly List<TagFixup> _fixups = new List<TagFixup>();
			private readonly List<TagFixup> _resourceFixups = new List<TagFixup>(); 

			public TagDataBlock(TagSerializationContext context)
			{
				_context = context;
				Stream = new MemoryStream();
				Writer = new BinaryWriter(Stream);
			}

			public MemoryStream Stream { get; private set; }

			public BinaryWriter Writer { get; private set; }

			public void WritePointer(uint targetOffset, Type type)
			{
				// Add a data fixup for the pointer
				var fixup = MakeFixup(targetOffset);
				_fixups.Add(fixup);

				// Add a resource fixup if this is a resource reference
				if (type == typeof(ResourceReference))
					_resourceFixups.Add(fixup);

				// Write the address
				Writer.Write(targetOffset + AddressMagic);
			}

			public object PreSerialize(TagElementAttribute info, object obj)
			{
				if (obj == null)
					return null;

				// Get the object type and make sure it's supported
				var type = obj.GetType();
				if (type == typeof(ResourceDataReference) || (type.IsGenericType && type.GetGenericTypeDefinition() == typeof(D3DPointer<>)))
					throw new InvalidOperationException(type + " cannot be serialized as tag data");

				if (type == typeof(HaloTag))
				{
					// Object is a tag reference - add it as a dependency
					var referencedTag = obj as HaloTag;
					if (referencedTag != null)
						_context._dependencies.Add(referencedTag.Index);
				}
				return obj;
			}

			public uint Finalize(Stream outStream)
			{
				// Write the data out, aligning the offset and size
				StreamUtil.Align(outStream, DefaultBlockAlign);
				var dataOffset = (uint)outStream.Position;
				outStream.Write(Stream.GetBuffer(), 0, (int)Stream.Length);
				StreamUtil.Align(outStream, DefaultBlockAlign);

				// Adjust fixups and add them to the tag
				_context._dataFixups.AddRange(_fixups.Select(f => FinalizeFixup(f, dataOffset)));
				_context._resourceFixups.AddRange(_resourceFixups.Select(f => FinalizeFixup(f, dataOffset)));

				// Free the block data
				Writer.Close();
				Stream = null;
				Writer = null;
				return dataOffset;
			}

			private TagFixup MakeFixup(uint targetOffset)
			{
				return new TagFixup
				{
					TargetOffset = targetOffset,
					WriteOffset = (uint)Stream.Position
				};
			}

			private static TagFixup FinalizeFixup(TagFixup fixup, uint dataOffset)
			{
				return new TagFixup
				{
					TargetOffset = fixup.TargetOffset,
					WriteOffset = dataOffset + fixup.WriteOffset
				};
			}
		}
	}
}
