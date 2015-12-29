using System;
using System.Collections.Generic;
using System.Collections;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Editing
{
    class ListFieldsCommand : Command
    {
        private OpenTagCache Info { get; }

        private TagStructureInfo Structure { get; }

        private object Value { get; }

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

                string valueString;

                if (fieldValue == null)
                    valueString = "null";
                else if (fieldType.GetInterface(typeof(IList).Name) != null)
                    valueString =
                        ((IList)fieldValue).Count != 0 ?
                            $"{{...}}[{((IList)fieldValue).Count}]" :
                        "null";
                else if (fieldType == typeof(StringId))
                    valueString = Info.StringIds.GetString((StringId)fieldValue);
                else
                    valueString = fieldValue.ToString();
                
                Console.WriteLine("{0}: {1} = {2}", nameString, typeString, valueString);
            }

            return true;
        }
    }
}
