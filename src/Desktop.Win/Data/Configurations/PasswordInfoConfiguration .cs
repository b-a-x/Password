using Desktop.Win.Model;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desktop.Win.Data.Configurations
{
    public class PasswordInfoConfiguration : IEntityTypeConfiguration<PasswordInfo>
    {
        public void Configure(EntityTypeBuilder<PasswordInfo> builder)
        {
            builder.ToTable("PasswordInfo");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
            builder.Property(u => u.Login).HasColumnName("Login").IsRequired();
            builder.Property(u => u.Password).HasColumnName("Password").IsRequired();
        }
    }
}
