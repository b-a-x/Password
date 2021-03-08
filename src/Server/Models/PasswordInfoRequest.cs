namespace Passwords.Server.Models
{
    public class PasswordInfoRequest
    {
        private string oldPassword;
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string OldPassword
        {
            get => oldPassword ?? string.Empty;
            set => oldPassword = value;
        }

        public int UserId { get; set; }
    }
}
