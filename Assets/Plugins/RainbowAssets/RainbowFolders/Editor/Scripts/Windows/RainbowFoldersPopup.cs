using System.Collections.Generic;
using System.IO;
using Borodar.RainbowCore;
using Borodar.RainbowFolders.Settings;
using UnityEditor;
using UnityEngine;
using KeyType = Borodar.RainbowFolders.Settings.KeyType;

namespace Borodar.RainbowFolders
{
    public class RainbowFoldersPopup : CoreDraggablePopupWindow
    {
        #region  Fields

        private const float PADDING = 8f;
        private const float SPACING = 1f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 85f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;
        private const float BUTTON_WIDTH = 55f;
        private const float BUTTON_WIDTH_SMALL = 16f;

        private const float WINDOW_WIDTH = 325f;
        private const float WINDOW_HEIGHT = 140f;

        private static readonly Vector2 WINDOW_SIZE = new Vector2(WINDOW_WIDTH, WINDOW_HEIGHT);

        private static Rect _windowRect;
        private static Rect _backgroundRect;

        private List<string> _paths;
        private RainbowFoldersSettings _settings;
        private ProjectItem[] _existingItems;
        private ProjectItem _currentItem;

        #endregion  Fields

        #region Public Methods

        public static RainbowFoldersPopup GetDraggableWindow()
        {
            return GetDraggableWindow<RainbowFoldersPopup>();
        }

        public void ShowWithParams(Vector2 inPosition, List<string> paths, int pathIndex)
        {
            _paths = paths;
            _settings = RainbowFoldersSettings.Instance;

            int size = paths.Count;
            _existingItems = new ProjectItem[size];
            _currentItem = new ProjectItem(KeyType.Path, paths[pathIndex]);

            for (int i = 0; i < size; i++)
            {
                _existingItems[i] = _settings.GetFolderByPath(paths[i]);
            }

            if (_existingItems[pathIndex] != null)
            {
                _currentItem.CopyFrom(_existingItems[pathIndex]);
            }

            // Resize

            float customIconHeight = _currentItem.HasCustomIcon() ? LINE_HEIGHT * 2f : 0f;
            float customBackgroundHeight = _currentItem.HasCustomBackground() ? LINE_HEIGHT : 0f;

            Rect rect = new Rect(inPosition, WINDOW_SIZE)
            {
                height = WINDOW_HEIGHT + customIconHeight + customBackgroundHeight
            };

            _windowRect = new Rect(Vector2.zero, rect.size);
            _backgroundRect = new Rect(Vector2.one, rect.size - new Vector2(2f, 2f));

            Show<RainbowFoldersPopup>(rect);
        }

        #endregion Public Methods

        #region Unity Methods

        public override void OnGUI()
        {
            base.OnGUI();
            ChangeWindowSize(_currentItem.HasCustomIcon(), _currentItem.HasCustomBackground());
            Rect rect = _windowRect;

            // Background

            Color borderColor = EditorGUIUtility.isProSkin ? new Color(0.13f, 0.13f, 0.13f) : new Color(0.51f, 0.51f, 0.51f);
            EditorGUI.DrawRect(_windowRect, borderColor);

            Color backgroundColor = EditorGUIUtility.isProSkin ? new Color(0.18f, 0.18f, 0.18f) : new Color(0.83f, 0.83f, 0.83f);
            EditorGUI.DrawRect(_backgroundRect, backgroundColor);

            // Body

            DrawLabels(ref rect, _currentItem);
            DrawValues(ref rect, _currentItem, _paths);
            DrawPreview(ref rect, _currentItem);

            // Buttons

            rect.x = PADDING;
            rect.y = position.height - LINE_HEIGHT - (0.75f * PADDING);
            rect.width = BUTTON_WIDTH_SMALL;
            ButtonSettings(rect);

            rect.x += BUTTON_WIDTH_SMALL + (0.75f * PADDING);
            ButtonDefault(rect);

            rect.x = WINDOW_WIDTH - (2f * (BUTTON_WIDTH + PADDING));
            rect.width = BUTTON_WIDTH;
            ButtonCancel(rect);

            rect.x = WINDOW_WIDTH - BUTTON_WIDTH - PADDING;
            ButtonApply(rect);
        }

