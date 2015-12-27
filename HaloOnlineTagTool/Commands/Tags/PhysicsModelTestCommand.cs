using HaloOnlineTagTool.Resources.Geometry;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Commands.Tags
{
    class PhysicsModelTestCommand : Command
    {
        private readonly OpenTagCache _info;

        public PhysicsModelTestCommand(OpenTagCache info): base(
            CommandFlags.None,
            "phmotest",
            "Physics Model Import Command (Test)",
            "phmotest <filepath> <index>|<new> [force]",
            "injects a physics model from the file specified exported from Blender in JSON format.\n" +
            "A tag-index can be specified to override an existing tag, or 'new' can be used to create a new tag.\n" +
            "Tags that are not type- 'phmo' will not be overridden unless the third argument is specified- 'force'. ")
        {
            _info = info;
        }

        public override bool Execute(List<string> args)
        {
            //Arguments needed: filepath, <new>|<tagIndex>
            if (args.Count < 2)
            {
                return false;
            }

            TagInstance tag = null;
            bool b_duplicate;
            // optional argument: forces overwriting of tags that are not type: phmo
            bool b_force = (args.Count >= 3 && args[2].ToLower().Equals("force"));

            if (args[1].ToLower().Equals("new"))
            {
                b_duplicate = true;
            }
            else
            {
                tag = ArgumentParser.ParseTagIndex(_info.Cache, args[1]);
                if (tag == null)
                {
                    return false;
                }
                b_duplicate = false;
            }

            if (!b_force && !b_duplicate && !tag.IsInGroup("phmo"))
            {
                Console.WriteLine("Tag to override was not of class- 'phmo'. Use third argument- 'force' to inject.");
                return false;
            }

            var filename = args[0];

            var modelbuilder = new PhysicsModelBuilder();
            if (!modelbuilder.ParseFromFile(filename))
            {
                return false;
            }
            //modelbuilder must also make a node for the physics model
            var phmo = modelbuilder.Build();

            if (phmo == null)
            {
                return false;
            }

            using (var stream = _info.OpenCacheReadWrite())
            {

                if (b_duplicate)
                {
                    //duplicate an existing tag, trashcan phmo
                    tag = _info.Cache.DuplicateTag(stream, _info.Cache.Tags[0x4436]);
                    if (tag == null)
                    {
                        Console.WriteLine("Failed tag duplication.");
                        return false;
                    }
                }

                var context = new TagSerializationContext(stream, _info.Cache, _info.StringIds, tag);
                _info.Serializer.Serialize(context, phmo);

            }

            Console.Write("Successfully imported phmo to: ");
            TagPrinter.PrintTagShort(tag);

            return true;
        }
    }
}
