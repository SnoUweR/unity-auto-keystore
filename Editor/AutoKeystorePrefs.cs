using UnityEditor;

namespace SnUnityCommonUtils.Building.AutoKeystore
{
    internal static class AutoKeystorePrefs
    {
        private static string KeystorePassKey => $"{PlayerSettings.productName}_KEYSTORE_PASS";
        private static string KeyAliasPassKey => $"{PlayerSettings.productName}_KEYALIAS_PASS";
        private static string KeyAliasNameKey => $"{PlayerSettings.productName}_KEYALIAS_NAME";
        private static string RestoreKeystoreKey => $"{PlayerSettings.productName}_RESTORE_KEYSTORE";
        private static string AutoKeyStoreVersionKey => $"{PlayerSettings.productName}_AUTOKEYSTORE_VER";
        
        public static string KeystorePass
        {
            get => EditorPrefs.GetString(KeystorePassKey);
            set => EditorPrefs.SetString(KeystorePassKey, value);
        }
        
        public static string KeyAliasPass
        {
            get => EditorPrefs.GetString(KeyAliasPassKey);
            set => EditorPrefs.SetString(KeyAliasPassKey, value);
        }
        
        public static string KeyAliasName
        {
            get => EditorPrefs.GetString(KeyAliasNameKey);
            set => EditorPrefs.SetString(KeyAliasNameKey, value);
        }

        public static bool RestoreKeystore
        {
            get => EditorPrefs.GetBool(RestoreKeystoreKey);
            set => EditorPrefs.SetBool(RestoreKeystoreKey, value);
        }

        public static int AutoKeystoreVersion
        {
            get => EditorPrefs.GetInt(AutoKeyStoreVersionKey);
            set => EditorPrefs.GetInt(AutoKeyStoreVersionKey, value);
        }
    }
}