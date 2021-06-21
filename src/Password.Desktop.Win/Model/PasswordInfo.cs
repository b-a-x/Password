using System;

namespace Password.Desktop.Win.Model
{
    public class PasswordInfo
    {
        private string _oldPassword;

        public Guid Id { get; set; }
        public long Timestamp { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string OldPassword
        {
            get => _oldPassword ?? string.Empty;
            set => _oldPassword = value;
        }
    }
}