﻿using System;
using System.Collections.Generic;
using System.Globalization;

namespace HaloOnlineTagTool.Commands.Core
{
    class SetLocaleCommand : Command
    {
        public SetLocaleCommand()
            : base(CommandFlags.Inherit,
                  "SetLocale",
                  "Changes the parsing locale of numbers to the specified locale.",
                  "SetLocale <locale>",
                  "Use a culture name from https://msdn.microsoft.com/en-us/library/system.globalization.cultureinfo(vs.71).aspx")
        {
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count < 1)
                return false;
            CultureInfo ci;
            try
            {
                ci = CultureInfo.GetCultureInfo(args[0]);
            }
            catch (Exception e)
            {
                Console.WriteLine(e.Message);
                return false;
            }
            CultureInfo.DefaultThreadCurrentCulture = ci;
            return true;
        }
    }
}
