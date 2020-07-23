using Desktop.Win.Data.Configurations;
using Desktop.Win.Data.Migration;
using Desktop.Win.Model;
using Microsoft.EntityFrameworkCore;

namespace Desktop.Win.Data
{
    public sealed class ApplicationContext : DbContext
    {
        public ApplicationContext()
        {
            Database.EnsureCreated();
        }

        public DbSet<PasswordInfo> PasswordInfos { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlite("Filename=PasswordDataBase.db");
        }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration(new PasswordInfoConfiguration());
            builder.UseMigrationsHistory();
            base.OnModelCreating(builder);
        }
    }
}
