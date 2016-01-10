using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.RenderModels
{
    static class RenderModelContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, TagInstance tag, RenderModel renderModel)
        {
            var groupName = info.StringIds.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            Populate(context, info, tag, renderModel);

            return context;
        }

        public static void Populate(CommandContext context, OpenTagCache info, TagInstance tag, RenderModel renderModel)
        {
            context.AddCommand(new SpecifyShadersCommand(info, tag, renderModel));
        }
    }
}
