using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Editing
{
    class ListFieldsCommand : Command
    {
        public OpenTagCache Info { get; }

        public TagStructureInfo Structure { get; }

        public object Value { get; }

        public ListFieldsCommand(OpenTagCache info, TagStructureInfo structure, object value)
            : base(CommandFlags.Inherit,
                  "ListFields",
                  $"Lists the fields in the current {structure.Types[0].Name} definition.",
                  "ListFields",
                  $"Lists the fields in the current {structure.Types[0].Name} definition.")
        {
            Info = info;
            Structure = structure;
            Value = value;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 0)
                return false;

            var enumerator = new TagFieldEnumerator(Structure);

            while (enumerator.Next())
                Console.WriteLine("{0}: {1} = {2}", enumerator.Field.Name, enumerator.Field.FieldType.Name, enumerator.Field.GetValue(Value));

            return true;
        }
    }
}
