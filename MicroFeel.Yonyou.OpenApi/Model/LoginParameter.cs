using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;

namespace MicroFeel.Yonyou.Api
{
    public class LoginParameter
    {
        [JsonPropertyName("user")]
        public User User { get; set; }
    }

    public class User
    {
        public User(string user_id, string password)
        {
            User_id = user_id;
            Password = password;
        }

        /// <summary>
        /// 操作员编码
        /// </summary>
        [JsonPropertyName("user_id")]
        public string User_id { get; set; }
        [JsonPropertyName("password")]
        public string Password { get; set; }
    }
}
