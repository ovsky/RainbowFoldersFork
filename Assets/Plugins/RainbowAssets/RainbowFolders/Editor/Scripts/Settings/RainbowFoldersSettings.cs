using System;
using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.IO;
using System.Linq;
using Borodar.RainbowCore;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders.Settings
{
    [HelpURL(AssetInfo.HELP_URL)]
    public class RainbowFoldersSettings : ScriptableObject
    {
        #region Fields

        private const string RELATIVE_PATH = "Editor/Data/RainbowFoldersSettings.asset";
        private const string DEVEL_PATH = "Assets/Devel/Editor/Data/RainbowFoldersSettings.asset";

        public static Action OnSettingsChangeCallback;
        public List<ProjectItem> Folders;
        private static RainbowFoldersSettings _instance;
       
        #endregion Fields

        #region Instance 

        [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
        public static RainbowFoldersSettings Instance
        {
            get
            {
                if (_instance == null)
                #if RAINBOW_FOLDERS_DEVEL
                    _instance = AssetDatabase.LoadAssetAtPath<RainbowFoldersSettings>(DEVEL_PATH);
                #else
                    _instance = ProjectEditorUtility.LoadFromAsset<RainbowFoldersSettings>(RELATIVE_PATH);
                  #endif

                return _instance;
            }
        }
        #endregion Instance 

        #region Public Methods 

        /// <summary>
        /// Searches for a folder config that has the same type and key values.
        /// Returns the first occurrence within the settings, if found; null otherwise.
        /// </summary>
        /// <param name="match"></param>
        public ProjectItem GetFolder(ProjectItem match)
        {
            return IsNullOrEmpty(Folders) || match == null ? null : Folders.Find(x => x.Type == match.Type && x.Key == match.Key);
        }

        /// <summary>
        /// Searches for a folder config that should be applied for the specified path (regardless of
        /// the key type). Returns the last occurrence within the settings, if found; null otherwise.
        /// </summary>
        /// <param name="folderPath"></param>
        /// <param name="allowRecursive"></param>
        /// <exception cref="ArgumentOutOfRangeException"></exception>
        public ProjectItem GetFolderByPath(string folderPath, bool allowRecursive = false)
        {
            if (IsNullOrEmpty(Folders))
            {
                return null;
            }

            for (int index = Folders.Count - 1; index >= 0; index--)
            {
                ProjectItem folder = Folders[index];
                switch (folder.Type)
                {
                    case KeyType.Name:
                        string folderName = Path.GetFileName(folderPath);
                        if (allowRecursive && folder.IsRecursive())
                        {
                            // Root
                            if (folder.Key.Equals(folderName))
                            {
                                return folder;
                            }

                            // Children
                            if (folderPath.Contains(string.Format("/{0}/", folder.Key)))
                            {
                                return CopyRecursiveItem(folder);
                            }
                        }
                        else if (folder.Key.Equals(folderName))
                        {
                            return folder;
                        }
                        break;

                    case KeyType.Path:
                        if (allowRecursive && folder.IsRecursive())
                        {
                            // Root
                            if (folder.Key.Equals(folderPath))
                            {
                                return folder;
                            }

                            // Children
                            if (folderPath.StartsWith(folder.Key + "/"))
                            {
                                return CopyRecursiveItem(folder);
                            }
                        }
                        else if (folder.Key.Equals(folderPath))
                        {
                            return folder;
                        }
                        break;

                    default:
                        throw new ArgumentOutOfRangeException();
                }
            }

            return null;
        }

        /// <summary>
        /// Searches for a folder config that has the same type and key, and updates
        /// its other fields with provided value, if found; creates new folder config otherwise.
        /// </summary>
        /// <param name="match"></param>
        /// <param name="value"></param>
        public void UpdateFolder(ProjectItem match, ProjectItem value)
        {
            Undo.RecordObject(this, "Modify Rainbow Folder Settings");

            ProjectItem existingFolder = GetFolder(match);
            if (existingFolder != null)
            {
                if (value.HasAtLeastOneTexture())
                {
                    existingFolder.CopyFrom(value);
                    SaveSetting();
                }
                else
                {
                    RemoveAll(match);
                }
            }
            else if (value.HasAtLeastOneTexture())
            {
                AddFolder(value);
            }
        }

        public void AddFolder(ProjectItem value)
        {
            Folders.Add(new ProjectItem(value));
            SaveSetting();
        }

        public void RemoveAll(ProjectItem match)
        {
            if (match == null)
            {
                return;
            }

            Undo.RecordObject(this, "Modify Rainbow Folder Settings");
            Folders.RemoveAll(x => x.Type == match.Type && x.Key == match.Key);
            SaveSetting();
        }

        public void RemoveAllByPath(string path)
        {
            ProjectItem match = GetFolderByPath(path);
            RemoveAll(match);
        }

        public void ChangeFolderIcons(ProjectItem value)
        {
            Undo.RecordObject(this, "Modify Rainbow Folder Settings");

            ProjectItem folder = Folders.SingleOrDefault(x => x.Type == value.Type && x.Key == value.Key);
            if (folder == null)
            {
                AddFolder(new ProjectItem(value));
            }
            else
            {
                folder.IconType = value.IconType;
                folder.SmallIcon = value.SmallIcon;
                folder.LargeIcon = value.LargeIcon;
                SaveSetting();
            }
        }

        public void ChangeFolderBackground(ProjectItem value)
        {
            Undo.RecordObject(this, "Modify Rainbow Folder Settings");

            ProjectItem folder = Folders.SingleOrDefault(x => x.Type == value.Type && x.Key == value.Key);
            if (folder == null)
            {
                AddFolder(new ProjectItem(value));
            }
            else
            {
                folder.BackgroundType = value.BackgroundType;
                folder.BackgroundTexture = value.BackgroundTexture;
                SaveSetting();
            }
        }

        public void ChangeFolderIconsByPath(string path, ProjectIcon icon)
        {
            ChangeFolderIcons(new ProjectItem(KeyType.Path, path, icon));
        }

        public void ChangeFolderBackgroundByPath(string path, CoreBackground background)
        {
            ChangeFolderBackground(new ProjectItem(KeyType.Path, path, background));
        }

        #endregion Public Methods 

        #region Private Methods 

        private static ProjectItem CopyRecursiveItem(ProjectItem item)
        {
            ProjectItem itemCopy = new ProjectItem(item);

            if (!item.IsIconRecursive)
            {
                itemCopy.IconType = ProjectIcon.None;
            }

            if (!item.IsBackgroundRecursive)
            {
                itemCopy.BackgroundType = CoreBackground.None;
            }

            return itemCopy;
        }

        private static bool IsNullOrEmpty(ICollection collection)
        {
            return collection == null || (collection.Count == 0);
        }

        private void SaveSetting()
        {
            EditorUtility.SetDirty(this);
            OnSettingsChangeCallback();
        }

        #endregion Private Methods 

    }
}