using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Analysis
{
	public static class LayoutGuessWriter
	{
		public static void Write(HaloTag tag, TagLayoutGuess layout, ITagLayoutWriter writer)
		{
			if (tag != null)
				writer.Begin(tag.Class, tag.ClassId, layout);
			else
				writer.Begin(new MagicNumber(0), StringId.Null, layout);

			for (uint offset = 0; offset < layout.Size; offset += 4)
			{
				var guess = layout.TryGet(offset);
				if (guess != null)
				{
					writer.AddGuess(offset, guess);
					offset += guess.Size - 4;
				}
				else
				{
					var remaining = layout.Size - offset;
					switch (remaining)
					{
						case 3:
							writer.AddUnknownInt16(offset);
							writer.AddUnknownByte(offset + 2);
							break;
						case 2:
							writer.AddUnknownInt16(offset);
							break;
						case 1:
							writer.AddUnknownByte(offset);
							break;
						default: // >= 4
							writer.AddUnknownInt32(offset);
							break;
					}
				}
			}
			writer.End();
		}
	}
}
