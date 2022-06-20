using UnityEditor;
using UnityEngine;

namespace SnUnityCommonUtils.Building.AutoKeystore
{
    internal class EditorWindowAutoKeystore : EditorWindow
    {
        [MenuItem("Window/Auto Keystore...")]
        private static void ShowWindow()
        {
            var window = GetWindow<EditorWindowAutoKeystore>();
            window.titleContent = new GUIContent("Set Keystore");
            window.Show();
        }

        private void OnGUI()
        {
            var config = AutoKeystoreSetterHolder.Instance.GetData();
            config.RestoreKeystore = EditorGUILayout.Toggle("Enabled", config.RestoreKeystore);
            config.KeyAliasName = EditorGUILayout.TextField("Alias Name", config.KeyAliasName);
            config.KeyAliasPass = EditorGUILayout.PasswordField("Alias Pass", config.KeyAliasPass);
            config.KeystorePass = EditorGUILayout.PasswordField("Keystore Pass", config.KeystorePass);

            AutoKeystoreSetterHolder.Instance.SetData(config);
            if (GUILayout.Button("Set to Project Now"))
            {
                AutoKeystoreSetterHolder.Instance.ApplyToProject();
            }
        }
    }
}