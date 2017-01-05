using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.BSP
{
    static class BSPContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, TagInstance tag, ScenarioStructureBsp sbsp)
        {
            var groupName = info.StringIds.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(context, info, tag, sbsp);

            return context;
        }

        public static void Populate(CommandContext context, OpenTagCache info, TagInstance tag, ScenarioStructureBsp sbsp)
        {
            context.AddCommand(new CollisionCommand(info, tag, sbsp));
        }
    }
}
