using System.Linq;
using Borodar.RainbowCore;
using Borodar.RainbowFolders.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    public static class RainbowFoldersContextMenu
    {
        #region Context Menu - Base
        private const string MENU_BASE = "Assets/Rainbow Folders/";
        #endregion Context Menu - Base

        #region Context Menu - Items
        private const string ITEM_CUSTOM = MENU_BASE + "Apply Custom";
        private const string ITEM_DEFAULT = MENU_BASE + "Revert to Default";
        private const string ITEM_SETTINGS = MENU_BASE + "Settings";
        #endregion Context Menu - Items

        #region Context Menu - Sub-Menus
        private const string MENU_COLOR = MENU_BASE + "Color/";
        private const string MENU_TRANSPARENT = MENU_BASE + "Transparent/";
        private const string MENU_TAG = MENU_BASE + "Tag/";
        private const string MENU_TYPE = MENU_BASE + "Type/";
        private const string MENU_PLATFORM = MENU_BASE + "Platform/";
        private const string MENU_BACKGROUND = MENU_BASE + "Background/";
        #endregion Context Menu - Sub-Menus

        #region Context Menu - Color Sub-Context Menu
        private const string COLOR_RED = MENU_COLOR + "Red";
        private const string COLOR_VERMILION = MENU_COLOR + "Vermilion";
        private const string COLOR_ORANGE = MENU_COLOR + "Orange";
        private const string COLOR_AMBER = MENU_COLOR + "Amber";
        private const string COLOR_YELLOW = MENU_COLOR + "Yellow";
        private const string COLOR_LIME = MENU_COLOR + "Lime";
        private const string COLOR_CHARTREUSE = MENU_COLOR + "Chartreuse";
        private const string COLOR_HARLEQUIN = MENU_COLOR + "Harlequin";
        private const string COLOR_GREEN = MENU_COLOR + "Green";
        private const string COLOR_EMERALD = MENU_COLOR + "Emerald";
        private const string COLOR_SPRING_GREEN = MENU_COLOR + "Spring-green";
        private const string COLOR_AQUAMARINE = MENU_COLOR + "Aquamarine";
        private const string COLOR_CYAN = MENU_COLOR + "Cyan";
        private const string COLOR_SKY_BLUE = MENU_COLOR + "Sky-blue";
        private const string COLOR_AZURE = MENU_COLOR + "Azure";
        private const string COLOR_CERULEAN = MENU_COLOR + "Cerulean";
        private const string COLOR_BLUE = MENU_COLOR + "Blue";
        private const string COLOR_INDIGO = MENU_COLOR + "Indigo";
        private const string COLOR_VIOLET = MENU_COLOR + "Violet";
        private const string COLOR_PURPLE = MENU_COLOR + "Purple";
        private const string COLOR_MAGENTA = MENU_COLOR + "Magenta";
        private const string COLOR_FUCHSIA = MENU_COLOR + "Fuchsia";
        private const string COLOR_ROSE = MENU_COLOR + "Rose";
        private const string COLOR_CRIMSON = MENU_COLOR + "Crimson";
        #endregion Context Menu - Color Sub-Context Menu

        #region Context Menu - Transparents Sub-Context Menu
        private const string TRANSPARENT_15 = MENU_TRANSPARENT + "15%";
        private const string TRANSPARENT_25 = MENU_TRANSPARENT + "25%";
        private const string TRANSPARENT_50 = MENU_TRANSPARENT + "50%";
        #endregion Context Menu - Transparents Sub-Context Menu

        #region Context Menu - Tags Sub-Context Menu
        private const string TAG_RED = MENU_TAG + "Red";
        private const string TAG_VERMILION = MENU_TAG + "Vermilion";
        private const string TAG_ORANGE = MENU_TAG + "Orange";
        private const string TAG_AMBER = MENU_TAG + "Amber";
        private const string TAG_YELLOW = MENU_TAG + "Yellow";
        private const string TAG_LIME = MENU_TAG + "Lime";
        private const string TAG_CHARTREUSE = MENU_TAG + "Chartreuse";
        private const string TAG_HARLEQUIN = MENU_TAG + "Harlequin";
        private const string TAG_GREEN = MENU_TAG + "Green";
        private const string TAG_EMERALD = MENU_TAG + "Emerald";
        private const string TAG_SPRING_GREEN = MENU_TAG + "Spring-green";
        private const string TAG_AQUAMARINE = MENU_TAG + "Aquamarine";
        private const string TAG_CYAN = MENU_TAG + "Cyan";
        private const string TAG_SKY_BLUE = MENU_TAG + "Sky-blue";
        private const string TAG_AZURE = MENU_TAG + "Azure";
        private const string TAG_CERULEAN = MENU_TAG + "Cerulean";
        private const string TAG_BLUE = MENU_TAG + "Blue";
        private const string TAG_INDIGO = MENU_TAG + "Indigo";
        private const string TAG_VIOLET = MENU_TAG + "Violet";
        private const string TAG_PURPLE = MENU_TAG + "Purple";
        private const string TAG_MAGENTA = MENU_TAG + "Magenta";
        private const string TAG_FUCHSIA = MENU_TAG + "Fuchsia";
        private const string TAG_ROSE = MENU_TAG + "Rose";
        private const string TAG_CRIMSON = MENU_TAG + "Crimson";
        #endregion Context Menu - Tags Sub-Context Menu

        #region Context Menu - Types Sub-Context Menu
        private const string TYPE_PREFABS = MENU_TYPE + "Prefabs";
        private const string TYPE_SCENES = MENU_TYPE + "Scenes";
        private const string TYPE_SCRIPTS = MENU_TYPE + "Scripts";
        private const string TYPE_EXTENSIONS = MENU_TYPE + "Extensions";
        private const string TYPE_FLARES = MENU_TYPE + "Flares";
        private const string TYPE_PLUGINS = MENU_TYPE + "Plugins";
        private const string TYPE_TEXTURES = MENU_TYPE + "Textures";
        private const string TYPE_MATERIALS = MENU_TYPE + "Materials";
        private const string TYPE_AUDIO = MENU_TYPE + "Audio";
        private const string TYPE_PROJECT = MENU_TYPE + "Project";
        private const string TYPE_FONTS = MENU_TYPE + "Fonts";
        private const string TYPE_EDITOR = MENU_TYPE + "Editor";
        private const string TYPE_RESOURCES = MENU_TYPE + "Resources";
        private const string TYPE_SHADERS = MENU_TYPE + "Shaders";
        private const string TYPE_TERRAINS = MENU_TYPE + "Terrains";
        private const string TYPE_MESHES = MENU_TYPE + "Meshes";
        private const string TYPE_RAINBOW = MENU_TYPE + "Rainbow";
        private const string TYPE_ANIMATIONS = MENU_TYPE + "Animations";
        private const string TYPE_PHYSICS = MENU_TYPE + "Physics";
        #endregion Context Menu - Types Sub-Context Menu

        #region Context Menu - Platforms Sub-Context Menu
        private const string PLATFORM_ANDROID = MENU_PLATFORM + "Android";
        private const string PLATFORM_IOS = MENU_PLATFORM + "iOS";
        private const string PLATFORM_MAC = MENU_PLATFORM + "Mac";
        private const string PLATFORM_WEBGL = MENU_PLATFORM + "WebGL";
        private const string PLATFORM_WINDOWS = MENU_PLATFORM + "Windows";
        #endregion Context Menu - Platforms Sub-Context Menu

        #region Context Menu - Backgrounds Sub-Context Menu
        private const string BACKGROUND_RED = MENU_BACKGROUND + "Red";
        private const string BACKGROUND_VERMILION = MENU_BACKGROUND + "Vermilion";
        private const string BACKGROUND_ORANGE = MENU_BACKGROUND + "Orange";
        private const string BACKGROUND_AMBER = MENU_BACKGROUND + "Amber";
        private const string BACKGROUND_YELLOW = MENU_BACKGROUND + "Yellow";
        private const string BACKGROUND_LIME = MENU_BACKGROUND + "Lime";
        private const string BACKGROUND_CHARTREUSE = MENU_BACKGROUND + "Chartreuse";
        private const string BACKGROUND_HARLEQUIN = MENU_BACKGROUND + "Harlequin";
        private const string BACKGROUND_GREEN = MENU_BACKGROUND + "Green";
        private const string BACKGROUND_EMERALD = MENU_BACKGROUND + "Emerald";
        private const string BACKGROUND_SPRING_GREEN = MENU_BACKGROUND + "Spring-green";
        private const string BACKGROUND_AQUAMARINE = MENU_BACKGROUND + "Aquamarine";
        private const string BACKGROUND_CYAN = MENU_BACKGROUND + "Cyan";
        private const string BACKGROUND_SKY_BLUE = MENU_BACKGROUND + "Sky-blue";
        private const string BACKGROUND_AZURE = MENU_BACKGROUND + "Azure";
        private const string BACKGROUND_CERULEAN = MENU_BACKGROUND + "Cerulean";
        private const string BACKGROUND_BLUE = MENU_BACKGROUND + "Blue";
        private const string BACKGROUND_INDIGO = MENU_BACKGROUND + "Indigo";
        private const string BACKGROUND_VIOLET = MENU_BACKGROUND + "Violet";
        private const string BACKGROUND_PURPLE = MENU_BACKGROUND + "Purple";
        private const string BACKGROUND_MAGENTA = MENU_BACKGROUND + "Magenta";
        private const string BACKGROUND_FUCHSIA = MENU_BACKGROUND + "Fuchsia";
        private const string BACKGROUND_ROSE = MENU_BACKGROUND + "Rose";
        private const string BACKGROUND_CRIMSON = MENU_BACKGROUND + "Crimson";
        #endregion Context Menu - Backgrounds Sub-Context Menu

        #region Context Menu - Prioritity
        private const int DEFAULT_PRIORITY = 2100;
        private const int ICONS_PRIORITY = 2200;
        private const int BACKGROUND_PRIORITY = 2300;
        private const int SETTINGS_PRIORITY = 2400;
        #endregion Context Menu - Prioritity

        #region Context Menu Items - Basic
        [MenuItem(ITEM_CUSTOM, false, DEFAULT_PRIORITY)]
        public static void ApplyCustom()
        {
            RainbowFoldersPopup window = RainbowFoldersPopup.GetDraggableWindow();
            Vector2 position = ProjectWindowAdapter.GetFirstProjectWindow().position.position + new Vector2(10f, 30f);
            System.Collections.Generic.List<string> paths = Selection.assetGUIDs.Select(AssetDatabase.GUIDToAssetPath).Where(AssetDatabase.IsValidFolder).ToList();
            window.ShowWithParams(position, paths.ToList(), 0);
        }

        [MenuItem(ITEM_DEFAULT, false, DEFAULT_PRIORITY)]
        public static void RevertToDefault()
        {
            RevertSelectedFoldersToDefault();
        }

        [MenuItem(ITEM_SETTINGS, false, SETTINGS_PRIORITY)]
        public static void OpenSettings()
        {
            Selection.activeObject = RainbowFoldersSettings.Instance;
        }

        [MenuItem(ITEM_CUSTOM, true)]
        [MenuItem(ITEM_DEFAULT, true)]
        public static bool IsValidFolder()
        {
            bool hasValidFolder = false;

            foreach (string guid in Selection.assetGUIDs)
            {
                string path = AssetDatabase.GUIDToAssetPath(guid);
                hasValidFolder |= AssetDatabase.IsValidFolder(path);
            }

            return hasValidFolder;
        }
        #endregion Context Menu Items - Basic

        #region Context Menu Items - Colors
        [MenuItem(COLOR_RED, false, ICONS_PRIORITY)]
        public static void Red() { AssignIconForSelection(ProjectIcon.ClrRed); }
        [MenuItem(COLOR_VERMILION, false, ICONS_PRIORITY)]
        public static void Vermilion() { AssignIconForSelection(ProjectIcon.ClrVermilion); }
        [MenuItem(COLOR_ORANGE, false, ICONS_PRIORITY)]
        public static void Orange() { AssignIconForSelection(ProjectIcon.ClrOrange); }
        [MenuItem(COLOR_AMBER, false, ICONS_PRIORITY)]
        public static void Amber() { AssignIconForSelection(ProjectIcon.ClrAmber); }
        [MenuItem(COLOR_YELLOW, false, ICONS_PRIORITY)]
        public static void Yellow() { AssignIconForSelection(ProjectIcon.ClrYellow); }
        [MenuItem(COLOR_LIME, false, ICONS_PRIORITY)]
        public static void Lime() { AssignIconForSelection(ProjectIcon.ClrLime); }
        [MenuItem(COLOR_CHARTREUSE, false, ICONS_PRIORITY)]
        public static void Chartreuse() { AssignIconForSelection(ProjectIcon.ClrChartreuse); }
        [MenuItem(COLOR_HARLEQUIN, false, ICONS_PRIORITY)]
        public static void Harlequin() { AssignIconForSelection(ProjectIcon.ClrHarlequin); }
        [MenuItem(COLOR_GREEN, false, ICONS_PRIORITY + 100)]
        public static void Green() { AssignIconForSelection(ProjectIcon.ClrGreen); }
        [MenuItem(COLOR_EMERALD, false, ICONS_PRIORITY + 100)]
        public static void Emerald() { AssignIconForSelection(ProjectIcon.ClrEmerald); }
        [MenuItem(COLOR_SPRING_GREEN, false, ICONS_PRIORITY + 100)]
        public static void SpringGreen() { AssignIconForSelection(ProjectIcon.ClrSpringGreen); }
        [MenuItem(COLOR_AQUAMARINE, false, ICONS_PRIORITY + 100)]
        public static void Aquamarine() { AssignIconForSelection(ProjectIcon.ClrAquamarine); }
        [MenuItem(COLOR_CYAN, false, ICONS_PRIORITY + 100)]
        public static void BondiBlue() { AssignIconForSelection(ProjectIcon.ClrCyan); }
        [MenuItem(COLOR_SKY_BLUE, false, ICONS_PRIORITY + 100)]
        public static void SkyBlue() { AssignIconForSelection(ProjectIcon.ClrSkyBlue); }
        [MenuItem(COLOR_AZURE, false, ICONS_PRIORITY + 100)]
        public static void Azure() { AssignIconForSelection(ProjectIcon.ClrAzure); }
        [MenuItem(COLOR_CERULEAN, false, ICONS_PRIORITY + 100)]
        public static void Cerulean() { AssignIconForSelection(ProjectIcon.ClrCerulean); }
        [MenuItem(COLOR_BLUE, false, ICONS_PRIORITY + 200)]
        public static void Blue() { AssignIconForSelection(ProjectIcon.ClrBlue); }
        [MenuItem(COLOR_INDIGO, false, ICONS_PRIORITY + 200)]
        public static void Indigo() { AssignIconForSelection(ProjectIcon.ClrIndigo); }
        [MenuItem(COLOR_VIOLET, false, ICONS_PRIORITY + 200)]
        public static void Violet() { AssignIconForSelection(ProjectIcon.ClrViolet); }
        [MenuItem(COLOR_PURPLE, false, ICONS_PRIORITY + 200)]
        public static void Purple() { AssignIconForSelection(ProjectIcon.ClrPurple); }
        [MenuItem(COLOR_MAGENTA, false, ICONS_PRIORITY + 200)]
        public static void Magenta() { AssignIconForSelection(ProjectIcon.ClrMagenta); }
        [MenuItem(COLOR_FUCHSIA, false, ICONS_PRIORITY + 200)]
        public static void Fuchsia() { AssignIconForSelection(ProjectIcon.ClrFuchsia); }
        [MenuItem(COLOR_ROSE, false, ICONS_PRIORITY + 200)]
        public static void Rose() { AssignIconForSelection(ProjectIcon.ClrRose); }
        [MenuItem(COLOR_CRIMSON, false, ICONS_PRIORITY + 200)]
        public static void Crimson() { AssignIconForSelection(ProjectIcon.ClrCrimson); }
        #endregion Context Menu Items - Colors

        #region Context Menu Items - Transparent
        [MenuItem(TRANSPARENT_15, false, ICONS_PRIORITY)]
        public static void Transparent15() { AssignIconForSelection(ProjectIcon.Transparent15); }
        [MenuItem(TRANSPARENT_25, false, ICONS_PRIORITY)]
        public static void Transparent25() { AssignIconForSelection(ProjectIcon.Transparent25); }
        [MenuItem(TRANSPARENT_50, false, ICONS_PRIORITY)]
        public static void Transparent50() { AssignIconForSelection(ProjectIcon.Transparent50); }
        #endregion Context Menu Items - Transparent

        #region Context Menu Items - Tags
        [MenuItem(TAG_RED, false, ICONS_PRIORITY)]
        public static void TagRed() { AssignIconForSelection(ProjectIcon.TagRed); }
        [MenuItem(TAG_VERMILION, false, ICONS_PRIORITY)]
        public static void TagVermilion() { AssignIconForSelection(ProjectIcon.TagVermilion); }
        [MenuItem(TAG_ORANGE, false, ICONS_PRIORITY)]
        public static void TagOrange() { AssignIconForSelection(ProjectIcon.TagOrange); }
        [MenuItem(TAG_AMBER, false, ICONS_PRIORITY)]
        public static void TagAmber() { AssignIconForSelection(ProjectIcon.TagAmber); }
        [MenuItem(TAG_YELLOW, false, ICONS_PRIORITY)]
        public static void TagYellow() { AssignIconForSelection(ProjectIcon.TagYellow); }
        [MenuItem(TAG_LIME, false, ICONS_PRIORITY)]
        public static void TagLime() { AssignIconForSelection(ProjectIcon.TagLime); }
        [MenuItem(TAG_CHARTREUSE, false, ICONS_PRIORITY)]
        public static void TagChartreuse() { AssignIconForSelection(ProjectIcon.TagChartreuse); }
        [MenuItem(TAG_HARLEQUIN, false, ICONS_PRIORITY)]
        public static void TagHarlequin() { AssignIconForSelection(ProjectIcon.TagHarlequin); }
        [MenuItem(TAG_GREEN, false, ICONS_PRIORITY + 100)]
        public static void TagGreen() { AssignIconForSelection(ProjectIcon.TagGreen); }
        [MenuItem(TAG_EMERALD, false, ICONS_PRIORITY + 100)]
        public static void TagEmerald() { AssignIconForSelection(ProjectIcon.TagEmerald); }
        [MenuItem(TAG_SPRING_GREEN, false, ICONS_PRIORITY + 100)]
        public static void TagSpringGreen() { AssignIconForSelection(ProjectIcon.TagSpringGreen); }
        [MenuItem(TAG_AQUAMARINE, false, ICONS_PRIORITY + 100)]
        public static void TagAquamarine() { AssignIconForSelection(ProjectIcon.TagAquamarine); }
        [MenuItem(TAG_CYAN, false, ICONS_PRIORITY + 100)]
        public static void TagBondiBlue() { AssignIconForSelection(ProjectIcon.TagCyan); }
        [MenuItem(TAG_SKY_BLUE, false, ICONS_PRIORITY + 100)]
        public static void TagSkyBlue() { AssignIconForSelection(ProjectIcon.TagSkyBlue); }
        [MenuItem(TAG_AZURE, false, ICONS_PRIORITY + 100)]
        public static void TagAzure() { AssignIconForSelection(ProjectIcon.TagAzure); }
        [MenuItem(TAG_CERULEAN, false, ICONS_PRIORITY + 100)]
        public static void TagCerulean() { AssignIconForSelection(ProjectIcon.TagCerulean); }
        [MenuItem(TAG_BLUE, false, ICONS_PRIORITY + 200)]
        public static void TagBlue() { AssignIconForSelection(ProjectIcon.TagBlue); }
        [MenuItem(TAG_INDIGO, false, ICONS_PRIORITY + 200)]
        public static void TagIndigo() { AssignIconForSelection(ProjectIcon.TagIndigo); }
        [MenuItem(TAG_VIOLET, false, ICONS_PRIORITY + 200)]
        public static void TagViolet() { AssignIconForSelection(ProjectIcon.TagViolet); }
        [MenuItem(TAG_PURPLE, false, ICONS_PRIORITY + 200)]
        public static void TagPurple() { AssignIconForSelection(ProjectIcon.TagPurple); }
        [MenuItem(TAG_MAGENTA, false, ICONS_PRIORITY + 200)]
        public static void TagMagenta() { AssignIconForSelection(ProjectIcon.TagMagenta); }
        [MenuItem(TAG_FUCHSIA, false, ICONS_PRIORITY + 200)]
        public static void TagFuchsia() { AssignIconForSelection(ProjectIcon.TagFuchsia); }
        [MenuItem(TAG_ROSE, false, ICONS_PRIORITY + 200)]
        public static void TagRose() { AssignIconForSelection(ProjectIcon.TagRose); }
        [MenuItem(TAG_CRIMSON, false, ICONS_PRIORITY + 200)]
        public static void TagCrimson() { AssignIconForSelection(ProjectIcon.TagCrimson); }
        #endregion Context Menu Items - Tags

        #region Context Menu Items - Types
        [MenuItem(TYPE_ANIMATIONS, false, ICONS_PRIORITY)]
        public static void TypeAnimations() { AssignIconForSelection(ProjectIcon.TpeAnimations); }
        [MenuItem(TYPE_AUDIO, false, ICONS_PRIORITY)]
        public static void TypeAudio() { AssignIconForSelection(ProjectIcon.TpeAudio); }
        [MenuItem(TYPE_EDITOR, false, ICONS_PRIORITY)]
        public static void TypeEditor() { AssignIconForSelection(ProjectIcon.TpeEditor); }
        [MenuItem(TYPE_EXTENSIONS, false, ICONS_PRIORITY)]
        public static void TypeExtensions() { AssignIconForSelection(ProjectIcon.TpeExtensions); }
        [MenuItem(TYPE_FLARES, false, ICONS_PRIORITY)]
        public static void TypeFlares() { AssignIconForSelection(ProjectIcon.TpeFlares); }
        [MenuItem(TYPE_FONTS, false, ICONS_PRIORITY)]
        public static void TypeFonts() { AssignIconForSelection(ProjectIcon.TpeFonts); }
        [MenuItem(TYPE_MATERIALS, false, ICONS_PRIORITY)]
        public static void TypeMaterials() { AssignIconForSelection(ProjectIcon.TpeMaterials); }
        [MenuItem(TYPE_MESHES, false, ICONS_PRIORITY)]
        public static void TypeMeshes() { AssignIconForSelection(ProjectIcon.TpeMeshes); }
        [MenuItem(TYPE_PHYSICS, false, ICONS_PRIORITY)]
        public static void TypePhysics() { AssignIconForSelection(ProjectIcon.TpePhysics); }
        [MenuItem(TYPE_PLUGINS, false, ICONS_PRIORITY)]
        public static void TypePlugins() { AssignIconForSelection(ProjectIcon.TpePlugins); }
        [MenuItem(TYPE_PREFABS, false, ICONS_PRIORITY)]
        public static void TypePrefabs() { AssignIconForSelection(ProjectIcon.TpePrefabs); }
        [MenuItem(TYPE_PROJECT, false, ICONS_PRIORITY)]
        public static void TypeProject() { AssignIconForSelection(ProjectIcon.TpeProject); }
        [MenuItem(TYPE_RAINBOW, false, ICONS_PRIORITY)]
        public static void TypeRainbow() { AssignIconForSelection(ProjectIcon.TpeRainbow); }
        [MenuItem(TYPE_RESOURCES, false, ICONS_PRIORITY)]
        public static void TypeResources() { AssignIconForSelection(ProjectIcon.TpeResources); }
        [MenuItem(TYPE_SCENES, false, ICONS_PRIORITY)]
        public static void TypeScenes() { AssignIconForSelection(ProjectIcon.TpeScenes); }
        [MenuItem(TYPE_SCRIPTS, false, ICONS_PRIORITY)]
        public static void TypeScripts() { AssignIconForSelection(ProjectIcon.TpeScripts); }
        [MenuItem(TYPE_SHADERS, false, ICONS_PRIORITY)]
        public static void TypeShaders() { AssignIconForSelection(ProjectIcon.TpeShaders); }
        [MenuItem(TYPE_TERRAINS, false, ICONS_PRIORITY)]
        public static void TypeTerrains() { AssignIconForSelection(ProjectIcon.TpeTerrains); }
        [MenuItem(TYPE_TEXTURES, false, ICONS_PRIORITY)]
        public static void TypeTextures() { AssignIconForSelection(ProjectIcon.TpeTextures); }
        #endregion Context Menu Items - Types

        #region Context Menu Items - Platforms
        [MenuItem(PLATFORM_ANDROID, false, ICONS_PRIORITY)]
        public static void PlatformAndroid() { AssignIconForSelection(ProjectIcon.PfmAndroid); }
        [MenuItem(PLATFORM_IOS, false, ICONS_PRIORITY)]
        public static void PlatformiOS() { AssignIconForSelection(ProjectIcon.PfmiOS); }
        [MenuItem(PLATFORM_MAC, false, ICONS_PRIORITY)]
        public static void PlatformMac() { AssignIconForSelection(ProjectIcon.PfmMac); }
        [MenuItem(PLATFORM_WEBGL, false, ICONS_PRIORITY)]
        public static void PlatformWebGL() { AssignIconForSelection(ProjectIcon.PfmWebGL); }
        [MenuItem(PLATFORM_WINDOWS, false, ICONS_PRIORITY)]
        public static void PlatformWindows() { AssignIconForSelection(ProjectIcon.PfmWindows); }
        #endregion Context Menu Items - Platforms

        #region Context Menu Items - Backgrounds
        [MenuItem(BACKGROUND_RED, false, BACKGROUND_PRIORITY)]
        public static void BackgroundRed() { AssignBackgroundForSelection(CoreBackground.ClrRed); }
        [MenuItem(BACKGROUND_VERMILION, false, BACKGROUND_PRIORITY)]
        public static void BackgroundVermilion() { AssignBackgroundForSelection(CoreBackground.ClrVermilion); }
        [MenuItem(BACKGROUND_ORANGE, false, BACKGROUND_PRIORITY)]
        public static void BackgroundOrange() { AssignBackgroundForSelection(CoreBackground.ClrOrange); }
        [MenuItem(BACKGROUND_AMBER, false, BACKGROUND_PRIORITY)]
        public static void BackgroundAmber() { AssignBackgroundForSelection(CoreBackground.ClrAmber); }
        [MenuItem(BACKGROUND_YELLOW, false, BACKGROUND_PRIORITY)]
        public static void BackgroundYellow() { AssignBackgroundForSelection(CoreBackground.ClrYellow); }
        [MenuItem(BACKGROUND_LIME, false, BACKGROUND_PRIORITY)]
        public static void BackgroundLime() { AssignBackgroundForSelection(CoreBackground.ClrLime); }
        [MenuItem(BACKGROUND_CHARTREUSE, false, BACKGROUND_PRIORITY)]
        public static void BackgroundChartreuse() { AssignBackgroundForSelection(CoreBackground.ClrChartreuse); }
        [MenuItem(BACKGROUND_HARLEQUIN, false, BACKGROUND_PRIORITY)]
        public static void BackgroundHarlequin() { AssignBackgroundForSelection(CoreBackground.ClrHarlequin); }
        [MenuItem(BACKGROUND_GREEN, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundGreen() { AssignBackgroundForSelection(CoreBackground.ClrGreen); }
        [MenuItem(BACKGROUND_EMERALD, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundEmerald() { AssignBackgroundForSelection(CoreBackground.ClrEmerald); }
        [MenuItem(BACKGROUND_SPRING_GREEN, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundSpringGreen() { AssignBackgroundForSelection(CoreBackground.ClrSpringGreen); }
        [MenuItem(BACKGROUND_AQUAMARINE, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundAquamarine() { AssignBackgroundForSelection(CoreBackground.ClrAquamarine); }
        [MenuItem(BACKGROUND_CYAN, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundBondiBlue() { AssignBackgroundForSelection(CoreBackground.ClrCyan); }
        [MenuItem(BACKGROUND_SKY_BLUE, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundSkyBlue() { AssignBackgroundForSelection(CoreBackground.ClrSkyBlue); }
        [MenuItem(BACKGROUND_AZURE, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundAzure() { AssignBackgroundForSelection(CoreBackground.ClrAzure); }
        [MenuItem(BACKGROUND_CERULEAN, false, BACKGROUND_PRIORITY + 100)]
        public static void BackgroundCerulean() { AssignBackgroundForSelection(CoreBackground.ClrCerulean); }
        [MenuItem(BACKGROUND_BLUE, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundBlue() { AssignBackgroundForSelection(CoreBackground.ClrBlue); }
        [MenuItem(BACKGROUND_INDIGO, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundIndigo() { AssignBackgroundForSelection(CoreBackground.ClrIndigo); }
        [MenuItem(BACKGROUND_VIOLET, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundViolet() { AssignBackgroundForSelection(CoreBackground.ClrViolet); }
        [MenuItem(BACKGROUND_PURPLE, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundPurple() { AssignBackgroundForSelection(CoreBackground.ClrPurple); }
        [MenuItem(BACKGROUND_MAGENTA, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundMagenta() { AssignBackgroundForSelection(CoreBackground.ClrMagenta); }
        [MenuItem(BACKGROUND_FUCHSIA, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundFuchsia() { AssignBackgroundForSelection(CoreBackground.ClrFuchsia); }
        [MenuItem(BACKGROUND_ROSE, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundRose() { AssignBackgroundForSelection(CoreBackground.ClrRose); }
        [MenuItem(BACKGROUND_CRIMSON, false, BACKGROUND_PRIORITY + 200)]
        public static void BackgroundCrimson() { AssignBackgroundForSelection(CoreBackground.ClrCrimson); }
        #endregion Context Menu Items - Backgrounds

        #region  Private Methods
        private static void AssignIconForSelection(ProjectIcon icon)
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (!AssetDatabase.IsValidFolder(assetPath))
                    {
                        return;
                    }

                    DefaultAsset folder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(assetPath);
                    string path = AssetDatabase.GetAssetPath(folder);
                    RainbowFoldersSettings.Instance.ChangeFolderIconsByPath(path, icon);
                }
            );
        }

        private static void AssignBackgroundForSelection(CoreBackground background)
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (!AssetDatabase.IsValidFolder(assetPath))
                    {
                        return;
                    }

                    DefaultAsset folder = AssetDatabase.LoadAssetAtPath<DefaultAsset>(assetPath);
                    string path = AssetDatabase.GetAssetPath(folder);
                    RainbowFoldersSettings.Instance.ChangeFolderBackgroundByPath(path, background);
                }
            );
        }

        private static void RevertSelectedFoldersToDefault()
        {
            Selection.assetGUIDs.ToList().ForEach(
                assetGuid =>
                {
                    string assetPath = AssetDatabase.GUIDToAssetPath(assetGuid);
                    if (AssetDatabase.IsValidFolder(assetPath))
                    {
                        RainbowFoldersSettings.Instance.RemoveAllByPath(assetPath);
                    }
                }
            );
        }
        #endregion Private Methods
    }
}