using Desktop.Win.Data.Encryption;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using System.Text;
using Passwords.Model.Entities;

namespace Passwords.Server.Data.Configurations
{
    public class PasswordInfoConfiguration : EntityConfiguration, IEntityTypeConfiguration<PasswordInfo>
    {
        //TODO: Сделать асимметричное шифрование
        private IEncryptionProvider provider = new AesProvider(Encoding.UTF8.GetBytes("keqwertyuiopqwertyuiqwertyuioqwe"), Encoding.UTF8.GetBytes("qwertyuiopqwerty"));

        public void Configure(EntityTypeBuilder<PasswordInfo> builder)
        {
            builder.ToTable("PasswordInfo");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
            builder.Property(u => u.Login).HasColumnName("Login").HasColumnType(VarcharValue(100)).IsRequired().IsEncrypted(provider);
            builder.Property(u => u.Password).HasColumnName("Password").HasColumnType(VarcharValue(100)).IsRequired().IsEncrypted(provider);
            builder.Property(u => u.OldPassword).HasColumnName("OldPassword").HasColumnType(VarcharValue(100)).IsEncrypted(provider);

            builder.OwnsOne(x => x.User);
        }
    }
}