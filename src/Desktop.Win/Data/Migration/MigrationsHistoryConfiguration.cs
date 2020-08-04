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
            builder.Property(u => u.FullName).HasColumnName("FullName").HasColumnType("nvarchar(50)").IsRequired();
            builder.Property(u => u.DataCreated).HasColumnName("DataCreated").HasColumnType("datetime2").IsRequired();
            
            builder.Ignore(u => u.FullPatch);
        }
    }
}