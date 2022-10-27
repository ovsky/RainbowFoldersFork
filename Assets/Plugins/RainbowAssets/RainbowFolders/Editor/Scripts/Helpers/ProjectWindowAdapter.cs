using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Reflection;
using Borodar.RainbowCore;
using Borodar.RainbowFolders.Settings;
using UnityEditor;
using UnityEditor.IMGUI.Controls;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    public static class ProjectWindowAdapter
    {
        #region Fields

        #region Fields - Constant

        private const string EDITOR_WINDOW_TYPE = "UnityEditor.ProjectBrowser";

        private const BindingFlags STATIC_PRIVATE = BindingFlags.Static | BindingFlags.NonPublic;
        private const BindingFlags INSTANCE_PRIVATE = BindingFlags.Instance | BindingFlags.NonPublic;
        private const BindingFlags INSTANCE_PUBLIC = BindingFlags.Instance | BindingFlags.Public;

        #endregion Fields - Constant

        #region Fields - Static

        #region Asset Database - Fields

        private static readonly MethodInfo INSTANCE_ID_BY_PATH_METHOD;

        #endregion Asset Database - Fields

        #region First Column - Fields

        private static readonly FieldInfo PROJECT_FOLDER_TREE_FIELD;
        private static readonly FieldInfo PROJECT_ASSET_TREE_FIELD;
        private static readonly PropertyInfo TREE_VIEW_DATA_PROPERTY;
        private static readonly MethodInfo TWO_COLUMN_ITEMS_METHOD;
        private static readonly MethodInfo ONE_COLUMN_ITEMS_METHOD;

        #endregion First Column - Fields

        #region Second Column - Fields

        private static readonly FieldInfo PROJECT_OBJECT_LIST_FIELD;
        private static readonly FieldInfo PROJECT_LOCAL_ASSETS_FIELD;
        private static readonly PropertyInfo ASSETS_LIST_MODE_PROPERTY;
        private static readonly FieldInfo LIST_FILTERED_HIERARCHY_FIELD;
        private static readonly PropertyInfo FILTERED_HIERARCHY_RESULTS_METHOD;

        #endregion Second Column - Fields

        #region Filter Results - Fields

        private static readonly FieldInfo FILTER_RESULT_ID_FIELD;
        private static readonly PropertyInfo FILTER_RESULT_ICON_PROPERTY;

        private static readonly object[] ASSET_PATH_PARAM = new object[1]; // prevent allocation

        #endregion Filter Results - Fields

        #endregion Fields - Static

        #endregion Fields

        #region Project Window Adapter Constructor

        static ProjectWindowAdapter()
        {
            Assembly assembly = Assembly.GetAssembly(typeof(EditorWindow));

            System.Type assetDatabaseType = assembly.GetType("UnityEditor.AssetDatabase");
            INSTANCE_ID_BY_PATH_METHOD = assetDatabaseType.GetMethod("GetMainAssetInstanceID", STATIC_PRIVATE);

            #region First Column - Properties

            System.Type projectWindowType = assembly.GetType(EDITOR_WINDOW_TYPE);
            PROJECT_FOLDER_TREE_FIELD = projectWindowType.GetField("m_AssetTree", INSTANCE_PRIVATE);
            PROJECT_ASSET_TREE_FIELD = projectWindowType.GetField("m_FolderTree", INSTANCE_PRIVATE);

            System.Type treeViewType = assembly.GetType("UnityEditor.IMGUI.Controls.TreeViewController");
            TREE_VIEW_DATA_PROPERTY = treeViewType.GetProperty("data", INSTANCE_PUBLIC);

            System.Type oneColumnTreeViewDataType = assembly.GetType("UnityEditor.ProjectBrowserColumnOneTreeViewDataSource");
            TWO_COLUMN_ITEMS_METHOD = oneColumnTreeViewDataType.GetMethod("GetRows", INSTANCE_PUBLIC);

            System.Type twoColumnTreeViewDataType = assembly.GetType("UnityEditor.AssetsTreeViewDataSource");
            ONE_COLUMN_ITEMS_METHOD = twoColumnTreeViewDataType.GetMethod("GetRows", INSTANCE_PUBLIC);

            #endregion First Column - Properties

            #region Second Column - Properties

            PROJECT_OBJECT_LIST_FIELD = projectWindowType.GetField("m_ListArea", INSTANCE_PRIVATE);

            System.Type objectListType = assembly.GetType("UnityEditor.ObjectListArea");
            PROJECT_LOCAL_ASSETS_FIELD = objectListType.GetField("m_LocalAssets", INSTANCE_PRIVATE);

            System.Type localGroupType = objectListType.GetNestedType("LocalGroup", INSTANCE_PRIVATE);
            ASSETS_LIST_MODE_PROPERTY = localGroupType.GetProperty("ListMode", INSTANCE_PUBLIC);
            LIST_FILTERED_HIERARCHY_FIELD = localGroupType.GetField("m_FilteredHierarchy", INSTANCE_PRIVATE);

            System.Type filteredHierarchyType = assembly.GetType("UnityEditor.FilteredHierarchy");
            FILTERED_HIERARCHY_RESULTS_METHOD = filteredHierarchyType.GetProperty("results", INSTANCE_PUBLIC);

            #endregion Second Column - Properties

            #region Filter Result - Properties

            System.Type filterResultType = filteredHierarchyType.GetNestedType("FilterResult");
            FILTER_RESULT_ID_FIELD = filterResultType.GetField("instanceID", INSTANCE_PUBLIC);
            FILTER_RESULT_ICON_PROPERTY = filterResultType.GetProperty("icon", INSTANCE_PUBLIC);

            #endregion Filter Result - Properties

            RainbowFoldersSettings.OnSettingsChangeCallback += ApplyDefaultIconsToAll;
        }

        #endregion Project Window Adapter Constructor

        #region Public Methods

        public static EditorWindow GetFirstProjectWindow()
        {
            return CoreEditorUtility.GetWindowByType(EDITOR_WINDOW_TYPE);
        }

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static IEnumerable<EditorWindow> GetAllProjectWindows()
        {
            return CoreEditorUtility.GetAllWindowsByType(EDITOR_WINDOW_TYPE);
        }

        public static int GetMainAssetInstanceId(string assetPath)
        {
            ASSET_PATH_PARAM[0] = assetPath;
            return (int)INSTANCE_ID_BY_PATH_METHOD.Invoke(null, ASSET_PATH_PARAM);
        }

        public static void ApplyIconByPath(int assetId, Texture2D icon, bool isIconSmall)
        {
            foreach (EditorWindow window in GetAllProjectWindows())
            {
                #region First Column - Icons

                if (isIconSmall)
                {
                    IEnumerable<TreeViewItem> treeViewItems = GetFirstColumnItems(window);
                    if (treeViewItems == null)
                    {
                        continue;
                    }

                    TreeViewItem treeViewItem = treeViewItems.FirstOrDefault(item => item.id == assetId);
                    if (treeViewItem != null)
                    {
                        treeViewItem.icon = icon;
                    }
                }

                #endregion  First Column - Icons

                #region  Second Column - Icons

                IEnumerable<object> listItems = GetSecondColumnItems(window, isIconSmall);
                if (listItems == null)
                {
                    continue;
                }

                object listItem = listItems.FirstOrDefault(item =>
                {
                    int instanceId = (int)FILTER_RESULT_ID_FIELD.GetValue(item);
                    return instanceId == assetId;
                });

                if (listItem != null)
                {
                    SetIconForListItem(listItem, icon);
                }

                #endregion Second Column - Icons
            }
        }

        /// <summary>
        /// Check if TreeViewItem related to current path has children.
        /// Unfortunately, we cannot differentiate if one- or two-column layout is shown,
        /// so this method will return reliable results only for multiple project views with the same n-column layout
        /// </summary>
        /// <param name="assetId"></param>
        /// <returns>Returns [bool] if related TreeViewItem has children.</returns>
        [SuppressMessage("ReSharper", "LoopCanBeConvertedToQuery")]
        public static bool HasChildren(int assetId)
        {
            foreach (EditorWindow window in GetAllProjectWindows())
            {
                IEnumerable<TreeViewItem> treeViewItems = GetFirstColumnItems(window);
                if (treeViewItems == null)
                {
                    continue;
                }

                TreeViewItem treeViewItem = treeViewItems.FirstOrDefault(item => item.id == assetId);
                if (treeViewItem != null)
                {
                    return treeViewItem.hasChildren;
                }
            }

            return false;
        }

        #endregion Public Methods

        #region  Private Methods

        [SuppressMessage("ReSharper", "InvertIf")]
        private static IEnumerable<TreeViewItem> GetFirstColumnItems(EditorWindow window)
        {
            object oneColumnTree = PROJECT_FOLDER_TREE_FIELD.GetValue(window);
            if (oneColumnTree != null)
            {
                object treeViewData = TREE_VIEW_DATA_PROPERTY.GetValue(oneColumnTree, null);
                return (IEnumerable<TreeViewItem>)ONE_COLUMN_ITEMS_METHOD.Invoke(treeViewData, null);
            }

            object twoColumnTree = PROJECT_ASSET_TREE_FIELD.GetValue(window);
            if (twoColumnTree != null)
            {
                object treeViewData = TREE_VIEW_DATA_PROPERTY.GetValue(twoColumnTree, null);
                return (IEnumerable<TreeViewItem>)TWO_COLUMN_ITEMS_METHOD.Invoke(treeViewData, null);
            }

            return null;
        }

        private static IEnumerable<object> GetSecondColumnItems(EditorWindow window, bool onlyInListMode = false)
        {
            object assetsList = PROJECT_OBJECT_LIST_FIELD.GetValue(window);
            if (assetsList == null)
            {
                return null;
            }

            object localAssets = PROJECT_LOCAL_ASSETS_FIELD.GetValue(assetsList);
            if (onlyInListMode && !InListMode(localAssets))
            {
                return null;
            }

            object filteredHierarchy = LIST_FILTERED_HIERARCHY_FIELD.GetValue(localAssets);
            object results = FILTERED_HIERARCHY_RESULTS_METHOD.GetValue(filteredHierarchy, null);

            return (IEnumerable<object>)results;
        }

        private static void ApplyDefaultIconsToAll()
        {
            foreach (EditorWindow window in GetAllProjectWindows())
            {
                #region First Column - View

                IEnumerable<TreeViewItem> treeViewItems = GetFirstColumnItems(window);
                if (treeViewItems == null)
                {
                    continue;
                }

                foreach (TreeViewItem item in treeViewItems)
                {
                    item.icon = null;
                }

                #endregion First Column - View

                #region Second Column - View

                IEnumerable<object> listItems = GetSecondColumnItems(window);
                if (listItems == null)
                {
                    continue;
                }

                foreach (object item in listItems)
                {
                    SetIconForListItem(item, null);
                }

                #endregion Second Column - View

                window.Repaint();
            }
        }

        private static bool InListMode(object localAssets)
        {
            return (bool)ASSETS_LIST_MODE_PROPERTY.GetValue(localAssets, null);
        }

        private static void SetIconForListItem(object listItem, Texture2D icon)
        {
            FILTER_RESULT_ICON_PROPERTY.SetValue(listItem, icon, null);
        }

        #endregion Private Methods

    }
}