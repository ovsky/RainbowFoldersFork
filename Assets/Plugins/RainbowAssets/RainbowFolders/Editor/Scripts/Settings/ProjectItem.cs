using System;
using Borodar.RainbowCore;
using UnityEngine;

namespace Borodar.RainbowFolders.Settings
{
    [Serializable]
    public class ProjectItem
    {
        #region Fields

        public KeyType Type;
        public string Key;

        public ProjectIcon IconType;
        public Texture2D SmallIcon;
        public Texture2D LargeIcon;
        public bool IsIconRecursive;

        public CoreBackground BackgroundType;
        public Texture2D BackgroundTexture;
        public bool IsBackgroundRecursive;

        #endregion Fields

        #region Project Item Constructor

        public ProjectItem(ProjectItem value)
        {
            Type = value.Type;
            Key = value.Key;

            IconType = value.IconType;
            SmallIcon = value.SmallIcon;
            LargeIcon = value.LargeIcon;
            IsIconRecursive = value.IsIconRecursive;

            BackgroundType = value.BackgroundType;
            BackgroundTexture = value.BackgroundTexture;
            IsBackgroundRecursive = value.IsBackgroundRecursive;
        }

        public ProjectItem(KeyType type, string key)
        {
            Type = type;
            Key = key;
        }

        public ProjectItem(KeyType type, string key, ProjectIcon iconType)
        {
            Type = type;
            Key = key;
            IconType = iconType;
            SmallIcon = null;
            LargeIcon = null;
        }

        public ProjectItem(KeyType type, string key, Texture2D smallIcon, Texture2D largeIcon)
        {
            Type = type;
            Key = key;
            IconType = ProjectIcon.Custom;
            SmallIcon = smallIcon;
            LargeIcon = largeIcon;
        }

        public ProjectItem(KeyType type, string key, CoreBackground background)
        {
            Type = type;
            Key = key;
            BackgroundType = background;
            BackgroundTexture = null;
        }

        public ProjectItem(KeyType type, string key, Texture2D background)
        {
            Type = type;
            Key = key;
            IconType = ProjectIcon.Custom;
            BackgroundTexture = background;
        }

        #endregion Project Item Constructor

        #region Public Methods

        public void CopyFrom(ProjectItem target)
        {
            Type = target.Type;
            Key = target.Key;

            IconType = target.IconType;
            SmallIcon = target.SmallIcon;
            LargeIcon = target.LargeIcon;
            IsIconRecursive = target.IsIconRecursive;

            BackgroundType = target.BackgroundType;
            BackgroundTexture = target.BackgroundTexture;
            IsBackgroundRecursive = target.IsBackgroundRecursive;
        }

        public bool HasIcon()
        {
            return IconType != ProjectIcon.None && (!HasCustomIcon() || SmallIcon != null || LargeIcon != null);
        }

        public bool HasSmallIcon()
        {
            return IconType != ProjectIcon.None && (!HasCustomIcon() || SmallIcon != null);
        }

        public bool HasLargeIcon()
        {
            return IconType != ProjectIcon.None && (!HasCustomIcon() || LargeIcon != null);
        }

        public bool HasCustomIcon()
        {
            return IconType == ProjectIcon.Custom;
        }

        public bool HasBackground()
        {
            return BackgroundType != CoreBackground.None && (!HasCustomBackground() || BackgroundTexture != null);
        }

        public bool HasCustomBackground()
        {
            return BackgroundType == CoreBackground.Custom;
        }

        public bool HasAtLeastOneTexture()
        {
            return HasIcon() || HasBackground();
        }

        public bool IsRecursive()
        {
            return IsIconRecursive || IsBackgroundRecursive;
        }

        #endregion Public Methods
    }
}