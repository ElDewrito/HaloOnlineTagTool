using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Commands.Editing
{
    class EditBlockCommand : Command
    {
        private CommandContextStack Stack { get; }

        private OpenTagCache Info { get; }

        private TagInstance Tag { get; }

        public TagStructureInfo Structure { get; set; }

        public object Owner { get; set; }
        
        public EditBlockCommand(CommandContextStack stack, OpenTagCache info, TagInstance tag, object value)
            : base(CommandFlags.Inherit,
                  "Edit",
                  "Edit the fields of a particular block element.",
                  "Edit <block name> [block index (if block)]",
                  "Edit the fields of a particular block element.")
        {
            Info = info;
            Stack = stack;
            Tag = tag;
            Structure = new TagStructureInfo(value.GetType(), Info.Version);
            Owner = value;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 1 || args.Count > 2)
                return false;

            var blockName = args[0];
            var ownerType = Owner.GetType();

            var enumerator = new TagFieldEnumerator(Structure);

            var deferredNames = new List<string>();
            var deferredArgs = new List<string>();

            if (blockName.Contains("."))
            {
                deferredNames.AddRange(blockName.Split('.'));
                blockName = deferredNames[0];
                deferredNames = deferredNames.Skip(1).ToList();
                deferredArgs.AddRange(args.Skip(1));
                args = new List<string> { blockName };
            }

            if (blockName.Contains("]"))
            {
                var openBracketIndex = blockName.IndexOf('[');
                var closeBracketIndex = blockName.IndexOf(']');
                var name = blockName.Substring(0, openBracketIndex);
                var index = blockName.Substring(openBracketIndex + 1, (closeBracketIndex - openBracketIndex) - 1);

                blockName = name;
                args = new List<string> { name, index };
            }

            var blockNameLow = blockName.ToLower();
            var field = enumerator.Find(f => f.Name == blockName || f.Name.ToLower() == blockNameLow);

            if (field == null)
            {
                Console.WriteLine("{0} does not contain a block named \"{1}\"", ownerType.Name, blockName);
                return false;
            }
            
            var contextName = "";
            object blockValue = null;

            var structureAttribute = field.FieldType.CustomAttributes.ToList().Find(a => a.AttributeType == typeof(TagStructureAttribute));

            if (structureAttribute != null)
            {
                if (args.Count != 1)
                    return false;

                blockValue = field.GetValue(Owner);
                contextName = $"{blockName}";
            }
            else
            {
                if (args.Count != 2)
                    return false;
                
                IList fieldValue = null;

                if (field.FieldType.GetInterface("IList") == null || (fieldValue = (IList)field.GetValue(Owner)) == null)
                {
                    Console.WriteLine("{0} does not contain a block named \"{1}\"", ownerType.Name, blockName);
                    return false;
                }

                int blockIndex = 0;

                if (args[1] == "*")
                    blockIndex = fieldValue.Count - 1;
                else if (!int.TryParse(args[1], out blockIndex))
                {
                    Console.WriteLine("Invalid index requested from block {0}: {1}", blockName, blockIndex);
                    return false;
                }

                if (blockIndex >= fieldValue.Count || blockIndex < 0)
                {
                    Console.WriteLine("Invalid index requested from block {0}: {1}", blockName, blockIndex);
                    return false;
                }

                blockValue = fieldValue[blockIndex];
                contextName = $"{blockName}[{blockIndex}]";
            }

            var blockStructure = new TagStructureInfo(blockValue.GetType());

            var blockContext = new CommandContext(Stack.Context, contextName);
            blockContext.AddCommand(new ListFieldsCommand(Info, blockStructure, blockValue));
            blockContext.AddCommand(new SetFieldCommand(Stack, Info, Tag, blockStructure, blockValue));
            blockContext.AddCommand(new EditBlockCommand(Stack, Info, Tag, blockValue));
            blockContext.AddCommand(new AddToBlockCommand(Stack, Info, Tag, blockStructure, blockValue));
            blockContext.AddCommand(new RemoveFromBlockCommand(Stack, Info, Tag, blockStructure, blockValue));
            blockContext.AddCommand(new ExitToCommand(Stack));
            Stack.Push(blockContext);

            if (deferredNames.Count != 0)
            {
                var name = deferredNames[0];
                deferredNames = deferredNames.Skip(1).ToList();

                foreach (var deferredName in deferredNames)
                    name += '.' + deferredName;

                args = new List<string> { name };
                args.AddRange(deferredArgs);

                var command = new EditBlockCommand(Stack, Info, Tag, blockValue);
                return command.Execute(args);
            }
            
            return true;
        }
    }
}
