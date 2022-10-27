using System.Collections.Generic;
using System.Linq;
using Borodar.RainbowCore;
using Borodar.RainbowFolders.Settings;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    [InitializeOnLoad]
    public class RainbowFoldersGUI
    {
        private const float SMALL_ICON_SIZE = 16f;
        private const float LARGE_ICON_SIZE = 64f;
        
        private static readonly Color ROW_SHADING_COLOR = new Color(0f, 0f, 0f, 0.03f);

        private static bool _multiSelection;

        //---------------------------------------------------------------------
        // Ctors
        //---------------------------------------------------------------------

        static RainbowFoldersGUI()
        {
            EditorApplication.projectWindowItemOnGUI += ProjectWindowItemOnGUI;
            EditorApplication.projectWindowItemOnGUI += DrawEditIcon;
            EditorApplication.projectWindowItemOnGUI += ShowWelcomeWindow;
        }

        //---------------------------------------------------------------------
        // Delegates
        //---------------------------------------------------------------------

        private static void ProjectWindowItemOnGUI(string guid, Rect rect)
        {
            var isSmall = IsIconSmall(rect);
            var path = AssetDatabase.GUIDToAssetPath(guid);
            var id = ProjectWindowAdapter.GetMainAssetInstanceId(path);

            if (isSmall)
            {
                DrawRowShading(rect);
                DrawFoldouts(rect, id);
            }
            
            ReplaceFolderIcons(rect, id, path, isSmall);
        }
        
        //---------------------------------------------------------------------
        // GUI
        //---------------------------------------------------------------------
        
        private static void DrawRowShading(Rect rect)
        {
            if (!ProjectPreferences.DrawRowShading) return;

            var isOdd = Mathf.FloorToInt(((rect.y - 4) / 16) % 2) != 0;
            if (isOdd) return;

            var drawArea = new Rect(rect);
            drawArea.width += rect.x + 16f;
            drawArea.height += 1f;
            drawArea.x = 0f;

            // Background
            EditorGUI.DrawRect(drawArea, ROW_SHADING_COLOR);
            // Top line
            drawArea.height = 1f;
            EditorGUI.DrawRect(drawArea, ROW_SHADING_COLOR);
            // Bottom line
            drawArea.y += 16f;
            EditorGUI.DrawRect(drawArea, ROW_SHADING_COLOR);
        }
        
        private static void DrawFoldouts(Rect rect, int id)
        {
            if (!ProjectPreferences.ShowProjectTree) return;

            var foldoutRect = new Rect(rect) {width = 128f};
            foldoutRect.x -= 128f + 16f;
            GUI.DrawTexture(foldoutRect, ProjectEditorUtility.GetFoldoutLevelsIcon());

            if (IsRootItem(rect) || ProjectWindowAdapter.HasChildren(id)) return;

            foldoutRect.width = 16f;
            foldoutRect.x = rect.x - 16f;
            GUI.DrawTexture(foldoutRect, ProjectEditorUtility.GetFoldoutIcon());
        }

        private static void ReplaceFolderIcons(Rect rect, int assetId, string path, bool isSmall)
        {
            if (!AssetDatabase.IsValidFolder(path)) return;

            var setting = RainbowFoldersSettings.Instance;
            if (setting == null) return;
            
            var folder = RainbowFoldersSettings.Instance.GetFolderByPath(path, true);
            if (folder == null) return;

            // Background
            DrawCustomBackground(rect, folder, isSmall);
            // Icon
            ReplaceIcon(assetId, folder, isSmall);            
        }

        private static void DrawEditIcon(string guid, Rect rect)
        {
            if ((Event.current.modifiers & ProjectPreferences.ModifierKey) == EventModifiers.None)
            {
                _multiSelection = false;
                return;
            }

            var isSmall = IsIconSmall(rect);
            var iconRect = GetIconRect(rect, isSmall);
            var isMouseOver = rect.Contains(Event.current.mousePosition);
            _multiSelection = (IsSelected(guid)) ? isMouseOver || _multiSelection : !isMouseOver && _multiSelection;

            // if mouse is not over current folder icon or selected group
            if (!isMouseOver && (!IsSelected(guid) || !_multiSelection)) return;

            var path = AssetDatabase.GUIDToAssetPath(guid);
            if (!AssetDatabase.IsValidFolder(path)) return;

            var editIcon = ProjectEditorUtility.GetEditFolderIcon(isSmall, EditorGUIUtility.isProSkin);
            DrawCustomIcon(iconRect, editIcon);

            if (GUI.Button(rect, GUIContent.none, GUIStyle.none))
            {
                ShowPopupWindow(iconRect, path);
            }

            EditorApplication.RepaintProjectWindow();
        }

        private static void ShowWelcomeWindow(string guid, Rect rect)
        {
            if (EditorPrefs.GetBool(RainbowFoldersWelcome.PREF_KEY))
            {
                // ReSharper disable once DelegateSubtraction
                EditorApplication.projectWindowItemOnGUI -= ShowWelcomeWindow;
                return;
            }

            RainbowFoldersWelcome.ShowWindow();
            EditorPrefs.SetBool(RainbowFoldersWelcome.PREF_KEY, true);

        }

        //---------------------------------------------------------------------
        // Helpers
        //---------------------------------------------------------------------

        private static void ShowPopupWindow(Rect rect, string path)
        {
            var window = RainbowFoldersPopup.GetDraggableWindow();
            var position = GUIUtility.GUIToScreenPoint(rect.position + new Vector2(0, rect.height + 2));

            if (_multiSelection)
            {
                // ReSharper disable once RedundantTypeArgumentsOfMethod
                var paths = Selection.assetGUIDs
                    .Select<string, string>(AssetDatabase.GUIDToAssetPath)
                    .Where(AssetDatabase.IsValidFolder).ToList();

                var index = paths.IndexOf(path);
                window.ShowWithParams(position, paths, index);
            }
            else
            {
                window.ShowWithParams(position, new List<string> {path}, 0);
            }
        }

        private static void DrawCustomIcon(Rect rect, Texture texture)
        {
            var iconRect = rect;
            if (iconRect.width > LARGE_ICON_SIZE)
            {
                // center the icon if it is zoomed
                var offset = (iconRect.width - LARGE_ICON_SIZE) / 2f;
                iconRect = new Rect(iconRect.x + offset, iconRect.y + offset, LARGE_ICON_SIZE, LARGE_ICON_SIZE);
            }
            
            GUI.DrawTexture(iconRect, texture);
        }

        private static void DrawCustomBackground(Rect rect, ProjectItem item, bool isSmall)
        {
            if (item == null || !item.HasBackground()) return;            
            var backgroundRect = GetBackgroundRect(rect, isSmall);
            var backgroundTex = (item.HasCustomBackground()) 
                    ? item.BackgroundTexture
                    
                    : CoreBackgroundsStorage.GetBackground(item.BackgroundType);
            GUI.DrawTexture(backgroundRect, backgroundTex);
        }

        private static void ReplaceIcon(int assetId, ProjectItem item, bool isSmall)
        {
            if (!item.HasIcon()) return;
            
            Texture2D iconTex = null;
            if (item.HasCustomIcon())
            {
                iconTex = isSmall ? item.SmallIcon : item.LargeIcon;
            }
            else
            {
                var icons = ProjectIconsStorage.GetIcons(item.IconType);
                if (icons != null)
                {
                    iconTex = isSmall ? icons.Item2 : icons.Item1;
                }
            }
            
            if (iconTex != null) ProjectWindowAdapter.ApplyIconByPath(assetId, iconTex, isSmall);
        }

        private static bool IsIconSmall(Rect rect)
        {
            return rect.width > rect.height;
        }

        private static Rect GetIconRect(Rect rect, bool isSmall)
        {
            if (isSmall)
                rect.width = rect.height;
            else
                rect.height = rect.width;

            return rect;
        }

        private static Rect GetBackgroundRect(Rect rect, bool isSmall)
        {
            if (isSmall)
            {
                rect.x += SMALL_ICON_SIZE + 1f;
                rect.width -= SMALL_ICON_SIZE + 1f;
            }
            else
            {
                rect.y += rect.width;
                rect.height -= rect.width;
            }

            return rect;
        }

        private static bool IsSelected(string guid)
        {
            return Selection.assetGUIDs.Contains(guid);
        }

        private static bool IsRootItem(Rect rect)
        {
            return rect.x <= 20f;
        }
    }
}
