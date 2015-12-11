using HaloOnlineTagTool.Serialization;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Editing
{
    class EditBlockCommand : Command
    {
        public CommandContextStack Stack { get; }

        public OpenTagCache Info { get; }

        public HaloTag Tag { get; }

        public object Owner { get; }
        
        public EditBlockCommand(CommandContextStack stack, OpenTagCache info, HaloTag tag, object value)
            : base(CommandFlags.Inherit,
                  "Edit",
                  "Edit the fields of a particular block element.",
                  "Edit <block name> <block index>",
                  "Edit the fields of a particular block element.")
        {
            Info = info;
            Stack = stack;
            Owner = value;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 2)
                return false;

            var blockName = args[0];
            var ownerType = Owner.GetType();

            var enumerator = new TagFieldEnumerator(
                new TagStructureInfo(ownerType, Info.Version));

            var field = enumerator.Find(f => f.Name == blockName);

            if (field == null)
            {
                Console.WriteLine("{0} does not contain a block named \"{1}\"", ownerType.Name, blockName);
                return false;
            }

            var fieldValue = (IList)field.GetValue(Owner);
            
            int blockIndex = 0;
            if (!int.TryParse(args[1], out blockIndex) ||
                blockIndex >= fieldValue.Count ||
                blockIndex < 0)
            {
                Console.WriteLine("Invalid index requested from block {0}: {1}", blockName, blockIndex);
                return false;
            }

            var blockValue = fieldValue[blockIndex];
            var blockStructure = new TagStructureInfo(blockValue.GetType());

            var blockContext = new CommandContext(Stack.Context, $"{blockName}[{blockIndex}]");
            blockContext.AddCommand(new ListFieldsCommand(Info, blockStructure, blockValue));
            blockContext.AddCommand(new SetFieldCommand(Info, Tag, blockStructure, blockValue));
            blockContext.AddCommand(new EditBlockCommand(Stack, Info, Tag, blockValue));
            Stack.Push(blockContext);
            
            return true;
        }
    }
}
