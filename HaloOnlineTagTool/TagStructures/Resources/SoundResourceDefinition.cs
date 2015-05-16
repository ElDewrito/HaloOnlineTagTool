using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures.Resources
{
	/// <summary>
	/// Resource definition data for sounds.
	/// </summary>
	[TagStructure(Size = 0x14)]
	public class SoundResourceDefinition
	{
		/// <summary>
		/// Gets or sets the reference to the sound data.
		/// </summary>
		[TagElement]
		public RawResourceDataReference Data { get; set; }
	}
}
