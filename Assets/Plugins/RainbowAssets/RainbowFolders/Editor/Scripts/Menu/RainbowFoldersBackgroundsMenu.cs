using Borodar.RainbowCore;
using Borodar.RainbowFolders.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    public static class RainbowFoldersBackgroundsMenu
    {
        #region GUI Labels
        private const string MENU_COLORIZE = "Colors/";
        private const string MENU_CUSTOM = "Custom";
        private const string MENU_NONE = "None";
        #endregion GUI Labels

        #region GUI Colors
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
        #endregion GUI Colors

        #region GUI Selection
        private static readonly GUIContent SELECT_CUSTOM = new(MENU_CUSTOM);
        private static readonly GUIContent SELECT_NONE = new(MENU_NONE);
        #endregion GUI Selection

        #region Public Methods

        public static void ShowDropDown(Rect position, object item)
        {
            GenericMenu menu = new();

            // Colors Menu
            menu.AddItem(COLOR_RED, false, RedCallback, item);
            menu.AddItem(COLOR_VERMILION, false, VermilionCallback, item);
            menu.AddItem(COLOR_ORANGE, false, OrangeCallback, item);
            menu.AddItem(COLOR_AMBER, false, AmberCallback, item);
            menu.AddItem(COLOR_YELLOW, false, YellowCallback, item);
            menu.AddItem(COLOR_LIME, false, LimeCallback, item);
            menu.AddItem(COLOR_CHARTREUSE, false, ChartreuseCallback, item);
            menu.AddItem(COLOR_HARLEQUIN, false, HarlequinCallback, item);
            menu.AddSeparator(MENU_COLORIZE);
            menu.AddItem(COLOR_GREEN, false, GreenCallback, item);
            menu.AddItem(COLOR_EMERALD, false, EmeraldCallback, item);
            menu.AddItem(COLOR_SPRING_GREEN, false, SpringGreenCallback, item);
            menu.AddItem(COLOR_AQUAMARINE, false, AquamarineCallback, item);
            menu.AddItem(COLOR_CYAN, false, CyanCallback, item);
            menu.AddItem(COLOR_SKY_BLUE, false, SkyBlueCallback, item);
            menu.AddItem(COLOR_AZURE, false, AzureCallback, item);
            menu.AddItem(COLOR_CERULEAN, false, CeruleanCallback, item);
            menu.AddSeparator(MENU_COLORIZE);
            menu.AddItem(COLOR_BLUE, false, BlueCallback, item);
            menu.AddItem(COLOR_INDIGO, false, IndigoCallback, item);
            menu.AddItem(COLOR_VIOLET, false, VioletCallback, item);
            menu.AddItem(COLOR_PURPLE, false, PurpleCallback, item);
            menu.AddItem(COLOR_MAGENTA, false, MagentaCallback, item);
            menu.AddItem(COLOR_FUCHSIA, false, FuchsiaCallback, item);
            menu.AddItem(COLOR_ROSE, false, RoseCallback, item);
            menu.AddItem(COLOR_CRIMSON, false, CrimsonCallback, item);

            menu.AddSeparator(string.Empty); // Separator between colors and callbacks

            menu.AddItem(SELECT_CUSTOM, false, SelectCustomCallback, item); // Custom Selection

            menu.AddItem(SELECT_NONE, false, SelectNoneCallback, item); // None Selection

            menu.DropDown(position);
        }

        #endregion Public Methods

        #region Callbacks - Colors

        private static void RedCallback(object item)
        => AssignBackground(CoreBackground.ClrRed, item);

        private static void VermilionCallback(object item)
        => AssignBackground(CoreBackground.ClrVermilion, item);

        private static void OrangeCallback(object item)
        => AssignBackground(CoreBackground.ClrOrange, item);

        private static void AmberCallback(object item)
        => AssignBackground(CoreBackground.ClrAmber, item);

        private static void YellowCallback(object item)
        => AssignBackground(CoreBackground.ClrYellow, item);

        private static void LimeCallback(object item)
        => AssignBackground(CoreBackground.ClrLime, item);

        private static void ChartreuseCallback(object item)
        => AssignBackground(CoreBackground.ClrChartreuse, item);

        private static void HarlequinCallback(object item)
        => AssignBackground(CoreBackground.ClrHarlequin, item);

        private static void GreenCallback(object item)
        => AssignBackground(CoreBackground.ClrGreen, item);

        private static void EmeraldCallback(object item)
        => AssignBackground(CoreBackground.ClrEmerald, item);

        private static void SpringGreenCallback(object item)
        => AssignBackground(CoreBackground.ClrSpringGreen, item);

        private static void AquamarineCallback(object item)
        => AssignBackground(CoreBackground.ClrAquamarine, item);

        private static void CyanCallback(object item)
        => AssignBackground(CoreBackground.ClrCyan, item);

        private static void SkyBlueCallback(object item)
        => AssignBackground(CoreBackground.ClrSkyBlue, item);

        private static void AzureCallback(object item)
        => AssignBackground(CoreBackground.ClrAzure, item);

        private static void CeruleanCallback(object item)
        => AssignBackground(CoreBackground.ClrCerulean, item);

        private static void BlueCallback(object item)
        => AssignBackground(CoreBackground.ClrBlue, item);

        private static void IndigoCallback(object item)
        => AssignBackground(CoreBackground.ClrIndigo, item);

        private static void VioletCallback(object item)
        => AssignBackground(CoreBackground.ClrViolet, item);

        private static void PurpleCallback(object item)
        => AssignBackground(CoreBackground.ClrPurple, item);

        private static void MagentaCallback(object item)
        => AssignBackground(CoreBackground.ClrMagenta, item);

        private static void FuchsiaCallback(object item)
        => AssignBackground(CoreBackground.ClrFuchsia, item);

        private static void RoseCallback(object item)
        => AssignBackground(CoreBackground.ClrRose, item);

        private static void CrimsonCallback(object item)
        => AssignBackground(CoreBackground.ClrCrimson, item);

        #endregion Callbacks - Colors

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

        #region Internal Helpers

        // Background

        private static void AssignBackground(CoreBackground type, object item)
        {
            if (IsSerializedProperty(item))
            {
                AssignBackground(type, item as SerializedProperty);
            }
            else
            {
                AssignBackground(type, item as ProjectItem);
            }
        }

        // Project Item

        private static void AssignBackground(CoreBackground type, ProjectItem item)
        {
            item.BackgroundType = type;
            item.BackgroundTexture = null;
        }

        private static void SelectNone(ProjectItem item)
        {
            item.BackgroundType = CoreBackground.None;
            item.BackgroundTexture = null;
            item.IsBackgroundRecursive = false;
        }

        private static void SelectCustom(ProjectItem item)
        {
            item.BackgroundType = CoreBackground.Custom;
            item.BackgroundTexture = null;
        }

        // Serialized Property

        private static void AssignBackground(CoreBackground type, SerializedProperty property)
        {
            property.FindPropertyRelative("BackgroundType").intValue = (int)type;
            property.FindPropertyRelative("BackgroundTexture").objectReferenceValue = null;
            ApplyModifiedProperties(property);
        }

        private static void SelectNone(SerializedProperty property)
        {
            property.FindPropertyRelative("BackgroundType").intValue = (int)CoreBackground.None;
            property.FindPropertyRelative("BackgroundTexture").objectReferenceValue = null;
            property.FindPropertyRelative("IsBackgroundRecursive").boolValue = false;
            ApplyModifiedProperties(property);
        }

        private static void SelectCustom(SerializedProperty property)
        {
            property.FindPropertyRelative("BackgroundType").intValue = (int)CoreBackground.Custom;
            property.FindPropertyRelative("BackgroundTexture").objectReferenceValue = null;
            ApplyModifiedProperties(property);
        }

        // Other

        private static void ApplyModifiedProperties(SerializedProperty hierarchyItem)
        {
            SerializedObject serializedObject = hierarchyItem.serializedObject;
            serializedObject.ApplyModifiedProperties();
            // TODO: check if we do not need this:
            //            var sceneConfig = (HierarchySceneConfig) serializedObject.targetObject;
            //            sceneConfig.SendMessage("OnConfigChange");
        }

        private static bool IsSerializedProperty(object item)
        {
            return item.GetType() == typeof(SerializedProperty);
        }

        #endregion Internal Helpers
    }
}