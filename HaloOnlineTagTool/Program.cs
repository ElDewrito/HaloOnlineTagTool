using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Commands;

namespace HaloOnlineTagTool
{
	class Program
	{
		static void Main(string[] args)
		{
			// Get the file path from the first argument
			// If no argument is given, load tags.dat
			var filePath = (args.Length > 0) ? args[0] : "tags.dat";

			// If there are extra arguments, use them to automatically execute a command
			List<string> autoexecCommand = null;
			if (args.Length > 1)
				autoexecCommand = args.Skip(1).ToList();

			if (autoexecCommand == null)
			{
				Console.WriteLine("Halo Online Tag Tool [{0}]", Assembly.GetExecutingAssembly().GetName().Version);
				Console.WriteLine("Written by Shockfire");
				Console.WriteLine();
				Console.WriteLine("Please report any bugs and feature requests at");
				Console.WriteLine("<https://gitlab.com/Shockfire/HaloOnlineTagTool/issues>.");
				Console.WriteLine();

				Console.Write("Reading...");
			}

			// Load the tag cache
			var fileName = Path.GetFileName(filePath);
			TagCache cache;
			using (var stream = File.OpenRead(filePath))
				cache = new TagCache(stream);

			if (autoexecCommand == null)
				Console.WriteLine("{0} tags loaded.", cache.Tags.Count);

			// Create command dictionary
			var commandDict = new List<Command>
			{
				new DependencyCommand(),
				new ListCommand(),
				new InfoCommand(),
				new ExtractCommand(),
				new ImportCommand(),
				new InsertCommand(),
				new MapCommand()
			}.ToDictionary(c => c.Name);
			var helpCommand = new HelpCommand(commandDict);
			commandDict[helpCommand.Name] = helpCommand;

			// If autoexecuting a command, just run it and return
			if (autoexecCommand != null)
			{
				if (!ExecuteCommand(commandDict, cache, filePath, autoexecCommand))
					Console.Error.WriteLine("Unrecognized command: {0}", autoexecCommand[0]);
				return;
			}
			
			Console.WriteLine("Enter \"help\" to list available commands. Enter \"exit\" to quit.");
			while (true)
			{
				// Read and parse a command
				Console.WriteLine();
				Console.Write("{0}> ", fileName);
				var commandLine = Console.ReadLine();
				string redirectFile;
				var commandArgs = ParseCommand(commandLine, out redirectFile);
				if (commandArgs.Count == 0)
					continue;
				if (commandArgs[0] == "exit" || commandArgs[0] == "quit")
					break;

				// Handle redirection
				var oldOut = Console.Out;
				StreamWriter redirectWriter = null;
				if (redirectFile != null)
				{
					redirectWriter = new StreamWriter(File.Open(redirectFile, FileMode.Create, FileAccess.Write));
					Console.SetOut(redirectWriter);
				}

				// Try to execute it
				if (!ExecuteCommand(commandDict, cache, filePath, commandArgs))
				{
					Console.Error.WriteLine("Unrecognized command: {0}", commandArgs[0]);
					Console.Error.WriteLine("Use \"help\" to list available commands.");
				}

				// Undo redirection
				if (redirectFile != null)
				{
					Console.SetOut(oldOut);
					redirectWriter.Dispose();
					Console.WriteLine("Wrote output to {0}.", redirectFile);
				}
			}
		}

		private static bool ExecuteCommand(Dictionary<string, Command> commands, TagCache cache, string filePath, List<string> commandAndArgs)
		{
			if (commandAndArgs.Count == 0)
				return true;

			// Look up the command
			Command command;
			if (!commands.TryGetValue(commandAndArgs[0], out command))
				return false;

			// Open tags.dat as R/W and then execute the command
			commandAndArgs.RemoveAt(0);
			using (var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
				ExecuteCommand(command, cache, stream, commandAndArgs);

			return true;
		}

		private static void ExecuteCommand(Command command, TagCache cache, Stream stream, List<string> args)
		{
			if (command.Execute(cache, stream, args))
				return;

			Console.Error.WriteLine("{0}: {1}", command.Name, command.Description);
			Console.Error.WriteLine();
			Console.Error.WriteLine("Usage:");
			Console.Error.WriteLine("{0}", command.Usage);
			Console.Error.WriteLine();
			Console.Error.WriteLine("Use \"help {0}\" for more information.", command.Name);
		}

		private static List<string> ParseCommand(string command, out string redirectFile)
		{
			var results = new List<string>();
			var currentArg = new StringBuilder();
			var partStart = -1;
			var quoted = false;
			var redirectStart = -1;
			redirectFile = null;
			for (var i = 0; i < command.Length; i++)
			{
				switch (command[i])
				{
					case '>':
						if (quoted)
							goto default; // Treat like a normal char when quoted
						redirectStart = (partStart != -1) ? results.Count + 1 : results.Count;
						goto case ' '; // Treat like a space
					case ' ':
						if (quoted)
							goto default; // Treat like a normal char when quoted
						if (partStart != -1)
							currentArg.Append(command.Substring(partStart, i - partStart));
						if (currentArg.Length > 0)
							results.Add(currentArg.ToString());
						currentArg.Clear();
						partStart = -1;
						break;
					case '"':
						quoted = !quoted;
						if (partStart != -1)
							currentArg.Append(command.Substring(partStart, i - partStart));
						partStart = -1;
						break;
					default:
						if (partStart == -1)
							partStart = i;
						break;
				}
			}
			if (partStart != -1)
				currentArg.Append(command.Substring(partStart));
			if (currentArg.Length > 0)
				results.Add(currentArg.ToString());
			if (redirectStart >= 0 && redirectStart < results.Count)
			{
				redirectFile = string.Join(" ", results.Skip(redirectStart));
				results.RemoveRange(redirectStart, results.Count - redirectStart);
			}
			return results;
		}
	}
}
