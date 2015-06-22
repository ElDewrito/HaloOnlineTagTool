using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
	/// <summary>
	/// Reads index buffer data.
	/// </summary>
	public class IndexBufferReader
	{
		private readonly BinaryReader _reader;
		private readonly IndexBufferFormat _format;
		private readonly long _baseOffset;
		private readonly uint _indexSize;

		/// <summary>
		/// Creates an index buffer reader on a stream.
		/// </summary>
		/// <param name="reader">The reader to use. It must point to the beginning of the index buffer.</param>
		/// <param name="format">The format of each index in the buffer.</param>
		public IndexBufferReader(BinaryReader reader, IndexBufferFormat format)
		{
			_reader = reader;
			_format = format;
			_baseOffset = _reader.BaseStream.Position;
			_indexSize = (format == IndexBufferFormat.UInt16) ? 2U : 4U;
		}

		/// <summary>
		/// Gets or sets the position of the stream in units of indexes.
		/// </summary>
		public uint Position
		{
			get { return (uint)(_reader.BaseStream.Position - _baseOffset) / _indexSize; }
			set { _reader.BaseStream.Position = _baseOffset + value * _indexSize; }
		}

		/// <summary>
		/// Reads an index and advances the stream.
		/// </summary>
		/// <returns>The index that was read.</returns>
		public uint ReadIndex()
		{
			return _format == IndexBufferFormat.UInt16 ? _reader.ReadUInt16() : _reader.ReadUInt32();
		}

		/// <summary>
		/// Reads indexes into an array and advances the stream.
		/// </summary>
		/// <param name="buffer">The buffer to read into.</param>
		/// <param name="offset">The offset into the buffer to start storing at.</param>
		/// <param name="count">The number of indexes to read.</param>
		public void ReadIndexes(uint[] buffer, uint offset, uint count)
		{
			for (var i = 0; i < count; i++)
				buffer[i + offset] = ReadIndex();
		}

		/// <summary>
		/// Reads an array of indexes.
		/// </summary>
		/// <param name="count">The number of indexes to read.</param>
		/// <returns>The indexes that were read.</returns>
		public uint[] ReadIndexes(uint count)
		{
			var result = new uint[count];
			ReadIndexes(result, 0, count);
			return result;
		}

		/// <summary>
		/// Reads a triangle strip and converts it into a triangle list.
		/// Degenerate triangles will be included and must be discarded manually.
		/// </summary>
		/// <param name="indexCount">The number of indexes in the strip. Cannot be 1 or 2.</param>
		/// <returns>The triangle strip converted into a triangle list.</returns>
		public uint[] ReadTriangleStrip(uint indexCount)
		{
			if (indexCount == 0)
				return new uint[0];
			if (indexCount < 3)
				throw new InvalidOperationException("Invalid triangle strip index buffer");

			var triangleCount = indexCount - 2;
			var result = new uint[triangleCount * 3];
			var previous = ReadIndexes(2);
			for (var i = 0; i < triangleCount; i++)
			{
				var index = ReadIndex();

				// Swap the order of the first two indices every other triangle
				// in order to preserve the winding order
				if (i % 2 == 0)
				{
					result[i * 3] = previous[0];
					result[i * 3 + 1] = previous[1];
				}
				else
				{
					result[i * 3] = previous[1];
					result[i * 3 + 1] = previous[0];
				}

				result[i * 3 + 2] = index;
				previous[0] = previous[1];
				previous[1] = index;
			}
			return result;
		}
	}

	/// <summary>
	/// Index buffer formats.
	/// </summary>
	public enum IndexBufferFormat
	{
		/// <summary>
		/// Each index is an unsigned 16-bit integer.
		/// </summary>
		UInt16,

		/// <summary>
		/// Each index is an unsigned 32-bit integer.
		/// </summary>
		UInt32
	}
}
