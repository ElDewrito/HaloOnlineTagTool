using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Unicode
{
    static class UnicodeContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, TagInstance tag, MultilingualUnicodeStringList unic)
        {
            var groupName = info.StringIds.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(context, info, tag, unic);

            return context;
        }

        public static void Populate(CommandContext context, OpenTagCache info, TagInstance tag, MultilingualUnicodeStringList unic)
        {
            if (info.StringIds == null)
                return;

            context.AddCommand(new ListCommand(info, unic));
            context.AddCommand(new SetCommand(info, tag, unic));
        }
    }
}
