using System;
using System.Collections.Generic;
using System.Text;

namespace Ergogame
{
    public class User
    {
        public static string Email { get; set; }
        public static string Password { get; set; }

        public User(string email, string password)
        {
            Email = email;
            Password = password;
        }
    }
}
