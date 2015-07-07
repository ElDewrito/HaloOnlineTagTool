using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
	public class CppStructWriter : ITagLayoutWriter
	{
		private readonly StringIdCache _stringIds;
		private readonly string _outDir;
		private TextWriter _writer;
		private StructBuilder _builder;

		public CppStructWriter(StringIdCache stringIds, string outDir)
		{
			_stringIds = stringIds;
			_outDir = outDir;
		}

		public void Begin(MagicNumber tagClass, int classStringId, TagLayoutGuess layout)
		{
			if (_writer != null)
				throw new InvalidOperationException("Cannot begin a new tag while another is still in progress");

			// Convert the class name to a pascal case string and use that as the file name
			var name = _stringIds.GetString(classStringId);
			if (string.IsNullOrEmpty(name))
				throw new InvalidOperationException("Unable to look up the tag class name");
			name = ConvertToPascalCase(name);
			var path = Path.Combine(_outDir, name + ".hpp");
			_writer = new StreamWriter(File.Open(path, FileMode.Create, FileAccess.Write));

			// Write the C++ header
			_writer.WriteLine("#pragma once");
			_writer.WriteLine("#include \"Tags.hpp\"");
			_writer.WriteLine();
			_writer.WriteLine("namespace Blam");
			_writer.WriteLine("{");
			_writer.WriteLine("\tnamespace Tags");
			_writer.WriteLine("\t{");

			_builder = new StructBuilder(_writer, 2, name);
			_builder.Begin(tagClass, classStringId, layout);
		}

		public void AddUnknownByte(uint offset)
		{
			_builder.AddUnknownByte(offset);
		}

		public void AddUnknownInt16(uint offset)
		{
			_builder.AddUnknownInt16(offset);
		}

		public void AddUnknownInt32(uint offset)
		{
			_builder.AddUnknownInt32(offset);
		}

		public void AddGuess(uint offset, ITagElementGuess guess)
		{
			_builder.AddGuess(offset, guess);
		}

		public void End()
		{
			_builder.End();
			_writer.WriteLine("\t}");
			_writer.WriteLine("}");
			_writer.Close();
			_writer = null;
		}

		private static string ConvertToPascalCase(string name)
		{
			var result = new StringBuilder();
			var uppercase = true;
			foreach (var ch in name)
			{
				if (ch != '_')
				{
					result.Append(uppercase ? char.ToUpperInvariant(ch) : ch);
					uppercase = false;
				}
				else
				{
					uppercase = true;
				}
			}
			return result.ToString();
		}

		private class StructBuilder : ITagLayoutWriter, ITagElementGuessVisitor
		{
			private readonly TextWriter _writer;
			private string _indent;
			private int _indentLevel;
			private readonly string _name;
			private int _nextUnknownBlock;
			private readonly StringWriter _fields = new StringWriter();
			private readonly Queue<string> _subBlocks = new Queue<string>();
			private uint _size;

			public StructBuilder(TextWriter writer, int indent, string name)
			{
				_writer = writer;
				_name = name;
				SetIndent(indent);
			}

			public void Begin(MagicNumber tagClass, int classStringId, TagLayoutGuess layout)
			{
				_size = layout.Size;
				if (tagClass.Value != 0)
					_writer.WriteLine("{0}struct {1} : Tag<'{2}'>", _indent, _name, tagClass);
				else
					_writer.WriteLine("{0}struct {1}", _indent, _name);
				_writer.WriteLine("{0}{{", _indent);
				SetIndent(_indentLevel + 1);
			}

			public void AddGuess(uint offset, ITagElementGuess guess)
			{
				guess.Accept(offset, this);
			}

			public void AddUnknownByte(uint offset)
			{
				AddUnknown(offset, "uint8_t");
			}

			public void AddUnknownInt16(uint offset)
			{
				AddUnknown(offset, "int16_t");
			}

			public void AddUnknownInt32(uint offset)
			{
				AddUnknown(offset, "int");
			}

			void ITagElementGuessVisitor.Visit(uint offset, TagBlockGuess guess)
			{
				var structName = string.Format("TagBlock{0}", _nextUnknownBlock++);
				_writer.WriteLine("{0}struct {1};", _indent, structName);
				using (var blockWriter = new StringWriter())
				{
					var blockBuilder = new StructBuilder(blockWriter, _indentLevel, structName);
					blockBuilder._nextUnknownBlock = _nextUnknownBlock;
					LayoutGuessWriter.Write(null, guess.ElementLayout, blockBuilder);
					_subBlocks.Enqueue(blockWriter.ToString());
					_nextUnknownBlock = blockBuilder._nextUnknownBlock;
				}
				AddUnknown(offset, string.Format("TagBlock<{0}>", structName));
			}

			void ITagElementGuessVisitor.Visit(uint offset, DataReferenceGuess guess)
			{
				AddUnknown(offset, "DataReference<uint8_t>");
			}

			void ITagElementGuessVisitor.Visit(uint offset, TagReferenceGuess guess)
			{
				AddUnknown(offset, "TagReference");
			}

			void ITagElementGuessVisitor.Visit(uint offset, ResourceReferenceGuess guess)
			{
				AddUnknown(offset, "void*");
			}

			public void End()
			{
				if (_subBlocks.Count > 0)
					_writer.WriteLine();
				_writer.Write(_fields.ToString());

				// Put tag block definitions at the end
				while (_subBlocks.Count > 0)
				{
					_writer.WriteLine();
					_writer.Write(_subBlocks.Dequeue());
				}

				SetIndent(_indentLevel - 1);
				_writer.WriteLine("{0}}};", _indent);
				_writer.WriteLine("{0}TAG_STRUCT_SIZE_ASSERT({1}, 0x{2:X});", _indent, _name, _size);
			}

			private void AddUnknown(uint offset, string type)
			{
				_fields.WriteLine("{0}{1} Unknown{2:X};", _indent, type, offset);
			}

			private void SetIndent(int level)
			{
				_indentLevel = level;
				_indent = new string('\t', level);
			}
		}
	}
}
