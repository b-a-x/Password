using Microsoft.EntityFrameworkCore;
using Passwords.Server.Data;
using Passwords.Server.Entities;

namespace Passwords.Server.Helpers
{
    public static class DBInitialize
    {
        public static void EnsureCreated(DataContext context)
        {
            context.Database.EnsureCreated();
        }

        public static void Migrate(DataContext context)
        {
            context.Database.Migrate();
        }

        public static void CreateUser(DataContext context)
        {
            context.Users.Add(new User { FirstName = "Test", LastName = "User", UserName = "test", Password = "test" });
            context.SaveChanges();
        }
    }
}
