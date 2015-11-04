using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Layouts
{
	/// <summary>
	/// Base class for a field in a tag layout.
	/// </summary>
	public abstract class TagLayoutField
	{
		protected TagLayoutField(string name)
		{
			Name = name;
		}

		/// <summary>
		/// Gets the name of the field.
		/// </summary>
		public string Name { get; private set; }

		public abstract void Accept(ITagLayoutFieldVisitor visitor);
	}
}
