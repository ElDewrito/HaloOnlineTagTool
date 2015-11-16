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
	[TagStructure(Class = "cddf", Size = 0x30)]
	public class CollisionDamage
	{
		public float ApplyDamageScale;
		public float ApplyRecoilDamageScale;
		public float DamageAccelerationMin;
		public float DamageAccelerationMax;
		public float DamageScaleMin;
		public float DamageScaleMin2;
		public float Unknown;
		public float Unknown2;
		public float RecoilDamageAccelerationMin;
		public float RecoilDamageAccelerationMax;
		public float RecoilDamageScaleMin;
		public float RecoilDamageScaleMax;
	}
}
