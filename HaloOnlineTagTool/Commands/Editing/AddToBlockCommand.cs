using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Commands.Editing
{
    class AddToBlockCommand : Command
    {
        private CommandContextStack Stack { get; }

        private OpenTagCache Info { get; }

        private TagInstance Tag { get; }

        private TagStructureInfo Structure { get; set; }

        private object Owner { get; set; }

        public AddToBlockCommand(CommandContextStack stack, OpenTagCache info, TagInstance tag, TagStructureInfo structure, object owner)
            : base(CommandFlags.Inherit,
                  "AddTo",
                  $"Adds block element(s) to the end of a specific tag block in the current {structure.Types[0].Name} definition.",
                  "AddTo <tag block name> [amount = 1] [index = *]",
                  $"Adds block element(s) to the end of a specific tag block in the current {structure.Types[0].Name} definition.")
        {
            Stack = stack;
            Info = info;
            Tag = tag;
            Structure = structure;
            Owner = owner;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 3)
                return false;

            var fieldName = args[0];
            var fieldNameLow = fieldName.ToLower();

            var previousContext = Stack.Context;
            var previousOwner = Owner;
            var previousStructure = Structure;

            if (fieldName.Contains("."))
            {
                var lastIndex = fieldName.LastIndexOf('.');
                var blockName = fieldName.Substring(0, lastIndex);
                fieldName = fieldName.Substring(lastIndex + 1, (fieldName.Length - lastIndex) - 1);
                fieldNameLow = fieldName.ToLower();

                var command = new EditBlockCommand(Stack, Info, Tag, Owner);

                if (!command.Execute(new List<string> { blockName }))
                {
                    while (Stack.Context != previousContext) Stack.Pop();
                    Owner = previousOwner;
                    Structure = previousStructure;
                    return false;
                }

                command = (Stack.Context.GetCommand("Edit") as EditBlockCommand);

                Owner = command.Owner;
                Structure = command.Structure;

                if (Owner == null)
                {
                    while (Stack.Context != previousContext) Stack.Pop();
                    Owner = previousOwner;
                    Structure = previousStructure;
                    return false;
                }
            }

            var count = 1;

            if ((args.Count > 1 && !int.TryParse(args[1], out count)) || count < 1)
            {
                Console.WriteLine($"Invalid amount specified: {args[1]}");
                return false;
            }

            var index = -1;

            if (args.Count > 2)
            {
                if (args[2] != "*" && (!int.TryParse(args[2], out index) || index < 0))
                {
                    Console.WriteLine($"Invalid index specified: {args[2]}");
                    return false;
                }
            }

            var enumerator = new TagFieldEnumerator(Structure);
            var field = enumerator.Find(f => f.Name == fieldName || f.Name.ToLower() == fieldNameLow);
            var fieldType = field.FieldType;

            if ((field == null) ||
                (!fieldType.IsGenericType) ||
                (fieldType.GetInterface("IList") == null))
            {
                Console.WriteLine("ERROR: {0} does not contain a tag block named \"{1}\".", Structure.Types[0].Name, args[0]);
                while (Stack.Context != previousContext) Stack.Pop();
                Owner = previousOwner;
                Structure = previousStructure;
                return false;
            }

            var blockValue = field.GetValue(Owner) as IList;

            if (blockValue == null)
            {
                blockValue = Activator.CreateInstance(field.FieldType) as IList;
                field.SetValue(Owner, blockValue);
            }
            
            if (index > blockValue.Count)
            {
                Console.WriteLine($"Invalid index specified: {args[2]}");
                return false;
            }

            var elementType = field.FieldType.GenericTypeArguments[0];
            
            for (var i = 0; i < count; i++)
            {
                var element = CreateElement(elementType);

                if (index == -1)
                    blockValue.Add(element);
                else
                    blockValue.Insert(index + i, element);
            }

            field.SetValue(Owner, blockValue);

            var typeString =
                fieldType.IsGenericType ?
                    $"{fieldType.Name}<{fieldType.GenericTypeArguments[0].Name}>" :
                fieldType.Name;

            var itemString = count < 2 ? "element" : "elements";

            var valueString =
                ((IList)blockValue).Count != 0 ?
                    $"{{...}}[{((IList)blockValue).Count}]" :
                "null";

            Console.WriteLine($"Successfully added {count} {itemString} to {field.Name}: {typeString}");
            Console.WriteLine(valueString);

            while (Stack.Context != previousContext) Stack.Pop();
            Owner = previousOwner;
            Structure = previousStructure;

            return true;
        }

        private object CreateElement(Type elementType)
        {
            var element = Activator.CreateInstance(elementType);

            var isTagStructure = Attribute.IsDefined(elementType, typeof(TagStructureAttribute));

            if (isTagStructure)
            {
                var enumerator = new TagFieldEnumerator(
                    new TagStructureInfo(elementType));

                while (enumerator.Next())
                {
                    var fieldType = enumerator.Field.FieldType;

                    if (fieldType.IsArray && enumerator.Attribute.Count > 0)
                    {
                        var array = (IList)Activator.CreateInstance(enumerator.Field.FieldType,
                            new object[] { enumerator.Attribute.Count });

                        for (var i = 0; i < enumerator.Attribute.Count; i++)
                            array[i] = CreateElement(fieldType.GetElementType());
                    }
                    else
                    {
                        try
                        {
                            enumerator.Field.SetValue(element, CreateElement(enumerator.Field.FieldType));
                        }
                        catch
                        {
                            enumerator.Field.SetValue(element, null);
                        }
                    }
                }
            }

            return element;
        }
    }
}
