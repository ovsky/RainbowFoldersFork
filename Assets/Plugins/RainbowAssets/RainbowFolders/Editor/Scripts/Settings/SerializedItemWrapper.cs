using Borodar.RainbowCore;
using UnityEditor;

namespace Borodar.RainbowFolders.Settings
{
    public class SerializedItemWrapper
    {
        #region Fields

        public readonly SerializedProperty Property;

        public readonly SerializedProperty FolderKey;
        public readonly SerializedProperty FolderKeyType;

        public readonly SerializedProperty IconType;
        public readonly SerializedProperty SmallIcon;
        public readonly SerializedProperty LargeIcon;
        public readonly SerializedProperty IconRecursive;

        public readonly SerializedProperty BackgroundType;
        public readonly SerializedProperty Background;
        public readonly SerializedProperty BackgroundRecursive;

        public readonly bool HasIcon;
        public readonly bool HasCustomIcon;
        public readonly bool HasBackground;
        public readonly bool HasCustomBackground;

        #endregion Fields

        #region Constructor

        public SerializedItemWrapper(SerializedProperty property)
        {
            Property = property;

            FolderKey = property.FindPropertyRelative("Key");
            FolderKeyType = property.FindPropertyRelative("Type");

            IconType = property.FindPropertyRelative("IconType");
            SmallIcon = property.FindPropertyRelative("SmallIcon");
            LargeIcon = property.FindPropertyRelative("LargeIcon");
            IconRecursive = property.FindPropertyRelative("IsIconRecursive");

            BackgroundType = property.FindPropertyRelative("BackgroundType");
            Background = property.FindPropertyRelative("BackgroundTexture");
            BackgroundRecursive = property.FindPropertyRelative("IsBackgroundRecursive");

            HasIcon = IconType.intValue != (int)ProjectIcon.None;
            HasCustomIcon = IconType.intValue == (int)ProjectIcon.Custom;
            HasBackground = BackgroundType.intValue != (int)CoreBackground.None;
            HasCustomBackground = BackgroundType.intValue == (int)CoreBackground.Custom;
        }

        #endregion Constructor
    }
}