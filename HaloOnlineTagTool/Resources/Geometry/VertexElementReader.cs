using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;

namespace HaloOnlineTagTool.Resources.Geometry
{
	public class VertexElementReader
	{
		private readonly BinaryReader _reader;

		public VertexElementReader(BinaryReader reader)
		{
			_reader = reader;
		}

		public float ReadFloat1()
		{
			return _reader.ReadSingle();
		}

		public Vector2 ReadFloat2()
		{
			return new Vector2(Read(2, () => _reader.ReadSingle()));
		}

		public Vector3 ReadFloat3()
		{
			return new Vector3(Read(3, () => _reader.ReadSingle()));
		}

		public Vector4 ReadFloat4()
		{
			return new Vector4(Read(4, () => _reader.ReadSingle()));
		}

		public uint ReadColor()
		{
			return _reader.ReadUInt32();
		}

		public byte[] ReadUByte4()
		{
			return _reader.ReadBytes(4);
		}

		public short[] ReadShort2()
		{
			return Read(2, () => _reader.ReadInt16());
		}

		public short[] ReadShort4()
		{
			return Read(2, () => _reader.ReadInt16());
		}

		public Vector4 ReadUByte4N()
		{
			return new Vector4(Read(4, () => _reader.ReadByte() / 255.0f));
		}

		public Vector2 ReadShort2N()
		{
			return new Vector2(Read(2, () => _reader.ReadInt16() / 32767.0f));
		}

		public Vector4 ReadShort4N()
		{
			return new Vector4(Read(4, () => _reader.ReadInt16() / 32767.0f));
		}

		public Vector2 ReadUShort2N()
		{
			return new Vector2(Read(2, () => _reader.ReadUInt16() / 65535.0f));
		}

		public Vector4 ReadUShort4N()
		{
			return new Vector4(Read(4, () => _reader.ReadUInt16() / 65535.0f));
		}

		public Vector3 ReadUDec3()
		{
			var val = _reader.ReadUInt32();
			var x = (float) (val >> 22);
			var y = (float)((val >> 12) & 0x3FF);
			var z = (float)((val >> 2)  & 0x3FF);
			return new Vector3(x, y, z);
		}

		public Vector3 ReadDec3N()
		{
			var val = _reader.ReadUInt32();
			var x =  ((val >> 22)          - 512) / 1023.0f;
			var y = (((val >> 12) & 0x3FF) - 512) / 1023.0f;
			var z = (((val >> 2)  & 0x3FF) - 512) / 1023.0f;
			return new Vector3(x, y, z);
		}

		public Vector2 ReadFloat16_2()
		{
			return new Vector2(Read(2, () => (float)Half.ToHalf(_reader.ReadUInt16())));
		}

		public Vector4 ReadFloat16_4()
		{
			return new Vector4(Read(4, () => (float)Half.ToHalf(_reader.ReadUInt16())));
		}

		private static T[] Read<T>(int count, Func<T> readFunc)
		{
			var c = new T[count];
			for (var i = 0; i < count; i++)
				c[i] = readFunc();
			return c;
		}
	}
}
