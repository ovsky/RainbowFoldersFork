using Borodar.RainbowFolders.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    public static class RainbowFoldersIconsMenu
    {
        #region  Fields

        #region Icons Menu - Items
        private const string MENU_COLORIZE = "Colors/";
        private const string MENU_TRANSPARENT = "Transparent/";
        private const string MENU_TAG = "Tags/";
        private const string MENU_TYPE = "Types/";
        private const string MENU_PLATFORM = "Platforms/";
        private const string MENU_CUSTOM = "Custom";
        private const string MENU_NONE = "None";
        #endregion Icons Menu - Items

        #region Icons Menu - Colors
        private static readonly GUIContent COLOR_RED = new(MENU_COLORIZE + "Red");
        private static readonly GUIContent COLOR_VERMILION = new(MENU_COLORIZE + "Vermilion");
        private static readonly GUIContent COLOR_ORANGE = new(MENU_COLORIZE + "Orange");
        private static readonly GUIContent COLOR_AMBER = new(MENU_COLORIZE + "Amber");
        private static readonly GUIContent COLOR_YELLOW = new(MENU_COLORIZE + "Yellow");
        private static readonly GUIContent COLOR_LIME = new(MENU_COLORIZE + "Lime");
        private static readonly GUIContent COLOR_CHARTREUSE = new(MENU_COLORIZE + "Chartreuse");
        private static readonly GUIContent COLOR_HARLEQUIN = new(MENU_COLORIZE + "Harlequin");
        private static readonly GUIContent COLOR_GREEN = new(MENU_COLORIZE + "Green");
        private static readonly GUIContent COLOR_EMERALD = new(MENU_COLORIZE + "Emerald");
        private static readonly GUIContent COLOR_SPRING_GREEN = new(MENU_COLORIZE + "Spring-green");
        private static readonly GUIContent COLOR_AQUAMARINE = new(MENU_COLORIZE + "Aquamarine");
        private static readonly GUIContent COLOR_CYAN = new(MENU_COLORIZE + "Cyan");
        private static readonly GUIContent COLOR_SKY_BLUE = new(MENU_COLORIZE + "Sky-blue");
        private static readonly GUIContent COLOR_AZURE = new(MENU_COLORIZE + "Azure");
        private static readonly GUIContent COLOR_CERULEAN = new(MENU_COLORIZE + "Cerulean");
        private static readonly GUIContent COLOR_BLUE = new(MENU_COLORIZE + "Blue");
        private static readonly GUIContent COLOR_INDIGO = new(MENU_COLORIZE + "Indigo");
        private static readonly GUIContent COLOR_VIOLET = new(MENU_COLORIZE + "Violet");
        private static readonly GUIContent COLOR_PURPLE = new(MENU_COLORIZE + "Purple");
        private static readonly GUIContent COLOR_MAGENTA = new(MENU_COLORIZE + "Magenta");
        private static readonly GUIContent COLOR_FUCHSIA = new(MENU_COLORIZE + "Fuchsia");
        private static readonly GUIContent COLOR_ROSE = new(MENU_COLORIZE + "Rose");
        private static readonly GUIContent COLOR_CRIMSON = new(MENU_COLORIZE + "Crimson");
        #endregion Icons Menu - Colors

        #region Icons Menu - Transparent
        private static readonly GUIContent TRANSPARENT_15 = new(MENU_TRANSPARENT + "15%");
        private static readonly GUIContent TRANSPARENT_25 = new(MENU_TRANSPARENT + "25%");
        private static readonly GUIContent TRANSPARENT_50 = new(MENU_TRANSPARENT + "50%");
        #endregion Icons Menu - Transparent

        #region Icons Menu - Tags
        private static readonly GUIContent TAG_RED = new(MENU_TAG + "Red");
        private static readonly GUIContent TAG_VERMILION = new(MENU_TAG + "Vermilion");
        private static readonly GUIContent TAG_ORANGE = new(MENU_TAG + "Orange");
        private static readonly GUIContent TAG_AMBER = new(MENU_TAG + "Amber");
        private static readonly GUIContent TAG_YELLOW = new(MENU_TAG + "Yellow");
        private static readonly GUIContent TAG_LIME = new(MENU_TAG + "Lime");
        private static readonly GUIContent TAG_CHARTREUSE = new(MENU_TAG + "Chartreuse");
        private static readonly GUIContent TAG_HARLEQUIN = new(MENU_TAG + "Harlequin");
        private static readonly GUIContent TAG_GREEN = new(MENU_TAG + "Green");
        private static readonly GUIContent TAG_EMERALD = new(MENU_TAG + "Emerald");
        private static readonly GUIContent TAG_SPRING_GREEN = new(MENU_TAG + "Spring-green");
        private static readonly GUIContent TAG_AQUAMARINE = new(MENU_TAG + "Aquamarine");
        private static readonly GUIContent TAG_CYAN = new(MENU_TAG + "Cyan");
        private static readonly GUIContent TAG_SKY_BLUE = new(MENU_TAG + "Sky-blue");
        private static readonly GUIContent TAG_AZURE = new(MENU_TAG + "Azure");
        private static readonly GUIContent TAG_CERULEAN = new(MENU_TAG + "Cerulean");
        private static readonly GUIContent TAG_BLUE = new(MENU_TAG + "Blue");
        private static readonly GUIContent TAG_INDIGO = new(MENU_TAG + "Indigo");
        private static readonly GUIContent TAG_VIOLET = new(MENU_TAG + "Violet");
        private static readonly GUIContent TAG_PURPLE = new(MENU_TAG + "Purple");
        private static readonly GUIContent TAG_MAGENTA = new(MENU_TAG + "Magenta");
        private static readonly GUIContent TAG_FUCHSIA = new(MENU_TAG + "Fuchsia");
        private static readonly GUIContent TAG_ROSE = new(MENU_TAG + "Rose");
        private static readonly GUIContent TAG_CRIMSON = new(MENU_TAG + "Crimson");
        #endregion Icons Menu - Tags

        #region Icons Menu - Types
        private static readonly GUIContent TYPE_ANIMATIONS = new(MENU_TYPE + "Animations");
        private static readonly GUIContent TYPE_AUDIO = new(MENU_TYPE + "Audio");
        private static readonly GUIContent TYPE_PROJECT = new(MENU_TYPE + "Project");
        private static readonly GUIContent TYPE_EDITOR = new(MENU_TYPE + "Editor");
        private static readonly GUIContent TYPE_EXTENSIONS = new(MENU_TYPE + "Extensions");
        private static readonly GUIContent TYPE_FLARES = new(MENU_TYPE + "Flares");
        private static readonly GUIContent TYPE_FONTS = new(MENU_TYPE + "Fonts");
        private static readonly GUIContent TYPE_MATERIALS = new(MENU_TYPE + "Materials");
        private static readonly GUIContent TYPE_MESHES = new(MENU_TYPE + "Meshes");
        private static readonly GUIContent TYPE_PHYSICS = new(MENU_TYPE + "Physics");
        private static readonly GUIContent TYPE_PLUGINS = new(MENU_TYPE + "Plugins");
        private static readonly GUIContent TYPE_PREFABS = new(MENU_TYPE + "Prefabs");
        private static readonly GUIContent TYPE_RAINBOW = new(MENU_TYPE + "Rainbow");
        private static readonly GUIContent TYPE_RESOURCES = new(MENU_TYPE + "Resources");
        private static readonly GUIContent TYPE_SCENES = new(MENU_TYPE + "Scenes");
        private static readonly GUIContent TYPE_SCRIPTS = new(MENU_TYPE + "Scripts");
        private static readonly GUIContent TYPE_SHADERS = new(MENU_TYPE + "Shaders");
        private static readonly GUIContent TYPE_TERRAINS = new(MENU_TYPE + "Terrains");
        private static readonly GUIContent TYPE_TEXTURES = new(MENU_TYPE + "Textures");
        #endregion Icons Menu - Types

        #region Icons Menu - Platforms
        private static readonly GUIContent PLATFORM_ANDROID = new(MENU_PLATFORM + "Android");
        private static readonly GUIContent PLATFORM_IOS = new(MENU_PLATFORM + "iOS");
        private static readonly GUIContent PLATFORM_MAC = new(MENU_PLATFORM + "Mac");
        private static readonly GUIContent PLATFORM_WEBGL = new(MENU_PLATFORM + "WebGL");
        private static readonly GUIContent PLATFORM_WINDOWS = new(MENU_PLATFORM + "Windows");
        #endregion Icons Menu - Platforms

        #region Icons Menu - Custom
        private static readonly GUIContent SELECT_CUSTOM = new(MENU_CUSTOM);
        #endregion Icons Menu - Custom

        #region Icons Menu - None
        private static readonly GUIContent SELECT_NONE = new(MENU_NONE);
        #endregion Icons Menu - None

        #endregion Fields

        #region Public Methods
        public static void ShowDropDown(Rect position, object projectItem)
        {
            GenericMenu menu = new();

            #region Generic Menu - Colors
            menu.AddItem(COLOR_RED, false, RedCallback, projectItem);
            menu.AddItem(COLOR_VERMILION, false, VermilionCallback, projectItem);
            menu.AddItem(COLOR_ORANGE, false, OrangeCallback, projectItem);
            menu.AddItem(COLOR_AMBER, false, AmberCallback, projectItem);
            menu.AddItem(COLOR_YELLOW, false, YellowCallback, projectItem);
            menu.AddItem(COLOR_LIME, false, LimeCallback, projectItem);
            menu.AddItem(COLOR_CHARTREUSE, false, ChartreuseCallback, projectItem);
            menu.AddItem(COLOR_HARLEQUIN, false, HarlequinCallback, projectItem);
            menu.AddSeparator(MENU_COLORIZE);
            menu.AddItem(COLOR_GREEN, false, GreenCallback, projectItem);
            menu.AddItem(COLOR_EMERALD, false, EmeraldCallback, projectItem);
            menu.AddItem(COLOR_SPRING_GREEN, false, SpringGreenCallback, projectItem);
            menu.AddItem(COLOR_AQUAMARINE, false, AquamarineCallback, projectItem);
            menu.AddItem(COLOR_CYAN, false, CyanCallback, projectItem);
            menu.AddItem(COLOR_SKY_BLUE, false, SkyBlueCallback, projectItem);
            menu.AddItem(COLOR_AZURE, false, AzureCallback, projectItem);
            menu.AddItem(COLOR_CERULEAN, false, CeruleanCallback, projectItem);
            menu.AddSeparator(MENU_COLORIZE);
            menu.AddItem(COLOR_BLUE, false, BlueCallback, projectItem);
            menu.AddItem(COLOR_INDIGO, false, IndigoCallback, projectItem);
            menu.AddItem(COLOR_VIOLET, false, VioletCallback, projectItem);
            menu.AddItem(COLOR_PURPLE, false, PurpleCallback, projectItem);
            menu.AddItem(COLOR_MAGENTA, false, MagentaCallback, projectItem);
            menu.AddItem(COLOR_FUCHSIA, false, FuchsiaCallback, projectItem);
            menu.AddItem(COLOR_ROSE, false, RoseCallback, projectItem);
            menu.AddItem(COLOR_CRIMSON, false, CrimsonCallback, projectItem);
            #endregion Generic Menu - Colors

            // Transparent
            #region Generic Menu - Transparent
            menu.AddItem(TRANSPARENT_15, false, Transparent15Callback, projectItem);
            menu.AddItem(TRANSPARENT_25, false, Transparent25Callback, projectItem);
            menu.AddItem(TRANSPARENT_50, false, Transparent50Callback, projectItem);
            #endregion Generic Menu - Transparent

            // Tags
            #region Generic Menu - Transparent
            menu.AddItem(TAG_RED, false, TagRedCallback, projectItem);
            menu.AddItem(TAG_VERMILION, false, TagVermilionCallback, projectItem);
            menu.AddItem(TAG_ORANGE, false, TagOrangeCallback, projectItem);
            menu.AddItem(TAG_AMBER, false, TagAmberCallback, projectItem);
            menu.AddItem(TAG_YELLOW, false, TagYellowCallback, projectItem);
            menu.AddItem(TAG_LIME, false, TagLimeCallback, projectItem);
            menu.AddItem(TAG_CHARTREUSE, false, TagChartreuseCallback, projectItem);
            menu.AddItem(TAG_HARLEQUIN, false, TagHarlequinCallback, projectItem);
            menu.AddSeparator(MENU_TAG);
            menu.AddItem(TAG_GREEN, false, TagGreenCallback, projectItem);
            menu.AddItem(TAG_EMERALD, false, TagEmeraldCallback, projectItem);
            menu.AddItem(TAG_SPRING_GREEN, false, TagSpringGreenCallback, projectItem);
            menu.AddItem(TAG_AQUAMARINE, false, TagAquamarineCallback, projectItem);
            menu.AddItem(TAG_CYAN, false, TagCyanCallback, projectItem);
            menu.AddItem(TAG_SKY_BLUE, false, TagSkyBlueCallback, projectItem);
            menu.AddItem(TAG_AZURE, false, TagAzureCallback, projectItem);
            menu.AddItem(TAG_CERULEAN, false, TagCeruleanCallback, projectItem);
            menu.AddSeparator(MENU_TAG);
            menu.AddItem(TAG_BLUE, false, TagBlueCallback, projectItem);
            menu.AddItem(TAG_INDIGO, false, TagIndigoCallback, projectItem);
            menu.AddItem(TAG_VIOLET, false, TagVioletCallback, projectItem);
            menu.AddItem(TAG_PURPLE, false, TagPurpleCallback, projectItem);
            menu.AddItem(TAG_MAGENTA, false, TagMagentaCallback, projectItem);
            menu.AddItem(TAG_FUCHSIA, false, TagFuchsiaCallback, projectItem);
            menu.AddItem(TAG_ROSE, false, TagRoseCallback, projectItem);
            menu.AddItem(TAG_CRIMSON, false, TagCrimsonCallback, projectItem);
            #endregion Generic Menu - Transparent

            //Types
            #region Generic Menu - Types
            menu.AddItem(TYPE_ANIMATIONS, false, AnimationsCallback, projectItem);
            menu.AddItem(TYPE_AUDIO, false, AudioCallback, projectItem);
            menu.AddItem(TYPE_EDITOR, false, EditorCallback, projectItem);
            menu.AddItem(TYPE_EXTENSIONS, false, ExtensionsCallback, projectItem);
            menu.AddItem(TYPE_FLARES, false, FlaresCallback, projectItem);
            menu.AddItem(TYPE_FONTS, false, FontsCallback, projectItem);
            menu.AddItem(TYPE_MATERIALS, false, MaterialsCallback, projectItem);
            menu.AddItem(TYPE_MESHES, false, MeshesCallback, projectItem);
            menu.AddItem(TYPE_PLUGINS, false, PluginsCallback, projectItem);
            menu.AddItem(TYPE_PHYSICS, false, PhysicsCallback, projectItem);
            menu.AddItem(TYPE_PREFABS, false, PrefabsCallback, projectItem);
            menu.AddItem(TYPE_PROJECT, false, ProjectCallback, projectItem);
            menu.AddItem(TYPE_RAINBOW, false, RainbowCallback, projectItem);
            menu.AddItem(TYPE_RESOURCES, false, ResourcesCallback, projectItem);
            menu.AddItem(TYPE_SCENES, false, ScenesCallback, projectItem);
            menu.AddItem(TYPE_SCRIPTS, false, ScriptsCallback, projectItem);
            menu.AddItem(TYPE_SHADERS, false, ShadersCallback, projectItem);
            menu.AddItem(TYPE_TERRAINS, false, TerrainsCallback, projectItem);
            menu.AddItem(TYPE_TEXTURES, false, TexturesCallback, projectItem);
            #region Generic Menu - Types

            #region Generic Menu - Platforms
            menu.AddItem(PLATFORM_ANDROID, false, AndroidCallback, projectItem);
            menu.AddItem(PLATFORM_IOS, false, IosCallback, projectItem);
            menu.AddItem(PLATFORM_MAC, false, MacCallback, projectItem);
            menu.AddItem(PLATFORM_WEBGL, false, WebGLCallback, projectItem);
            menu.AddItem(PLATFORM_WINDOWS, false, WindowsCallback, projectItem);
            #endregion Generic Menu - Platforms

            #endregion Generic Menu - Types
            menu.AddSeparator(string.Empty); // Add Separator
            menu.AddItem(SELECT_CUSTOM, false, SelectCustomCallback, projectItem); // Add Custom
            menu.AddItem(SELECT_NONE, false, SelectNoneCallback, projectItem);// Add None
            menu.DropDown(position); // Show Drop Down
            #endregion Generic Menu - Types
        }
        #endregion Public Methods

        #region Private Methods

        private static void AssignIconByType(ProjectIcon type, object item)
        {
            if (IsSerializedProperty(item))
            {
                AssignIconByType(type, item as SerializedProperty);
            }
            else
            {
                AssignIconByType(type, item as ProjectItem);
            }
        }

        private static void AssignIconByType(ProjectIcon type, ProjectItem item)
        {
            item.IconType = type;
            item.SmallIcon = null;
            item.LargeIcon = null;
        }

        private static void AssignIconByType(ProjectIcon type, SerializedProperty projectItem)
        {
            projectItem.FindPropertyRelative("IconType").intValue = (int)type;
            projectItem.FindPropertyRelative("SmallIcon").objectReferenceValue = null;
            projectItem.FindPropertyRelative("LargeIcon").objectReferenceValue = null;
            ApplyModifiedProperties(projectItem);
        }

        private static void SelectCustom(ProjectItem item)
        {
            item.IconType = ProjectIcon.Custom;
            item.SmallIcon = null;
            item.LargeIcon = null;
        }

        private static void SelectCustom(SerializedProperty projectItem)
        {
            projectItem.FindPropertyRelative("IconType").intValue = (int)ProjectIcon.Custom;
            projectItem.FindPropertyRelative("SmallIcon").objectReferenceValue = null;
            projectItem.FindPropertyRelative("LargeIcon").objectReferenceValue = null;
            ApplyModifiedProperties(projectItem);
        }

        private static void SelectNone(ProjectItem folder)
        {
            folder.IconType = ProjectIcon.None;
            folder.SmallIcon = null;
            folder.LargeIcon = null;
            folder.IsIconRecursive = false;
        }

        private static void SelectNone(SerializedProperty projectItem)
        {
            projectItem.FindPropertyRelative("IconType").intValue = (int)ProjectIcon.None;
            projectItem.FindPropertyRelative("SmallIcon").objectReferenceValue = null;
            projectItem.FindPropertyRelative("LargeIcon").objectReferenceValue = null;
            projectItem.FindPropertyRelative("IsIconRecursive").boolValue = false;
            ApplyModifiedProperties(projectItem);
        }

        private static void ApplyModifiedProperties(SerializedProperty projectItem)
        {
            SerializedObject serializedObject = projectItem.serializedObject;
            serializedObject.ApplyModifiedProperties();
            // RainbowFoldersSettings sceneConfig = (RainbowFoldersSettings)serializedObject.targetObject;
            //            sceneConfig.SendMessage("OnConfigChange"); // TODO
        }

        private static bool IsSerializedProperty(object item)
        {
            return item.GetType() == typeof(SerializedProperty);
        }

        #endregion Private Methods

        #region Callbacks

        #region Callbacks - Colors
        private static void RedCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrRed, folder); }

        private static void VermilionCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrVermilion, folder); }

        private static void OrangeCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrOrange, folder); }

        private static void AmberCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrAmber, folder); }

        private static void YellowCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrYellow, folder); }

        private static void LimeCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrLime, folder); }

        private static void ChartreuseCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrChartreuse, folder); }

        private static void HarlequinCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrHarlequin, folder); }

        private static void GreenCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrGreen, folder); }

        private static void EmeraldCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrEmerald, folder); }

        private static void SpringGreenCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrSpringGreen, folder); }

        private static void AquamarineCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrAquamarine, folder); }

        private static void CyanCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrCyan, folder); }

        private static void SkyBlueCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrSkyBlue, folder); }

        private static void AzureCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrAzure, folder); }

        private static void CeruleanCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrCerulean, folder); }

        private static void BlueCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrBlue, folder); }

        private static void IndigoCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrIndigo, folder); }

        private static void VioletCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrViolet, folder); }

        private static void PurpleCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrPurple, folder); }

        private static void MagentaCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrMagenta, folder); }

        private static void FuchsiaCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrFuchsia, folder); }

        private static void RoseCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrRose, folder); }

        private static void CrimsonCallback(object folder)
        { AssignIconByType(ProjectIcon.ClrCrimson, folder); }
        #endregion Callbacks - Colors

        #region Callbacks - Transparent
        private static void Transparent15Callback(object folder)
        { AssignIconByType(ProjectIcon.Transparent15, folder); }

        private static void Transparent25Callback(object folder)
        { AssignIconByType(ProjectIcon.Transparent25, folder); }

        private static void Transparent50Callback(object folder)
        { AssignIconByType(ProjectIcon.Transparent50, folder); }
        #endregion Callbacks - Transparent

        #region Callbacks - Tags
        private static void TagRedCallback(object folder)
        { AssignIconByType(ProjectIcon.TagRed, folder); }

        private static void TagVermilionCallback(object folder)
        { AssignIconByType(ProjectIcon.TagVermilion, folder); }

        private static void TagOrangeCallback(object folder)
        { AssignIconByType(ProjectIcon.TagOrange, folder); }

        private static void TagAmberCallback(object folder)
        { AssignIconByType(ProjectIcon.TagAmber, folder); }

        private static void TagYellowCallback(object folder)
        { AssignIconByType(ProjectIcon.TagYellow, folder); }

        private static void TagLimeCallback(object folder)
        { AssignIconByType(ProjectIcon.TagLime, folder); }

        private static void TagChartreuseCallback(object folder)
        { AssignIconByType(ProjectIcon.TagChartreuse, folder); }

        private static void TagHarlequinCallback(object folder)
        { AssignIconByType(ProjectIcon.TagHarlequin, folder); }

        private static void TagGreenCallback(object folder)
        { AssignIconByType(ProjectIcon.TagGreen, folder); }

        private static void TagEmeraldCallback(object folder)
        { AssignIconByType(ProjectIcon.TagEmerald, folder); }

        private static void TagSpringGreenCallback(object folder)
        { AssignIconByType(ProjectIcon.TagSpringGreen, folder); }

        private static void TagAquamarineCallback(object folder)
        { AssignIconByType(ProjectIcon.TagAquamarine, folder); }

        private static void TagCyanCallback(object folder)
        { AssignIconByType(ProjectIcon.TagCyan, folder); }

        private static void TagSkyBlueCallback(object folder)
        { AssignIconByType(ProjectIcon.TagSkyBlue, folder); }

        private static void TagAzureCallback(object folder)
        { AssignIconByType(ProjectIcon.TagAzure, folder); }

        private static void TagCeruleanCallback(object folder)
        { AssignIconByType(ProjectIcon.TagCerulean, folder); }

        private static void TagBlueCallback(object folder)
        { AssignIconByType(ProjectIcon.TagBlue, folder); }

        private static void TagIndigoCallback(object folder)
        { AssignIconByType(ProjectIcon.TagIndigo, folder); }

        private static void TagVioletCallback(object folder)
        { AssignIconByType(ProjectIcon.TagViolet, folder); }

        private static void TagPurpleCallback(object folder)
        { AssignIconByType(ProjectIcon.TagPurple, folder); }

        private static void TagMagentaCallback(object folder)
        { AssignIconByType(ProjectIcon.TagMagenta, folder); }

        private static void TagFuchsiaCallback(object folder)
        { AssignIconByType(ProjectIcon.TagFuchsia, folder); }

        private static void TagRoseCallback(object folder)
        { AssignIconByType(ProjectIcon.TagRose, folder); }

        private static void TagCrimsonCallback(object folder)
        { AssignIconByType(ProjectIcon.TagCrimson, folder); }
        #endregion Callbacks - Tags

        #region Callbacks - Types
        private static void AnimationsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeAnimations, folder); }

        private static void PhysicsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpePhysics, folder); }

        private static void PrefabsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpePrefabs, folder); }

        private static void ScenesCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeScenes, folder); }

        private static void ScriptsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeScripts, folder); }

        private static void ExtensionsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeExtensions, folder); }

        private static void FlaresCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeFlares, folder); }

        private static void PluginsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpePlugins, folder); }

        private static void TexturesCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeTextures, folder); }

        private static void MaterialsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeMaterials, folder); }

        private static void AudioCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeAudio, folder); }

        private static void ProjectCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeProject, folder); }

        private static void FontsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeFonts, folder); }

        private static void EditorCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeEditor, folder); }

        private static void ResourcesCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeResources, folder); }

        private static void ShadersCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeShaders, folder); }

        private static void TerrainsCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeTerrains, folder); }

        private static void MeshesCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeMeshes, folder); }

        private static void RainbowCallback(object folder)
        { AssignIconByType(ProjectIcon.TpeRainbow, folder); }
        #endregion Callbacks - Types

        #region Callbacks - Platforms
        private static void AndroidCallback(object folder)
        { AssignIconByType(ProjectIcon.PfmAndroid, folder); }

        private static void IosCallback(object folder)
        { AssignIconByType(ProjectIcon.PfmiOS, folder); }

        private static void MacCallback(object folder)
        { AssignIconByType(ProjectIcon.PfmMac, folder); }

        private static void WebGLCallback(object folder)
        { AssignIconByType(ProjectIcon.PfmWebGL, folder); }

        private static void WindowsCallback(object folder)
        { AssignIconByType(ProjectIcon.PfmWindows, folder); }
        #endregion Callbacks - Platforms

        #region Callbacks - Custom
        private static void SelectCustomCallback(object item)
        {
            if (IsSerializedProperty(item))
            {
                SelectCustom(item as SerializedProperty);
            }
            else
            {
                SelectCustom(item as ProjectItem);
            }
        }
        #endregion Callbacks - Custom

        #region Callbacks - None
        private static void SelectNoneCallback(object item)
        {
            if (IsSerializedProperty(item))
            {
                SelectNone(item as SerializedProperty);
            }
            else
            {
                SelectNone(item as ProjectItem);
            }
        }
        #endregion Callbacks - None

        #endregion Callbacks
    }
}