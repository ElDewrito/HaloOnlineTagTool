using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Resources.Geometry
{
	/// <summary>
	/// Vertex formats.
	/// </summary>
	public enum VertexFormat : byte
	{
		World,               // s_world_vertex
		Rigid,               // s_rigid_vertex
		Skinned,             // s_skinned_vertex
		ParticleModel,       // s_particle_model_vertex
		FlatWorld,           // s_flat_world_vertex
		FlatRigid,           // s_flat_rigid_vertex
		FlatSkinned,         // s_flat_skinned_vertex
		Screen,              // s_screen_vertex
		Debug,               // s_debug_vertex
		Transparent,         // s_transparent_vertex
		Particle,            // s_particle_vertex
		Contrail,            // s_contrail_vertex
		LightVolume,         // s_light_volume_vertex
		ChudSimple,          // s_chud_vertex_simple
		ChudFancy,           // s_chud_vertex_fancy
		Decorator,           // s_decorator_vertex
		TinyPosition,        // s_tiny_position_vertex
		PatchyFog,           // s_patchy_fog_vertex
		Water,               // s_water_vertex
		Ripple,              // s_ripple_vertex
		Implicit,            // s_implicit_vertex
		Beam,                // s_beam_vertex
		SkinnedDualQuatBlend // s_dual_quat_vertex
	}
}
