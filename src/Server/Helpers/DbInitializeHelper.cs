using Microsoft.EntityFrameworkCore;
using Passwords.Model.Entities;
using Passwords.Server.Data;

namespace Passwords.Server.Helpers
{
    public static class DbInitializeHelper
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
