using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;
using System.Collections;

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
            if (args.Count > 1)
                return false;

            var match = (args.Count == 1);
            var token = match ? args[0].ToLower() : "";
            
            var enumerator = new TagFieldEnumerator(Structure);

            while (enumerator.Next())
            {
                var nameString = enumerator.Field.Name;

                if (match && !nameString.ToLower().Contains(token))
                    continue;

                var fieldType = enumerator.Field.FieldType;
                var fieldValue = enumerator.Field.GetValue(Value);

                var typeString =
                    fieldType.IsGenericType ?
                        $"{fieldType.Name}<{fieldType.GenericTypeArguments[0].Name}>" :
                    fieldType.Name;

                var valueString =
                    fieldType == typeof(StringId) ?
                        Info.StringIds.GetString((StringId)fieldValue) :
                    fieldType.GetInterface(typeof(IList).Name) != null ?
                        (((IList)fieldValue).Count == 0 ? "null" : "{...}") :
                    fieldValue == null ?
                        "null" :
                    fieldValue.ToString();

                Console.WriteLine("{0}: {1} = {2}", nameString, typeString, valueString);
            }

            return true;
        }
    }
}
