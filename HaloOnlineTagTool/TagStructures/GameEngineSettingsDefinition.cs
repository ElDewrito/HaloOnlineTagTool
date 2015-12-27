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
    [TagStructure(Name = "game_engine_settings_definition", Class = "wezr", Size = 0x8C)]
    public class GameEngineSettingsDefinition
    {
        public uint Unknown;
        public List<TraitProfile> TraitProfiles;
        public List<SlayerVariant> SlayerVariants;
        public List<OddballVariant> OddballVariants;
        public List<CaptureTheFlagVariant> CaptureTheFlagVariants;
        public List<AssaultVariant> AssaultVariants;
        public List<InfectionVariant> InfectionVariants;
        public List<KingOfTheHillVariant> KingOfTheHillVariants;
        public List<TerritoriesVariant> TerritoriesVariants;
        public List<JuggernautVariant> JuggernautVariants;
        public List<VipVariant> VipVariants;
        public List<SandboxEditorVariant> SandboxEditorVariants;
        public uint Unknown2;

        [TagStructure(Size = 0x40)]
        public class TraitProfile
        {
            public StringId Name;
            public List<ShieldsAndHealthBlock> ShieldsAndHealth;
            public List<WeaponsAndDamageBlock> WeaponsAndDamage;
            public List<MovementBlock> Movement;
            public List<AppearanceBlock> Appearance;
            public List<Sensor> Sensors;

            [TagStructure(Size = 0x8)]
            public class ShieldsAndHealthBlock
            {
                public DamageResistanceValue DamageResistance;
                public ShieldMultiplierValue ShieldMultiplier;
                public ShieldRechargeRateValue ShieldRechargeRate;
                public HeadshotImmunityValue HeadshotImmunity;
                public ShieldVampirismValue ShieldVampirism;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;

                public enum DamageResistanceValue : sbyte
                {
                    Unchanged,
                    _10,
                    _50,
                    _90,
                    _100,
                    _110,
                    _150,
                    _200,
                    _300,
                    _500,
                    _1000,
                    _2000,
                    Invulnerable,
                }

                public enum ShieldMultiplierValue : sbyte
                {
                    Unchanged,
                    NoShields,
                    NormalShields,
                    _2xOvershields,
                    _3xOvershields,
                    _4xOvershields,
                }

                public enum ShieldRechargeRateValue : sbyte
                {
                    Unchanged,
                    _25,
                    _10,
                    _5,
                    _0,
                    _50,
                    _90,
                    _100,
                    _110,
                    _200,
                }

                public enum HeadshotImmunityValue : sbyte
                {
                    Unchanged,
                    Enabled,
                    Disabled,
                }

                public enum ShieldVampirismValue : sbyte
                {
                    Unchanged,
                    Disabled,
                    _10,
                    _25,
                    _50,
                    _100,
                }
            }

            [TagStructure(Size = 0x10)]
            public class WeaponsAndDamageBlock
            {
                public DamageModifierValue DamageModifier;
                public GrenadeRegenerationValue GrenadeRegeneration;
                public WeaponPickupValue WeaponPickup;
                public InfiniteAmmoValue InfiniteAmmo;
                public StringId PrimaryWeapon;
                public StringId SecondaryWeapon;
                public GrenadeCountValue GrenadeCount;
                public sbyte Unknown;
                public sbyte Unknown2;

                public enum DamageModifierValue : sbyte
                {
                    Unchanged,
                    _0,
                    _25,
                    _50,
                    _75,
                    _90,
                    _100,
                    _110,
                    _125,
                    _150,
                    _200,
                    _300,
                    InstantKill,
                }

                public enum GrenadeRegenerationValue : sbyte
                {
                    Unchanged,
                    Enabled,
                    Disabled,
                }

                public enum WeaponPickupValue : sbyte
                {
                    Unchanged,
                    Enabled,
                    Disabled,
                }

                public enum InfiniteAmmoValue : sbyte
                {
                    Unchanged,
                    Disabled,
                    Enabled,
                }

                public enum GrenadeCountValue : short
                {
                    Unchanged,
                    MapDefault,
                    None,
                }
            }

            [TagStructure(Size = 0x4)]
            public class MovementBlock
            {
                public PlayerSpeedValue PlayerSpeed;
                public PlayerGravityValue PlayerGravity;
                public VehicleUseValue VehicleUse;
                public sbyte Unknown;

                public enum PlayerSpeedValue : sbyte
                {
                    Unchanged,
                    _25,
                    _50,
                    _75,
                    _90,
                    _100,
                    _110,
                    _125,
                    _150,
                    _200,
                    _300,
                }

                public enum PlayerGravityValue : sbyte
                {
                    Unchanged,
                    _50,
                    _75,
                    _100,
                    _150,
                    _200,
                }

                public enum VehicleUseValue : sbyte
                {
                    Unchanged,
                    None,
                    PassengerOnly,
                    FullUse,
                }
            }

            [TagStructure(Size = 0x4)]
            public class AppearanceBlock
            {
                public ActiveCamoValue ActiveCamo;
                public WaypointValue Waypoint;
                public AuraValue Aura;
                public ForcedColorValue ForcedColor;

                public enum ActiveCamoValue : sbyte
                {
                    Unchanged,
                    Disabled,
                    BadCamo,
                    PoorCamo,
                    GoodCamo,
                }

                public enum WaypointValue : sbyte
                {
                    Unchanged,
                    None,
                    VisibleToAllies,
                    VisibleToEveryone,
                }

                public enum AuraValue : sbyte
                {
                    Unchanged,
                    Disabled,
                    Team,
                    Black,
                    White,
                }

                public enum ForcedColorValue : sbyte
                {
                    Unchanged,
                    Off,
                    Red,
                    Blue,
                    Green,
                    Orange,
                    Purple,
                    Gold,
                    Brown,
                    Pink,
                    White,
                    Black,
                    Zombie,
                    PinkUnused,
                }
            }

            [TagStructure(Size = 0x8)]
            public class Sensor
            {
                public MotionTrackerModeValue MotionTrackerMode;
                public MotionTrackerRangeValue MotionTrackerRange;

                public enum MotionTrackerModeValue : int
                {
                    Unchanged,
                    Disabled,
                    AllyMovement,
                    PlayerMovement,
                    PlayerLocations,
                }

                public enum MotionTrackerRangeValue : int
                {
                    Unchanged,
                    _10m,
                    _15m,
                    _25m,
                    _50m,
                    _75m,
                    _100m,
                    _150m,
                }
            }
        }

        [TagStructure(Size = 0x70)]
        public class SlayerVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public TeamScoringValue TeamScoring;
            public short PointsToWin;
            public short Unknown;
            public sbyte KillPoints;
            public sbyte AssistPoints;
            public sbyte DeathPoints;
            public sbyte SuicidePoints;
            public sbyte BetrayalPoints;
            public sbyte LeaderKillBonus;
            public sbyte EliminationBonus;
            public sbyte AssassinationBonus;
            public sbyte HeadshotBonus;
            public sbyte BeatdownBonus;
            public sbyte StickyBonus;
            public sbyte SplatterBonus;
            public sbyte SpreeBonus;
            public sbyte Unknown2;
            public StringId LeaderTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum TeamScoringValue : short
            {
                SumOfTeam,
                MinimumScore,
                MaximumScore,
                Default,
            }
        }

        [TagStructure(Size = 0x70)]
        public class OddballVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public TeamScoringValue TeamScoring;
            public short PointsToWin;
            public short Unknown;
            public sbyte CarryingPoints;
            public sbyte KillPoints;
            public sbyte BallKillPoints;
            public sbyte BallCarrierKillPoints;
            public sbyte BallCount;
            public sbyte Unknown2;
            public short InitialBallDelay;
            public short BallRespawnDelay;
            public StringId BallCarrierTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum TeamScoringValue : short
            {
                SumOfTeam,
                MinimumScore,
                MaximumScore,
                Default,
            }
        }

        [TagStructure(Size = 0x70)]
        public class CaptureTheFlagVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public HomeFlagWaypointValue HomeFlagWaypoint;
            public GameModeValue GameMode;
            public RespawnOnCaptureValue RespawnOnCapture;
            public short FlagReturnTime;
            public short SuddenDeathTime;
            public short ScoreToWin;
            public short Unknown;
            public short FlagResetTime;
            public StringId FlagCarrierTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum HomeFlagWaypointValue : short
            {
                Unknown1,
                Unknown2,
                Unknown3,
                NotInSingle,
            }

            public enum GameModeValue : short
            {
                Multiple,
                Single,
                Neutral,
            }

            public enum RespawnOnCaptureValue : short
            {
                Disabled,
                OnAllyCapture,
                OnEnemyCapture,
                OnAnyCapture,
            }
        }

        [TagStructure(Size = 0x80)]
        public class AssaultVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public RespawnOnCaptureValue RespawnOnCapture;
            public GameModeValue GameMode;
            public EnemyBombWaypointValue EnemyBombWaypoint;
            public short SuddenDeathTime;
            public short DetonationsToWin;
            public short Unknown;
            public short Unknown2;
            public short Unknown3;
            public short Unknown4;
            public short BombResetTime;
            public short BombArmingTime;
            public short BombDisarmingTime;
            public short BombFuseTime;
            public short Unknown5;
            public StringId BombCarrierTraitProfile;
            public StringId UnknownTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum RespawnOnCaptureValue : short
            {
                Disabled,
                OnAllyCapture,
                OnEnemyCapture,
                OnAnyCapture,
            }

            public enum GameModeValue : short
            {
                Multiple,
                Single,
                Neutral,
            }

            public enum EnemyBombWaypointValue : short
            {
                Unknown1,
                Unknown2,
                Unknown3,
                NotInSingle,
            }
        }

        [TagStructure(Size = 0x7C)]
        public class InfectionVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public SafeHavensValue SafeHavens;
            public NextZombieValue NextZombie;
            public short InitialZombieCount;
            public short SafeHavenMovementTime;
            public sbyte ZombieKillPoints;
            public sbyte InfectionPoints;
            public sbyte SafeHavenArrivalPoints;
            public sbyte SuicidePoints;
            public sbyte BetrayalPoints;
            public sbyte LastManStandingBonus;
            public sbyte Unknown;
            public sbyte Unknown2;
            public StringId ZombieTraitProfile;
            public StringId AlphaZombieTraitProfile;
            public StringId OnHavenTraitProfile;
            public StringId LastHumanTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum SafeHavensValue : short
            {
                None,
                Random,
                Sequence,
            }

            public enum NextZombieValue : short
            {
                MostPoints,
                FirstInfected,
                Unchanged,
                Random,
            }
        }

        [TagStructure(Size = 0x70)]
        public class KingOfTheHillVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public short ScoreToWin;
            public short Unknown;
            public TeamScoringValue TeamScoring;
            public HillMovementValue HillMovement;
            public HillMovementOrderValue HillMovementOrder;
            public short Unknown2;
            public sbyte OnHillPoints;
            public sbyte UncontestedControlPoints;
            public sbyte OffHillPoints;
            public sbyte KillPoints;
            public StringId OnHillTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum TeamScoringValue : short
            {
                Sum,
                Minimum,
                Maximum,
                Default,
            }

            public enum HillMovementValue : short
            {
                NoMovement,
                After10Seconds,
                After15Seconds,
                After30Seconds,
                After1Minute,
                After2Minutes,
                After3Minutes,
                After4Minutes,
                After5Minutes,
            }

            public enum HillMovementOrderValue : short
            {
                Random,
                Sequence,
            }
        }

        [TagStructure(Size = 0x6C)]
        public class TerritoriesVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public RespawnOnCaptureValue RespawnOnCapture;
            public short TerritoryCaptureTime;
            public short SuddenDeathTime;
            public short Unknown;
            public StringId DefenderTraitProfile;
            public StringId AttackerTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum RespawnOnCaptureValue : short
            {
                Disabled,
                OnAllyCapture,
                OnEnemyCapture,
                OnAnyCapture,
            }
        }

        [TagStructure(Size = 0x74)]
        public class JuggernautVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public FirstJuggernautValue FirstJuggernaut;
            public NextJuggernautValue NextJuggernaut;
            public GoalZoneMovementValue GoalZoneMovement;
            public GoalZoneOrderValue GoalZoneOrder;
            public short ScoreToWin;
            public short Unknown;
            public sbyte KillPoints;
            public sbyte TakedownPoints;
            public sbyte KillAsJuggernautPoints;
            public sbyte GoalArrivalPoints;
            public sbyte SuicidePoints;
            public sbyte BetrayalPoints;
            public sbyte NextJuggernautDelay;
            public sbyte Unknown2;
            public StringId JuggernautTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum FirstJuggernautValue : short
            {
                Random,
                FirstKill,
                FirstDeath,
            }

            public enum NextJuggernautValue : short
            {
                Killer,
                Killed,
                Unchanged,
                Random,
            }

            public enum GoalZoneMovementValue : short
            {
                NoMovement,
                After10Seconds,
                After15Seconds,
                After30Seconds,
                After1Minute,
                After2Minutes,
                After3Minutes,
                After4Minutes,
                After5Minutes,
                OnArrival,
                OnNewJuggernaut,
            }

            public enum GoalZoneOrderValue : short
            {
                Random,
                Sequence,
            }
        }

        [TagStructure(Size = 0x7C)]
        public class VipVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public short ScoreToWin;
            public short Unknown;
            public NextVipValue NextVip;
            public GoalZoneMovementValue GoalZoneMovement;
            public GoalZoneMovementOrderValue GoalZoneMovementOrder;
            public sbyte KillPoints;
            public sbyte VipTakedownPoints;
            public sbyte KillAsVipPoints;
            public sbyte VipDeathPoints;
            public sbyte GoalArrivalPoints;
            public sbyte SuicidePoints;
            public sbyte VipBetrayalPoints;
            public sbyte BetrayalPoints;
            public sbyte VipProximityTraitRadius;
            public sbyte Unknown2;
            public StringId VipTeamTraitProfile;
            public StringId VipProximityTraitProfile;
            public StringId VipTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum NextVipValue : short
            {
                Random,
                Unknown,
                NextDeath,
                Unchanged,
            }

            public enum GoalZoneMovementValue : short
            {
                NoMovement,
                After10Seconds,
                After15Seconds,
                After30Seconds,
                After1Minute,
                After2Minutes,
                After3Minutes,
                After4Minutes,
                After5Minutes,
                OnArrival,
                OnNewVip,
            }

            public enum GoalZoneMovementOrderValue : short
            {
                Random,
                Sequence,
            }
        }

        [TagStructure(Size = 0x64)]
        public class SandboxEditorVariant
        {
            [TagField(Length = 32)] public string NameAscii;
            public StringId Name;
            public StringId Description;
            public List<GeneralSetting> GeneralSettings;
            public List<RespawnSetting> RespawnSettings;
            public List<SocialSetting> SocialSettings;
            public List<MapOverride> MapOverrides;
            public uint Flags;
            public EditModeValue EditMode;
            public short EditorRespawnTime;
            public StringId EditorTraitProfile;

            [TagStructure(Size = 0x8)]
            public class GeneralSetting
            {
                public uint Flags;
                public sbyte TimeLimit;
                public sbyte NumberOfRounds;
                public sbyte EarlyVictoryWinCount;
                public RoundResetsValue RoundResets;

                public enum RoundResetsValue : sbyte
                {
                    Nothing,
                    PlayersOnly,
                    Everything,
                }
            }

            [TagStructure(Size = 0x10)]
            public class RespawnSetting
            {
                public ushort Flags;
                public sbyte LivesPerRound;
                public sbyte SharedTeamLives;
                public byte RespawnTime;
                public byte SuicidePenalty;
                public byte BetrayalPenalty;
                public byte UnknownPenalty;
                public byte RespawnTimeGrowth;
                public sbyte Unknown;
                public sbyte Unknown2;
                public sbyte Unknown3;
                public StringId RespawnTraitProfile;
                public sbyte RespawnTraitDuration;
                public sbyte Unknown4;
                public sbyte Unknown5;
                public sbyte Unknown6;
            }

            [TagStructure(Size = 0x4)]
            public class SocialSetting
            {
                public uint Flags;
            }

            [TagStructure(Size = 0x20)]
            public class MapOverride
            {
                public uint Flags;
                public StringId BasePlayerTraitProfile;
                public StringId WeaponSet;
                public StringId VehicleSet;
                public StringId OvershieldTraitProfile;
                public StringId ActiveCamoTraitProfile;
                public StringId CustomPowerupTraitProfile;
                public sbyte OvershieldTraitDuration;
                public sbyte ActiveCamoTraitDuration;
                public sbyte CustomPowerupTraitDuration;
                public sbyte Unknown;
            }

            public enum EditModeValue : short
            {
                Everyone,
                LeaderOnly,
            }
        }
    }
}
