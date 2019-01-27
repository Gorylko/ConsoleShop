using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Users
{
    public class User
    {
        private string _login;
        public string Login
        {
            get
            {
                return _login;
            }
            private set
            {
                if (value.Length >= MinLoginSize)
                    _login = value;
                else
                {
                    // позже
                }
            }
        }

        private string _password;
        public string Password
        {
            get
            {
                return _password;
            }
            private set
            {
                if (value.Length >= MinPasswordSize)
                    _login = value;
                else
                {
                    // позже
                }
            }
        }

        private string _email;
        public string Email
        {
            get
            {
                return _email;
            }
            private set
            {
                if (value.Contains("@") && value.Contains(".")) //Можно было регулярным выражением, но я их не знаю)
                    _email = value;
                else
                {
                    // позже
                }
            }
        }

        public RoleType Role { get; private set; }


    }
}
