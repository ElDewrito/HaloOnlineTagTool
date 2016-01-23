using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using HaloOnlineTagTool.Common;
using HaloOnlineTagTool.Resources;
using HaloOnlineTagTool.Serialization;

namespace HaloOnlineTagTool.TagStructures
{
    [TagStructure(Name = "model_animation_graph", Class = "jmad", Size = 0x104)]
    public class ModelAnimationGraph
    {
        public TagInstance ParentAnimationGraph;
        public byte InheritanceFlags;
        public byte PrivateFlags;
        public short AnimationCodecPack;
        public List<SkeletonNode> SkeletonNodes;
        public List<AnimationTagReference> SoundReferences;
        public List<AnimationTagReference> EffectReferences;
        public List<BlendScreen> BlendScreens;
        public List<Leg> Legs;
        public List<Animation> Animations;
        public List<Mode> Modes;
        public List<VehicleSuspensionBlock> VehicleSuspension;
        public List<ObjectOverlay> ObjectOverlays;
        public List<InheritanceListBlock> InheritanceList;
        public List<WeaponListBlock> WeaponList;
        public uint UnknownArmNodes1;
        public uint UnknownArmNodes2;
        public uint UnknownArmNodes3;
        public uint UnknownArmNodes4;
        public uint UnknownArmNodes5;
        public uint UnknownArmNodes6;
        public uint UnknownArmNodes7;
        public uint UnknownArmNodes8;
        public uint UnknownNodes1;
        public uint UnknownNodes2;
        public uint UnknownNodes3;
        public uint UnknownNodes4;
        public uint UnknownNodes5;
        public uint UnknownNodes6;
        public uint UnknownNodes7;
        public uint UnknownNodes8;
        public byte[] LastImportResults;
        public uint Unknown;
        public uint Unknown2;
        public uint Unknown3;
        public List<ResourceGroup> ResourceGroups;

        [TagStructure(Size = 0x20)]
        public class SkeletonNode
        {
            public StringId Name;
            public short NextSiblingNodeIndex;
            public short FirstChildNodeIndex;
            public short ParentNodeIndex;
            public byte ModelFlags;
            public byte NodeJointFlags;
            public float BaseVectorI;
            public float BaseVectorJ;
            public float BaseVectorK;
            public float VectorRange;
            public float ZPosition;
        }

        [TagStructure(Size = 0x14)]
        public class AnimationTagReference
        {
            public TagInstance Reference;
            public AnimationTagReferenceFlags Flags;
            public short Unknown;
        }

        [Flags]
        public enum AnimationTagReferenceFlags : ushort
        {
            None = 0,
            AllowOnPlayer = 1 << 0,
            LeftArmOnly = 1 << 1,
            RightArmOnly = 1 << 2,
            FirstPersonOnly = 1 << 3,
            ForwardOnly = 1 << 4,
            ReverseOnly = 1 << 5,
            Bit6 = 1 << 6,
            Bit7 = 1 << 7,
            Bit8 = 1 << 8,
            Bit9 = 1 << 9,
            Bit10 = 1 << 10,
            Bit11 = 1 << 11,
            Bit12 = 1 << 12,
            Bit13 = 1 << 13,
            Bit14 = 1 << 14,
            Bit15 = 1 << 15
        }
        
        [TagStructure(Size = 0x1C)]
        public class BlendScreen
        {
            public StringId Label;
            public Angle RightYawPerFrame;
            public Angle LeftYawPerFrame;
            public short RightFrameCount;
            public short LeftFrameCount;
            public Angle DownPitchPerFrame;
            public Angle UpPitchPerFrame;
            public short DownPitchFrameCount;
            public short UpPitchFrameCount;
        }

        [TagStructure(Size = 0x1C)]
        public class Leg
        {
            public StringId FootMarker;
            public float FootMin;
            public float FootMax;
            public StringId AnkleMarker;
            public float AnkleMin;
            public float AnkleMax;
            public AnchorsValue Anchors;
            public short Unknown;

            public enum AnchorsValue : short
            {
                False,
                True,
            }
        }

