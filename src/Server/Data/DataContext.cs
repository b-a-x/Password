using Microsoft.EntityFrameworkCore;
using Passwords.Model.Entities;
using Passwords.Server.Data.Configurations;


namespace Passwords.Server.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options) { }

        public DbSet<User> Users { get; set; }
        public DbSet<PasswordInfo> PasswordInfos { get; set; }

        protected override void OnModelCreating(ModelBuilder builder)
        {
            builder.ApplyConfiguration<User>(new UserConfiguration());

            base.OnModelCreating(builder);
        }
    }
}
