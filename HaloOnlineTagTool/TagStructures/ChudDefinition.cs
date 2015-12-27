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
    [TagStructure(Name = "chud_definition", Class = "chdt", Size = 0x18)]
    public class ChudDefinition
    {
        public List<HudWidget> HudWidgets;
        public int LowClipCutoff;
        public int LowAmmoCutoff;
        public int AgeCutoff;

        [TagStructure(Size = 0x60)]
        public class HudWidget
        {
            public StringId Name;
            public SpecialHudTypeValue SpecialHudType;
            public byte Unknown;
            public byte Unknown2;
            public List<StateDatum> StateData;
            public List<PlacementDatum> PlacementData;
            public List<AnimationDatum> AnimationData;
            public List<RenderDatum> RenderData;
            public TagInstance ParallaxData;
            public List<BitmapWidget> BitmapWidgets;
            public List<TextWidget> TextWidgets;

            public enum SpecialHudTypeValue : short
            {
                Unspecial,
                Ammo,
                CrosshairAndScope,
                UnitShieldMeter,
                Grenades,
                Gametype,
                MotionSensor,
                SpikeGrenade,
                FirebombGrenade,
                Compass,
                Stamina,
                EnergyMeter,
                Consumable,
            }

            [TagStructure(Size = 0x1C)]
            public class PlacementDatum
            {
                public AnchorValue Anchor;
                public short Unknown;
                public float MirrorOffsetX;
                public float MirrorOffsetY;
                public float OffsetX;
                public float OffsetY;
                public float ScaleX;
                public float ScaleY;

                public enum AnchorValue : short
                {
                    TopLeft,
                    TopRight,
                    BottomRight,
                    BottomLeft,
                    Center,
                    TopEdge,
                    GrenadeA,
                    GrenadeB,
                    GrenadeC,
                    GrenadeD,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    HealthAndShield,
                    BottomEdge,
                    Unknown,
                    Equipment,
                    Unknown2,
                    Depreciated,
                    Depreciated2,
                    Depreciated3,
                    Depreciated4,
                    Depreciated5,
                    Unknown3,
                    Gametype,
                    Unknown4,
                    StateRight,
                    StateLeft,
                    StateCenter,
                    Unknown5,
                    GametypeFriendly,
                    GametypeEnemy,
                    MetagameTop,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Theater,
                }
            }

            [TagStructure(Size = 0x90)]
            public class AnimationDatum
            {
                public uint Unknown;
                public TagInstance Animation1;
                public uint Unknown2;
                public uint Unknown3;
                public TagInstance Animation2;
                public uint Unknown4;
                public uint Unknown5;
                public TagInstance Animation3;
                public uint Unknown6;
                public uint Unknown7;
                public TagInstance Animation4;
                public uint Unknown8;
                public uint Unknown9;
                public TagInstance Animation5;
                public uint Unknown10;
                public uint Unknown11;
                public TagInstance Animation6;
                public uint Unknown12;
            }

            [TagStructure(Size = 0x4)]
            public class RgbaColor
            {
                public byte R;
                public byte G;
                public byte B;
                public byte A;
            }

            [TagStructure(Size = 0x48)]
            public class RenderDatum
            {
                public ShaderIndexValue ShaderIndex;
                public short Unknown;
                public InputValue Input;
                public RangeInputValue RangeInput;
                [TagField(Count = 0x4)] public RgbaColor[] Colors;
                public float LocalScalarA;
                public float LocalScalarB;
                public float LocalScalarC;
                public float LocalScalarD;
                public OutputColorAValue OutputColorA;
                public OutputColorBValue OutputColorB;
                public OutputColorCValue OutputColorC;
                public OutputColorDValue OutputColorD;
                public OutputColorEValue OutputColorE;
                public OutputColorFValue OutputColorF;
                public OutputScalarAValue OutputScalarA;
                public OutputScalarBValue OutputScalarB;
                public OutputScalarCValue OutputScalarC;
                public OutputScalarDValue OutputScalarD;
                public OutputScalarEValue OutputScalarE;
                public OutputScalarFValue OutputScalarF;
                public short Unknown2;
                public short Unknown3;
                public short Unknown4;
                public short Unknown5;

                public enum ShaderIndexValue : short
                {
                    Simple,
                    Meter,
                    TextSimple,
                    MeterShield,
                    MeterGradient,
                    Crosshair,
                    DirectionalDamage,
                    Solid,
                    Sensor,
                    MeterSingleColor,
                    Navpoint,
                    Medal,
                    TextureCam,
                    CortanaScreen,
                    CortanaCamera,
                    CortanaOffscreen,
                    CortanaScreenFinal,
                    MeterChapter,
                    MeterDoubleGradient,
                    MeterRadialGradient,
                    Turbulence,
                    Emblem,
                    CortanaComposite,
                    DirectionalDamageApply,
                    ReallySimple,
                    Unknown,
                }

                public enum InputValue : short
                {
                    Zero,
                    One,
                    Time,
                    Fade,
                    UnitHealthCurrent,
                    UnitHealth,
                    UnitShieldCurrent,
                    UnitShield,
                    ClipAmmoFraction,
                    TotalAmmoFraction,
                    WeaponVersionNumber,
                    HeatFraction,
                    BatteryFraction,
                    WeaponErrorCurrent1,
                    WeaponErrorCurrent2,
                    Pickup,
                    UnitAutoaimed,
                    Grenade,
                    GrenadeFraction,
                    ChargeFraction,
                    FriendlyScore,
                    EnemyScore,
                    ScoreToWin,
                    ArmingFraction,
                    UnknownX18,
                    Unit1xOvershieldCurrent,
                    Unit1xOvershield,
                    Unit2xOvershieldCurrent,
                    Unit2xOvershield,
                    Unit3xOvershieldCurrent,
                    Unit3xOvershield,
                    AimYaw,
                    AimPitch,
                    TargetDistance,
                    TargetElevation,
                    EditorBudget,
                    EditorBudgetCost,
                    FilmTotalTime,
                    FilmCurrentTime,
                    UnknownX27,
                    FilmTimelineFraction1,
                    FilmTimelineFraction2,
                    UnknownX2a,
                    UnknownX2b,
                    MetagameTime,
                    MetagameScoreTransient,
                    MetagameScorePlayer1,
                    MetagameScorePlayer2,
                    MetagameScorePlayer3,
                    MetagameScorePlayer4,
                    MetagameModifier,
                    MetagameSkullModifier,
                    SensorRange,
                    NetdebugLatency,
                    NetdebugLatencyQuality,
                    NetdebugHostQuality,
                    NetdebugLocalQuality,
                    MetagameScoreNegative,
                    SurvivalCurrentSet,
                    UnknownX3b,
                    UnknownX3c,
                    SurvivalCurrentLives,
                    SurvivalBonusTime,
                    SurvivalBonusScore,
                    SurvivalMultiplier,
                    UnknownX41,
                    UnknownX42,
                    UnknownX43,
                    UnknownX44,
                    UnknownX45,
                    UnknownX46,
                    UnknownX47,
                    UnknownX48,
                    UnknownX49,
                    UnknownX4a,
                    UnknownX4b,
                    UnknownX4c,
                    UnknownX4d,
                    Consumable1Icon,
                    Consumable2Icon,
                    UnknownX50,
                    UnknownX51,
                    UnknownX52,
                    Consumable3Icon,
                    Consumable4Icon,
                    ConsumableName,
                    UnknownX56,
                    UnknownX57,
                    UnknownX58,
                    ConsumableCooldownText,
                    ConsumableCooldownMeter,
                    UnknownX5b,
                    UnknownX5c,
                    UnknownX5d,
                    UnknownX5e,
                    Consumable1Charge,
                    Consumable2Charge,
                    Consumable3Charge,
                    Consumable4Charge,
                    UnknownX63,
                    UnknownX64,
                    EnergyMeter1,
                    EnergyMeter2,
                    EnergyMeter3,
                    EnergyMeter4,
                    EnergyMeter5,
                    Consumable1Cost,
                    Consumable2Cost,
                    Consumable3Cost,
                    Consumable4Cost,
                    UnitStaminaCurrent,
                }

                public enum RangeInputValue : short
                {
                    Zero,
                    One,
                    Time,
                    Fade,
                    UnitHealthCurrent,
                    UnitHealth,
                    UnitShieldCurrent,
                    UnitShield,
                    ClipAmmoFraction,
                    TotalAmmoFraction,
                    WeaponVersionNumber,
                    HeatFraction,
                    BatteryFraction,
                    WeaponErrorCurrent1,
                    WeaponErrorCurrent2,
                    Pickup,
                    UnitAutoaimed,
                    Grenade,
                    GrenadeFraction,
                    ChargeFraction,
                    FriendlyScore,
                    EnemyScore,
                    ScoreToWin,
                    ArmingFraction,
                    UnknownX18,
                    Unit1xOvershieldCurrent,
                    Unit1xOvershield,
                    Unit2xOvershieldCurrent,
                    Unit2xOvershield,
                    Unit3xOvershieldCurrent,
                    Unit3xOvershield,
                    AimYaw,
                    AimPitch,
                    TargetDistance,
                    TargetElevation,
                    EditorBudget,
                    EditorBudgetCost,
                    FilmTotalTime,
                    FilmCurrentTime,
                    UnknownX27,
                    FilmTimelineFraction1,
                    FilmTimelineFraction2,
                    UnknownX2a,
                    UnknownX2b,
                    MetagameTime,
                    MetagameScoreTransient,
                    MetagameScorePlayer1,
                    MetagameScorePlayer2,
                    MetagameScorePlayer3,
                    MetagameScorePlayer4,
                    MetagameModifier,
                    MetagameSkullModifier,
                    SensorRange,
                    NetdebugLatency,
                    NetdebugLatencyQuality,
                    NetdebugHostQuality,
                    NetdebugLocalQuality,
                    MetagameScoreNegative,
                    SurvivalCurrentSet,
                    UnknownX3b,
                    UnknownX3c,
                    SurvivalCurrentLives,
                    SurvivalBonusTime,
                    SurvivalBonusScore,
                    SurvivalMultiplier,
                    UnknownX41,
                    UnknownX42,
                    UnknownX43,
                    UnknownX44,
                    UnknownX45,
                    UnknownX46,
                    UnknownX47,
                    UnknownX48,
                    UnknownX49,
                    UnknownX4a,
                    UnknownX4b,
                    UnknownX4c,
                    UnknownX4d,
                    Consumable1Icon,
                    Consumable2Icon,
                    UnknownX50,
                    UnknownX51,
                    UnknownX52,
                    Consumable3Icon,
                    Consumable4Icon,
                    ConsumableName,
                    UnknownX56,
                    UnknownX57,
                    UnknownX58,
                    ConsumableCooldownText,
                    ConsumableCooldownMeter,
                    UnknownX5b,
                    UnknownX5c,
                    UnknownX5d,
                    UnknownX5e,
                    Consumable1Charge,
                    Consumable2Charge,
                    Consumable3Charge,
                    Consumable4Charge,
                    UnknownX63,
                    UnknownX64,
                    EnergyMeter1,
                    EnergyMeter2,
                    EnergyMeter3,
                    EnergyMeter4,
                    EnergyMeter5,
                    Consumable1Cost,
                    Consumable2Cost,
                    Consumable3Cost,
                    Consumable4Cost,
                    UnitStaminaCurrent,
                }

                public enum OutputColorAValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown4,
                    Unknown5,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingTeam,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Unknown13,
                    Unknown14,
                    GlobalDynamic0,
                    GlobalDynamic1,
                    GlobalDynamic2,
                    GlobalDynamic3,
                    GlobalDynamic4,
                    GlobalDynamic5,
                    GlobalDynamic6,
                    GlobalDynamic7,
                    GlobalDynamic8,
                    GlobalDynamic9,
                    GlobalDynamic10,
                    GlobalDynamic11,
                    GlobalDynamic12,
                    GlobalDynamic13,
                    GlobalDynamic14,
                    GlobalDynamic15,
                    GlobalDynamic16,
                    GlobalDynamic17,
                    GlobalDynamic18,
                    GlobalDynamic19,
                    GlobalDynamic20,
                    GlobalDynamic21,
                    GlobalDynamic22,
                    GlobalDynamic23,
                    GlobalDynamic24,
                    GlobalDynamic25,
                    GlobalDynamic26,
                    GlobalDynamic27,
                    GlobalDynamic28,
                    GlobalDynamic29,
                    GlobalDynamic30,
                    GlobalDynamic31,
                    GlobalDynamic32,
                    GlobalDynamic33,
                    GlobalDynamic34,
                    GlobalDynamic35,
                    GlobalDynamic36,
                }

                public enum OutputColorBValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown4,
                    Unknown5,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingTeam,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Unknown13,
                    Unknown14,
                    GlobalDynamic0,
                    GlobalDynamic1,
                    GlobalDynamic2,
                    GlobalDynamic3,
                    GlobalDynamic4,
                    GlobalDynamic5,
                    GlobalDynamic6,
                    GlobalDynamic7,
                    GlobalDynamic8,
                    GlobalDynamic9,
                    GlobalDynamic10,
                    GlobalDynamic11,
                    GlobalDynamic12,
                    GlobalDynamic13,
                    GlobalDynamic14,
                    GlobalDynamic15,
                    GlobalDynamic16,
                    GlobalDynamic17,
                    GlobalDynamic18,
                    GlobalDynamic19,
                    GlobalDynamic20,
                    GlobalDynamic21,
                    GlobalDynamic22,
                    GlobalDynamic23,
                    GlobalDynamic24,
                    GlobalDynamic25,
                    GlobalDynamic26,
                    GlobalDynamic27,
                    GlobalDynamic28,
                    GlobalDynamic29,
                    GlobalDynamic30,
                    GlobalDynamic31,
                    GlobalDynamic32,
                    GlobalDynamic33,
                    GlobalDynamic34,
                    GlobalDynamic35,
                    GlobalDynamic36,
                }

                public enum OutputColorCValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown4,
                    Unknown5,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingTeam,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Unknown13,
                    Unknown14,
                    GlobalDynamic0,
                    GlobalDynamic1,
                    GlobalDynamic2,
                    GlobalDynamic3,
                    GlobalDynamic4,
                    GlobalDynamic5,
                    GlobalDynamic6,
                    GlobalDynamic7,
                    GlobalDynamic8,
                    GlobalDynamic9,
                    GlobalDynamic10,
                    GlobalDynamic11,
                    GlobalDynamic12,
                    GlobalDynamic13,
                    GlobalDynamic14,
                    GlobalDynamic15,
                    GlobalDynamic16,
                    GlobalDynamic17,
                    GlobalDynamic18,
                    GlobalDynamic19,
                    GlobalDynamic20,
                    GlobalDynamic21,
                    GlobalDynamic22,
                    GlobalDynamic23,
                    GlobalDynamic24,
                    GlobalDynamic25,
                    GlobalDynamic26,
                    GlobalDynamic27,
                    GlobalDynamic28,
                    GlobalDynamic29,
                    GlobalDynamic30,
                    GlobalDynamic31,
                    GlobalDynamic32,
                    GlobalDynamic33,
                    GlobalDynamic34,
                    GlobalDynamic35,
                    GlobalDynamic36,
                }

                public enum OutputColorDValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown4,
                    Unknown5,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingTeam,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Unknown13,
                    Unknown14,
                    GlobalDynamic0,
                    GlobalDynamic1,
                    GlobalDynamic2,
                    GlobalDynamic3,
                    GlobalDynamic4,
                    GlobalDynamic5,
                    GlobalDynamic6,
                    GlobalDynamic7,
                    GlobalDynamic8,
                    GlobalDynamic9,
                    GlobalDynamic10,
                    GlobalDynamic11,
                    GlobalDynamic12,
                    GlobalDynamic13,
                    GlobalDynamic14,
                    GlobalDynamic15,
                    GlobalDynamic16,
                    GlobalDynamic17,
                    GlobalDynamic18,
                    GlobalDynamic19,
                    GlobalDynamic20,
                    GlobalDynamic21,
                    GlobalDynamic22,
                    GlobalDynamic23,
                    GlobalDynamic24,
                    GlobalDynamic25,
                    GlobalDynamic26,
                    GlobalDynamic27,
                    GlobalDynamic28,
                    GlobalDynamic29,
                    GlobalDynamic30,
                    GlobalDynamic31,
                    GlobalDynamic32,
                    GlobalDynamic33,
                    GlobalDynamic34,
                    GlobalDynamic35,
                    GlobalDynamic36,
                }

                public enum OutputColorEValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown4,
                    Unknown5,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingTeam,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Unknown13,
                    Unknown14,
                    GlobalDynamic0,
                    GlobalDynamic1,
                    GlobalDynamic2,
                    GlobalDynamic3,
                    GlobalDynamic4,
                    GlobalDynamic5,
                    GlobalDynamic6,
                    GlobalDynamic7,
                    GlobalDynamic8,
                    GlobalDynamic9,
                    GlobalDynamic10,
                    GlobalDynamic11,
                    GlobalDynamic12,
                    GlobalDynamic13,
                    GlobalDynamic14,
                    GlobalDynamic15,
                    GlobalDynamic16,
                    GlobalDynamic17,
                    GlobalDynamic18,
                    GlobalDynamic19,
                    GlobalDynamic20,
                    GlobalDynamic21,
                    GlobalDynamic22,
                    GlobalDynamic23,
                    GlobalDynamic24,
                    GlobalDynamic25,
                    GlobalDynamic26,
                    GlobalDynamic27,
                    GlobalDynamic28,
                    GlobalDynamic29,
                    GlobalDynamic30,
                    GlobalDynamic31,
                    GlobalDynamic32,
                    GlobalDynamic33,
                    GlobalDynamic34,
                    GlobalDynamic35,
                    GlobalDynamic36,
                }

                public enum OutputColorFValue : short
                {
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown4,
                    Unknown5,
                    ScoreboardFriendly,
                    ScoreboardEnemy,
                    ArmingTeam,
                    MetagamePlayer1,
                    MetagamePlayer2,
                    MetagamePlayer3,
                    MetagamePlayer4,
                    Unknown13,
                    Unknown14,
                    GlobalDynamic0,
                    GlobalDynamic1,
                    GlobalDynamic2,
                    GlobalDynamic3,
                    GlobalDynamic4,
                    GlobalDynamic5,
                    GlobalDynamic6,
                    GlobalDynamic7,
                    GlobalDynamic8,
                    GlobalDynamic9,
                    GlobalDynamic10,
                    GlobalDynamic11,
                    GlobalDynamic12,
                    GlobalDynamic13,
                    GlobalDynamic14,
                    GlobalDynamic15,
                    GlobalDynamic16,
                    GlobalDynamic17,
                    GlobalDynamic18,
                    GlobalDynamic19,
                    GlobalDynamic20,
                    GlobalDynamic21,
                    GlobalDynamic22,
                    GlobalDynamic23,
                    GlobalDynamic24,
                    GlobalDynamic25,
                    GlobalDynamic26,
                    GlobalDynamic27,
                    GlobalDynamic28,
                    GlobalDynamic29,
                    GlobalDynamic30,
                    GlobalDynamic31,
                    GlobalDynamic32,
                    GlobalDynamic33,
                    GlobalDynamic34,
                    GlobalDynamic35,
                    GlobalDynamic36,
                }

                public enum OutputScalarAValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown6,
                    Unknown7,
                }

                public enum OutputScalarBValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown6,
                    Unknown7,
                }

                public enum OutputScalarCValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown6,
                    Unknown7,
                }

                public enum OutputScalarDValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown6,
                    Unknown7,
                }

                public enum OutputScalarEValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown6,
                    Unknown7,
                }

                public enum OutputScalarFValue : short
                {
                    Input,
                    RangeInput,
                    LocalA,
                    LocalB,
                    LocalC,
                    LocalD,
                    Unknown6,
                    Unknown7,
                }
            }

            [TagStructure(Size = 0x54)]
            public class BitmapWidget
            {
                public StringId Name;
                public SpecialHudTypeValue SpecialHudType;
                public byte Unknown;
                public byte Unknown2;
                public List<StateDatum> StateData;
                public List<PlacementDatum> PlacementData;
                public List<AnimationDatum> AnimationData;
                public List<RenderDatum> RenderData;
                public int WidgetIndex;
                public ushort Flags;
                public short Unknown3;
                public TagInstance Bitmap;
                public byte BitmapSpriteIndex;
                public byte Unknown4;
                public byte Unknown5;
                public byte Unknown6;

                public enum SpecialHudTypeValue : short
                {
                    Unspecial,
                    Ammo,
                    CrosshairAndScope,
                    UnitShieldMeter,
                    Grenades,
                    Gametype,
                    MotionSensor,
                    SpikeGrenade,
                    FirebombGrenade,
                    Compass,
                    Stamina,
                    EnergyMeter,
                    Consumable,
                }

                [TagStructure(Size = 0x1C)]
                public class PlacementDatum
                {
                    public AnchorValue Anchor;
                    public short Unknown;
                    public float MirrorOffsetX;
                    public float MirrorOffsetY;
                    public float OffsetX;
                    public float OffsetY;
                    public float ScaleX;
                    public float ScaleY;

                    public enum AnchorValue : short
                    {
                        TopLeft,
                        TopRight,
                        BottomRight,
                        BottomLeft,
                        Center,
                        TopEdge,
                        GrenadeA,
                        GrenadeB,
                        GrenadeC,
                        GrenadeD,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        HealthAndShield,
                        BottomEdge,
                        Unknown,
                        Equipment,
                        Unknown2,
                        Depreciated,
                        Depreciated2,
                        Depreciated3,
                        Depreciated4,
                        Depreciated5,
                        Unknown3,
                        Gametype,
                        Unknown4,
                        StateRight,
                        StateLeft,
                        StateCenter,
                        Unknown5,
                        GametypeFriendly,
                        GametypeEnemy,
                        MetagameTop,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Theater,
                    }
                }

                [TagStructure(Size = 0x90)]
                public class AnimationDatum
                {
                    public uint Unknown;
                    public TagInstance Animation1;
                    public uint Unknown2;
                    public uint Unknown3;
                    public TagInstance Animation2;
                    public uint Unknown4;
                    public uint Unknown5;
                    public TagInstance Animation3;
                    public uint Unknown6;
                    public uint Unknown7;
                    public TagInstance Animation4;
                    public uint Unknown8;
                    public uint Unknown9;
                    public TagInstance Animation5;
                    public uint Unknown10;
                    public uint Unknown11;
                    public TagInstance Animation6;
                    public uint Unknown12;
                }

                [TagStructure(Size = 0x48)]
                public class RenderDatum
                {
                    public ShaderIndexValue ShaderIndex;
                    public short Unknown;
                    public InputValue Input;
                    public RangeInputValue RangeInput;
                    [TagField(Count = 0x4)] public RgbaColor[] Colors;
                    public float LocalScalarA;
                    public float LocalScalarB;
                    public float LocalScalarC;
                    public float LocalScalarD;
                    public OutputColorAValue OutputColorA;
                    public OutputColorBValue OutputColorB;
                    public OutputColorCValue OutputColorC;
                    public OutputColorDValue OutputColorD;
                    public OutputColorEValue OutputColorE;
                    public OutputColorFValue OutputColorF;
                    public OutputScalarAValue OutputScalarA;
                    public OutputScalarBValue OutputScalarB;
                    public OutputScalarCValue OutputScalarC;
                    public OutputScalarDValue OutputScalarD;
                    public OutputScalarEValue OutputScalarE;
                    public OutputScalarFValue OutputScalarF;
                    public short Unknown2;
                    public short Unknown3;
                    public short Unknown4;
                    public short Unknown5;

                    public enum ShaderIndexValue : short
                    {
                        Simple,
                        Meter,
                        TextSimple,
                        MeterShield,
                        MeterGradient,
                        Crosshair,
                        DirectionalDamage,
                        Solid,
                        Sensor,
                        MeterSingleColor,
                        Navpoint,
                        Medal,
                        TextureCam,
                        CortanaScreen,
                        CortanaCamera,
                        CortanaOffscreen,
                        CortanaScreenFinal,
                        MeterChapter,
                        MeterDoubleGradient,
                        MeterRadialGradient,
                        Turbulence,
                        Emblem,
                        CortanaComposite,
                        DirectionalDamageApply,
                        ReallySimple,
                        Unknown,
                    }

                    public enum InputValue : short
                    {
                        Zero,
                        One,
                        Time,
                        Fade,
                        UnitHealthCurrent,
                        UnitHealth,
                        UnitShieldCurrent,
                        UnitShield,
                        ClipAmmoFraction,
                        TotalAmmoFraction,
                        WeaponVersionNumber,
                        HeatFraction,
                        BatteryFraction,
                        WeaponErrorCurrent1,
                        WeaponErrorCurrent2,
                        Pickup,
                        UnitAutoaimed,
                        Grenade,
                        GrenadeFraction,
                        ChargeFraction,
                        FriendlyScore,
                        EnemyScore,
                        ScoreToWin,
                        ArmingFraction,
                        UnknownX18,
                        Unit1xOvershieldCurrent,
                        Unit1xOvershield,
                        Unit2xOvershieldCurrent,
                        Unit2xOvershield,
                        Unit3xOvershieldCurrent,
                        Unit3xOvershield,
                        AimYaw,
                        AimPitch,
                        TargetDistance,
                        TargetElevation,
                        EditorBudget,
                        EditorBudgetCost,
                        FilmTotalTime,
                        FilmCurrentTime,
                        UnknownX27,
                        FilmTimelineFraction1,
                        FilmTimelineFraction2,
                        UnknownX2a,
                        UnknownX2b,
                        MetagameTime,
                        MetagameScoreTransient,
                        MetagameScorePlayer1,
                        MetagameScorePlayer2,
                        MetagameScorePlayer3,
                        MetagameScorePlayer4,
                        MetagameModifier,
                        MetagameSkullModifier,
                        SensorRange,
                        NetdebugLatency,
                        NetdebugLatencyQuality,
                        NetdebugHostQuality,
                        NetdebugLocalQuality,
                        MetagameScoreNegative,
                        SurvivalCurrentSet,
                        UnknownX3b,
                        UnknownX3c,
                        SurvivalCurrentLives,
                        SurvivalBonusTime,
                        SurvivalBonusScore,
                        SurvivalMultiplier,
                        UnknownX41,
                        UnknownX42,
                        UnknownX43,
                        UnknownX44,
                        UnknownX45,
                        UnknownX46,
                        UnknownX47,
                        UnknownX48,
                        UnknownX49,
                        UnknownX4a,
                        UnknownX4b,
                        UnknownX4c,
                        UnknownX4d,
                        Consumable1Icon,
                        Consumable2Icon,
                        UnknownX50,
                        UnknownX51,
                        UnknownX52,
                        Consumable3Icon,
                        Consumable4Icon,
                        ConsumableName,
                        UnknownX56,
                        UnknownX57,
                        UnknownX58,
                        ConsumableCooldownText,
                        ConsumableCooldownMeter,
                        UnknownX5b,
                        UnknownX5c,
                        UnknownX5d,
                        UnknownX5e,
                        Consumable1Charge,
                        Consumable2Charge,
                        Consumable3Charge,
                        Consumable4Charge,
                        UnknownX63,
                        UnknownX64,
                        EnergyMeter1,
                        EnergyMeter2,
                        EnergyMeter3,
                        EnergyMeter4,
                        EnergyMeter5,
                        Consumable1Cost,
                        Consumable2Cost,
                        Consumable3Cost,
                        Consumable4Cost,
                        UnitStaminaCurrent,
                    }

                    public enum RangeInputValue : short
                    {
                        Zero,
                        One,
                        Time,
                        Fade,
                        UnitHealthCurrent,
                        UnitHealth,
                        UnitShieldCurrent,
                        UnitShield,
                        ClipAmmoFraction,
                        TotalAmmoFraction,
                        WeaponVersionNumber,
                        HeatFraction,
                        BatteryFraction,
                        WeaponErrorCurrent1,
                        WeaponErrorCurrent2,
                        Pickup,
                        UnitAutoaimed,
                        Grenade,
                        GrenadeFraction,
                        ChargeFraction,
                        FriendlyScore,
                        EnemyScore,
                        ScoreToWin,
                        ArmingFraction,
                        UnknownX18,
                        Unit1xOvershieldCurrent,
                        Unit1xOvershield,
                        Unit2xOvershieldCurrent,
                        Unit2xOvershield,
                        Unit3xOvershieldCurrent,
                        Unit3xOvershield,
                        AimYaw,
                        AimPitch,
                        TargetDistance,
                        TargetElevation,
                        EditorBudget,
                        EditorBudgetCost,
                        FilmTotalTime,
                        FilmCurrentTime,
                        UnknownX27,
                        FilmTimelineFraction1,
                        FilmTimelineFraction2,
                        UnknownX2a,
                        UnknownX2b,
                        MetagameTime,
                        MetagameScoreTransient,
                        MetagameScorePlayer1,
                        MetagameScorePlayer2,
                        MetagameScorePlayer3,
                        MetagameScorePlayer4,
                        MetagameModifier,
                        MetagameSkullModifier,
                        SensorRange,
                        NetdebugLatency,
                        NetdebugLatencyQuality,
                        NetdebugHostQuality,
                        NetdebugLocalQuality,
                        MetagameScoreNegative,
                        SurvivalCurrentSet,
                        UnknownX3b,
                        UnknownX3c,
                        SurvivalCurrentLives,
                        SurvivalBonusTime,
                        SurvivalBonusScore,
                        SurvivalMultiplier,
                        UnknownX41,
                        UnknownX42,
                        UnknownX43,
                        UnknownX44,
                        UnknownX45,
                        UnknownX46,
                        UnknownX47,
                        UnknownX48,
                        UnknownX49,
                        UnknownX4a,
                        UnknownX4b,
                        UnknownX4c,
                        UnknownX4d,
                        Consumable1Icon,
                        Consumable2Icon,
                        UnknownX50,
                        UnknownX51,
                        UnknownX52,
                        Consumable3Icon,
                        Consumable4Icon,
                        ConsumableName,
                        UnknownX56,
                        UnknownX57,
                        UnknownX58,
                        ConsumableCooldownText,
                        ConsumableCooldownMeter,
                        UnknownX5b,
                        UnknownX5c,
                        UnknownX5d,
                        UnknownX5e,
                        Consumable1Charge,
                        Consumable2Charge,
                        Consumable3Charge,
                        Consumable4Charge,
                        UnknownX63,
                        UnknownX64,
                        EnergyMeter1,
                        EnergyMeter2,
                        EnergyMeter3,
                        EnergyMeter4,
                        EnergyMeter5,
                        Consumable1Cost,
                        Consumable2Cost,
                        Consumable3Cost,
                        Consumable4Cost,
                        UnitStaminaCurrent,
                    }

                    public enum OutputColorAValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorBValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorCValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorDValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorEValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorFValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputScalarAValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarBValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarCValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarDValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarEValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarFValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }
                }
            }

            [TagStructure(Size = 0x48)]
            public class TextWidget
            {
                public StringId Name;
                public SpecialHudTypeValue SpecialHudType;
                public byte Unknown;
                public byte Unknown2;
                public List<StateDatum> StateData;
                public List<PlacementDatum> PlacementData;
                public List<AnimationDatum> AnimationData;
                public List<RenderDatum> RenderData;
                public int WidgetIndex;
                public uint Flags;
                public FontValue Font;
                public short Unknown3;
                public StringId String;

                public enum SpecialHudTypeValue : short
                {
                    Unspecial,
                    Ammo,
                    CrosshairAndScope,
                    UnitShieldMeter,
                    Grenades,
                    Gametype,
                    MotionSensor,
                    SpikeGrenade,
                    FirebombGrenade,
                    Compass,
                    Stamina,
                    EnergyMeter,
                    Consumable,
                }

                [TagStructure(Size = 0x1C)]
                public class PlacementDatum
                {
                    public AnchorValue Anchor;
                    public short Unknown;
                    public float MirrorOffsetX;
                    public float MirrorOffsetY;
                    public float OffsetX;
                    public float OffsetY;
                    public float ScaleX;
                    public float ScaleY;

                    public enum AnchorValue : short
                    {
                        TopLeft,
                        TopRight,
                        BottomRight,
                        BottomLeft,
                        Center,
                        TopEdge,
                        GrenadeA,
                        GrenadeB,
                        GrenadeC,
                        GrenadeD,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        HealthAndShield,
                        BottomEdge,
                        Unknown,
                        Equipment,
                        Unknown2,
                        Depreciated,
                        Depreciated2,
                        Depreciated3,
                        Depreciated4,
                        Depreciated5,
                        Unknown3,
                        Gametype,
                        Unknown4,
                        StateRight,
                        StateLeft,
                        StateCenter,
                        Unknown5,
                        GametypeFriendly,
                        GametypeEnemy,
                        MetagameTop,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Theater,
                        Unknown6,
                    }
                }

                [TagStructure(Size = 0x78)]
                public class AnimationDatum
                {
                    public uint Unknown;
                    public TagInstance Animation1;
                    public uint Unknown2;
                    public uint Unknown3;
                    public TagInstance Animation2;
                    public uint Unknown4;
                    public uint Unknown5;
                    public TagInstance Animation3;
                    public uint Unknown6;
                    public uint Unknown7;
                    public TagInstance Animation4;
                    public uint Unknown8;
                    public uint Unknown9;
                    public TagInstance Animation5;
                    public uint Unknown10;
                    public uint Unknown11;
                    public TagInstance Animation6;
                    public uint Unknown12;
                }

                [TagStructure(Size = 0x48)]
                public class RenderDatum
                {
                    public ShaderIndexValue ShaderIndex;
                    public short Unknown;
                    public InputValue Input;
                    public RangeInputValue RangeInput;
                    [TagField(Count = 0x4)] public RgbaColor[] Colors;
                    public float LocalScalarA;
                    public float LocalScalarB;
                    public float LocalScalarC;
                    public float LocalScalarD;
                    public OutputColorAValue OutputColorA;
                    public OutputColorBValue OutputColorB;
                    public OutputColorCValue OutputColorC;
                    public OutputColorDValue OutputColorD;
                    public OutputColorEValue OutputColorE;
                    public OutputColorFValue OutputColorF;
                    public OutputScalarAValue OutputScalarA;
                    public OutputScalarBValue OutputScalarB;
                    public OutputScalarCValue OutputScalarC;
                    public OutputScalarDValue OutputScalarD;
                    public OutputScalarEValue OutputScalarE;
                    public OutputScalarFValue OutputScalarF;
                    public short Unknown2;
                    public short Unknown3;
                    public short Unknown4;
                    public short Unknown5;

                    public enum ShaderIndexValue : short
                    {
                        Simple,
                        Meter,
                        TextSimple,
                        MeterShield,
                        MeterGradient,
                        Crosshair,
                        DirectionalDamage,
                        Solid,
                        Sensor,
                        MeterSingleColor,
                        Navpoint,
                        Medal,
                        TextureCam,
                        CortanaScreen,
                        CortanaCamera,
                        CortanaOffscreen,
                        CortanaScreenFinal,
                        MeterChapter,
                        MeterDoubleGradient,
                        MeterRadialGradient,
                        Turbulence,
                        Emblem,
                        CortanaComposite,
                        DirectionalDamageApply,
                        ReallySimple,
                        Unknown,
                    }

                    public enum InputValue : short
                    {
                        Zero,
                        One,
                        Time,
                        Fade,
                        UnitHealthCurrent,
                        UnitHealth,
                        UnitShieldCurrent,
                        UnitShield,
                        ClipAmmoFraction,
                        TotalAmmoFraction,
                        WeaponVersionNumber,
                        HeatFraction,
                        BatteryFraction,
                        WeaponErrorCurrent1,
                        WeaponErrorCurrent2,
                        Pickup,
                        UnitAutoaimed,
                        Grenade,
                        GrenadeFraction,
                        ChargeFraction,
                        FriendlyScore,
                        EnemyScore,
                        ScoreToWin,
                        ArmingFraction,
                        UnknownX18,
                        Unit1xOvershieldCurrent,
                        Unit1xOvershield,
                        Unit2xOvershieldCurrent,
                        Unit2xOvershield,
                        Unit3xOvershieldCurrent,
                        Unit3xOvershield,
                        AimYaw,
                        AimPitch,
                        TargetDistance,
                        TargetElevation,
                        EditorBudget,
                        EditorBudgetCost,
                        FilmTotalTime,
                        FilmCurrentTime,
                        UnknownX27,
                        FilmTimelineFraction1,
                        FilmTimelineFraction2,
                        UnknownX2a,
                        UnknownX2b,
                        MetagameTime,
                        MetagameScoreTransient,
                        MetagameScorePlayer1,
                        MetagameScorePlayer2,
                        MetagameScorePlayer3,
                        MetagameScorePlayer4,
                        MetagameModifier,
                        MetagameSkullModifier,
                        SensorRange,
                        NetdebugLatency,
                        NetdebugLatencyQuality,
                        NetdebugHostQuality,
                        NetdebugLocalQuality,
                        MetagameScoreNegative,
                        SurvivalCurrentSet,
                        UnknownX3b,
                        UnknownX3c,
                        SurvivalCurrentLives,
                        SurvivalBonusTime,
                        SurvivalBonusScore,
                        SurvivalMultiplier,
                        UnknownX41,
                        UnknownX42,
                        UnknownX43,
                        UnknownX44,
                        UnknownX45,
                        UnknownX46,
                        UnknownX47,
                        UnknownX48,
                        UnknownX49,
                        UnknownX4a,
                        UnknownX4b,
                        UnknownX4c,
                        UnknownX4d,
                        Consumable1Icon,
                        Consumable2Icon,
                        UnknownX50,
                        UnknownX51,
                        UnknownX52,
                        Consumable3Icon,
                        Consumable4Icon,
                        ConsumableName,
                        UnknownX56,
                        UnknownX57,
                        UnknownX58,
                        ConsumableCooldownText,
                        ConsumableCooldownMeter,
                        UnknownX5b,
                        UnknownX5c,
                        UnknownX5d,
                        UnknownX5e,
                        Consumable1Charge,
                        Consumable2Charge,
                        Consumable3Charge,
                        Consumable4Charge,
                        UnknownX63,
                        UnknownX64,
                        EnergyMeter1,
                        EnergyMeter2,
                        EnergyMeter3,
                        EnergyMeter4,
                        EnergyMeter5,
                        Consumable1Cost,
                        Consumable2Cost,
                        Consumable3Cost,
                        Consumable4Cost,
                        UnitStaminaCurrent,
                    }

                    public enum RangeInputValue : short
                    {
                        Zero,
                        One,
                        Time,
                        Fade,
                        UnitHealthCurrent,
                        UnitHealth,
                        UnitShieldCurrent,
                        UnitShield,
                        ClipAmmoFraction,
                        TotalAmmoFraction,
                        WeaponVersionNumber,
                        HeatFraction,
                        BatteryFraction,
                        WeaponErrorCurrent1,
                        WeaponErrorCurrent2,
                        Pickup,
                        UnitAutoaimed,
                        Grenade,
                        GrenadeFraction,
                        ChargeFraction,
                        FriendlyScore,
                        EnemyScore,
                        ScoreToWin,
                        ArmingFraction,
                        UnknownX18,
                        Unit1xOvershieldCurrent,
                        Unit1xOvershield,
                        Unit2xOvershieldCurrent,
                        Unit2xOvershield,
                        Unit3xOvershieldCurrent,
                        Unit3xOvershield,
                        AimYaw,
                        AimPitch,
                        TargetDistance,
                        TargetElevation,
                        EditorBudget,
                        EditorBudgetCost,
                        FilmTotalTime,
                        FilmCurrentTime,
                        UnknownX27,
                        FilmTimelineFraction1,
                        FilmTimelineFraction2,
                        UnknownX2a,
                        UnknownX2b,
                        MetagameTime,
                        MetagameScoreTransient,
                        MetagameScorePlayer1,
                        MetagameScorePlayer2,
                        MetagameScorePlayer3,
                        MetagameScorePlayer4,
                        MetagameModifier,
                        MetagameSkullModifier,
                        SensorRange,
                        NetdebugLatency,
                        NetdebugLatencyQuality,
                        NetdebugHostQuality,
                        NetdebugLocalQuality,
                        MetagameScoreNegative,
                        SurvivalCurrentSet,
                        UnknownX3b,
                        UnknownX3c,
                        SurvivalCurrentLives,
                        SurvivalBonusTime,
                        SurvivalBonusScore,
                        SurvivalMultiplier,
                        UnknownX41,
                        UnknownX42,
                        UnknownX43,
                        UnknownX44,
                        UnknownX45,
                        UnknownX46,
                        UnknownX47,
                        UnknownX48,
                        UnknownX49,
                        UnknownX4a,
                        UnknownX4b,
                        UnknownX4c,
                        UnknownX4d,
                        Consumable1Icon,
                        Consumable2Icon,
                        UnknownX50,
                        UnknownX51,
                        UnknownX52,
                        Consumable3Icon,
                        Consumable4Icon,
                        ConsumableName,
                        UnknownX56,
                        UnknownX57,
                        UnknownX58,
                        ConsumableCooldownText,
                        ConsumableCooldownMeter,
                        UnknownX5b,
                        UnknownX5c,
                        UnknownX5d,
                        UnknownX5e,
                        Consumable1Charge,
                        Consumable2Charge,
                        Consumable3Charge,
                        Consumable4Charge,
                        UnknownX63,
                        UnknownX64,
                        EnergyMeter1,
                        EnergyMeter2,
                        EnergyMeter3,
                        EnergyMeter4,
                        EnergyMeter5,
                        Consumable1Cost,
                        Consumable2Cost,
                        Consumable3Cost,
                        Consumable4Cost,
                        UnitStaminaCurrent,
                    }

                    public enum OutputColorAValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorBValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorCValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorDValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorEValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputColorFValue : short
                    {
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown4,
                        Unknown5,
                        ScoreboardFriendly,
                        ScoreboardEnemy,
                        ArmingTeam,
                        MetagamePlayer1,
                        MetagamePlayer2,
                        MetagamePlayer3,
                        MetagamePlayer4,
                        Unknown13,
                        Unknown14,
                        GlobalDynamic0,
                        GlobalDynamic1,
                        GlobalDynamic2,
                        GlobalDynamic3,
                        GlobalDynamic4,
                        GlobalDynamic5,
                        GlobalDynamic6,
                        GlobalDynamic7,
                        GlobalDynamic8,
                        GlobalDynamic9,
                        GlobalDynamic10,
                        GlobalDynamic11,
                        GlobalDynamic12,
                        GlobalDynamic13,
                        GlobalDynamic14,
                        GlobalDynamic15,
                        GlobalDynamic16,
                        GlobalDynamic17,
                        GlobalDynamic18,
                        GlobalDynamic19,
                        GlobalDynamic20,
                        GlobalDynamic21,
                        GlobalDynamic22,
                        GlobalDynamic23,
                        GlobalDynamic24,
                        GlobalDynamic25,
                        GlobalDynamic26,
                        GlobalDynamic27,
                        GlobalDynamic28,
                        GlobalDynamic29,
                        GlobalDynamic30,
                        GlobalDynamic31,
                        GlobalDynamic32,
                        GlobalDynamic33,
                        GlobalDynamic34,
                        GlobalDynamic35,
                        GlobalDynamic36,
                    }

                    public enum OutputScalarAValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarBValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarCValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarDValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarEValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }

                    public enum OutputScalarFValue : short
                    {
                        Input,
                        RangeInput,
                        LocalA,
                        LocalB,
                        LocalC,
                        LocalD,
                        Unknown6,
                        Unknown7,
                    }
                }

                public enum FontValue : short
                {
                    Conduit18,
                    Agency16,
                    Fixedsys9,
                    Conduit14,
                    Conduit32,
                    Agency32,
                    Conduit23,
                    Agency18,
                    Conduit18_2,
                    Conduit16,
                    Agency23,
                }
            }
        }

        [TagStructure(Size = 0x44, MaxVersion = EngineVersion.V11_1_571627_Live)]
        [TagStructure(Size = 0x48, MinVersion = EngineVersion.V12_1_700123_cert_ms30_oct19)]
        public class StateDatum
        {
            public ushort _1Engine;
            public ushort _2;
            public ushort _3;
            public ushort _4Resolution;
            public ushort _5Scoreboard;
            public ushort _6ScoreboardB;
            public ushort _7;
            public ushort _7b;
            public ushort _7Editor;
            public ushort _9;
            public ushort _10Skulls;
            public ushort _11;
            public ushort _12;
            public ushort _13;
            public ushort _14;
            public ushort _15;
            public ushort _16;
            public ushort _17;
            public ushort _18;
            public ushort _19;
            public ushort _20;
            public ushort _21;
            public ushort _22;
            public ushort _23;
            public ushort _24;
            public ushort _25;
            public ushort _26;
            public ushort _27Ammo;
            public ushort _28;
            public ushort _29;
            public ushort _30;
            public ushort _31;
            public ushort _32;
            public ushort _33;
            [MinVersion(EngineVersion.V12_1_700123_cert_ms30_oct19)] public ushort _34;
            [MinVersion(EngineVersion.V12_1_700123_cert_ms30_oct19)] public ushort _35;
        }
    }
}
