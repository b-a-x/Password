using System;
using Microsoft.EntityFrameworkCore;
using Password.Desktop.Win.Data.Configurations;
using Password.Desktop.Win.Data.Migration;
using Password.Desktop.Win.Model;

namespace Password.Desktop.Win.Data
{
    public sealed class ApplicationContext : DbContext
    {
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

        public override int SaveChanges()
        {
            OnBeforeSaving();
            return base.SaveChanges();
        }

        private void OnBeforeSaving()
        {
            var entries = ChangeTracker.Entries();
            foreach (var entry in entries)
            {
                //TODO: Добавить интерфейс
                if (entry.Entity is PasswordInfo password) 
                    password.Timestamp = DateTimeOffset.UtcNow.ToUnixTimeSeconds();
                /*if (entry.Entity is ITrackable trackable)
                {
                    var now = DateTime.UtcNow;
                    var user = GetCurrentUser();
                    switch (entry.State)
                    {
                        case EntityState.Modified:
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = user;
                            break;

                        case EntityState.Added:
                            trackable.CreatedAt = now;
                            trackable.CreatedBy = user;
                            trackable.LastUpdatedAt = now;
                            trackable.LastUpdatedBy = user;
                            break;
                        default:
                    }
                }*/
            }
        }
    }
}