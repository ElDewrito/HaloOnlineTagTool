using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
	/// <summary>
	/// Model primitive types. Corresponds to the D3DPRIMITIVETYPE enum.
	/// </summary>
	public enum PrimitiveType : int
	{
		Invalid,
		PointList,
		LineList,
		LineStrip,
		TriangleList,
		TriangleStrip,
		TriangleFan
	}
}
