using System;
using System.Text;
using UnityEngine;

namespace SnUnityCommonUtils.Building.AutoKeystore.Crypting
{
    internal class Crypter
    {
        private readonly ICryptService _cryptService;

        public Crypter(ICryptService cryptService)
        {
            _cryptService = cryptService;
        }

        public string Encrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            try
            {
                var valueBytes = Encoding.Unicode.GetBytes(value);
                var encryptedBytes = _cryptService.Encrypt(valueBytes);
                return Convert.ToBase64String(encryptedBytes);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return string.Empty;
            }
        }

        public string Decrypt(string value)
        {
            if (string.IsNullOrEmpty(value))
            {
                return string.Empty;
            }

            try
            {
                var valueBytes = Convert.FromBase64String(value);
                var decryptedBytes = _cryptService.Decrypt(valueBytes);
                return Encoding.Unicode.GetString(decryptedBytes);
            }
            catch (Exception ex)
            {
                Debug.LogError(ex.Message);
                return string.Empty;
            }
        }
    }
}