        [TagStructure(Size = 0x88)]
        public class Animation
        {
            public StringId Name;
            public float Weight;
            public short LoopFrameIndex;
            public ushort PlaybackFlags;
            public sbyte BlendScreen;
            public CompressionValue DesiredCompression;
            public CompressionValue CurrentCompression;
            public sbyte NodeCount;
            public short FrameCount;
            public TypeValue Type;
            public FrameInfoTypeValue FrameInfoType;
            public ushort ProductionFlags;
            public ushort InternalFlags;
            public int NodeListChecksum;
            public int ProductionChecksum;
            public short Unknown;
            public short Unknown2;
            public short PreviousVariantSibling;
            public short NextVariantSibling;
            public short ResourceGroupIndex;
            public short ResourceGroupMemberIndex;
            public List<FrameEvent> FrameEvents;
            public List<SoundEvent> SoundEvents;
            public List<EffectEvent> EffectEvents;
            public List<UnknownBlock> Unknown3;
            public List<ObjectSpaceParentNode> ObjectSpaceParentNodes;
            public List<LegAnchoringBlock> LegAnchoring;
            public float Unknown4;
            public float Unknown5;
            public float Unknown6;
            public float Unknown7;
            public float Unknown8;

            public enum CompressionValue : sbyte
            {
                BestScore,
                BestCompression,
                BestAccuracy,
                BestFullframe,
                BestSmallKeyframe,
                BestLargeKeyframe,
            }

            public enum TypeValue : sbyte
            {
                Base,
                Overlay,
                Replacement,
            }

            public enum FrameInfoTypeValue : sbyte
            {
                None,
                DxDy,
                DxDyDyaw,
                DxDyDzDyaw,
            }

            [TagStructure(Size = 0x4)]
            public class FrameEvent
            {
                public TypeValue Type;
                public short Frame;

                public enum TypeValue : short
                {
                    PrimaryKeyframe,
                    SecondaryKeyframe,
                    LeftFoot,
                    RightFoot,
                    AllowInterruption,
                    TransitionA,
                    TransitionB,
                    TransitionC,
                    TransitionD,
                    BothFeetShuffle,
                    BodyImpact,
                }
            }

            [TagStructure(Size = 0x8)]
            public class SoundEvent
            {
                public short Sound;
                public short Frame;
                public StringId MarkerName;
            }

            [TagStructure(Size = 0x8)]
            public class EffectEvent
            {
                public short Effect;
                public short Frame;
                public StringId MarkerName;
            }

            [TagStructure(Size = 0x4)]
            public class UnknownBlock
            {
                public short Unknown;
                public short Unknown2;
            }

            [TagStructure(Size = 0x1C)]
            public class ObjectSpaceParentNode
            {
                public short NodeIndex;
                public ushort ComponentFlags;
                public Vector4 Rotation;
                public Vector3 DefaultTranslation;
                public float DefaultScale;
            }

            [TagStructure(Size = 0x10)]
            public class LegAnchoringBlock
            {
                public short LegIndex;
                public short Unknown;
                public List<UnknownBlock> Unknown2;

                [TagStructure(Size = 0x14)]
                public class UnknownBlock
                {
                    public short Frame1a;
                    public short Frame2a;
                    public short Frame1b;
                    public short Frame2b;
                    public uint Unknown;
                    public uint Unknown2;
                    public uint Unknown3;
                }
            }
        }

        [TagStructure(Size = 0x28)]
        public class Mode
        {
            public StringId Label;
            public List<WeaponClassBlock> WeaponClass;
            public List<ModeIkBlock> ModeIk;
            public uint Unknown;
            public uint Unknown2;
            public uint Unknown3;

            [TagStructure(Size = 0x28)]
            public class WeaponClassBlock
            {
                public StringId Label;
                public List<WeaponTypeBlock> WeaponType;
                public List<WeaponIkBlock> WeaponIk;
                public List<SyncAction> SyncActions;

                [TagStructure(Size = 0x34)]
                public class WeaponTypeBlock
                {
                    public StringId Label;
                    public List<Action> Actions;
                    public List<Overlay> Overlays;
                    public List<DeathAndDamageBlock> DeathAndDamage;
                    public List<Transition> Transitions;

                    [TagStructure(Size = 0x8)]
                    public class Action
                    {
                        public StringId Label;
                        public short GraphIndex;
                        public short Animation;
                    }

                    [TagStructure(Size = 0x8)]
                    public class Overlay
                    {
                        public StringId Label;
                        public short GraphIndex;
                        public short Animation;
                    }

