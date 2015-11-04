using System;
using System.Data.Entity.Design.PluralizationServices;
using System.Globalization;
using System.Linq;
using System.Xml;

namespace HaloOnlineTagTool.Layouts
{
	public static class AssemblyPluginLoader
	{
		private static readonly PluralizationService Pluralization =
			PluralizationService.CreateService(new CultureInfo("en-US"));

		/// <summary>
		/// Parses an XML plugin into a <see cref="TagLayout"/>.
		/// </summary>
		/// <param name="reader">The XmlReader to read the plugin XML from.</param>
		/// <param name="name">The name to give the resulting layout.</param>
		/// <param name="groupTag">The group tag to give to the resulting layout.</param>
		/// <returns>The loaded layout.</returns>
		public static TagLayout LoadPlugin(XmlReader reader, string name, MagicNumber groupTag)
		{
			if (!reader.ReadToNextSibling("plugin"))
				throw new ArgumentException("The XML file is missing a <plugin> tag.");

			int baseSize = 0;
			if (reader.MoveToAttribute("baseSize"))
				baseSize = ParseInt(reader.Value);

			var result = new TagLayout(name, (uint)baseSize, groupTag);
			ReadElements(reader, true, result);
			return result;
		}

		private static void ReadElements(XmlReader reader, bool topLevel, TagLayout layout)
		{
			while (reader.Read())
			{
				if (reader.NodeType != XmlNodeType.Element) continue;
				if (topLevel)
					HandleTopLevelElement(reader, layout);
				else
					HandleElement(reader, layout);
			}
		}

		private static void HandleTopLevelElement(XmlReader reader, TagLayout layout)
		{
			if (reader.Name == "revisions")
			{
				// TODO: Revision support?
				/*if (visitor.EnterRevisions())
				{
					ReadRevisions(reader.ReadSubtree(), visitor);
					visitor.LeaveRevisions();
				}
				else
				{
					reader.Skip();
				}*/
				reader.Skip();
			}
			else
			{
				HandleElement(reader, layout);
			}
		}

		private static void HandleElement(XmlReader reader, TagLayout layout)
		{
			switch (reader.Name)
			{
				case "comment":
					ReadComment(reader, layout);
					break;
				default:
					HandleValueElement(reader, reader.Name, layout);
					break;
			}
		}

		private static void ReadComment(XmlReader reader, TagLayout layout)
		{
			/*string title = "Comment";

			if (reader.MoveToAttribute("title"))
				title = reader.Value;

			reader.MoveToElement();
			var xmlLineInfo = reader as IXmlLineInfo;
			if (xmlLineInfo == null) return;
			var pluginLine = (uint) xmlLineInfo.LineNumber;
			string text = reader.ReadElementContentAsString();
			layout.VisitComment(title, text, pluginLine);*/
		}

