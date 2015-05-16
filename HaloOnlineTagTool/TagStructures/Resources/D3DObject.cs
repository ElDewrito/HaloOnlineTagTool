using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures.Resources
{
	/// <summary>
	/// Points to a D3D-related object.
	/// </summary>
	[TagStructure(Size = 0xC)]
	public class D3DObject<TDefinition>
	{
		/// <summary>
		/// Gets or sets the definition data for the object.
		/// </summary>
		[TagElement(Flags = TagElementFlags.Indirect)]
		public TDefinition Buffer { get; set; }

		/// <summary>
		/// Gets or sets the address of the object in memory.
		/// This should be set to 0 because it will be filled in by the game.
		/// </summary>
		[TagElement]
		public uint Address { get; set; }

		[TagElement]
		public int UnusedC { get; set; }
	}
}
