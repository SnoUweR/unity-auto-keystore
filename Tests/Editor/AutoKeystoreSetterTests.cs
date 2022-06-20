using NUnit.Framework;
using SnUnityCommonUtils.Building.AutoKeystore;
using UnityEditor;

namespace Building.Editor.AutoKeystore.Tests.Editor
{
    [TestFixture]
    internal class AutoKeystoreSetterTests
    {
        private const string KeyAliasName = "testAliasName";
        private const string KeyAliasPass = "testAliasPass";
        private const string KeystorePass = "testPass";
        
        private AutoKeystoreSetter _setter;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _setter = new AutoKeystoreSetter();
        }
        
        [Test]
        public void TestGetData()
        {
            // Act
            var data = _setter.GetData();
            
            // Assert
            Assert.IsNotNull(data);
        }
        
        [Test]
        public void TestSetData()
        {
            // Arrange
            var data = _setter.GetData();
            data.KeyAliasName = KeyAliasName;
            data.KeyAliasPass = KeyAliasPass;
            data.KeystorePass = KeystorePass;
            data.RestoreKeystore = true;

            // Act
            _setter.SetData(data);
            
            // Assert
            var newData = _setter.GetData();
            Assert.AreEqual(newData.KeyAliasName, KeyAliasName);
            Assert.AreEqual(newData.KeyAliasPass, KeyAliasPass);
            Assert.AreEqual(newData.KeystorePass, KeystorePass);
            Assert.AreEqual(newData.RestoreKeystore, true);
        }
        
        [Test]
        public void TestApplyToProject()
        {
            // Arrange
            var data = _setter.GetData();
            data.KeyAliasName = KeyAliasName;
            data.KeyAliasPass = KeyAliasPass;
            data.KeystorePass = KeystorePass;
            data.RestoreKeystore = true;
            _setter.SetData(data);
            
            // Act
            _setter.ApplyToProject();
            
            // Assert
            Assert.AreEqual(PlayerSettings.Android.keyaliasName, KeyAliasName);
            Assert.AreEqual(PlayerSettings.Android.keyaliasPass, KeyAliasPass);
            Assert.AreEqual(PlayerSettings.Android.keystorePass, KeystorePass);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            var data = new AutoKeystoreData(false, string.Empty, string.Empty, string.Empty);
            _setter.SetData(data);
            _setter.ApplyToProject();
            
            _setter = null;
        }
    }
}