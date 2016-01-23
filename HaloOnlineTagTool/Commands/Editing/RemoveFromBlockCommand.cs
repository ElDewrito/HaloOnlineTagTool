﻿using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Commands.Editing
{
    class RemoveFromBlockCommand : Command
    {
        private CommandContextStack Stack { get; }

        private OpenTagCache Info { get; }

        private TagInstance Tag { get; }

        private TagStructureInfo Structure { get; set; }

        private object Owner { get; set; }

        public RemoveFromBlockCommand(CommandContextStack stack, OpenTagCache info, TagInstance tag, TagStructureInfo structure, object owner)
            : base(CommandFlags.Inherit,
                  "RemoveFrom",
                  $"Removes block element(s) from a specified index of a specific tag block in the current {structure.Types[0].Name} definition.",
                  "RemoveFrom <tag block name> [* | <tag block index> [* | amount = 1]]",
                  $"Removes block element(s) from a specified index of a specific tag block in the current {structure.Types[0].Name} definition.")
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

            var elementType = field.FieldType.GenericTypeArguments[0];

            var index = blockValue.Count - 1;
            var count = 1;

            var genericIndex = false;
            var genericCount = false;

            if (args.Count == 1)
            {
                count = 1;
            }
            else
            {
                if (args.Count >= 2)
                {
                    if (args[1] == "*")
                    {
                        genericIndex = true;
                        index = blockValue.Count - 1;
                    }
                    else if (!int.TryParse(args[1], out index) || index < 0 || index >= blockValue.Count)
                    {
                        Console.WriteLine($"Invalid index specified: {args[1]}");
                        return false;
                    }
                }

                if (args.Count == 3)
                {
                    if (args[2] == "*")
                    {
                        genericCount = true;
                        count = blockValue.Count - index;
                    }
                    else if (!int.TryParse(args[2], out count) || count < 1)
                    {
                        Console.WriteLine($"Invalid number specified: {args[2]}");
                        return false;
                    }
                }
            }

            if (genericIndex && genericCount)
            {
                index = 0;
                count = blockValue.Count;
            }
            else if (genericIndex)
            {
                index -= count;

                if (index < 0)
                    index = 0;
            }

            if (index + count > blockValue.Count)
            {
                Console.WriteLine($"ERROR: Too many block elements specified to be removed: {count}. Maximum at index {index} can be {blockValue.Count - index}");
                return false;
            }

            for (var i = 0; i < count; i++)
                blockValue.RemoveAt(index);

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

            Console.WriteLine($"Successfully removed {count} {itemString} from {field.Name} at index {index}: {typeString}");
            Console.WriteLine(valueString);

            while (Stack.Context != previousContext) Stack.Pop();
            Owner = previousOwner;
            Structure = previousStructure;

            return true;
        }
    }
}
