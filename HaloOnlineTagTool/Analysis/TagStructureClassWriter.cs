using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
    public class TagStructureClassWriter : ITagLayoutWriter
    {
        private readonly StringIdCache _stringIds;
        private readonly string _outDir;
	    private TextWriter _writer;
        private ClassBuilder _builder;

        public TagStructureClassWriter(StringIdCache stringIds, string outDir)
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
            var path = Path.Combine(_outDir, name + ".cs");
            _writer = new StreamWriter(File.Open(path, FileMode.Create, FileAccess.Write));

            // Write the C# header
            _writer.WriteLine("using System;");
            _writer.WriteLine("using System.Collections.Generic;");
            _writer.WriteLine("using System.Linq;");
            _writer.WriteLine("using System.Text;");
            _writer.WriteLine("using System.Threading.Tasks;");
            _writer.WriteLine("using HaloOnlineTagTool.Serialization;");
            _writer.WriteLine();
            _writer.WriteLine("namespace HaloOnlineTagTool.TagStructures");
            _writer.WriteLine("{");

            _builder = new ClassBuilder(_writer, 1, name);
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

        private class ClassBuilder : ITagLayoutWriter, ITagElementGuessVisitor
        {
            private readonly TextWriter _writer;
	        private string _indent;
	        private int _indentLevel;
			private readonly string _name;
	        private int _nextUnknownBlock;
			private readonly Queue<string> _subBlocks = new Queue<string>();

            public ClassBuilder(TextWriter writer, int indent, string name)
            {
	            _writer = writer;
	            _name = name;
				SetIndent(indent);
            }

			public void Begin(MagicNumber tagClass, int classStringId, TagLayoutGuess layout)
			{
				if (classStringId != 0)
					_writer.WriteLine("{0}[TagStructure(Class = \"{1}\", Size = 0x{2:X})]", _indent, tagClass, layout.Size);
				else
					_writer.WriteLine("{0}[TagStructure(Size = 0x{1:X})]", _indent, layout.Size);
				_writer.WriteLine("{0}public class {1}", _indent, _name);
				_writer.WriteLine("{0}{{", _indent);
				SetIndent(_indentLevel + 1);
			}

			public void AddGuess(uint offset, ITagElementGuess guess)
			{
				guess.Accept(offset, this);
			}

            public void AddUnknownByte(uint offset)
            {
				AddUnknown(offset, "byte");
            }

            public void AddUnknownInt16(uint offset)
            {
				AddUnknown(offset, "short");
            }

            public void AddUnknownInt32(uint offset)
            {
				AddUnknown(offset, "int");
            }

			void ITagElementGuessVisitor.Visit(uint offset, TagBlockGuess guess)
			{
				var className = string.Format("TagBlock{0}", _nextUnknownBlock++);
	            using (var blockWriter = new StringWriter())
	            {
		            var blockBuilder = new ClassBuilder(blockWriter, _indentLevel, className);
		            blockBuilder._nextUnknownBlock = _nextUnknownBlock;
		            LayoutGuessWriter.Write(null, guess.ElementLayout, blockBuilder);
					_subBlocks.Enqueue(blockWriter.ToString());
		            _nextUnknownBlock = blockBuilder._nextUnknownBlock;
	            }
				AddUnknown(offset, string.Format("List<{0}>", className));
            }

			void ITagElementGuessVisitor.Visit(uint offset, DataReferenceGuess guess)
            {
				AddUnknown(offset, "byte[]");
            }

			void ITagElementGuessVisitor.Visit(uint offset, TagReferenceGuess guess)
            {
                AddUnknown(offset, "HaloTag");
            }

	        void ITagElementGuessVisitor.Visit(uint offset, ResourceReferenceGuess guess)
	        {
		        AddUnknown(offset, "ResourceReference");
	        }

            public void End()
            {
				// Put tag block definitions at the end
	            while (_subBlocks.Count > 0)
	            {
					_writer.WriteLine();
		            _writer.Write(_subBlocks.Dequeue());
	            }

	            SetIndent(_indentLevel - 1);
                _writer.WriteLine("{0}}}", _indent);
            }

            private void AddUnknown(uint offset, string type)
            {
                _writer.WriteLine("{0}[TagElement]", _indent);
                _writer.WriteLine("{0}public {1} Unknown{2:X} {{ get; set; }}", _indent, type, offset);
            }

	        private void SetIndent(int level)
	        {
		        _indentLevel = level;
				_indent = new string('\t', level);
	        }
		}
	}
}
