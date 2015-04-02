using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands
{
	class HelpCommand : Command
	{
		private readonly Dictionary<string, Command> _commands;
 
		public HelpCommand(Dictionary<string, Command> commands) : base(
			"help",
			"Display help",

			"help [command]",

			"Displays help on how to use a command.\n" +
			"If no command is given, help will list all available commands.")
		{
			_commands = commands;
		}

		public override bool Execute(TagCache cache, Stream stream, List<string> args)
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
			// Sort commands and pad them to the length of the longest command name
			var commands = _commands.Values.Where(c => c.Name != "help").OrderBy(c => c.Name);
			var width = commands.Max(c => c.Name.Length);
			var format = "{0,-" + width + "}  {1}";

			Console.WriteLine("Available commands:");
			Console.WriteLine();
			foreach (var command in commands)
				Console.WriteLine(format, command.Name, command.Description);
			Console.WriteLine(format, "help", Description);
			Console.WriteLine(format, "exit", "Exit the program");
			Console.WriteLine();
			Console.WriteLine("Use \"help <command>\" for more information on how to use a command.");
			Console.WriteLine();
			Console.WriteLine("To write the output of a command to a file instead of the screen,");
			Console.WriteLine("use > followed by the name of a file. For example,");
			Console.WriteLine("\"list bipd > bipeds.txt\" will write a list of bipd tags to bipeds.txt.");
			Console.WriteLine();
			Console.WriteLine("All numbers and tag indexes will be parsed as big-endian hexadecimal.");
		}

		private void DisplayCommandHelp(string commandName)
		{
			Command command;
			if (!_commands.TryGetValue(commandName, out command))
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
	}
}
