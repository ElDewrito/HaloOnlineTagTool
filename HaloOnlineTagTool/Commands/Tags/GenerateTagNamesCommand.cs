using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Tags
{
    class GenerateTagNamesCommand : Command
    {
        private OpenTagCache Info { get; }

        public GenerateTagNamesCommand(OpenTagCache info)
            : base(CommandFlags.Inherit,
                  "gentagnames",
                  "Generates tag names into a csv file (overwriting existing entries).",
                  "gentagnames <csv file>",
                  "Generates tag names into a csv file (overwriting existing entries).")
        {
            Info = info;
        }

        public override bool Execute(List<string> args)
        {
            if (args.Count != 1)
                return false;

            var csvFile = new FileInfo(args[0]);
            var tagNames = new Dictionary<int, string>();

            if (csvFile.Exists)
                tagNames = LoadTagNames(csvFile);

            using (var cacheStream = Info.OpenCacheRead())
            {
                var scenarioTags = Info.Cache.Tags.FindAllInGroup(new Tag("scnr"));
                foreach (var scenarioTag in scenarioTags)
                    SetScenarioName(cacheStream, scenarioTag, ref tagNames);

                var objectTags = Info.Cache.Tags.FindAllInGroup(new Tag("obje"));
                foreach (var objectTag in objectTags)
                    SetGameObjectName(cacheStream, objectTag, ref tagNames);

                var renderModelTags = Info.Cache.Tags.FindAllInGroup(new Tag("mode"));
                foreach (var renderModelTag in renderModelTags)
                    SetRenderModelName(cacheStream, renderModelTag, ref tagNames);

                var modelTags = Info.Cache.Tags.FindAllInGroup(new Tag("hlmt"));
                foreach (var modelTag in modelTags)
                    SetModelName(cacheStream, modelTag, ref tagNames);
            }

            foreach (var tag in Info.Cache.Tags)
                if (!(tag == null || tagNames.ContainsKey(tag.Index)))
                    tagNames[tag.Index] = $"0x{tag.Index:X4}";

            var sortedNames = tagNames.ToList();
            sortedNames.Sort((a, b) => a.Key.CompareTo(b.Key));

            using (var csvStream = csvFile.Open(FileMode.Create, FileAccess.ReadWrite))
            {
                var writer = new StreamWriter(csvStream);

                foreach (var entry in sortedNames)
                {
                    var value = entry.Value;

                    if (value.StartsWith("0x"))
                        writer.WriteLine($"0x{entry.Key:X8},{value}");
                    else
                        writer.WriteLine($"0x{entry.Key:X8},0x{entry.Key:X4} {value}");
                }

                writer.Close();
            }

            return true;
        }

        private void SetRenderModelName(Stream stream, TagInstance tag, ref Dictionary<int, string> tagNames)
        {
            if (tagNames.ContainsKey(tag.Index))
                return;

            var context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, tag);
            var definition = Info.Deserializer.Deserialize<RenderModel>(context);
            tagNames[tag.Index] = $"{Info.StringIds.GetString(definition.Name)}";
        }

        private void SetModelName(Stream stream, TagInstance tag, ref Dictionary<int, string> tagNames)
        {
            if (tag == null || tagNames.ContainsKey(tag.Index))
                return;

            var context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, tag);
            var definition = Info.Deserializer.Deserialize<Model>(context);

            if (definition.RenderModel == null)
                return;

            SetRenderModelName(stream, definition.RenderModel, ref tagNames);

            var tagName = tagNames[definition.RenderModel.Index];

            if (tagName.StartsWith("0x"))
                tagName = $"0x{tag.Index:X4}";

            tagNames[tag.Index] = tagName;

            if (definition.CollisionModel != null && !tagName.StartsWith("0x"))
                tagNames[definition.CollisionModel.Index] = $"{tagName}";

            if (definition.Animation != null && !tagName.StartsWith("0x"))
                tagNames[definition.Animation.Index] = $"{tagName}";
        }

        private void SetGameObjectName(Stream stream, TagInstance tag, ref Dictionary<int, string> tagNames)
        {
            var context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, tag);
            var definition = (GameObject)Info.Deserializer.Deserialize(context, TagStructureTypes.FindByGroupTag(tag.Group.Tag));

            if (definition.Model == null)
                return;

            context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, definition.Model);
            var modelDefinition = Info.Deserializer.Deserialize<Model>(context);

            if (modelDefinition.RenderModel == null)
                return;

            context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, modelDefinition.RenderModel);
            var renderModelDefinition = Info.Deserializer.Deserialize<RenderModel>(context);

            var objectName = Info.StringIds.GetString(renderModelDefinition.Name);

            if (tag.Group.Tag == new Tag("bipd"))
            {
                var biped = (Biped)definition;

                var isMultiplayer = objectName.StartsWith("mp_");
                var isMonitor = objectName.StartsWith("monitor");

                var objectRootName = isMultiplayer ?
                    objectName.Substring(3) :
                    objectName;

                var objectGenericName = $"objects\\characters\\{objectRootName}\\{objectRootName}";

                if (objectRootName != objectName)
                    objectName = $"objects\\characters\\{objectRootName}\\{objectName}\\{objectName}";
                else if (isMonitor)
                    objectName = $"{objectGenericName}_editor";
                else
                    objectName = objectGenericName;

                tagNames[definition.Model.Index] = objectName;

                if (modelDefinition.RenderModel != null)
                    tagNames[modelDefinition.RenderModel.Index] = objectName;

                if (modelDefinition.CollisionModel != null)
                    tagNames[modelDefinition.CollisionModel.Index] = objectGenericName;

                if (modelDefinition.PhysicsModel != null)
                    tagNames[modelDefinition.PhysicsModel.Index] = objectGenericName;

                if (modelDefinition.Animation != null)
                    tagNames[modelDefinition.Animation.Index] = objectGenericName;

                if (biped.CollisionDamage != null && !tagNames.ContainsKey(biped.CollisionDamage.Index))
                    tagNames[biped.CollisionDamage.Index] = isMonitor ?
                        "globals\\collision_damage\\invulnerable_harmless" :
                        "globals\\collision_damage\\biped_player";

                if (biped.MaterialEffects != null && !tagNames.ContainsKey(biped.MaterialEffects.Index))
                    tagNames[biped.MaterialEffects.Index] =
                        $"fx\\material_effects\\objects\\characters\\{objectRootName}";

                if (biped.MeleeImpact != null && !tagNames.ContainsKey(biped.MeleeImpact.Index))
                    tagNames[biped.MeleeImpact.Index] =
                        "sounds\\materials\\soft\\organic_flesh\\melee_impact";

                if (biped.CameraTracks.Count != 0 && biped.CameraTracks[0].Track != null && !tagNames.ContainsKey(biped.CameraTracks[0].Track.Index))
                    tagNames[biped.CameraTracks[0].Track.Index] = isMonitor ?
                        "camera\\biped_follow_camera" :
                        "camera\\biped_support_camera";

                if (biped.MeleeDamage != null && !tagNames.ContainsKey(biped.MeleeDamage.Index))
                    tagNames[biped.MeleeDamage.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_melee";

                if (biped.BoardingMeleeDamage != null && !tagNames.ContainsKey(biped.BoardingMeleeDamage.Index))
                    tagNames[biped.BoardingMeleeDamage.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_boarding_melee";

                if (biped.BoardingMeleeResponse != null && !tagNames.ContainsKey(biped.BoardingMeleeResponse.Index))
                    tagNames[biped.BoardingMeleeResponse.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_boarding_melee_response";

                if (biped.EjectionMeleeDamage != null && !tagNames.ContainsKey(biped.EjectionMeleeDamage.Index))
                    tagNames[biped.EjectionMeleeDamage.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_ejection_melee";

                if (biped.EjectionMeleeResponse != null && !tagNames.ContainsKey(biped.EjectionMeleeResponse.Index))
                    tagNames[biped.EjectionMeleeResponse.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_ejection_melee_response";

                if (biped.LandingMeleeDamage != null && !tagNames.ContainsKey(biped.LandingMeleeDamage.Index))
                    tagNames[biped.LandingMeleeDamage.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_landing_melee";

                if (biped.FlurryMeleeDamage != null && !tagNames.ContainsKey(biped.FlurryMeleeDamage.Index))
                    tagNames[biped.FlurryMeleeDamage.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_flurry_melee";

                if (biped.ObstacleSmashMeleeDamage != null && !tagNames.ContainsKey(biped.ObstacleSmashMeleeDamage.Index))
                    tagNames[biped.ObstacleSmashMeleeDamage.Index] =
                        $"objects\\characters\\{objectRootName}\\damage_effects\\{objectRootName}_obstacle_smash";

                if (biped.AreaDamageEffect != null && !tagNames.ContainsKey(biped.AreaDamageEffect.Index))
                    tagNames[biped.AreaDamageEffect.Index] =
                        $"fx\\material_effects\\objects\\characters\\contact\\collision\\blood_aoe_{objectRootName}";
            }
            else if (tag.Group.Tag == new Tag("weap"))
            {
                var weapon = (Weapon)definition;

                if (weapon.HudInterface != null && !tagNames.ContainsKey(weapon.HudInterface.Index))
                    tagNames[weapon.HudInterface.Index] = $"ui\\chud\\{objectName}";

                if (weapon.FirstPerson.Count > 0)
                {
                    var spartanJmadTag = weapon.FirstPerson[0].FirstPersonAnimations;
                    if (spartanJmadTag != null)
                        tagNames[spartanJmadTag.Index] = $"objects\\characters\\mp_masterchief\\fp\\weapons\\fp_{objectName}\\fp_{objectName}";
                }

                if (weapon.FirstPerson.Count > 1)
                {
                    var eliteJmadTag = weapon.FirstPerson[1].FirstPersonAnimations;
                    if (eliteJmadTag != null)
                        tagNames[eliteJmadTag.Index] = $"objects\\characters\\mp_elite\\fp\\weapons\\fp_{objectName}\\fp_{objectName}";
                }

                var weaponClassName =
                    // HUNTER WEAPONS
                    objectName.StartsWith("flak_cannon") ?
                        "hunter\\hunter_flak_cannon" :
                    // MELEE WEAPONS
                    objectName.StartsWith("energy_blade") ?
                        "melee\\energy_blade" :
                    objectName.StartsWith("gravity_hammer") ?
                        "melee\\gravity_hammer" :
                    // MULTIPLAYER WEAPONS
                    objectName.StartsWith("assault_bomb") ?
                        "multiplayer\\assault_bomb" :
                    objectName.StartsWith("ball") ?
                        "multiplayer\\ball" :
                    objectName.StartsWith("flag") ?
                        "multiplayer\\flag" :
                    // PISTOL WEAPONS
                    objectName.StartsWith("excavator") ?
                        "pistol\\excavator" :
                    objectName.StartsWith("magnum") ?
                        "pistol\\magnum" :
                    objectName.StartsWith("needler") ?
                        "pistol\\needler" :
                    objectName.StartsWith("plasma_pistol") ?
                        "pistol\\plasma_pistol" :
                    // RIFLE WEAPONS
                    (objectName.StartsWith("assault_rifle") || objectName.StartsWith("ar_variant")) ?
                        "rifle\\assault_rifle" :
                    (objectName.StartsWith("battle_rifle") || objectName.StartsWith("br_variant")) ?
                        "rifle\\battle_rifle" :
                    objectName.StartsWith("beam_rifle") ?
                        "rifle\\beam_rifle" :
                    objectName.StartsWith("covenant_carbine") ?
                        "rifle\\covenant_carbine" :
                    objectName.StartsWith("dmr") ?
                        "rifle\\dmr" :
                    objectName.StartsWith("needle_rifle") ?
                        "rifle\\needle_rifle" :
                    objectName.StartsWith("plasma_rifle") ?
                        "rifle\\plasma_rifle" :
                    objectName.StartsWith("shotgun") ?
                        "rifle\\shotgun" :
                    objectName.StartsWith("smg") ?
                        "rifle\\smg" :
                    objectName.StartsWith("sniper_rifle") ?
                        "rifle\\sniper_rifle" :
                    objectName.StartsWith("spike_rifle") ?
                        "rifle\\spike_rifle" :
                    // SUPPORT WEAPONS
                    objectName.StartsWith("rocket_launcher") ?
                        "support_high\\rocket_launcher" :
                    objectName.StartsWith("spartan_laser") ?
                        "support_high\\spartan_laser" :
                    objectName.StartsWith("brute_shot") ?
                        "support_low\\brute_shot" :
                    objectName.StartsWith("sentinel_gun") ?
                        "support_low\\sentinel_gun" :
                    // OTHER WEAPONS
                    objectName;

                objectName = $"objects\\weapons\\{weaponClassName}\\{objectName}";

                if (objectName.EndsWith("energy_blade") && definition.WaterDensity == GameObject.WaterDensityValue.Default)
                    objectName += "_useless";

                tagNames[definition.Model.Index] = objectName;

                if (modelDefinition.RenderModel != null)
                    tagNames[modelDefinition.RenderModel.Index] = objectName;

                if (modelDefinition.CollisionModel != null)
                    tagNames[modelDefinition.CollisionModel.Index] = objectName;

                if (modelDefinition.PhysicsModel != null)
                    tagNames[modelDefinition.PhysicsModel.Index] = objectName;

                if (modelDefinition.Animation != null)
                    tagNames[modelDefinition.Animation.Index] = objectName;
            }
            else if (tag.Group.Tag == new Tag("eqip"))
            {
                var equipment = (Equipment)definition;

                var equipmentClassName =
                    (objectName.StartsWith("health_pack") || objectName.EndsWith("ammo")) ?
                        $"powerups\\{objectName}" :
                    objectName.StartsWith("powerup") ?
                        $"multi\\powerups\\{objectName}" :
                    objectName.EndsWith("grenade") ?
                        $"weapons\\grenade\\{objectName}" :
                    $"equipment\\{objectName}";

                objectName = $"objects\\{equipmentClassName}\\{objectName}";
            }
            else if (tag.Group.Tag == new Tag("vehi"))
            {

            }
            else if (tag.Group.Tag == new Tag("armr"))
            {
                // TODO: figure out spartan/elite armor name differences

                objectName = $"objects\\characters\\masterchief\\mp_masterchief\\armor\\{objectName}";

                tagNames[definition.Model.Index] = objectName;

                if (modelDefinition.RenderModel != null)
                    tagNames[modelDefinition.RenderModel.Index] = objectName;

                if (modelDefinition.CollisionModel != null)
                    tagNames[modelDefinition.CollisionModel.Index] = objectName;

                if (modelDefinition.PhysicsModel != null)
                    tagNames[modelDefinition.PhysicsModel.Index] = objectName;

                if (modelDefinition.Animation != null)
                    tagNames[modelDefinition.Animation.Index] = objectName;
            }

            tagNames[tag.Index] = objectName;
        }

        private void SetScenarioName(Stream stream, TagInstance tag, ref Dictionary<int, string> tagNames)
        {
            var context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, tag);
            var definition = Info.Deserializer.Deserialize<Scenario>(context);

            var tagName = Info.StringIds.GetString(definition.ScenarioZonesetGroups[0].Name);
            var slashIndex = tagName.LastIndexOf('\\');
            var scenarioName = tagName.Substring(slashIndex + 1);

            tagNames[tag.Index] = tagName;

            var bsp = definition.StructureBsps[0].StructureBsp2;
            if (bsp != null)
                tagNames[bsp.Index] = tagName;

            var design = definition.StructureBsps[0].Design;
            if (design != null)
                tagNames[design.Index] = $"{tagName}_design";

            var cubemap = definition.StructureBsps[0].Cubemap;
            if (cubemap != null)
                tagNames[cubemap.Index] = $"{tagName}_{scenarioName}_cubemaps";

            var skyObject = definition.SkyReferences[0].SkyObject;
            if (skyObject != null)
                tagNames[skyObject.Index] = $"{tagName.Substring(0, slashIndex)}\\sky\\sky";
        }

        private Dictionary<int, string> LoadTagNames(FileInfo csvFile)
        {
            var result = new Dictionary<int, string>();

            using (var streamReader = new StreamReader(csvFile.OpenRead()))
            {
                while (!streamReader.EndOfStream)
                {
                    var line = streamReader.ReadLine().Split(',');

                    if (line[0] == line[1] || line[1].Length == 0)
                        continue;

                    int tagIndex;

                    if (!int.TryParse(line[0].Replace("0x", ""), NumberStyles.HexNumber, null, out tagIndex))
                        continue;

                    var name = line[1];
                    if (name.StartsWith("0x"))
                        name = name.Substring(name.IndexOf(' ') + 1);

                    result[tagIndex] = name.Replace(' ', '_');
                }
            }

            return result;
        }
    }
}