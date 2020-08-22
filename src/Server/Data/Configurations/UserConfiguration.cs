using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passwords.Server.Entities;

namespace Passwords.Server.Data.Configurations
{
    public class UserConfiguration : EntityConfiguration, IEntityTypeConfiguration<User>
    {
        public void Configure(EntityTypeBuilder<User> builder)
        {
            builder.ToTable("Users");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(x => x.FirstName).HasColumnName("FirstName").HasColumnType(VarcharValue(100)).IsRequired();
            builder.Property(x => x.LastName).HasColumnName("LastName").HasColumnType(VarcharValue(100)).IsRequired();
            builder.Property(x => x.Password).HasColumnName("Password").HasColumnType(VarcharValue(100)).IsRequired();
            builder.Property(x => x.UserName).HasColumnName("UserName").HasColumnType(VarcharValue(100)).IsRequired();

            builder.OwnsMany(x => x.RefreshTokens, rt =>
            {
                rt.HasKey(p => p.Id);
                rt.HasIndex(p => p.Id).IsUnique();
                rt.Property(x => x.CreatedByIp).HasColumnName("CreatedByIp").HasColumnType(VarcharValue(20)).IsRequired();
                rt.Property(x => x.Created).HasColumnName("Created").HasColumnType(timestamptz).IsRequired();
                rt.Property(x => x.Expires).HasColumnName("Expires").HasColumnType(timestamptz).IsRequired();
                rt.Property(x => x.ReplacedByToken).HasColumnName("ReplacedByToken").HasColumnType(VarcharValue());
                rt.Property(x => x.Revoked).HasColumnName("Revoked").HasColumnType(timestamptz);
                rt.Property(x => x.RevokedByIp).HasColumnName("RevokedByIp").HasColumnType(VarcharValue(20));
                rt.Property(x => x.Token).HasColumnName("Token").HasColumnType(VarcharValue()).IsRequired();
            });
        }
    }
}
