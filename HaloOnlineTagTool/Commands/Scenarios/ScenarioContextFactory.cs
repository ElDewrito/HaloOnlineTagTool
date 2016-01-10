using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.Scenarios
{
    static class ScnrContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, TagInstance tag, Scenario scenario)
        {
            var groupName = info.StringIds.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(context, info, tag, scenario);

            return context;
        }

        public static void Populate(CommandContext context, OpenTagCache info, TagInstance tag, Scenario scenario)
        {
            context.AddCommand(new CopyForgePaletteCommand(info, scenario));
        }
    }
}

