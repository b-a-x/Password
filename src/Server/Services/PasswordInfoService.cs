using System.Collections.Generic;
using System.Linq;
using Passwords.Model.Entities;
using Passwords.Server.Data;
using Passwords.Server.Models;

namespace Passwords.Server.Services
{
    public interface IPasswordInfoService
    {
        void Add(PasswordInfoRequest model);

        IReadOnlyCollection<PasswordInfo> GetAll(int userId);
    }

    public class PasswordInfoService : IPasswordInfoService
    {
        private DataContext context;

        public PasswordInfoService(DataContext context)
        {
            this.context = context;
        }

        public void Add(PasswordInfoRequest model)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == model.UserId);
            context.PasswordInfos.Add(new PasswordInfo
            {
                Login = model.Login,
                Name = model.Name,
                OldPassword = model.OldPassword,
                Password = model.Password,
                User = user
            });
            context.SaveChanges();
        }

        public IReadOnlyCollection<PasswordInfo> GetAll(int userId)
        {
            User user = context.Users.FirstOrDefault(x => x.Id == userId);
            var result = user?.PasswordInfos;
            return result;
        }
    }
}
