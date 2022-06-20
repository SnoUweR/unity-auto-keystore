namespace SnUnityCommonUtils.Building.AutoKeystore
{
    internal struct AutoKeystoreData
    {
        public bool RestoreKeystore { get; set; }
        public string KeyAliasName { get; set; }
        public string KeyAliasPass { get; set; }
        public string KeystorePass { get; set; }

        public AutoKeystoreData(bool restoreKeystore, string keyAliasName, string keyAliasPass, string keystorePass)
        {
            RestoreKeystore = restoreKeystore;
            KeyAliasName = keyAliasName;
            KeyAliasPass = keyAliasPass;
            KeystorePass = keystorePass;
        }
    }
}