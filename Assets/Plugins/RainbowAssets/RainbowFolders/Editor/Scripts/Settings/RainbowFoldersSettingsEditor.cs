using Borodar.RainbowCore.RList.Collections;
using UnityEditor;

namespace Borodar.RainbowFolders.Settings
{
    [CustomEditor(typeof(RainbowFoldersSettings))]
    public class RainbowFoldersSettingsEditor : Editor
    {
        #region Fields

        private const string PROP_NAME_FOLDERS = "Folders";
        private SerializedProperty _foldersProperty;

        #endregion Fields

        #region Unity Methods

        protected void OnEnable()
        {
            _foldersProperty = serializedObject.FindProperty(PROP_NAME_FOLDERS);
        }

        public override void OnInspectorGUI()
        {
            serializedObject.Update();

            DrawReorderableList();

            serializedObject.ApplyModifiedProperties();
        }

        #endregion Unity Methods

        #region Private Methods

        private void DrawReorderableList()
        {
            EditorGUI.BeginChangeCheck();

            ReorderableListGUI.Title("Rainbow Folders");
            ReorderableListGUI.ListField(_foldersProperty);

            // Track changes in reorderable list
            if (EditorGUI.EndChangeCheck())
            {
                RainbowFoldersSettings.OnSettingsChangeCallback();
            }
        }

        #endregion Private Methods
    }
}