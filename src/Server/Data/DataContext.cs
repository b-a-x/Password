using Microsoft.EntityFrameworkCore;
using Passwords.Server.Entities;

namespace Passwords.Server.Data
{
    public class DataContext : DbContext
    {
        public DbSet<User> Users { get; set; }

        public DataContext(DbContextOptions<DataContext> options) : base(options) { }
    }
}
