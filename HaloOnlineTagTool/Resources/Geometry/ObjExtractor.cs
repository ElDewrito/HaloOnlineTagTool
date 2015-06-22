using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;

namespace HaloOnlineTagTool.Resources.Geometry
{
	/// <summary>
	/// Extracts render model data to Wavefront .obj files.
	/// </summary>
	public class ObjExtractor
	{
		private readonly TextWriter _writer;
		private readonly StringWriter _faceWriter = new StringWriter();
		private uint _baseIndex = 1;

		/// <summary>
		/// Initializes a new instance of the <see cref="ObjExtractor"/> class.
		/// </summary>
		/// <param name="writer">The stream to write the output file to.</param>
		public ObjExtractor(TextWriter writer)
		{
			_writer = writer;
			WriteHeader();
		}

		/// <summary>
		/// Writes mesh data to the .obj.
		/// </summary>
		/// <param name="reader">The mesh reader to use.</param>
		/// <param name="compressor">The vertex compressor to use.</param>
		/// <param name="resourceStream">A stream open on the resource data.</param>
		public void ExtractMesh(MeshReader reader, VertexCompressor compressor, Stream resourceStream)
		{
			// Read the vertex buffer and decompress each vertex
			var vertices = ReadVertices(reader, resourceStream);
			DecompressVertices(vertices, compressor);

			// Write out the vertices
			WriteVertices(vertices);

			// Read and write out the triangles for each part
			foreach (var part in reader.Mesh.Parts)
			{
				var indexes = ReadIndexes(reader, part, resourceStream);
				WriteTriangles(indexes);
			}
			_baseIndex += (uint)vertices.Count;
		}

		/// <summary>
		/// Finishes writing meshes out to the file.
		/// </summary>
		public void Finish()
		{
			_writer.Write(_faceWriter.ToString());
			_faceWriter.Close();
		}

		/// <summary>
		/// Reads the vertex data for a mesh into a format-independent list.
		/// </summary>
		/// <param name="reader">The mesh reader to use.</param>
		/// <param name="resourceStream">A stream open on the resource data.</param>
		/// <returns>The list of vertices that were read.</returns>
		private static List<ObjVertex> ReadVertices(MeshReader reader, Stream resourceStream)
		{
			// Open a vertex reader on stream 0 (main vertex data)
			var mainBuffer = reader.VertexStreams[0];
			if (mainBuffer == null)
				throw new InvalidOperationException("Mesh does not have a vertex buffer bound to stream 0");
			var vertexReader = reader.OpenVertexReader(mainBuffer, resourceStream);

			switch (reader.Mesh.Type)
			{
				case VertexType.Rigid:
					return ReadRigidVertices(vertexReader, mainBuffer.Count);
				case VertexType.Skinned:
					return ReadSkinnedVertices(vertexReader, mainBuffer.Count);
				case VertexType.DualQuat:
					return ReadDualQuatVertices(vertexReader, mainBuffer.Count);
				default:
					throw new InvalidOperationException("Only Rigid, Skinned, and DualQuat meshes are supported");
			}
		}

		/// <summary>
		/// Reads rigid vertices into a format-independent list.
		/// </summary>
		/// <param name="reader">The vertex reader to read from.</param>
		/// <param name="count">The number of vertices to read.</param>
		/// <returns>The vertices that were read.</returns>
		private static List<ObjVertex> ReadRigidVertices(VertexReader reader, int count)
		{
			var result = new List<ObjVertex>();
			for (var i = 0; i < count; i++)
			{
				var rigid = reader.ReadRigidVertex();
				result.Add(new ObjVertex
				{
					Position = rigid.Position,
					Normal = rigid.Normal,
					TexCoords = rigid.Texcoord,
				});
			}
			return result;
		}

		/// <summary>
		/// Reads skinned vertices into a format-independent list.
		/// </summary>
		/// <param name="reader">The vertex reader to read from.</param>
		/// <param name="count">The number of vertices to read.</param>
		/// <returns>The vertices that were read.</returns>
		private static List<ObjVertex> ReadSkinnedVertices(VertexReader reader, int count)
		{
			var result = new List<ObjVertex>();
			for (var i = 0; i < count; i++)
			{
				var skinned = reader.ReadSkinnedVertex();
				result.Add(new ObjVertex
				{
					Position = skinned.Position,
					Normal = skinned.Normal,
					TexCoords = skinned.Texcoord,
				});
			}
			return result;
		}

