using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources
{
	/// <summary>
	/// A data reference to raw resource data. Only used in resource definitions.
	/// </summary>
	/// <remarks>
	/// Not to be confused with <see cref="ResourceReference"/>, which references a resource as a whole and is found in normal tag data.
	/// </remarks>
	[TagStructure(Size = 0x14)]
	public class ResourceDataReference
	{
		public ResourceDataReference()
		{
		}

		public ResourceDataReference(int size, ResourceAddress address)
		{
			Size = size;
			Address = address;
		}

		/// <summary>
		/// Gets or sets the size of the referenced data in bytes.
		/// </summary>
		[TagElement]
		public int Size { get; set; }

		[TagElement]
		public int Unused4 { get; set; }
		[TagElement]
		public int Unused8 { get; set; }

		/// <summary>
		/// Gets or sets the address of the referenced data.
		/// </summary>
		[TagElement]
		public ResourceAddress Address { get; set; }

		[TagElement]
		public int Unused10 { get; set; }
	}
}
