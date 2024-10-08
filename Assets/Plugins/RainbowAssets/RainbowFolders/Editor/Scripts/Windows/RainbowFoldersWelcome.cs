﻿using Borodar.RainbowCore;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    public class RainbowFoldersWelcome : CoreDraggablePopupWindow
    {
        #region Fields

        public const string PREF_KEY = "RainbowFolders.IsWelcomeShown";

        private const float WINDOW_WIDTH = 325f;
        private const float WINDOW_HEIGHT = 250f;

        private static readonly Vector2 WINDOW_SIZE = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);
        private static readonly Rect WINDOW_RECT = new Rect(Vector2.zero, WINDOW_SIZE);
        private static readonly Rect BACKGROUND_RECT = new Rect(Vector2.one, WINDOW_SIZE - new Vector2(2f, 2f));

        #endregion Fields

        #region Public Methods

        public static void ShowWindow()
        {
            Rect position = new Rect(CalcWindowPosition(), WINDOW_SIZE);
            RainbowFoldersWelcome window = GetDraggableWindow<RainbowFoldersWelcome>();
            window.Show<RainbowFoldersWelcome>(position);
        }

        #endregion Public Methods

        #region Unity Methods

        public override void OnGUI()
        {
            base.OnGUI();

            // Background

            Color borderColor = EditorGUIUtility.isProSkin ? new Color(0.13f, 0.13f, 0.13f) : new Color(0.51f, 0.51f, 0.51f);
            EditorGUI.DrawRect(WINDOW_RECT, borderColor);

            Color backgroundColor = EditorGUIUtility.isProSkin ? new Color(0.18f, 0.18f, 0.18f) : new Color(0.83f, 0.83f, 0.83f);
            EditorGUI.DrawRect(BACKGROUND_RECT, backgroundColor);

            // Content

            GUILayout.BeginHorizontal();
            {
                GUI.skin.label.wordWrap = true;
                GUILayout.Label(new GUIContent(ProjectEditorUtility.GetAssetLogo()));

                GUILayout.BeginVertical();
                {
                    GUILayout.Label("Welcome!", EditorStyles.boldLabel);
                    GUILayout.Label("With \"Rainbow Folders\" you can set custom icon for any folder in Unity project browser.");
                }
                GUILayout.EndVertical();
            }
            GUILayout.EndHorizontal();

            GUILayout.Label("• Just hold the Alt key and click on any folder icon.");
            GUILayout.Label("• Configuration dialogue will appear, and you'll be able to assign icons the for the corresponding folder, your own ones or chose from dozens of presets.");
            GUILayout.Label("• To revert the folder icon to the default, just Alt-click on it, then press the red cross button in configuration dialogue and apply changes.");
            GUILayout.Label("• You can also edit multiple folders at once, just select them all and Alt-click at one of their icons.\n");

            GUILayout.BeginHorizontal();
            {
                GUILayout.FlexibleSpace();
                if (GUILayout.Button("More Info", GUILayout.Width(100f)))
                {
                    Application.OpenURL(AssetInfo.HELP_URL);
                }
                if (GUILayout.Button("Close", GUILayout.Width(100f)))
                {
                    Close();
                }

                GUILayout.FlexibleSpace();
            }
            GUILayout.EndHorizontal();
        }

        #endregion Unity Methods

        #region Private Methods

        private static Vector2 CalcWindowPosition()
        {
            return ProjectWindowAdapter.GetFirstProjectWindow().position.position + new Vector2(10f, 30f);
        }
        #endregion Private Methods
    }
}