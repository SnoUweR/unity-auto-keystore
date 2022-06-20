namespace SnUnityCommonUtils.Building.AutoKeystore.Crypting
{
    internal interface ICryptService
    {
        byte[] Encrypt(byte[] value);
        byte[] Decrypt(byte[] value);
    }
}