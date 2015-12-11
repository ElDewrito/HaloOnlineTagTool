using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Commands.Editing
{
    class SaveChangesCommand : Command
    {
        public OpenTagCache Info { get; }

        public HaloTag Tag { get; }

        public object Value { get; }

        public SaveChangesCommand(OpenTagCache info, HaloTag tag, object value)
            : base(CommandFlags.Inherit,
                  "SaveChanges",
                  $"Saves changes made to the current {info.StringIds.GetString(tag.GroupName)} definition.",
                  "SaveChanges",
                  $"Saves changes made to the current {info.StringIds.GetString(tag.GroupName)} definition.")
        {
            Info = info;
            Tag = tag;
            Value = value;
        }

        public override bool Execute(List<string> args)
        {
            using (var stream = Info.OpenCacheReadWrite())
            {
                var context = new TagSerializationContext(stream, Info.Cache, Info.StringIds, Tag);
                Info.Serializer.Serialize(context, Value);
            }

            Console.WriteLine("Done!");

            return true;
        }
    }
}
