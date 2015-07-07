using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
	/// <summary>
	/// Interface for a class which writes tag layout files.
	/// </summary>
	public interface ITagLayoutWriter
	{
		/// <summary>
		/// Begins writing a layout.
		/// </summary>
		/// <param name="tagClass">The tag class magic number. Can be 0 if none.</param>
		/// <param name="classStringId">The tag class name stringID. Can be 0 if none.</param>
		/// <param name="layout">The tag layout.</param>
		void Begin(MagicNumber tagClass, int classStringId, TagLayoutGuess layout);

		/// <summary>
		/// Adds an unknown byte to the layout.
		/// </summary>
		/// <param name="offset">The offset of the value.</param>
		void AddUnknownByte(uint offset);

		/// <summary>
		/// Adds an unknown 16-bit signed integer to the layout.
		/// </summary>
		/// <param name="offset">The offset of the value.</param>
		void AddUnknownInt16(uint offset);

		/// <summary>
		/// Adds an unknown 32-bit signed integer to the layout.
		/// </summary>
		/// <param name="offset">The offset of the value.</param>
		void AddUnknownInt32(uint offset);

		/// <summary>
		/// Adds a guess to the layout.
		/// </summary>
		/// <param name="offset">The offset of the guess.</param>
		/// <param name="guess">The guess to add.</param>
		void AddGuess(uint offset, ITagElementGuess guess);

		/// <summary>
		/// Stops writing the current layout.
		/// </summary>
		void End();
	}
}
