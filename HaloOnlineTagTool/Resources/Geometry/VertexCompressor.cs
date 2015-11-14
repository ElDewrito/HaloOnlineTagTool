using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Resources.Geometry
{
	/// <summary>
	/// Compresses and decompresses vertex data.
	/// </summary>
	public class VertexCompressor
	{
		private readonly GeometryCompressionInfo _info;
		private readonly float _xScale;
		private readonly float _yScale;
		private readonly float _zScale;
		private readonly float _uScale;
		private readonly float _vScale;

		/// <summary>
		/// Initializes a new instance of the <see cref="VertexCompressor"/> class.
		/// </summary>
		/// <param name="info">The compression info to use.</param>
		public VertexCompressor(GeometryCompressionInfo info)
		{
			_info = info;
			_xScale = info.PositionMaxX - info.PositionMinX;
			_yScale = info.PositionMaxY - info.PositionMinY;
			_zScale = info.PositionMaxZ - info.PositionMinZ;
			_uScale = info.TextureMaxU - info.TextureMinU;
			_vScale = info.TextureMaxV - info.TextureMinV;
		}

		/// <summary>
		/// Compresses a position so that its components are between 0 and 1.
		/// </summary>
		/// <param name="pos">The position to compress.</param>
		/// <returns>The compressed position.</returns>
		public Vector4 CompressPosition(Vector4 pos)
		{
			var newX = (pos.X - _info.PositionMinX) / _xScale;
			var newY = (pos.Y - _info.PositionMinY) / _yScale;
			var newZ = (pos.Z - _info.PositionMinZ) / _zScale;
			return new Vector4(newX, newY, newZ, pos.W);
		}

		/// <summary>
		/// Decompresses a position so that its components are in model space.
		/// </summary>
		/// <param name="pos">The position to decompress.</param>
		/// <returns>The decompressed position.</returns>
		public Vector4 DecompressPosition(Vector4 pos)
		{
			var newX = pos.X * _xScale + _info.PositionMinX;
			var newY = pos.Y * _yScale + _info.PositionMinY;
			var newZ = pos.Z * _zScale + _info.PositionMinZ;
			return new Vector4(newX, newY, newZ, pos.W);
		}

		/// <summary>
		/// Compresses texture coordinates so that the components are between 0 and 1.
		/// </summary>
		/// <param name="uv">The texture coordinates to compress.</param>
		/// <returns>The compressed coordinates.</returns>
		public Vector2 CompressUv(Vector2 uv)
		{
			var newU = (uv.X - _info.TextureMinU) / _uScale;
			var newV = (uv.Y - _info.TextureMinV) / _vScale;
			return new Vector2(newU, newV);
		}

		/// <summary>
		/// Decompresses texture coordinates.
		/// </summary>
		/// <param name="uv">The texture coordinates to decompress.</param>
		/// <returns>The decompressed coordinates.</returns>
		public Vector2 DecompressUv(Vector2 uv)
		{
			var newU = uv.X * _uScale + _info.TextureMinU;
			var newV = uv.Y * _vScale + _info.TextureMinV;
			return new Vector2(newU, newV);
		}
	}
}
