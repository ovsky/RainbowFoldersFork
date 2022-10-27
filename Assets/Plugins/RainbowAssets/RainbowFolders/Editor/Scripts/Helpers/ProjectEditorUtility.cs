using System.Diagnostics.CodeAnalysis;
using System.IO;
using Borodar.RainbowCore;
using UnityEditor;
using UnityEngine;

namespace Borodar.RainbowFolders
{
    [SuppressMessage("ReSharper", "ConvertIfStatementToNullCoalescingExpression")]
    public static class ProjectEditorUtility
    {
        #region Fields

        #region Fields - Constant
        private const string LOAD_ASSET_ERROR_MSG
            = "Could not load {0}\n"
            + "Did you move the \"Rainbow Folders\" around in your project? "
            + "Go to \"Preferences -> Rainbow Folders\" and update the location of the asset.";
        #endregion Fields - Constant

        #region Fields - Statc
        private static Texture2D _defaultFolderIcon;

        private static Texture2D _editIconSmallPro;
        private static Texture2D _editIconSmallFree;
        private static Texture2D _editIconLargePro;
        private static Texture2D _editIconLargeFree;

        private static Texture2D _settingsIcon;
        private static Texture2D _deleteIcon;
        private static Texture2D _assetLogo;

        private static Texture2D _foldoutIcon;
        private static Texture2D _foldoutLevelsIcon;
        #endregion Fields - Statc

        #endregion Fields

        #region Public Methods

        #region Asset Management

        [SuppressMessage("ReSharper", "MemberCanBePrivate.Global")]
        public static T LoadFromAsset<T>(string relativePath) where T : Object
        {
            string assetPath = Path.Combine(ProjectPreferences.HomeFolder, relativePath);
            T asset = AssetDatabase.LoadAssetAtPath<T>(assetPath);
            if (!asset)
            {
                Debug.LogError(string.Format(LOAD_ASSET_ERROR_MSG, assetPath));
            }

            return asset;
        }

        #endregion Asset Management

        #region Texture Management

        public static Texture2D GetDefaultFolderIcon()
            => _defaultFolderIcon ?? EditorGUIUtility.FindTexture("Folder Icon");

        public static Texture2D GetEditFolderIcon(bool isSmall, bool isPro)
            => isSmall ? GetEditIconSmall(isPro) : GetEditIconLarge(isPro);

        public static Texture2D GetSettingsButtonIcon()
            => GetCoreTexture(ref _settingsIcon, CoreEditorTexture.IcnSettings);

        public static Texture2D GetDeleteButtonIcon()
            => GetCoreTexture(ref _deleteIcon, CoreEditorTexture.IcnDelete);

        public static Texture2D GetAssetLogo()
            => GetTexture(ref _assetLogo, ProjectEditorTexture.IcnRainbowLogo);

        public static Texture2D GetFoldoutIcon()
            => GetCoreTexture(ref _foldoutIcon, CoreEditorTexture.IcnFoldoutMiddle);

        public static Texture2D GetFoldoutLevelsIcon()
            => GetCoreTexture(ref _foldoutLevelsIcon, CoreEditorTexture.IcnFoldoutLevels);

        #endregion Texture Management

        #endregion Public Methods

        #region Private Methods

        private static Texture2D GetEditIconSmall(bool isPro) => isPro
                ? GetTexture(ref _editIconSmallPro, ProjectEditorTexture.IcnEditProSmall)
                : GetTexture(ref _editIconSmallFree, ProjectEditorTexture.IcnEditFreeSmall);

        private static Texture2D GetEditIconLarge(bool isPro) => isPro
                ? GetTexture(ref _editIconLargePro, ProjectEditorTexture.IcnEditProLarge)
                : GetTexture(ref _editIconLargeFree, ProjectEditorTexture.IcnEditFreeLarge);

        private static Texture2D GetTexture(ref Texture2D texture, ProjectEditorTexture type)
             => texture ??= ProjectEditorTexturesStorage.GetTexture(type);

        private static Texture2D GetCoreTexture(ref Texture2D texture, CoreEditorTexture type)
            => texture ??= CoreEditorTexturesStorage.GetTexture(type);

        #endregion Private Methods
    }
}