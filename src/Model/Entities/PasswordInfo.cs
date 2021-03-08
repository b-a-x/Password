using System.Text.Json.Serialization;

namespace Passwords.Model.Entities
{
    public class PasswordInfo : Entity
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

        [JsonIgnore]
        public User User { get; set; }
    }
}
