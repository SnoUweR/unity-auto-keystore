using SnUnityCommonUtils.Building.AutoKeystore.Crypting;
using UnityEditor;

namespace SnUnityCommonUtils.Building.AutoKeystore
{
    /// <summary>
    /// Automatically restore keystore name and passwords from the local editor prefs on each Unity Editor start.
    /// You can save these parameters in <see cref="EditorWindowAutoKeystore"/>.
    /// Warning! It can be dangerous to save your keystore credentials on the public computers, because EditorPrefs
    /// can be viewed by anyone!
    /// </summary>
    internal class AutoKeystoreSetter
    {
        private const int Version = 1;
        private readonly Crypter _crypter;

        public AutoKeystoreSetter()
        {
            _crypter = new Crypter(new XorCryptService());
        }

        public AutoKeystoreData GetData()
        {
            var restoreKeystore = AutoKeystorePrefs.RestoreKeystore;
            var keyaliasName = _crypter.Decrypt(AutoKeystorePrefs.KeyAliasName);
            var keyaliasPass = _crypter.Decrypt(AutoKeystorePrefs.KeyAliasPass);
            var keystorePass = _crypter.Decrypt(AutoKeystorePrefs.KeystorePass);
            return new AutoKeystoreData(restoreKeystore, keyaliasName, keyaliasPass, keystorePass);
        }

        public void ApplyToProject()
        {
            var config = GetData();
            PlayerSettings.Android.keyaliasName = config.KeyAliasName;
            PlayerSettings.Android.keyaliasPass = config.KeyAliasPass;
            PlayerSettings.Android.keystorePass = config.KeystorePass;
        }

        public void SetData(AutoKeystoreData data)
        {
            AutoKeystorePrefs.RestoreKeystore = data.RestoreKeystore;
            AutoKeystorePrefs.KeyAliasName = _crypter.Encrypt(data.KeyAliasName);
            AutoKeystorePrefs.KeyAliasPass = _crypter.Encrypt(data.KeyAliasPass);
            AutoKeystorePrefs.KeystorePass = _crypter.Encrypt(data.KeystorePass);
            AutoKeystorePrefs.AutoKeystoreVersion = Version;
        }
    }
}