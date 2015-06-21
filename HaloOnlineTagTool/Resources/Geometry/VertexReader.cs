using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
	public class VertexReader
	{
		private readonly VertexElementReader _reader;

		public VertexReader(BinaryReader reader)
		{
			_reader = new VertexElementReader(reader);
		}

		public WorldVertex ReadWorldVertex()
		{
			return new WorldVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
			};
		}

		public RigidVertex ReadRigidVertex()
		{
			return new RigidVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
			};
		}

		public SkinnedVertex ReadSkinnedVertex()
		{
			return new SkinnedVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
				BlendIndices = _reader.ReadUByte4(),
				BlendWeights = _reader.ReadUByte4N().ToArray(),
			};
		}

		public ParticleModelVertex ReadParticleModelVertex()
		{
			return new ParticleModelVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
			};
		}

		public FlatWorldVertex ReadFlatWorldVertex()
		{
			return new FlatWorldVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
			};
		}

		public FlatRigidVertex ReadFlatRigidVertex()
		{
			return new FlatRigidVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
			};
		}

		public FlatSkinnedVertex ReadFlatSkinnedVertex()
		{
			return new FlatSkinnedVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
				BlendIndices = _reader.ReadUByte4(),
				BlendWeights = _reader.ReadUByte4N().ToArray(),
			};
		}

		public ScreenVertex ReadScreenVertex()
		{
			return new ScreenVertex
			{
				Position = _reader.ReadFloat2(),
				Texcoord = _reader.ReadFloat2(),
				Color = _reader.ReadColor(),
			};
		}

		public DebugVertex ReadDebugVertex()
		{
			return new DebugVertex
			{
				Position = _reader.ReadFloat3(),
				Color = _reader.ReadColor(),
			};
		}

		public TransparentVertex ReadTransparentVertex()
		{
			return new TransparentVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Color = _reader.ReadColor(),
			};
		}

		public ParticleVertex ReadParticleVertex()
		{
			return new ParticleVertex
			{
			};
		}

		public ContrailVertex ReadContrailVertex()
		{
			return new ContrailVertex
			{
				Position = _reader.ReadFloat4(),
				Position2 = _reader.ReadFloat16_4(),
				Position3 = _reader.ReadShort4N(),
				Texcoord = _reader.ReadFloat16_4(),
				Texcoord2 = _reader.ReadShort4N(),
				Texcoord3 = _reader.ReadFloat16_2(),
				Color = _reader.ReadColor(),
				Color2 = _reader.ReadColor(),
				Position4 = _reader.ReadFloat4(),
			};
		}

		public LightVolumeVertex ReadLightVolumeVertex()
		{
			return new LightVolumeVertex
			{
				Texcoord = _reader.ReadShort2(),
			};
		}

		public ChudVertexSimple ReadChudVertexSimple()
		{
			return new ChudVertexSimple
			{
				Position = _reader.ReadFloat2(),
				Texcoord = _reader.ReadFloat2(),
			};
		}

		public ChudVertexFancy ReadChudVertexFancy()
		{
			return new ChudVertexFancy
			{
				Position = _reader.ReadFloat3(),
				Color = _reader.ReadColor(),
				Texcoord = _reader.ReadFloat2(),
			};
		}

		public DecoratorVertex ReadDecoratorVertex()
		{
			return new DecoratorVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Texcoord2 = _reader.ReadShort4(),
				Texcoord3 = _reader.ReadUByte4N(),
				Texcoord4 = _reader.ReadUByte4N(),
			};
		}

		public TinyPositionVertex ReadTinyPositionVertex()
		{
			return new TinyPositionVertex
			{
				Position = _reader.ReadShort4N(),
			};
		}

		public PatchyFogVertex ReadPatchyFogVertex()
		{
			return new PatchyFogVertex
			{
				Position = _reader.ReadFloat4(),
				Texcoord = _reader.ReadFloat2(),
			};
		}

		public WaterVertex ReadWaterVertex()
		{
			return new WaterVertex
			{
				Position = _reader.ReadFloat4(),
				Position2 = _reader.ReadFloat4(),
				Position3 = _reader.ReadFloat4(),
				Position4 = _reader.ReadFloat4(),
				Position5 = _reader.ReadFloat4(),
				Position6 = _reader.ReadFloat4(),
				Position7 = _reader.ReadFloat4(),
				Position8 = _reader.ReadFloat4(),
				Texcoord = _reader.ReadFloat4(),
				Texcoord2 = _reader.ReadFloat3(),
				Normal = _reader.ReadFloat4(),
				Normal2 = _reader.ReadFloat4(),
				Normal3 = _reader.ReadFloat4(),
				Normal4 = _reader.ReadFloat4(),
				Normal5 = _reader.ReadFloat2(),
				Texcoord3 = _reader.ReadFloat3(),
			};
		}

		public RippleVertex ReadRippleVertex()
		{
			return new RippleVertex
			{
				Position = _reader.ReadFloat4(),
				Texcoord = _reader.ReadFloat4(),
				Texcoord2 = _reader.ReadFloat4(),
				Texcoord3 = _reader.ReadFloat4(),
				Texcoord4 = _reader.ReadFloat4(),
				Texcoord5 = _reader.ReadFloat4(),
				Color = _reader.ReadFloat4(),
				Color2 = _reader.ReadFloat4(),
				Texcoord6 = _reader.ReadShort2(),
			};
		}

		public ImplicitVertex ReadImplicitVertex()
		{
			return new ImplicitVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
			};
		}

		public BeamVertex ReadBeamVertex()
		{
			return new BeamVertex
			{
				Position = _reader.ReadFloat4(),
				Texcoord = _reader.ReadShort4N(),
				Texcoord2 = _reader.ReadFloat16_4(),
				Color = _reader.ReadColor(),
				Position2 = _reader.ReadFloat3(),
				Texcoord3 = _reader.ReadShort2(),
			};
		}

		public DualQuatVertex ReadDualQuatVertex()
		{
			return new DualQuatVertex
			{
				Position = _reader.ReadFloat3(),
				Texcoord = _reader.ReadFloat2(),
				Normal = _reader.ReadFloat3(),
				Tangent = _reader.ReadFloat3(),
				Binormal = _reader.ReadFloat3(),
				BlendIndices = _reader.ReadUByte4(),
				BlendWeights = _reader.ReadUByte4N().ToArray(),
			};
		}

		public StaticPerVertexColorData ReadStaticPerVertexColorData()
		{
			return new StaticPerVertexColorData
			{
				Color = _reader.ReadFloat3(),
			};
		}

		public StaticPerPixelData ReadStaticPerPixelData()
		{
			return new StaticPerPixelData
			{
				Texcoord = _reader.ReadFloat2(),
			};
		}

		public StaticPerVertexData ReadStaticPerVertexData()
		{
			return new StaticPerVertexData
			{
				Texcoord = _reader.ReadUByte4N(),
				Texcoord2 = _reader.ReadUByte4N(),
				Texcoord3 = _reader.ReadUByte4N(),
				Texcoord4 = _reader.ReadUByte4N(),
				Texcoord5 = _reader.ReadUByte4N(),
			};
		}

		public AmbientPrtData ReadAmbientPrtData()
		{
			return new AmbientPrtData
			{
				Brightness = _reader.ReadFloat1(),
			};
		}

		public LinearPrtData ReadLinearPrtData()
		{
			return new LinearPrtData
			{
				BlendWeight = _reader.ReadUByte4N(),
			};
		}

		public QuadraticPrtData ReadQuadraticPrtData()
		{
			return new QuadraticPrtData
			{
				BlendWeight = _reader.ReadFloat3(),
				BlendWeight2 = _reader.ReadFloat3(),
				BlendWeight3 = _reader.ReadFloat3(),
			};
		}
	}
}
