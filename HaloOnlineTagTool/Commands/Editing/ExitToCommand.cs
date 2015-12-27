using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Editing
{
    class ExitToCommand : Command
    {
        private CommandContextStack Stack { get; }

        public ExitToCommand(CommandContextStack stack)
            : base( CommandFlags.Inherit,
                  "ExitTo",
                  "Exits each context on the stack until the specified one is found.",
                  "ExitTo <context name>",
                  "Exits each context on the stack until the specified one is found.")
        {
            Stack = stack;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            var found = false;

            var request = args[0];
            var requestLow = request.ToLower();
            var context = Stack.Context;

            // Assert that there is a context with the requested name.
            for (var parent = Stack.Context; parent != null; parent = parent.Parent)
            {
                if (parent.Name == request || parent.Name.ToLower() == requestLow)
                {
                    found = true;
                    break;
                }
            }

            if (!found)
            {
                Console.WriteLine($"ERROR: No context named '{request}' was found.");
                return false;
            }

            // Pop each child context off of the stack until the requested is active.
            while (context != null)
            {
                if (request == context.Name || requestLow == context.Name.ToLower())
                    break;
                Stack.Pop();
                context = Stack.Context;
            }

            return true;
        }
    }
}
