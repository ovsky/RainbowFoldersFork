using System;
using System.Diagnostics.CodeAnalysis;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    public static class ProjectPreferences
    {
        #region Fields

        #region Fields - Constants
        private const float PREF_LABEL_WIDTH = 150f;

        private const string HOME_FOLDER_PREF_KEY = "Borodar.RainbowFolders.HomeFolder.";
        private const string HOME_FOLDER_DEFAULT = "Assets/Plugins/RainbowAssets/RainbowFolders";
        private const string HOME_FOLDER_HINT = "Change this setting to the new location of the \"Rainbow Folders\" if you move the folder around in your project.";

        private const string MOD_KEY_PREF_KEY = "Borodar.RainbowFolders.EditMod.";
        private const string MOD_KEY_HINT = "Modifier key that is used to show configuration dialogue when clicking on a folder icon.";
        private const EventModifiers MOD_KEY_DEFAULT = EventModifiers.Alt;

        private const string PROJECT_TREE_PREF_KEY = "Borodar.RainbowFolders.ShowProjectTree.";
        private const string PROJECT_TREE_HINT = "(Experimental)\nChange this setting to show/hide the \"branches\" in the project window.";
        private const bool PROJECT_TREE_DEFAULT = true;

        private const string ROW_SHADING_PREF_KEY = "Borodar.RainbowFolders.RowShading.";
        private const string ROW_SHADING_HINT = "Change this settings to enable/disable row shading in the project window.";
        private const bool ROW_SHADING_DEFAULT = true;
        #endregion Fields - Constants

        #region Fields - Readonly
        private static readonly EditorPrefsString HOME_FOLDER_PREF;
        private static readonly EditorPrefsModifierKey MODIFIER_KEY_PREF;
        private static readonly EditorPrefsBoolean PROJECT_TREE_PREF;
        private static readonly EditorPrefsBoolean ROW_SHADING_PREF;
        #endregion Fields - Readonly

        #region Fields - Static
        public static string HomeFolder;
        public static EventModifiers ModifierKey;
        public static bool ShowProjectTree;
        public static bool DrawRowShading;
        #endregion Fields - Static

        #endregion Fields

        #region ProjectPreferences Constructor

        static ProjectPreferences()
        {
            GUIContent homeLabel = new("Folder Location", HOME_FOLDER_HINT);
            HOME_FOLDER_PREF = new EditorPrefsString(HOME_FOLDER_PREF_KEY + ProjectName, homeLabel, HOME_FOLDER_DEFAULT);
            HomeFolder = HOME_FOLDER_PREF.Value;

            GUIContent modifierLabel = new("Modifier Key", MOD_KEY_HINT);
            MODIFIER_KEY_PREF = new EditorPrefsModifierKey(MOD_KEY_PREF_KEY + ProjectName, modifierLabel, MOD_KEY_DEFAULT);
            ModifierKey = MODIFIER_KEY_PREF.Value;

            GUIContent hierarchyTreeLabel = new("Project Tree", PROJECT_TREE_HINT);
            PROJECT_TREE_PREF = new EditorPrefsBooleanRepaint(PROJECT_TREE_PREF_KEY + ProjectName, hierarchyTreeLabel, PROJECT_TREE_DEFAULT);
            ShowProjectTree = PROJECT_TREE_PREF.Value;

            GUIContent rowShadingLabel = new("Row Shading", ROW_SHADING_HINT);
            ROW_SHADING_PREF = new EditorPrefsBooleanRepaint(ROW_SHADING_PREF_KEY + ProjectName, rowShadingLabel, ROW_SHADING_DEFAULT);
            DrawRowShading = ROW_SHADING_PREF.Value;
        }

        #endregion ProjectPreferences Constructor

        #region Public Methods

        [SettingsProvider]
        [SuppressMessage("ReSharper", "UnusedMember.Global")]
        public static SettingsProvider CreateSettingProvider()
        {
            return new SettingsProvider("Borodar/RainbowFolders", SettingsScope.Project)
            {
                label = AssetInfo.NAME,
                guiHandler = (_) =>
                {
                    EditorGUILayout.LabelField("General", EditorStyles.boldLabel);
                    EditorGUILayout.Separator();

                    HOME_FOLDER_PREF.Draw();
                    HomeFolder = HOME_FOLDER_PREF.Value;
                    TinySeparator();

                    MODIFIER_KEY_PREF.Draw();
                    ModifierKey = MODIFIER_KEY_PREF.Value;

                    EditorGUILayout.Separator();
                    EditorGUILayout.LabelField("Enhancements", EditorStyles.boldLabel);
                    EditorGUILayout.Separator();

                    PROJECT_TREE_PREF.Draw();
                    ShowProjectTree = PROJECT_TREE_PREF.Value;
                    TinySeparator();

                    ROW_SHADING_PREF.Draw();
                    DrawRowShading = ROW_SHADING_PREF.Value;

                    GUILayout.FlexibleSpace();
                    EditorGUILayout.LabelField("Version " + AssetInfo.VERSION, EditorStyles.centeredGreyMiniLabel);
                },
            };
        }

        #endregion Public Methods

        #region Private Methods

        private static string ProjectName
        {
            get
            {
                string[] s = Application.dataPath.Split('/');
                return s[^2];
            }
        }

        private static void TinySeparator()
        {
            GUILayoutUtility.GetRect(0f, 0f);
        }

        #region Private  Methods - Nasted

        private abstract class EditorPrefsItem<T>
        {
            protected readonly string Key;
            protected readonly GUIContent Label;
            protected readonly T DefaultValue;

            protected EditorPrefsItem(string key, GUIContent label, T defaultValue)
            {
                if (string.IsNullOrEmpty(key))
                {
                    throw new ArgumentNullException(nameof(key));
                }

                Key = key;
                Label = label;
                DefaultValue = defaultValue;
            }

            public abstract T Value { get; set; }
            public abstract void Draw();

            public static implicit operator T(EditorPrefsItem<T> s)
            {
                return s.Value;
            }
        }

        private class EditorPrefsString : EditorPrefsItem<string>
        {
            public EditorPrefsString(string key, GUIContent label, string defaultValue)
                : base(key, label, defaultValue) { }

            public override string Value
            {
                get => EditorPrefs.GetString(Key, DefaultValue);
                set => EditorPrefs.SetString(Key, value);
            }

            public override void Draw()
            {
                EditorGUIUtility.labelWidth = 100f;
                Value = EditorGUILayout.TextField(Label, Value);
            }
        }

        private class EditorPrefsModifierKey : EditorPrefsItem<EventModifiers>
        {
            public EditorPrefsModifierKey(string key, GUIContent label, EventModifiers defaultValue)
                : base(key, label, defaultValue) { }

            public override EventModifiers Value
            {
                get
                {
                    int index = EditorPrefs.GetInt(Key, (int)DefaultValue);
                    return Enum.IsDefined(typeof(EventModifiers), index) ? (EventModifiers)index : DefaultValue;
                }
                set => EditorPrefs.SetInt(Key, (int)value);
            }

            public override void Draw()
            {
                Value = (EventModifiers)EditorGUILayout.EnumPopup(Label, Value);
            }
        }

        private class EditorPrefsBoolean : EditorPrefsItem<bool>
        {
            protected EditorPrefsBoolean(string key, GUIContent label, bool defaultValue)
                : base(key, label, defaultValue) { }

            public override bool Value
            {
                get => EditorPrefs.GetBool(Key, DefaultValue);
                set
                {
                    bool isChanged = Value != value;
                    EditorPrefs.SetBool(Key, value);
                    if (isChanged)
                    {
                        OnChange(value);
                    }
                }
            }

            public override void Draw()
            {
                EditorGUIUtility.labelWidth = PREF_LABEL_WIDTH;
                Value = EditorGUILayout.Toggle(Label, Value);
            }

            protected virtual void OnChange(bool value) { }
        }

        private class EditorPrefsBooleanRepaint : EditorPrefsBoolean
        {
            public EditorPrefsBooleanRepaint(string key, GUIContent label, bool defaultValue)
                : base(key, label, defaultValue) { }

            protected override void OnChange(bool value)
            {
                EditorApplication.RepaintProjectWindow();
            }
        }

        #endregion Private  Methods - Nasted

        #endregion Private Methods
    }
}