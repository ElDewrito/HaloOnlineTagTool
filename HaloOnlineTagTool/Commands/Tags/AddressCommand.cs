﻿using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HaloOnlineTagTool.Commands.Tags
{
    class AddressCommand : Command
    {
        public AddressCommand() : base(
            CommandFlags.Inherit,

            "address",
            "Get the address of a tag in memory",

            "address <tag index> [process id]",

            "Gets the address of the given tag in memory.\n" +
            "By default, this will read the memory of the first eldorado.exe process found.\n" +
            "Specify a process ID in hexadecimal to read the memory of a specific process.\n")
        {
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1 && args.Count != 2)
                return false;
            int tagIndex;
            if (!int.TryParse(args[0], NumberStyles.HexNumber, null, out tagIndex) || tagIndex < 0)
                return false;

            // Get the process to open
            Process process;
            if (args.Count == 2)
            {
                // Get process by ID
                int processId;
                if (!int.TryParse(args[1], NumberStyles.HexNumber, null, out processId) || processId < 0)
                    return false;
                try
                {
                    process = Process.GetProcessById(processId);
                }
                catch (ArgumentException)
                {
                    Console.Error.WriteLine("Unable to find a process with an ID of 0x{0:X}", processId);
                    return true;
                }
            }
            else
            {
                // Find first eldorado process
                var processes = Process.GetProcessesByName("eldorado");
                if (processes.Length == 0)
                {
                    Console.Error.WriteLine("Unable to find any eldorado.exe processes.");
                    return true;
                }
                process = processes[0];
            }
            using (var stream = new ProcessMemoryStream(process))
            {
                var address = GetTagAddress(stream, tagIndex);
                if (address != 0)
                    Console.WriteLine("Tag 0x{0:X} is loaded at 0x{1:X8} in process 0x{2:X}.", tagIndex, address, process.Id);
                else
                    Console.Error.WriteLine("Tag 0x{0:X} is not loaded in process 0x{1:X}.", tagIndex, process.Id);
            }
            return true;
        }

        private static uint GetTagAddress(ProcessMemoryStream stream, int tagIndex)
        {
            // Read the tag count and validate the tag index
            var reader = new BinaryReader(stream);
            reader.BaseStream.Position = 0x22AB008;
            var maxIndex = reader.ReadInt32();
            if (tagIndex >= maxIndex)
                return 0;

            // Read the tag index table to get the index of the tag in the address table
            reader.BaseStream.Position = 0x22AAFFC;
            var tagIndexTableAddress = reader.ReadUInt32();
            if (tagIndexTableAddress == 0)
                return 0;
            reader.BaseStream.Position = tagIndexTableAddress + tagIndex * 4;
            var addressIndex = reader.ReadInt32();
            if (addressIndex < 0)
                return 0;

            // Read the tag's address in the address table
            reader.BaseStream.Position = 0x22AAFF8;
            var tagAddressTableAddress = reader.ReadUInt32();
            if (tagAddressTableAddress == 0)
                return 0;
            reader.BaseStream.Position = tagAddressTableAddress + addressIndex * 4;
            return reader.ReadUInt32();
        }
    }
}