        #endregion Unity Methods

        #region Private Methods

        private static void DrawLabels(ref Rect rect, ProjectItem item)
        {
            rect.x += 0.5f * PADDING;
            rect.y += PADDING;
            rect.width = LABELS_WIDTH - PADDING;
            rect.height = LINE_HEIGHT;

            item.Type = (KeyType)EditorGUI.EnumPopup(rect, item.Type);

            rect.y += LINE_HEIGHT + 6f;
            EditorGUI.LabelField(rect, "Icon");

            if (item.HasCustomIcon())
            {
                rect.y += LINE_HEIGHT + 4f;
                EditorGUI.LabelField(rect, "x16", EditorStyles.miniLabel);
                rect.y += LINE_HEIGHT + 2f;
                EditorGUI.LabelField(rect, "x64", EditorStyles.miniLabel);
            }

            rect.y += LINE_HEIGHT + 2f;
            EditorGUI.LabelField(rect, "Recursive", EditorStyles.miniLabel);

            rect.y += LINE_HEIGHT + (SPACING * 6f);
            EditorGUI.LabelField(rect, "Background");

            if (item.HasCustomBackground())
            {
                rect.y += LINE_HEIGHT + 4f;
                EditorGUI.LabelField(rect, "x16", EditorStyles.miniLabel);
            }

            rect.y += LINE_HEIGHT + 2f;
            EditorGUI.LabelField(rect, "Recursive", EditorStyles.miniLabel);
        }

        private static void DrawValues(ref Rect rect, ProjectItem item, IList<string> paths)
        {
            rect.x += LABELS_WIDTH;
            rect.y = _windowRect.y + PADDING;
            rect.width = _windowRect.width - LABELS_WIDTH - PADDING;

            GUI.enabled = false;
            item.Key = paths.Count == 1 ? item.Type == KeyType.Path ? paths[0] : Path.GetFileName(paths[0]) : "---";

            EditorGUI.TextField(rect, GUIContent.none, item.Key);
            GUI.enabled = true;

            rect.width -= PREVIEW_SIZE_LARGE + PADDING;
            rect.y += LINE_HEIGHT + (SPACING * 4f) + SPACING;
            DrawIconPopupMenu(rect, item);

            if (item.HasCustomIcon())
            {
                rect.y += LINE_HEIGHT + 4f + SPACING;
                item.SmallIcon = (Texture2D)EditorGUI.ObjectField(rect, item.SmallIcon, typeof(Texture2D), false);

                rect.y += LINE_HEIGHT + SPACING;
                item.LargeIcon = (Texture2D)EditorGUI.ObjectField(rect, item.LargeIcon, typeof(Texture2D), false);
            }

            rect.y += LINE_HEIGHT + 2f;
            item.IsIconRecursive = EditorGUI.Toggle(rect, item.IsIconRecursive);

            rect.y += LINE_HEIGHT + (SPACING * 6f);
            DrawBackgroundPopupMenu(rect, item);

            if (item.HasCustomBackground())
            {
                rect.y += LINE_HEIGHT + 4f + SPACING;
                item.BackgroundTexture = (Texture2D)EditorGUI.ObjectField(rect, item.BackgroundTexture, typeof(Texture2D), false);
            }

            rect.y += LINE_HEIGHT + 2f;
            item.IsBackgroundRecursive = EditorGUI.Toggle(rect, item.IsBackgroundRecursive);
        }