		/// <summary>
		/// Handles an element which describes how a value
		/// should be read from the cache file.
		/// </summary>
		/// <param name="reader">The XmlReader that read the element.</param>
		/// <param name="elementName">The element's name.</param>
		/// <param name="layout">The layout to add to.</param>
		private static void HandleValueElement(XmlReader reader, string elementName, TagLayout layout)
		{
			string name = "Unknown";
			uint offset = 0;
			var xmlLineInfo = reader as IXmlLineInfo;
			if (xmlLineInfo == null) return;
			var pluginLine = (uint) xmlLineInfo.LineNumber;
			bool visible = true;

			if (reader.MoveToAttribute("name"))
				name = reader.Value;
			if (reader.MoveToAttribute("offset"))
				offset = ParseUInt(reader.Value);
			if (reader.MoveToAttribute("visible"))
				visible = ParseBool(reader.Value);

			reader.MoveToElement();
			switch (elementName.ToLower()) // FIXME: Using ToLower() here violates XML standards
			{
				case "uint8":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.UInt8));
					break;
				case "int8":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.Int8));
					break;
				case "uint16":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.UInt16));
					break;
				case "int16":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.Int16));
					break;
				case "uint32":
					if (name.Contains("Resource Reference Address"))
						layout.Add(new BasicTagLayoutField(name.Replace(" Reference Address", ""), BasicFieldType.ResourceReference)); // hack
					else
						layout.Add(new BasicTagLayoutField(name, BasicFieldType.UInt32));
					break;
				case "int32":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.Int32));
					break;
				case "float32":
				case "float":
				case "undefined":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.Float32));
					break;
				case "vector3":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.Vector3));
					break;
				case "degree":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.Angle));
					break;
				case "stringid":
					layout.Add(new BasicTagLayoutField(name, BasicFieldType.StringId));
					break;
				case "tagref":
					ReadTagRef(reader, name, offset, visible, layout, pluginLine);
					break;

				case "range":
					ReadRange(reader, name, offset, visible, layout, pluginLine);
					break;

				case "ascii":
					ReadAscii(reader, name, offset, visible, layout, pluginLine);
					break;

				case "utf16":
					ReadUtf16(reader, name, offset, visible, layout, pluginLine);
					break;

				case "bitfield8":
					ReadBits(reader, name, BasicFieldType.UInt8, layout);
					break;
				case "bitfield16":
					ReadBits(reader, name, BasicFieldType.UInt16, layout);
					break;
				case "bitfield32":
					ReadBits(reader, name, BasicFieldType.UInt32, layout);
					break;

				case "enum8":
					ReadOptions(reader, name, BasicFieldType.Int8, layout);
					break;
				case "enum16":
					ReadOptions(reader, name, BasicFieldType.Int16, layout);
					break;
				case "enum32":
					ReadOptions(reader, name, BasicFieldType.Int32, layout);
					break;

					//case "color8": case "colour8":
					//case "color16": case "colour16":
				case "color":
				case "colour":
					layout.AddRange(ReadColorFormat(reader).Select(ch => new BasicTagLayoutField(name + " " + ch, BasicFieldType.UInt8)));
					break;
				case "color24":
				case "colour24":
					layout.AddRange("rgb".Select(ch => new BasicTagLayoutField(name + " " + ch, BasicFieldType.UInt8)));
					break;
				case "color32":
				case "colour32":
					layout.AddRange("argb".Select(ch => new BasicTagLayoutField(name + " " + ch, BasicFieldType.UInt8)));
					break;
				case "colorf":
				case "colourf":
					layout.AddRange(ReadColorFormat(reader).Select(ch => new BasicTagLayoutField(name + " " + ch, BasicFieldType.Float32)));
					break;

				case "dataref":
					ReadDataRef(reader, name, offset, visible, layout, pluginLine);
					break;

				case "reflexive":
					ReadReflexive(reader, name, offset, visible, layout, pluginLine);
					break;

				case "raw":
					ReadRaw(reader, name, offset, visible, layout, pluginLine);
					break;

				case "shader":
					ReadShader(reader, name, offset, visible, layout, pluginLine);
					break;

				case "uniclist":
					ReadUnicList(reader, name, offset, visible, layout, pluginLine);
					break;

				default:
					throw new ArgumentException("Unknown element \"" + elementName + "\"." + PositionInfo(reader));
			}
		}

		/*private static void ReadRevisions(XmlReader reader, TagLayout layout)
		{
			reader.ReadStartElement();
			while (reader.ReadToFollowing("revision"))
				layout.VisitRevision(ReadRevision(reader));
		}

		private static PluginRevision ReadRevision(XmlReader reader)
		{
			string author = "";
			int version = 1;

			if (reader.MoveToAttribute("author"))
				author = reader.Value;
			if (reader.MoveToAttribute("version"))
				version = ParseInt(reader.Value);

			reader.MoveToElement();
			string description = reader.ReadElementContentAsString();
			return new PluginRevision(author, version, description);
		}*/

		private static void ReadDataRef(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			string format = "bytes";

			if (reader.MoveToAttribute("format"))
				format = reader.Value;

			if (format != "bytes" &&
			    format != "unicode" &&
			    format != "asciiz")
				throw new ArgumentException("Invalid format. Must be either `bytes`, `unicode` or `asciiz`.");

			int align = 4;
			if (reader.MoveToAttribute("align"))
				align = ParseInt(reader.Value);

			layout.Add(new BasicTagLayoutField(name, BasicFieldType.DataReference));
		}

		private static void ReadRange(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			double min = 0.0;
			double max = 0.0;
			double largeChange = 0.0;
			double smallChange = 0.0;
			string type = "int32";

			if (reader.MoveToAttribute("min"))
				min = double.Parse(reader.Value);
			if (reader.MoveToAttribute("max"))
				max = double.Parse(reader.Value);
			if (reader.MoveToAttribute("smallStep"))
				smallChange = double.Parse(reader.Value);
			if (reader.MoveToAttribute("largeStep"))
				largeChange = double.Parse(reader.Value);
			if (reader.MoveToAttribute("type"))
				type = reader.Value.ToLower();

			layout.Add(new BasicTagLayoutField(name, BasicFieldType.Int32)); // TODO: support types other than int32
		}

		private static void ReadTagRef(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			bool showJumpTo = true;
			bool withClass = true;

			if (reader.MoveToAttribute("showJumpTo"))
				showJumpTo = ParseBool(reader.Value);
			if (reader.MoveToAttribute("withClass"))
				withClass = ParseBool(reader.Value);

			layout.Add(new BasicTagLayoutField(name, BasicFieldType.TagReference));
		}

		private static void ReadAscii(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			// Both "size" and "length" are accepted here because they are the same
			// with ASCII strings, but "size" should be preferred because it's less ambiguous
			// and <utf16> only supports "size"
			int size = 0;
			if (reader.MoveToAttribute("size") || reader.MoveToAttribute("length"))
				size = ParseInt(reader.Value);

			layout.Add(new StringTagLayoutField(name, size));
		}

		private static void ReadUtf16(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			int size = 0;
			if (reader.MoveToAttribute("size"))
				size = ParseInt(reader.Value);

			// TODO: Proper UTF-16 support (does HO use these?)
			layout.Add(new ArrayTagLayoutField(new BasicTagLayoutField(name, BasicFieldType.UInt8), size));
		}

		private static void ReadBits(XmlReader reader, string name, BasicFieldType type, TagLayout layout)
		{
			// TODO: Bitfield support
			layout.Add(new BasicTagLayoutField(name, type));

			/*XmlReader subtree = reader.ReadSubtree();

			subtree.ReadStartElement();
			while (subtree.ReadToNextSibling("bit"))
				ReadBit(subtree, layout);

			layout.LeaveBitfield();*/
			reader.Skip();
		}

		/*private static void ReadBit(XmlReader reader, TagLayout layout)
		{
			string name = "Unknown";

			if (reader.MoveToAttribute("name"))
				name = reader.Value;
			if (!reader.MoveToAttribute("index"))
				throw new ArgumentException("Bit definitions must have an index." + PositionInfo(reader));
			int index = ParseInt(reader.Value);

			layout.VisitBit(name, index);
		}*/

		private static void ReadOptions(XmlReader reader, string name, BasicFieldType type, TagLayout layout)
		{
			XmlReader subtree = reader.ReadSubtree();

			var enumLayout = new EnumLayout(name, type);
			subtree.ReadStartElement();
			while (subtree.ReadToNextSibling("option"))
				enumLayout.Add(ReadOption(subtree));

			layout.Add(new EnumTagLayoutField(name, enumLayout));
		}

		private static EnumValue ReadOption(XmlReader reader)
		{
			string name = "Unknown";
			int value = 0;

			if (reader.MoveToAttribute("name"))
				name = reader.Value;
			if (reader.MoveToAttribute("value"))
				value = ParseInt(reader.Value);

			return new EnumValue(name, value);
		}

		private static string ReadColorFormat(XmlReader reader)
		{
			if (!reader.MoveToAttribute("format"))
				throw new ArgumentException("Color tags must have a format attribute." + PositionInfo(reader));

			string format = reader.Value.ToLower();

			if (format.Any(ch => ch != 'r' && ch != 'g' && ch != 'b' && ch != 'a'))
				throw new ArgumentException("Invalid color format: \"" + format + "\"" + PositionInfo(reader));

			return format;
		}

		private static void ReadReflexive(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			if (!reader.MoveToAttribute("entrySize"))
				throw new ArgumentException("Reflexives must have an entrySize attribute." + PositionInfo(reader));

			uint entrySize = ParseUInt(reader.Value);
			int align = 4;
			if (reader.MoveToAttribute("align"))
				align = ParseInt(reader.Value);

			reader.MoveToElement();
			XmlReader subtree = reader.ReadSubtree();
			subtree.ReadStartElement();

			// Singularize the last word in the block name to get the layout name
			var words = name.Split(' ');
			words[words.Length - 1] = Pluralization.Singularize(words[words.Length - 1]);
			var layoutName = string.Join(" ", words);

			var elemLayout = new TagLayout(layoutName, entrySize);
			ReadElements(subtree, false, elemLayout);
			layout.Add(new TagBlockTagLayoutField(name, elemLayout));
		}

		private static void ReadRaw(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			if (!reader.MoveToAttribute("size"))
				throw new ArgumentException("Raw data blocks must have a size attribute." + PositionInfo(reader));
			int size = ParseInt(reader.Value);

			layout.Add(new ArrayTagLayoutField(new BasicTagLayoutField(name, BasicFieldType.UInt8), size));
		}

		private enum ShaderType
		{
			Pixel,
			Vertex
		}

		private static void ReadShader(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			/*if (!reader.MoveToAttribute("type"))
				throw new ArgumentException("Shaders must have a type attribute." + PositionInfo(reader));

			ShaderType type;
			if (reader.Value == "pixel")
				type = ShaderType.Pixel;
			else if (reader.Value == "vertex")
				type = ShaderType.Vertex;
			else
				throw new ArgumentException("Invalid shader type \"" + reader.Value + "\"");*/
			reader.Skip();

			// TODO: Shader support
			layout.Add(new BasicTagLayoutField(name, BasicFieldType.UInt32));
		}

		private static void ReadUnicList(XmlReader reader, string name, uint offset, bool visible, TagLayout layout,
			uint pluginLine)
		{
			if (!reader.MoveToAttribute("languages"))
				throw new ArgumentException("Unicode string lists must have a languages attribute." + PositionInfo(reader));
			int languages = ParseInt(reader.Value);

			layout.Add(new ArrayTagLayoutField(new BasicTagLayoutField(name, BasicFieldType.Int32), languages));
		}

		private static string PositionInfo(XmlReader reader)
		{
			var info = reader as IXmlLineInfo;
			return info != null ? string.Format(" Line {0}, position {1}.", info.LineNumber, info.LinePosition) : "";
		}

		private static int ParseInt(string str)
		{
			if (str.StartsWith("0x"))
				return int.Parse(str.Substring(2), NumberStyles.HexNumber);
			if (str.StartsWith("-0x"))
				return -int.Parse(str.Substring(3), NumberStyles.HexNumber);
			return int.Parse(str);
		}

		private static uint ParseUInt(string str)
		{
			return str.StartsWith("0x") ? uint.Parse(str.Substring(2), NumberStyles.HexNumber) : uint.Parse(str);
		}

		private static bool ParseBool(string str)
		{
			return (str == "1" || str.ToLower() == "true");
		}
	}
}