                    [TagStructure(Size = 0x10)]
                    public class DeathAndDamageBlock
                    {
                        public StringId Label;
                        public List<Direction> Directions;

                        [TagStructure(Size = 0xC)]
                        public class Direction
                        {
                            public List<Region> Regions;

                            [TagStructure(Size = 0x4)]
                            public class Region
                            {
                                public short GraphIndex;
                                public short Animation;
                            }
                        }
                    }

                    [TagStructure(Size = 0x18)]
                    public class Transition
                    {
                        public StringId FullName;
                        public StringId StateName;
                        public short Unknown;
                        public sbyte IndexA;
                        public sbyte IndexB;
                        public List<Destination> Destinations;

                        [TagStructure(Size = 0x14)]
                        public class Destination
                        {
                            public StringId FullName;
                            public StringId ModeName;
                            public StringId StateName;
                            public FrameEventLinkValue FrameEventLink;
                            public sbyte Unknown;
                            public sbyte IndexA;
                            public sbyte IndexB;
                            public short GraphIndex;
                            public short Animation;

                            public enum FrameEventLinkValue : sbyte
                            {
                                NoKeyframe,
                                KeyframeTypeA,
                                KeyframeTypeB,
                                KeyframeTypeC,
                                KeyframeTypeD,
                            }
                        }
                    }
                }

                [TagStructure(Size = 0x8)]
                public class WeaponIkBlock
                {
                    public StringId Marker;
                    public StringId AttachToMarker;
                }

                [TagStructure(Size = 0x10)]
                public class SyncAction
                {
                    public StringId Label;
                    public List<ClassBlock> Class;

                    [TagStructure(Size = 0x1C)]
                    public class ClassBlock
                    {
                        public StringId Label;
                        public List<UnknownBlock> Unknown;
                        public List<SyncBipedBlock> SyncBiped;

                        [TagStructure(Size = 0x30)]
                        public class UnknownBlock
                        {
                            public int Unknown;
                            public short GraphIndex;
                            public short Animation;
                            public uint Unknown2;
                            public uint Unknown3;
                            public uint Unknown4;
                            public uint Unknown5;
                            public uint Unknown6;
                            public uint Unknown7;
                            public uint Unknown8;
                            public uint Unknown9;
                            public uint Unknown10;
                            public uint Unknown11;
                        }

                        [TagStructure(Size = 0x14)]
                        public class SyncBipedBlock
                        {
                            public int Unknown;
                            public TagInstance Biped;
                        }
                    }
                }
            }

            [TagStructure(Size = 0x8)]
            public class ModeIkBlock
            {
                public StringId Marker;
                public StringId AttachToMarker;
            }
        }

        [TagStructure(Size = 0x28)]
        public class VehicleSuspensionBlock
        {
            public StringId Label;
            public short GraphIndex;
            public short Animation;
            public StringId MarkerName;
            public float MassPointOffset;
            public float FullExtensionGroundDepth;
            public float FullCompressionGroundDepth;
            public StringId RegionName;
            public float MassPointOffset2;
            public float ExpressionGroundDepth;
            public float CompressionGroundDepth;
        }

        [TagStructure(Size = 0x14)]
        public class ObjectOverlay
        {
            public StringId Label;
            public short GraphIndex;
            public short Animation;
            public short Unknown;
            public FunctionControlsValue FunctionControls;
            public StringId Function;
            public uint Unknown2;

            public enum FunctionControlsValue : short
            {
                Frame,
                Scale,
            }
        }

        [TagStructure(Size = 0x30)]
        public class InheritanceListBlock
        {
            public TagInstance InheritedGraph;
            public List<NodeMapBlock> NodeMap;
            public List<NodeMapFlag> NodeMapFlags;
            public float RootZOffset;
            public uint InheritanceFlags;

            [TagStructure(Size = 0x2)]
            public class NodeMapBlock
            {
                public short LocalNode;
            }

            [TagStructure(Size = 0x4)]
            public class NodeMapFlag
            {
                public uint LocalNodeFlags;
            }
        }

        [TagStructure(Size = 0x8)]
        public class WeaponListBlock
        {
            public StringId WeaponName;
            public StringId WeaponClass;
        }

        [TagStructure(Size = 0xC)]
        public class ResourceGroup
        {
            public int MemberCount;
            public ResourceReference Resource;
            public int UnusedPadding;
        }
    }
}
