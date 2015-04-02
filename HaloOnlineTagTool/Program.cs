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
			Console.WriteLine("Halo Online Tag Tool [{0}]", Assembly.GetExecutingAssembly().GetName().Version);
			Console.WriteLine("Written by Shockfire");
			Console.WriteLine();
			Console.WriteLine("Please report any bugs and feature requests at");
			Console.WriteLine("<https://gitlab.com/Shockfire/HaloOnlineTagTool/issues>.");
			Console.WriteLine();

			var filePath = (args.Length > 0) ? args[0] : "tags.dat";
			
			Console.Write("Reading...");
			var fileName = Path.GetFileName(filePath);
			TagCache cache;
			using (var stream = File.OpenRead(filePath))
				cache = new TagCache(stream);
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
				Command command;
				if (commandDict.TryGetValue(commandArgs[0], out command))
				{
					commandArgs.RemoveAt(0);
					using (var stream = File.Open(filePath, FileMode.Open, FileAccess.ReadWrite))
						ExecuteCommand(command, cache, stream, commandArgs);
				}
				else
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
