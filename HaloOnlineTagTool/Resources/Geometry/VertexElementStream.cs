using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;

namespace HaloOnlineTagTool.Resources.Geometry
{
    public class VertexElementStream
    {
        private readonly BinaryReader _reader;
        private readonly BinaryWriter _writer;

        public VertexElementStream(Stream baseStream)
        {
            _reader = new BinaryReader(baseStream);
            _writer = new BinaryWriter(baseStream);
        }

        public float ReadFloat1()
        {
            return _reader.ReadSingle();
        }

        public void WriteFloat1(float v)
        {
            _writer.Write(v);
        }

        public Vector2 ReadFloat2()
        {
            return new Vector2(Read(2, () => _reader.ReadSingle()));
        }

        public void WriteFloat2(Vector2 v)
        {
            Write(v.ToArray(), 2, e => _writer.Write(e));
        }

        public Vector3 ReadFloat3()
        {
            return new Vector3(Read(3, () => _reader.ReadSingle()));
        }

        public void WriteFloat3(Vector3 v)
        {
            Write(v.ToArray(), 3, e => _writer.Write(e));
        }

        public Vector4 ReadFloat4()
        {
            return new Vector4(Read(4, () => _reader.ReadSingle()));
        }

        public void WriteFloat4(Vector4 v)
        {
            Write(v.ToArray(), 4, e => _writer.Write(e));
        }

        public uint ReadColor()
        {
            return _reader.ReadUInt32();
        }

        public void WriteColor(uint v)
        {
            _writer.Write(v);
        }

        public byte[] ReadUByte4()
        {
            return _reader.ReadBytes(4);
        }

        public void WriteUByte4(byte[] v)
        {
            _writer.Write(v, 0, 4);
        }

        public short[] ReadShort2()
        {
            return Read(2, () => _reader.ReadInt16());
        }

        public void WriteShort2(short[] v)
        {
            Write(v, 2, e => _writer.Write(e));
        }

        public short[] ReadShort4()
        {
            return Read(2, () => _reader.ReadInt16());
        }

        public void WriteShort4(short[] v)
        {
            Write(v, 4, e => _writer.Write(e));
        }

        public Vector4 ReadUByte4N()
        {
            return new Vector4(Read(4, () => _reader.ReadByte() / 255.0f * 2.0f - 1.0f));
        }

        public void WriteUByte4N(Vector4 v)
        {
            Write(v.ToArray(), 4, e => _writer.Write((byte)(Clamp((e + 1.0f) / 2.0f) * 255.0f)));
        }

        public Vector2 ReadShort2N()
        {
            return new Vector2(Read(2, () => _reader.ReadInt16() / 32767.0f));
        }

        public void WriteShort2N(Vector2 v)
        {
            Write(v.ToArray(), 2, e => _writer.Write((short)(Clamp(e) * 32767.0f)));
        }

        public Vector4 ReadShort4N()
        {
            return new Vector4(Read(4, () => _reader.ReadInt16() / 32767.0f));
        }

        public void WriteShort4N(Vector4 v)
        {
            Write(v.ToArray(), 4, e => _writer.Write((short)(Clamp(e) * 32767.0f)));
        }

        public Vector2 ReadUShort2N()
        {
            return new Vector2(Read(2, () => _reader.ReadUInt16() / 65535.0f * 2.0f - 1.0f));
        }

        public void WriteUShort2N(Vector2 v)
        {
            Write(v.ToArray(), 2, e => _writer.Write((ushort)(Clamp((e + 1.0f) / 2.0f) * 65535.0f)));
        }

        public Vector4 ReadUShort4N()
        {
            return new Vector4(Read(4, () => _reader.ReadUInt16() / 65535.0f * 2.0f - 1.0f));
        }

        public void WriteUShort4N(Vector4 v)
        {
            Write(v.ToArray(), 4, e => _writer.Write((ushort)(Clamp((e + 1.0f) / 2.0f) * 65535.0f)));
        }

        public Vector3 ReadUDec3()
        {
            var val = _reader.ReadUInt32();
            var x = (float)(val >> 22);
            var y = (float)((val >> 12) & 0x3FF);
            var z = (float)((val >> 2) & 0x3FF);
            return new Vector3(x, y, z);
        }

        public void WriteUDec3(Vector3 v)
        {
            var x = (uint)v.X & 0x3FF;
            var y = (uint)v.Y & 0x3FF;
            var z = (uint)v.Z & 0x3FF;
            _writer.Write((x << 22) | (y << 12) | (z << 2));
        }

        public Vector3 ReadDec3N()
        {
            var val = _reader.ReadUInt32();
            var x = ((val >> 22) - 512) / 511.0f;
            var y = (((val >> 12) & 0x3FF) - 512) / 511.0f;
            var z = (((val >> 2) & 0x3FF) - 512) / 511.0f;
            return new Vector3(x, y, z);
        }

        public void WriteDec3N(Vector3 v)
        {
            var x = (((uint)(Clamp(v.X) * 511.0f)) + 512) & 0x3FF;
            var y = (((uint)(Clamp(v.Y) * 511.0f)) + 512) & 0x3FF;
            var z = (((uint)(Clamp(v.Z) * 511.0f)) + 512) & 0x3FF;
            _writer.Write((x << 22) | (y << 12) | (z << 2));
        }

        public Vector2 ReadFloat16_2()
        {
            return new Vector2(Read(2, () => (float)Half.ToHalf(_reader.ReadUInt16())));
        }

        public void WriteFloat16_2(Vector2 v)
        {
            Write(v.ToArray(), 2, e => _writer.Write(Half.GetBytes(new Half(e))));
        }

        public Vector4 ReadFloat16_4()
        {
            return new Vector4(Read(4, () => (float)Half.ToHalf(_reader.ReadUInt16())));
        }

        public void WriteFloat16_4(Vector4 v)
        {
            Write(v.ToArray(), 4, e => _writer.Write(Half.GetBytes(new Half(e))));
        }

        private static T[] Read<T>(int count, Func<T> readFunc)
        {
            var c = new T[count];
            for (var i = 0; i < count; i++)
                c[i] = readFunc();
            return c;
        }

        private static void Write<T>(T[] elems, int count, Action<T> writeAction)
        {
            for (var i = 0; i < count; i++)
                writeAction(elems[i]);
        }

        private static float Clamp(float e)
        {
            return Math.Max(-1.0f, Math.Min(1.0f, e));
        }
    }
}
