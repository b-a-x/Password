using System;

namespace Desktop.Win.Data.Encryption
{
    [AttributeUsage(AttributeTargets.Property, AllowMultiple = false, Inherited = false)]
    public sealed class EncryptedAttribute : Attribute
    {
    }
}
