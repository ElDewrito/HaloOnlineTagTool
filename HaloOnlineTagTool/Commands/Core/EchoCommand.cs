using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Core
{
    class EchoCommand : Command
    {
        public EchoCommand()
            : base(CommandFlags.Inherit,
                  "echo",
                  "Prints arguments to the console.",
                  "echo <arg1> <arg2> ... <argN>",
                  "Prints arguments to the console.")
        {
        }

        public override bool Execute(List<string> args)
        {
            foreach (var arg in args)
                Console.Write($"{arg} ");
            
            return true;
        }
    }
}
