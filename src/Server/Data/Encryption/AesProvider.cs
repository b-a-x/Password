using System;
using System.IO;
using System.Security.Cryptography;
using System.Text;

namespace Desktop.Win.Data.Encryption
{
    public class AesProvider : IEncryptionProvider
    {
        private const int AesBlockSize = 128;
        private readonly byte[] _key;
        private readonly byte[] _initializationVector;
        private readonly CipherMode _mode;
        private readonly PaddingMode _padding;

        public AesProvider(byte[] key, byte[] initializationVector, CipherMode mode = CipherMode.CBC, PaddingMode padding = PaddingMode.PKCS7)
        {
            this._key = key;
            this._initializationVector = initializationVector;
            this._mode = mode;
            this._padding = padding;
        }

        public string Encrypt(string dataToEncrypt)
        {
            byte[] input = Encoding.UTF8.GetBytes(dataToEncrypt);
            byte[] encrypted = null;

            using (var aes = this.CreateNewAesEncryptor())
            {
                using (var memoryStream = new MemoryStream())
                {
                    using (var crypto = new CryptoStream(memoryStream, aes.CreateEncryptor(), CryptoStreamMode.Write))
                        crypto.Write(input, 0, input.Length);

                    encrypted = memoryStream.ToArray();
                }
            }

            return Convert.ToBase64String(encrypted);
        }

        public string Decrypt(string dataToDecrypt)
        {
            byte[] input = Convert.FromBase64String(dataToDecrypt);
            string decrypted = string.Empty;

            using (var aes = this.CreateNewAesEncryptor())
            {
                using (var memoryStream = new MemoryStream(input))
                using (var crypto = new CryptoStream(memoryStream, aes.CreateDecryptor(), CryptoStreamMode.Read))
                using (var sr = new StreamReader(crypto))
                    decrypted = sr.ReadToEnd().Trim('\0');
            }

            return decrypted;
        }

        private Aes CreateNewAesEncryptor()
        {
            var aes = Aes.Create();

            aes.Mode = this._mode;
            aes.Padding = this._padding;
            aes.Key = this._key;
            aes.IV = this._initializationVector;

            return aes;
        }

        public static KeyInfo GenerateKey(KeySize keySize)
        {
            var crypto = new AesCryptoServiceProvider
            {
                KeySize = (int)keySize,
                BlockSize = AesBlockSize,
                Mode = CipherMode.CBC,
                Padding = PaddingMode.PKCS7
            };

            crypto.GenerateKey();
            crypto.GenerateIV();

            return new KeyInfo(crypto.Key, crypto.IV);
        }
    }
}