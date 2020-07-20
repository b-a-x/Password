using Desktop.Win.Model;

namespace Desktop.Win.ViewModel
{
    public class PasswordInfoVM
    {
        public PasswordInfo PasswordInfo;

        internal PasswordInfoVM(PasswordInfo passwordInfo)
        {
            this.PasswordInfo = passwordInfo;
        }

        public int Id
        {
            get => PasswordInfo.Id;
            set => PasswordInfo.Id = value;
        }

        public string Name
        {
            get => PasswordInfo.Name;
            set => PasswordInfo.Name = value;
        }

        public string Login
        {
            get => PasswordInfo.Login;
            set => PasswordInfo.Login = value;
        }

        public string Password
        {
            get => PasswordInfo.Password;
            set => PasswordInfo.Password = value;
        }
    }
}
