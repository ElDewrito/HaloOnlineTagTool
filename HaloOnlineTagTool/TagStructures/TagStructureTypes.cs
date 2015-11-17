using System;
using System.Collections.Generic;

namespace HaloOnlineTagTool.TagStructures
{
	public static class TagStructureTypes
	{
		/// <summary>
		/// Finds the structure type corresponding to a group tag.
		/// </summary>
		/// <param name="groupTag">The group tag of the group to search for.</param>
		/// <returns>The structure type if found, or <c>null</c> otherwise.</returns>
		public static Type FindByGroupTag(MagicNumber groupTag)
		{
			return FindByGroupTag(groupTag.ToString());
		}

		/// <summary>
		/// Finds the structure type corresponding to a group tag.
		/// </summary>
		/// <param name="groupTag">The string representation of the group tag of the group to search for.</param>
		/// <returns>The structure type if found, or <c>null</c> otherwise.</returns>
		public static Type FindByGroupTag(string groupTag)
		{
			Type result;
			TypesByGroup.TryGetValue(groupTag, out result);
			return result;
		}

		private static readonly Dictionary<string, Type> TypesByGroup = new Dictionary<string, Type>
		{
			{ "<fx>", typeof(SoundEffectTemplate) },
			{ "achi", typeof(Achievements) },
			{ "adlg", typeof(AiDialogueGlobals) },
			{ "aigl", typeof(AiGlobals) },
			{ "ant!", typeof(Antenna) },
			{ "arms", typeof(ArmorSounds) },
			{ "beam", typeof(BeamSystem) },
			{ "bink", typeof(Bink) },
			{ "bipd", typeof(Biped) },
			{ "bitm", typeof(Bitmap) },
			{ "bkey", typeof(GuiButtonKeyDefinition) },
			{ "bloc", typeof(Crate) },
			{ "bmp3", typeof(GuiBitmapWidgetDefinition) },
			{ "bsdt", typeof(BreakableSurface) },
			{ "cddf", typeof(CollisionDamage) },
			{ "cfgt", typeof(CacheFileGlobalTags) },
			{ "cfxs", typeof(CameraFxSettings) },
			{ "chad", typeof(ChudAnimationDefinition) },
			{ "char", typeof(Character) },
			{ "chdt", typeof(ChudDefinition) },
			{ "chgd", typeof(ChudGlobalsDefinition) },
			{ "chmt", typeof(ChocolateMountainNew) },
			{ "clwd", typeof(Cloth) },
			{ "cmoe", typeof(Camo) },
			{ "cntl", typeof(ContrailSystem) },
			{ "coll", typeof(CollisionModel) },
			{ "colo", typeof(ColorTable) },
			{ "cprl", typeof(ChudWidgetParallaxData) },
			{ "crea", typeof(Creature) },
			{ "dctr", typeof(DecoratorSet) },
			{ "decs", typeof(DecalSystem) },
			{ "draw", typeof(RasterizerCacheFileGlobals) },
			{ "drdf", typeof(DamageResponseDefinition) },
			{ "dsrc", typeof(GuiDatasourceDefinition) },
			{ "effe", typeof(Effect) },
			{ "effg", typeof(EffectGlobals) },
			{ "efsc", typeof(EffectScenery) },
			{ "eqip", typeof(Equipment) },
			{ "flck", typeof(Flock) },
			{ "foot", typeof(MaterialEffects) },
			{ "form", typeof(Formation) },
			{ "gfxt", typeof(GfxTexturesList) },
			{ "glps", typeof(GlobalPixelShader) },
			{ "glvs", typeof(GlobalVertexShader) },
			{ "goof", typeof(MultiplayerVariantSettingsInterfaceDefinition) },
			{ "gpdt", typeof(GameProgression) },
			{ "grup", typeof(GuiGroupWidgetDefinition) },
			{ "hlmt", typeof(Model) },
			{ "inpg", typeof(InputGlobals) },
			{ "jmad", typeof(ModelAnimationGraph) },
			{ "jmrq", typeof(SandboxTextValuePairDefinition) },
			{ "jpt!", typeof(DamageEffect) },
			{ "Lbsp", typeof(ScenarioLightmapBspData) },
			{ "lens", typeof(LensFlare) },
			{ "ligh", typeof(Light) },
			{ "lsnd", typeof(SoundLooping) },
			{ "lst3", typeof(GuiListWidgetDefinition) },
			{ "ltvl", typeof(LightVolumeSystem) },
			{ "mach", typeof(DeviceMachine) },
			{ "matg", typeof(Globals) },
			{ "mdl3", typeof(GuiModelWidgetDefinition) },
			{ "mffn", typeof(Muffin) },
			{ "mode", typeof(RenderModel) },
			{ "mulg", typeof(MultiplayerGlobals) },
			{ "pdm!", typeof(PodiumSettings) },
			{ "perf", typeof(PerformanceThrottles) },
			{ "phmo", typeof(PhysicsModel) },
			{ "pixl", typeof(PixelShader) },
			{ "pmdf", typeof(ParticleModel) },
			{ "pmov", typeof(ParticlePhysics) },
			{ "pphy", typeof(PointPhysics) },
			{ "proj", typeof(Projectile) },
			{ "prt3", typeof(Particle) },
			{ "rasg", typeof(RasterizerGlobals) },
			{ "rmd ", typeof(ShaderDecal) },
			{ "rmdf", typeof(RenderMethodDefinition) },
			{ "rmfl", typeof(ShaderFoliage) },
			{ "rmhg", typeof(ShaderHalogram) },
			{ "rmop", typeof(RenderMethodOption) },
			{ "rmsh", typeof(Shader) },
			{ "rmss", typeof(ShaderScreen) },
			{ "rmt2", typeof(RenderMethodTemplate) },
			{ "rmtr", typeof(ShaderTerrain) },
			{ "rmw ", typeof(ShaderWater) },
			{ "rmzo", typeof(ShaderZonly) },
			{ "rwrd", typeof(RenderWaterRipple) },
			{ "sLdT", typeof(ScenarioLightmap) },
			{ "sbsp", typeof(ScenarioStructureBsp) },
			{ "scen", typeof(Scenery) },
			{ "scn3", typeof(GuiScreenWidgetDefinition) },
			{ "scnr", typeof(Scenario) },
			{ "sddt", typeof(StructureDesign) },
			{ "sefc", typeof(AreaScreenEffect) },
			{ "sfx+", typeof(SoundEffectCollection) },
			{ "sgp!", typeof(SoundGlobalPropagation) },
			{ "shit", typeof(ShieldImpact) },
			{ "sily", typeof(TextValuePairDefinition) },
			{ "skn3", typeof(GuiSkinDefinition) },
			{ "skya", typeof(SkyAtmParameters) },
			{ "smdt", typeof(SurvivalModeGlobals) },
			{ "sncl", typeof(SoundClasses) },
			{ "snd!", typeof(Sound) },
			{ "snde", typeof(SoundEnvironment) },
			{ "snmx", typeof(SoundMix) },
			{ "spk!", typeof(SoundDialogueConstants) },
			{ "sqtm", typeof(SquadTemplate) },
			{ "ssce", typeof(SoundScenery) },
			{ "styl", typeof(Style) },
			{ "sus!", typeof(SoundUiSounds) },
			{ "trak", typeof(CameraTrack) },
			{ "trdf", typeof(TextureRenderList) },
			{ "txt3", typeof(GuiTextWidgetDefinition) },
			{ "udlg", typeof(Dialogue) },
			{ "uise", typeof(UserInterfaceSoundsDefinition) },
			{ "unic", typeof(MultilingualUnicodeStringList) },
			{ "vehi", typeof(Vehicle) },
			{ "vfsl", typeof(VFilesList) },
			{ "vmdx", typeof(VisionMode) },
			{ "vtsh", typeof(VertexShader) },
			{ "wacd", typeof(GuiWidgetAnimationCollectionDefinition) },
			{ "wclr", typeof(GuiWidgetColorAnimationDefinition) },
			{ "weap", typeof(Weapon) },
			{ "wezr", typeof(GameEngineSettingsDefinition) },
			{ "wgan", typeof(GuiWidgetAnimationDefinition) },
			{ "wgtz", typeof(UserInterfaceGlobalsDefinition) },
			{ "wigl", typeof(UserInterfaceSharedGlobalsDefinition) },
			{ "wind", typeof(Wind) },
			{ "wpos", typeof(GuiWidgetPositionAnimationDefinition) },
			{ "wrot", typeof(GuiWidgetRotationAnimationDefinition) },
			{ "wscl", typeof(GuiWidgetScaleAnimationDefinition) },
			{ "wspr", typeof(GuiWidgetSpriteAnimationDefinition) },
			{ "wtuv", typeof(GuiWidgetTextureCoordinateAnimationDefinition) },
		};
	}
}
