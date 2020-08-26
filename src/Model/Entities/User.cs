using System.Collections.Generic;
using System.Text.Json.Serialization;

namespace Passwords.Model.Entities
{
    public class User : Entity
    {
        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string UserName { get; set; }

        [JsonIgnore]
        public string Password { get; set; }

        [JsonIgnore]
        public List<RefreshToken> RefreshTokens { get; set; }

        [JsonIgnore]
        public List<PasswordInfo> PasswordInfos { get; set; }
    }
}
