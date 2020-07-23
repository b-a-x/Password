using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Desktop.Win.Data.Migration
{
    public class MigrationsHistoryConfiguration : IEntityTypeConfiguration<MigrationsHistory>
    {
        public void Configure(EntityTypeBuilder<MigrationsHistory> builder)
        {
            builder.ToTable("MigrationsHistory");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();

            builder.Property(u => u.Number).HasColumnName("Number").IsRequired();
            builder.Property(u => u.Name).HasColumnName("Name").IsRequired();
            builder.Property(u => u.DataCreated).HasColumnName("DataCreated").IsRequired();
        }
    }
}