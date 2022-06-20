using System.IO;
using System.Linq;
using System.Security.Cryptography;

namespace SnUnityCommonUtils.Building.AutoKeystore.Crypting
{
    internal class XorCryptService : ICryptService
    {
        private static readonly byte[] Key = new byte[8] {1, 2, 3, 4, 5, 6, 7, 8};

        public byte[] Encrypt(byte[] value)
        {
            using (var algorithm = DES.Create())
            {
                algorithm.Mode = CipherMode.ECB;
                algorithm.Key = Key;         
                
                using (var memoryStream = new MemoryStream())
                {
                    using (var cryptoStream = new CryptoStream(memoryStream, algorithm.CreateEncryptor(), CryptoStreamMode.Write))
                    {
                        cryptoStream.Write(value, 0, value.Length);
                    }
                    return memoryStream.ToArray();
                }
            }
        }

        public byte[] Decrypt(byte[] value)
        {
            using (var algorithm = DES.Create())
            {
                algorithm.Mode = CipherMode.ECB;
                algorithm.Key = Key;         
                
                using (var memoryStream = new MemoryStream(value))
                {
                    var result = new byte[value.Length];
                    var readBytesCount = 0;
                    using (var cryptoStream = new CryptoStream(memoryStream, algorithm.CreateDecryptor(), CryptoStreamMode.Read))
                    {
                        readBytesCount += cryptoStream.Read(result, 0, result.Length);
                    }

                    return result.Take(readBytesCount).ToArray();
                }
            }
        }
    }
}