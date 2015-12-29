using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Class = "item", Size = 0xB4)]
    public class Item : GameObject
    {
        public uint Flags2;
        public short OldMessageIndex;
        public short SortOrder;
        public float OldMultiplayerOnGroundScale;
        public float OldCampaignOnGroundScale;
        public StringId PickupMessage;
        public StringId SwapMessage;
        public StringId PickupOrDualWieldMessage;
        public StringId SwapOrDualWieldMessage;
        public StringId PickedUpMessage;
        public StringId SwitchToMessage;
        public StringId SwitchToFromAiMessage;
        public StringId AllWeaponsEmptyMessage;
        public TagInstance CollisionSound;
        public List<TagInstance> PredictedBitmaps;
        public TagInstance DetonationDamageEffect;
        public float DetonationDelayMin;
        public float DetonationDelayMax;
        public TagInstance DetonatingEffect;
        public TagInstance DetonationEffect;
        public float CampaignGroundScale;
        public float MultiplayerGroundScale;
        public float SmallHoldScale;
        public float SmallHolsterScale;
        public float MediumHoldScale;
        public float MediumHolsterScale;
        public float LargeHoldScale;
        public float LargeHolsterScale;
        public float HugeHoldScale;
        public float HugeHolsterScale;
        public float GroundedFrictionLength;
        public float GroundedFrictionUnknown;
    }
}
