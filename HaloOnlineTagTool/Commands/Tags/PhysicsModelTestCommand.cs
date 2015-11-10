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

        public PhysicsModelTestCommand(OpenTagCache info) : base(
            CommandFlags.None,
            "phmotest",
            "Physics Model Import Command (Test)",
            "phmotest <filepath> [index]",
            "injects a physics model from the file specified exported from Blender in JSON format.\n" +
            "A tag-index can be specified to override an existing tag.\n"+
            "The default behaviour is to duplicate an existing phmo tag and insert into that."
        )
        {
            _info = info;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 1) {
                return false;
            }
            HaloTag tag = null;
            bool duplicate = true;

            if (args.Count >= 2) { 
                tag = ArgumentParser.ParseTagIndex(_info.Cache, args[1]);
                if (tag == null) {
                    return false;
                }
                duplicate = false;
            }
            var filename = args[0];
            //Console.WriteLine(filename);

            var modelbuilder = new PhysicsModelBuilder();
            modelbuilder.ParseFromFile(filename);
            //modelbuilder must also make a node for the physics model
            var phmo = modelbuilder.Build();

            if (phmo == null) {
                return false;
            }

            using (var stream = _info.OpenCacheReadWrite()) {

                if (duplicate)
                {
                    tag = _info.Cache.DuplicateTag(stream, _info.Cache.Tags[0x4436]); //trashcan phmo
                    if (tag == null)
                    {
                        Console.WriteLine("Failed tag duplication");
                        return false;
                    }
                }

                var context = new TagSerializationContext(stream, _info.Cache, tag);
                _info.Serializer.Serialize(context, phmo);

            }

            Console.Write("Successfully imported phmo to: ");
            TagPrinter.PrintTagShort(tag);

            return true;
        }
    }
}
