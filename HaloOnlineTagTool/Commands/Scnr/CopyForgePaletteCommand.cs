using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Scnr
{
    class CopyForgePaletteCommand : Command
    {
        private OpenTagCache Info { get; }
        private Scenario SourceScenario { get; }

        public CopyForgePaletteCommand(OpenTagCache info, Scenario sourceScenario)
            : base(CommandFlags.Inherit,
                 "CopyForgePalette",
                 "Copies the forge palette from the current scenario to another scenario.",
                 "CopyForgePalette <destination scenario>",
                 "Copies the forge palette from the current scenario to another scenario.")
        {
            Info = info;
            SourceScenario = sourceScenario;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            var destinationTag = ArgumentParser.ParseTagIndex(Info.Cache, args[0]);

            Scenario destinationScenario = null;

            using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var scenarioContext = new TagSerializationContext(cacheStream, Info.Cache, destinationTag);
                destinationScenario = Info.Deserializer.Deserialize<Scenario>(scenarioContext);
            }

            destinationScenario.SandboxBudget = SourceScenario.SandboxBudget;
            destinationScenario.SandboxEquipment = SourceScenario.SandboxEquipment;
            destinationScenario.SandboxGoalObjects = SourceScenario.SandboxGoalObjects;
            destinationScenario.SandboxScenery = SourceScenario.SandboxScenery;
            destinationScenario.SandboxSpawning = SourceScenario.SandboxSpawning;
            destinationScenario.SandboxTeleporters = SourceScenario.SandboxTeleporters;
            destinationScenario.SandboxVehicles = SourceScenario.SandboxVehicles;
            destinationScenario.SandboxWeapons = SourceScenario.SandboxWeapons;

            using (var cacheStream = Info.CacheFile.Open(FileMode.Open, FileAccess.ReadWrite))
            {
                var scenarioContext = new TagSerializationContext(cacheStream, Info.Cache, destinationTag);
                Info.Serializer.Serialize(scenarioContext, destinationScenario);
            }

            return true;
        }
    }
}

