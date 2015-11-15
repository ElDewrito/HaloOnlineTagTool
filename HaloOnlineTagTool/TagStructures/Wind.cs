using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
	[TagStructure(Class = "wind", Size = 0x7C)]
	public class Wind
	{
		public byte[] Function;
		public byte[] Function2;
		public byte[] Function3;
		public byte[] Function4;
		public byte[] Function5;
		public uint Unknown;
		public HaloTag WarpBitmap;
		public uint Unknown2;
	}
}
