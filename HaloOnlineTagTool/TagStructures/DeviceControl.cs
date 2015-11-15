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
	[TagStructure(Class = "ctrl", Size = 0x44)]
	public class DeviceControl : Device
	{
		public TypeValue Type;
		public TriggersWhenValue TriggersWhen;
		public float CallValue;
		public StringId ActionString;
		public HaloTag On;
		public HaloTag Off;
		public HaloTag Deny;
		public uint Unknown8;
		public uint Unknown9;

		public enum TypeValue : short
		{
			Toggle,
			On,
			Off,
			Call,
			Generator,
		}

		public enum TriggersWhenValue : short
		{
			TouchedByPlayer,
			Destroyed,
		}
	}
}
