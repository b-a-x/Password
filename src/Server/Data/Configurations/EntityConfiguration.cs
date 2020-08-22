using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Passwords.Server.Entities;

namespace Passwords.Server.Data.Configurations
{
    public class EntityConfiguration : IEntityTypeConfiguration<Entity>
    {
        protected const string timestamptz = "timestamptz";

        public void Configure(EntityTypeBuilder<Entity> builder)
        {
            builder.ToTable("Entities");

            builder.HasKey(p => p.Id);
            builder.HasIndex(p => p.Id).IsUnique();
        }

        protected string VarcharValue(int value = int.MaxValue)
        {
            return int.MaxValue == value ? "text" : $"varchar({value})";
        }
    }
}
