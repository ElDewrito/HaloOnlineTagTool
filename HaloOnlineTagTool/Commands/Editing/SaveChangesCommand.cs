using System;
using System.Collections.Generic;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Commands.Editing
{
    class SaveChangesCommand : Command
    {
        public OpenTagCache Info { get; }

        public TagInstance Tag { get; }

        public object Value { get; }

        public SaveChangesCommand(OpenTagCache info, TagInstance tag, object value)
            : base(CommandFlags.Inherit,
                  "savechanges",
                  $"Saves changes made to the current {info.StringIds.GetString(tag.Group.Name)} definition.",
                  "savechanges",
                  $"Saves changes made to the current {info.StringIds.GetString(tag.Group.Name)} definition.")
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
