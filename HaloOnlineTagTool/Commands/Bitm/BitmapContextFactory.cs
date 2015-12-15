using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Bitm
{
    static class BitmapContextFactory
    {
        public static void Populate(CommandContext context, OpenTagCache info, HaloTag tag, Bitmap bitmap)
        {
            context.AddCommand(new BitmImportCommand(info, tag, bitmap));
        }
    }
}
