using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desktop.Win.Data.Encryption
{
    public static class PropertyBuilderExtensions
    {
        public static PropertyBuilder<string> IsEncrypted(this PropertyBuilder<string> propertyBuilder, IEncryptionProvider encryptionProvider)
        {
            if (encryptionProvider == null)
                return propertyBuilder; 

            var encryptionConverter = new EncryptionConverter(encryptionProvider);

            return propertyBuilder.HasConversion(encryptionConverter);
        }
    }
}
