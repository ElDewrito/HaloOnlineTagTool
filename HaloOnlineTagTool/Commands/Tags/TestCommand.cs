using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Serialization;
using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Tags
{
    class TestCommand : Command
    {
        private OpenTagCache Info { get; }

        public TestCommand(OpenTagCache info)
            : base(CommandFlags.Inherit, "test", "", "test", "")
        {
            Info = info;
        }

        public override bool Execute(List<string> args)
        {
            var tag = ArgumentParser.ParseTagIndex(Info.Cache, args[0]);

            if (tag.Group.Tag != new Tag("scnr"))
            {
                Console.WriteLine("Invalid scenario tag index: {0}.", args[0]);
                return false;
            }

            var writer = new StreamWriter(File.Create($"h3-palette-{tag.Index:X4}.txt"));

            using (var cacheStream = Info.CacheFile.OpenRead())
            {
                var context = new TagSerializationContext(cacheStream, Info.Cache, Info.StringIds, tag);
                var scenario = Info.Deserializer.Deserialize<Scenario>(context);

                writer.WriteLine($"edit {tag.Index:X4}");
                writer.WriteLine("");

                writer.WriteLine("removefrom Weapons 0 *");
                writer.WriteLine("removefrom WeaponPalette 0 *");
                writer.WriteLine("");

                foreach (var placementEntry in scenario.Weapons)
                {
                    writer.WriteLine("addto Weapons");
                    writer.WriteLine("edit Weapons[*]");
                    writer.WriteLine("");

                    var e = new TagFieldEnumerator(
                        new TagStructureInfo(typeof(Scenario.Weapon), Info.Version));

                    while (e.Next())
                        if (e.Field.FieldType.GetInterface("IList") == null)
                            writer.WriteLine("setfield {0} {1}", e.Field.Name, GetFieldString(placementEntry, e.Field));

                    writer.WriteLine("");
                    writer.WriteLine("exit");
                    writer.WriteLine("");
                }

                foreach (var paletteEntry in scenario.WeaponPalette)
                {
                    writer.WriteLine("addto WeaponPalette");
                    writer.WriteLine("edit WeaponPalette[*]");
                    writer.WriteLine("");

                    var e = new TagFieldEnumerator(
                        new TagStructureInfo(typeof(Scenario.WeaponPaletteBlock), Info.Version));

                    while (e.Next())
                        if (e.Field.FieldType.GetInterface("IList") == null)
                            writer.WriteLine("setfield {0} {1}", e.Field.Name, GetFieldString(paletteEntry, e.Field));

                    writer.WriteLine("");
                    writer.WriteLine("exit");
                    writer.WriteLine("");
                }

                writer.WriteLine("removefrom Equipment 0 *");
                writer.WriteLine("removefrom EquipmentPalette 0 *");
                writer.WriteLine("");

                foreach (var placementEntry in scenario.Equipment)
                {
                    writer.WriteLine("addto Equipment");
                    writer.WriteLine("edit Equipment[*]");
                    writer.WriteLine("");

                    var e = new TagFieldEnumerator(
                        new TagStructureInfo(typeof(Scenario.EquipmentBlock), Info.Version));

                    while (e.Next())
                        if (e.Field.FieldType.GetInterface("IList") == null)
                            writer.WriteLine("setfield {0} {1}", e.Field.Name, GetFieldString(placementEntry, e.Field));

                    writer.WriteLine("");
                    writer.WriteLine("exit");
                    writer.WriteLine("");
                }

                foreach (var paletteEntry in scenario.EquipmentPalette)
                {
                    writer.WriteLine("addto EquipmentPalette");
                    writer.WriteLine("edit EquipmentPalette[*]");
                    writer.WriteLine("");

                    var e = new TagFieldEnumerator(
                        new TagStructureInfo(typeof(Scenario.EquipmentPaletteBlock), Info.Version));

                    while (e.Next())
                        if (e.Field.FieldType.GetInterface("IList") == null)
                            writer.WriteLine("setfield {0} {1}", e.Field.Name, GetFieldString(paletteEntry, e.Field));

                    writer.WriteLine("");
                    writer.WriteLine("exit");
                    writer.WriteLine("");
                }

                writer.WriteLine("savechanges");
                writer.WriteLine("exitto tags.dat");

            }

            writer.Close();

            return true;
        }

        private string GetFieldString(object parent, FieldInfo field)
        {
            var value = field.GetValue(parent);

            if (field.FieldType == typeof(Angle))
                return ((Angle)value).Radians.ToString();
            else if (field.FieldType == typeof(TagInstance))
                return ((TagInstance)value).Index.ToString("X4");
            else if (field.FieldType == typeof(StringId))
                return "\"" + Info.StringIds.GetString((StringId)value) + "\"";
            else
                return value.ToString();
        }
    }
}
