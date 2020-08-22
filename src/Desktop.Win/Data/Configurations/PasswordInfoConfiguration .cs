using Desktop.Win.Data.Encryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using Passwords.Model.Entities;

namespace Desktop.Win.Data.Configurations
{
    public class PasswordInfoConfiguration : IEntityTypeConfiguration<PasswordInfo>
    {
        private const string nvarchar100 = "nvarchar(100)";
        //TODO: Сделать асимметричное шифрование
        private IEncryptionProvider provider = new AesProvider(Encoding.UTF8.GetBytes("keqwertyuiopqwertyuiqwertyuioqwe"), Encoding.UTF8.GetBytes("qwertyuiopqwerty"));

        public void Configure(EntityTypeBuilder<PasswordInfo> builder)
        {
            builder.ToTable("PasswordInfo");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
            builder.Property(u => u.Login).HasColumnName("Login").HasColumnType(nvarchar100).IsRequired().IsEncrypted(provider);
            builder.Property(u => u.Password).HasColumnName("Password").HasColumnType(nvarchar100).IsRequired().IsEncrypted(provider);
            builder.Property(u => u.OldPassword).HasColumnName("OldPassword").HasColumnType(nvarchar100).IsEncrypted(provider);
        }
    }
}