        private static void DrawPreview(ref Rect rect, ProjectItem item)
        {
            rect.x += rect.width + PADDING;
            rect.y = _windowRect.y + LINE_HEIGHT + 4f;
            rect.width = rect.height = PREVIEW_SIZE_LARGE;

            // Large Icon

            Texture2D texture = item.HasLargeIcon()
                ? item.HasCustomIcon() ? item.LargeIcon : ProjectIconsStorage.GetIcons(item.IconType).Item1
                : ProjectEditorUtility.GetDefaultFolderIcon();
            GUI.DrawTexture(rect, texture);

            // Small Icon

            rect.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - 4f;
            rect.width = rect.height = PREVIEW_SIZE_SMALL;

            texture = item.HasSmallIcon()
                ? item.HasCustomIcon() ? item.SmallIcon : ProjectIconsStorage.GetIcons(item.IconType).Item2
                : ProjectEditorUtility.GetDefaultFolderIcon();

            GUI.DrawTexture(rect, texture);

            // Background

            rect.y += LINE_HEIGHT + (SPACING * 3f);
            rect.width = PREVIEW_SIZE_LARGE;

            if (item.HasBackground())
            {
                texture = item.HasCustomBackground()
                    ? item.BackgroundTexture
                    : CoreBackgroundsStorage.GetBackground(item.BackgroundType);

                GUI.DrawTexture(rect, texture);
            }

            rect.x += 13f;
            EditorGUI.LabelField(rect, "Folder");
        }

        private void ChangeWindowSize(bool hasCustomIcon, bool hasCustomBackground)
        {
            Rect rect = position;
            float customIconHeight = hasCustomIcon ? (LINE_HEIGHT * 2f) + 6f : 0f;
            float customBackgroundHeight = hasCustomBackground ? LINE_HEIGHT + 4f : 0f;

            float resizeHeight = WINDOW_HEIGHT + customIconHeight + customBackgroundHeight;
            if (resizeHeight == rect.height)
            {
                return;
            }

            rect.height = resizeHeight;
            position = rect;

            _windowRect.height = rect.height;
            _backgroundRect.height = rect.height - 2f;
        }

        private static void DrawIconPopupMenu(Rect rect, ProjectItem item)
        {
            string menuName = item.IconType.ToString();
            if (GUI.Button(rect, new GUIContent(menuName), "popup"))
            {
                RainbowFoldersIconsMenu.ShowDropDown(rect, item);
            }
        }

        private static void DrawBackgroundPopupMenu(Rect rect, ProjectItem item)
        {
            string menuName = item.BackgroundType.ToString();
            if (GUI.Button(rect, new GUIContent(menuName), "popup"))
            {
                RainbowFoldersBackgroundsMenu.ShowDropDown(rect, item);
            }
        }

        private void ButtonSettings(Rect rect)
        {
            Texture2D icon = ProjectEditorUtility.GetSettingsButtonIcon();
            if (!GUI.Button(rect, new GUIContent(icon, "Settings"), GUIStyle.none))
            {
                return;
            }

            Selection.activeObject = _settings;
            Close();
        }

        private void ButtonDefault(Rect rect)
        {
            Texture2D icon = ProjectEditorUtility.GetDeleteButtonIcon();
            if (!GUI.Button(rect, new GUIContent(icon, "Revert to Default"), GUIStyle.none))
            {
                return;
            }

            _currentItem.IconType = ProjectIcon.None;
            _currentItem.SmallIcon = null;
            _currentItem.LargeIcon = null;
            _currentItem.IsIconRecursive = false;

            _currentItem.BackgroundType = CoreBackground.None;
            _currentItem.BackgroundTexture = null;
            _currentItem.IsBackgroundRecursive = false;
        }

        private void ButtonCancel(Rect rect)
        {
            if (!GUI.Button(rect, "Cancel"))
            {
                return;
            }

            Close();
        }

        private void ButtonApply(Rect rect)
        {
            if (!GUI.Button(rect, "Apply"))
            {
                return;
            }

            for (int i = 0; i < _existingItems.Length; i++)
            {
                _currentItem.Key = (_currentItem.Type == KeyType.Path)
                    ? _paths[i]
                    : Path.GetFileName(_paths[i]);

                _settings.UpdateFolder(_existingItems[i], _currentItem);
            }
            Close();
        }
        #endregion Private Methods
    }
}