		/// <summary>
		/// Reads dualquat vertices into a format-independent list.
		/// </summary>
		/// <param name="reader">The vertex reader to read from.</param>
		/// <param name="count">The number of vertices to read.</param>
		/// <returns>The vertices that were read.</returns>
		private static List<ObjVertex> ReadDualQuatVertices(VertexReader reader, int count)
		{
			var result = new List<ObjVertex>();
			for (var i = 0; i < count; i++)
			{
				var dualQuat = reader.ReadDualQuatVertex();
				result.Add(new ObjVertex
				{
					Position = dualQuat.Position,
					Normal = dualQuat.Normal,
					TexCoords = dualQuat.Texcoord,
				});
			}
			return result;
		}

		/// <summary>
		/// Decompresses vertex data in-place.
		/// </summary>
		/// <param name="vertices">The vertices to decompress in-place.</param>
		/// <param name="compressor">The compressor to use.</param>
		private static void DecompressVertices(IEnumerable<ObjVertex> vertices, VertexCompressor compressor)
		{
			foreach (var vertex in vertices)
			{
				vertex.Position = compressor.DecompressPosition(vertex.Position);
				vertex.TexCoords = compressor.DecompressUv(vertex.TexCoords);
			}
		}

		/// <summary>
		/// Reads the index buffer data and converts it into a triangle list if necessary.
		/// </summary>
		/// <param name="reader">The mesh reader to use.</param>
		/// <param name="part">The mesh part to read.</param>
		/// <param name="resourceStream">A stream open on the resource data.</param>
		/// <returns>The index buffer converted into a triangle list.</returns>
		private static uint[] ReadIndexes(MeshReader reader, Mesh.Part part, Stream resourceStream)
		{
			// Use index buffer 0
			var indexBuffer = reader.IndexBuffers[0];
			if (indexBuffer == null)
				throw new InvalidOperationException("Index buffer 0 is null");

			// Read the indexes
			var indexReader = reader.OpenIndexBufferReader(indexBuffer, resourceStream);
			indexReader.Position = part.FirstIndex;
			switch (indexBuffer.Type)
			{
				case PrimitiveType.TriangleList:
					return indexReader.ReadIndexes(part.IndexCount);
				case PrimitiveType.TriangleStrip:
					return indexReader.ReadTriangleStrip(part.IndexCount);
				default:
					throw new InvalidOperationException("Unsupported index buffer type: " + indexBuffer.Type);
			}
		}

		/// <summary>
		/// Writes a header to the file.
		/// </summary>
		private void WriteHeader()
		{
			_writer.WriteLine("# Extracted by HaloOnlineTagTool on {0}", DateTime.Now);
		}

		/// <summary>
		/// Writes vertex data out to the file.
		/// </summary>
		/// <param name="vertices">The vertices to write.</param>
		private void WriteVertices(IEnumerable<ObjVertex> vertices)
		{
			foreach (var vertex in vertices)
				WriteVertex(vertex);
		}

		/// <summary>
		/// Writes a vertex out to the file.
		/// </summary>
		/// <param name="vertex">The vertex to write.</param>
		private void WriteVertex(ObjVertex vertex)
		{
			_writer.WriteLine("v {0} {1} {2}", vertex.Position.X, vertex.Position.Y, vertex.Position.Z);
			_writer.WriteLine("vn {0} {1} {2}", vertex.Normal.X, vertex.Normal.Y, vertex.Normal.Z);
			_writer.WriteLine("vt {0} {1}", vertex.TexCoords.X, vertex.TexCoords.Y);
		}

		/// <summary>
		/// Queues triangle list data to be written out to the file.
		/// </summary>
		/// <param name="indexes">The indexes for the triangle list. Each set of 3 indexes forms one triangle.</param>
		private void WriteTriangles(IReadOnlyList<uint> indexes)
		{
			for (var i = 0; i < indexes.Count; i += 3)
			{
				var a = indexes[i] + _baseIndex;
				var b = indexes[i + 1] + _baseIndex;
				var c = indexes[i + 2] + _baseIndex;

				// Discard degenerate triangles
				if (a == b || a == c || b == c)
					continue;

				// Write a face command for a triangle
				_faceWriter.WriteLine("f {0}/{0}/{0} {1}/{1}/{1} {2}/{2}/{2}", a, b, c);
			}
		}

		private class ObjVertex
		{
			public Vector3 Position { get; set; }
			public Vector3 Normal { get; set; }
			public Vector2 TexCoords { get; set; }
		}
	}
}
