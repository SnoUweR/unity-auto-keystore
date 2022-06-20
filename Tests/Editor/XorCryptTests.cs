using System.Text;
using NUnit.Framework;
using SnUnityCommonUtils.Building.AutoKeystore.Crypting;

namespace Building.Editor.AutoKeystore.Tests.Editor
{
    [TestFixture]
    internal class XorCryptTest
    {
        private const string TestString = "Test";
        private static readonly byte[] TestStringEncrypted =
            { 109, 14, 99, 221, 137, 129, 36, 45, 130, 7, 234, 93, 62, 25, 165, 253 };
        
        private XorCryptService _service;

        [OneTimeSetUp]
        public void OneTimeSetUp()
        {
            _service = new XorCryptService();
        }
        
        [Test]
        public void TestEncrypt()
        {
            // Arrange
            var strBytes = Encoding.Unicode.GetBytes(TestString);
            
            // Act
            var encryptedBytes = _service.Encrypt(strBytes);
            
            // Assert
            Assert.AreEqual(encryptedBytes, TestStringEncrypted);
        }
        
        [Test]
        public void TestDecrypt()
        {
            // Act
            var decryptedBytes = _service.Decrypt(TestStringEncrypted);

            // Assert
            var decryptedString = Encoding.Unicode.GetString(decryptedBytes);
            Assert.AreEqual(TestString, decryptedString);
        }

        [OneTimeTearDown]
        public void OneTimeTearDown()
        {
            _service = null;
        }
    }
}