using HaloOnlineTagTool.TagStructures;

namespace HaloOnlineTagTool.Commands.VFiles
{
    static class VFilesContextFactory
    {
        public static CommandContext Create(CommandContext parent, OpenTagCache info, TagInstance tag, VFilesList vfsl)
        {
            var groupName = info.StringIds.GetString(tag.Group.Name);

            var context = new CommandContext(parent,
                string.Format("{0:X8}.{1}", tag.Index, groupName));

            return context;
        }

        public static void Populate(CommandContext context, OpenTagCache info, TagInstance tag, VFilesList vfsl)
        {
            context.AddCommand(new ListCommand(vfsl));
            context.AddCommand(new ExtractCommand(vfsl));
            context.AddCommand(new ExtractAllCommand(vfsl));
            context.AddCommand(new ImportCommand(info, tag, vfsl));
            context.AddCommand(new ImportAllCommand(info, tag, vfsl));
        }
    }
}
