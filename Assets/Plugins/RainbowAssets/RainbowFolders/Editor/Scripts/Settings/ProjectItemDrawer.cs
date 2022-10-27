using System;
using Borodar.RainbowCore;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Settings
{
    [CustomPropertyDrawer(typeof(ProjectItem))]
    public class ProjectItemDrawer : PropertyDrawer
    {
        #region Fields - Constant
        private const float PADDING = 8f;
        private const float SPACING = 1f;
        private const float LINE_HEIGHT = 16f;
        private const float LABELS_WIDTH = 100f;
        private const float PREVIEW_SIZE_SMALL = 16f;
        private const float PREVIEW_SIZE_LARGE = 64f;
        private const float PROPERTY_HEIGHT = 104;
        #endregion Fields - Constant

        #region Public Methods

        public override void OnGUI(Rect position, SerializedProperty property, GUIContent label)
        {
            Rect originalPosition = position;
            SerializedItemWrapper serializedItem = new SerializedItemWrapper(property);

            DrawLabels(ref position, serializedItem);
            DrawValues(ref position, originalPosition, serializedItem);
            DrawPreview(ref position, originalPosition, serializedItem);
        }

        public override float GetPropertyHeight(SerializedProperty property, GUIContent label)
        {
            SerializedProperty iconType = property.FindPropertyRelative("IconType");
            SerializedProperty backgroundType = property.FindPropertyRelative("BackgroundType");
            bool hasCustomIcon = iconType.intValue == (int)ProjectIcon.Custom;
            bool hasCustomBackground = backgroundType.intValue == (int)CoreBackground.Custom;

            float height = PROPERTY_HEIGHT;
            if (hasCustomIcon)
            {
                height += LINE_HEIGHT * 2f;
            }

            if (hasCustomBackground)
            {
                height += LINE_HEIGHT;
            }

            return height;
        }

        #endregion Public Methods

        #region Private Methods

        private static void DrawLabels(ref Rect position, SerializedItemWrapper item)
        {
            position.y += PADDING;
            position.width = LABELS_WIDTH - PADDING;
            position.height = LINE_HEIGHT;

            KeyType typeSelected = (KeyType)Enum.GetValues(typeof(KeyType)).GetValue(item.FolderKeyType.enumValueIndex);
            item.FolderKeyType.enumValueIndex = (int)(KeyType)EditorGUI.EnumPopup(position, typeSelected);

            position.y += LINE_HEIGHT + (SPACING * 4f);
            EditorGUI.LabelField(position, "Icon");

            if (item.HasCustomIcon)
            {
                position.y += LINE_HEIGHT + SPACING;
                EditorGUI.LabelField(position, "x16");

                position.y += LINE_HEIGHT + SPACING;
                EditorGUI.LabelField(position, "x64");
            }

            position.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(position, "Recursive");

            position.y += LINE_HEIGHT + (SPACING * 4f);
            EditorGUI.LabelField(position, "Background");

            if (item.HasCustomBackground)
            {
                position.y += LINE_HEIGHT + SPACING;
                EditorGUI.LabelField(position, "x16");
            }

            position.y += LINE_HEIGHT + SPACING;
            EditorGUI.LabelField(position, "Recursive");
        }

        private static void DrawValues(ref Rect position, Rect originalPosition, SerializedItemWrapper item)
        {
            position.x += LABELS_WIDTH;
            position.y = originalPosition.y + PADDING;
            position.width = originalPosition.width - LABELS_WIDTH;
            EditorGUI.PropertyField(position, item.FolderKey, GUIContent.none);

            position.width = originalPosition.width - LABELS_WIDTH - PREVIEW_SIZE_LARGE - PADDING;

            position.y += LINE_HEIGHT + (SPACING * 4f);
            DrawIconPopupMenu(position, item.Property, item.HasCustomIcon, item.IconType.intValue);

            if (item.HasCustomIcon)
            {
                position.y += LINE_HEIGHT + SPACING + (EditorGUIUtility.isProSkin ? SPACING : 0f);
                EditorGUI.PropertyField(position, item.SmallIcon, GUIContent.none);

                position.y += LINE_HEIGHT + SPACING;
                EditorGUI.PropertyField(position, item.LargeIcon, GUIContent.none);
            }

            position.y += LINE_HEIGHT + (EditorGUIUtility.isProSkin ? 0f : SPACING);
            EditorGUI.PropertyField(position, item.IconRecursive, GUIContent.none);

            position.y += LINE_HEIGHT + (SPACING * 4f);
            DrawBackgroundPopupMenu(position, item.Property, item.HasCustomBackground, item.BackgroundType.intValue);

            if (item.HasCustomBackground)
            {
                position.y += LINE_HEIGHT + SPACING;
                EditorGUI.PropertyField(position, item.Background, GUIContent.none);
            }

            position.y += LINE_HEIGHT + (EditorGUIUtility.isProSkin ? 0f : SPACING);
            EditorGUI.PropertyField(position, item.BackgroundRecursive, GUIContent.none);
        }

        private static void DrawPreview(ref Rect position, Rect originalPosition, SerializedItemWrapper item)
        {
            Texture2D smallTexture = null;
            Texture2D largeTexture = null;

            if (item.HasIcon)
            {
                if (item.HasCustomIcon)
                {
                    smallTexture = (Texture2D)item.SmallIcon.objectReferenceValue;
                    largeTexture = (Texture2D)item.LargeIcon.objectReferenceValue;
                }
                else
                {
                    RainbowCore.Tuple<Texture2D, Texture2D> tuple = ProjectIconsStorage.GetIcons(item.IconType.intValue);
                    if (tuple != null)
                    {
                        largeTexture = tuple.Item1;
                        smallTexture = tuple.Item2;
                    }
                }
            }

            if (smallTexture == null)
            {
                smallTexture = ProjectEditorUtility.GetDefaultFolderIcon();
            }

            if (largeTexture == null)
            {
                largeTexture = ProjectEditorUtility.GetDefaultFolderIcon();
            }

            // Draw large texture
            position.x += position.width + PADDING;
            position.y = originalPosition.y + LINE_HEIGHT + SPACING + 4f;
            position.width = position.height = PREVIEW_SIZE_LARGE;
            GUI.DrawTexture(position, largeTexture);

            // Draw small texture
            position.y += PREVIEW_SIZE_LARGE - PREVIEW_SIZE_SMALL - 4f;
            position.width = position.height = PREVIEW_SIZE_SMALL;
            GUI.DrawTexture(position, smallTexture);

            // Draw background
            position.y += LINE_HEIGHT + (SPACING * 4f);
            position.width = PREVIEW_SIZE_LARGE;

            if (item.HasBackground)
            {
                Texture2D backgroundRef = item.HasCustomBackground
                    ? (Texture2D)item.Background.objectReferenceValue
                    : CoreBackgroundsStorage.GetBackground(item.BackgroundType.intValue);

                if (backgroundRef != null)
                {
                    GUI.DrawTexture(position, backgroundRef);
                }
            }

            position.x += 13f;
            EditorGUI.LabelField(position, "Folder");
        }

        private static void DrawIconPopupMenu(Rect rect, SerializedProperty property, bool hasCustomIcon, int iconType)
        {
            string menuName = hasCustomIcon ? "Custom" : ((ProjectIcon)iconType).ToString();
            if (GUI.Button(rect, new GUIContent(menuName), "MiniPopup"))
            {
                RainbowFoldersIconsMenu.ShowDropDown(rect, property);
            }
        }

        private static void DrawBackgroundPopupMenu(Rect rect, SerializedProperty property, bool hasCustomBackground, int backgroundType)
        {
            string menuName = hasCustomBackground ? "Custom" : ((CoreBackground)backgroundType).ToString();
            if (GUI.Button(rect, new GUIContent(menuName), "MiniPopup"))
            {
                RainbowFoldersBackgroundsMenu.ShowDropDown(rect, property);
            }
        }

        #endregion Private Methods
    }
}