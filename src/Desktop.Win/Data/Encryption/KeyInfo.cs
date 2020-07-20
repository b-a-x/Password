using System;

namespace Desktop.Win.Data.Encryption
{
    public readonly struct KeyInfo : IEquatable<KeyInfo>
    {
        public byte[] Key { get; }

        public byte[] IV { get; }

        internal KeyInfo(byte[] key, byte[] iv)
        {
            this.Key = key;
            this.IV = iv;
        }

        public bool Equals(KeyInfo other) => (this.Key, this.IV) == (other.Key, other.IV);

        public override bool Equals(object obj) => (obj is KeyInfo keyInfo) && this.Equals(keyInfo);

        public override int GetHashCode() => (this.Key, this.IV).GetHashCode();

        public static bool operator ==(KeyInfo left, KeyInfo right) => Equals(left, right);

        public static bool operator !=(KeyInfo left, KeyInfo right) => !Equals(left, right);
    }
}