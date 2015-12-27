using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.Resources
{
    /// <summary>
    /// Points to a D3D-related object.
    /// </summary>
    [TagStructure(Size = 0xC)]
    public class D3DPointer<TDefinition>
    {
        /// <summary>
        /// Gets or sets the definition data for the object.
        /// </summary>
        [TagField(Flags = TagFieldFlags.Indirect)] public TDefinition Definition;

        /// <summary>
        /// Gets or sets the address of the object in memory.
        /// This should be set to 0 because it will be filled in by the game.
        /// </summary>
        public uint Address;

        public int UnusedC;
    }
}
