namespace Passwords.Server.Models
{
    public class Error
    {
        public Error(string code, string message)
        {

        }
        public string Code { get; }
        public string Message { get; }
    }
}
