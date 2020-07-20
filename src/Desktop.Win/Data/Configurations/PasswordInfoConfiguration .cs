using Desktop.Win.Data.Encryption;
using Desktop.Win.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;

namespace Desktop.Win.Data.Configurations
{
    public class PasswordInfoConfiguration : IEntityTypeConfiguration<PasswordInfo>
    {
        private IEncryptionProvider provider = new AesProvider(Encoding.UTF8.GetBytes("keqwertyuiopqwertyuiqwertyuioqwe"), Encoding.UTF8.GetBytes("qwertyuiopqwerty"));

        public void Configure(EntityTypeBuilder<PasswordInfo> builder)
        {
            builder.ToTable("PasswordInfo");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
            builder.Property(u => u.Login).HasColumnName("Login").IsRequired().IsEncrypted(provider);
            builder.Property(u => u.Password).HasColumnName("Password").IsRequired().IsEncrypted(provider);
        }
    }
}