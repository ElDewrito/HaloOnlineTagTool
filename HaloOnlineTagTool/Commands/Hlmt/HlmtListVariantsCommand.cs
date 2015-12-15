using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Hlmt
{
    class HlmtListVariantsCommand : Command
    {
        private readonly OpenTagCache _info;
        private readonly TagStructures.Model _model;

        public HlmtListVariantsCommand(OpenTagCache info, TagStructures.Model model) : base(
            CommandFlags.Inherit,

            "listvariants",
            "List available variants",

            "listvariants",

            "Lists variant names which can be used with \"extractmode\".")
        {
            _info = info;
            _model = model;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 0)
                return false;
            var variantNames = _model.Variants.Select(v => _info.StringIds.GetString(v.Name) ?? v.Name.ToString()).OrderBy(n => n).ToList();
            if (variantNames.Count == 0)
            {
                Console.WriteLine("Model has no variants");
                return true;
            }
            foreach (var name in variantNames)
                Console.WriteLine(name);
            return true;
        }
    }
}
