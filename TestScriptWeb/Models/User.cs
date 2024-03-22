using System;
using System.Collections.Generic;
using System.Text;

namespace TestScriptWeb
{
    public class User
    {
        public string Username { get; set; }
        public string Password { get; set; }
        public string Gmail { get; set; }

        public User() { }
        public User(string name, string pass)
        {
            Username = name;
            Password = pass;
        }
        public User(string name, string pass, string gmail)
        {
            Username = name;
            Password = pass;
            Gmail = gmail;
        }
    }
}
