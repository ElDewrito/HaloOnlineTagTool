﻿using System;
using System.Collections.Generic;
using System.Linq;

namespace HaloOnlineTagTool.Commands.Core
{
    class HelpCommand : Command
    {
        private CommandContextStack ContextStack { get; }
 
        public HelpCommand(CommandContextStack contextStack) : base(
            CommandFlags.Inherit,

            "help",
            "Display help",

            "help [command]",

            "Displays help on how to use a command.\n" +
            "If no command is given, help will list all available commands.")
        {
            ContextStack = contextStack;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count > 1)
                return false;
            if (args.Count == 1)
                DisplayCommandHelp(args[0]);
            else
                ListCommands();
            return true;
        }

        private void ListCommands()
        {
            ListCommands(ContextStack.Context, new HashSet<string>());
            Console.WriteLine("Use \"help <command>\" for more information on how to use a command.");
            Console.WriteLine();
            Console.WriteLine("To write the output of a command to a file instead of the screen,");
            Console.WriteLine("use > followed by the name of a file. For example,");
            Console.WriteLine("\"list bipd > bipeds.txt\" will write a list of bipd tags to bipeds.txt.");
            Console.WriteLine();
            Console.WriteLine("All numbers and tag indexes will be parsed as big-endian hexadecimal.");
        }

        private void ListCommands(CommandContext context, HashSet<string> ignore)
        {
            // Sort commands and pad them to the length of the longest command name
            // Commands which aren't inherited or which have already been displayed are ignored
            var commands = context.Commands
                .Where(c => !ignore.Contains(c.Name) && IsAvailable(context, c))
                .OrderBy(c => c.Name);
            var width = commands.Max(c => c.Name.Length);
            var format = "{0,-" + width + "}  {1}";

            Console.WriteLine("Available commands for {0}:", context.Name);
            Console.WriteLine();
            foreach (var command in commands)
            {
                Console.WriteLine(format, command.Name, command.Description);
                ignore.Add(command.Name);
            }
            Console.WriteLine();

            if (context.Parent != null)
                ListCommands(context.Parent, ignore);
        }

        private void DisplayCommandHelp(string commandName)
        {
            var command = ContextStack.Context.GetCommand(commandName);
            if (command == null)
            {
                Console.WriteLine("Unable to find command: " + commandName);
                return;
            }
            Console.WriteLine("{0}: {1}", command.Name, command.Description);
            Console.WriteLine();
            Console.WriteLine("Usage:");
            Console.WriteLine("{0}", command.Usage);
            Console.WriteLine();
            Console.WriteLine(command.HelpMessage);
        }

        private bool IsAvailable(CommandContext context, Command command)
        {
            return ((command.Flags & CommandFlags.Inherit) != 0 || ContextStack.Context == context);
        }
    }
}
