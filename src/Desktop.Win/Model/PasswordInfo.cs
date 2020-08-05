namespace Desktop.Win.Model
{
    public class PasswordInfo
    {
        private string oldPassword;
        public int Id { get; set; }
        public string Name { get; set; }
        public string Login { get; set; }
        public string Password { get; set; }

        public string OldPassword
        {
            get => oldPassword ?? string.Empty;
            set => oldPassword = value;
        }
    }
}