using UnityEditor;

namespace SnUnityCommonUtils.Building.AutoKeystore
{
    [InitializeOnLoad]
    internal static class AutoKeystoreSetterHolder
    {
        public static AutoKeystoreSetter Instance => _instance ?? (_instance = new AutoKeystoreSetter());

        private static AutoKeystoreSetter _instance;

        static AutoKeystoreSetterHolder()
        {
            if (AutoKeystorePrefs.RestoreKeystore)
                Instance.ApplyToProject();
        }

    }
}