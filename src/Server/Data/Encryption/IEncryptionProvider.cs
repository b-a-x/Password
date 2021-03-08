namespace Desktop.Win.Data.Encryption
{
    public interface IEncryptionProvider
    {
        string Encrypt(string dataToEncrypt);

        string Decrypt(string dataToDecrypt);
    }
}
