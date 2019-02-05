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
            set
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
            set
            {
                if (value.Length >= MinPasswordSize)
                    _login = value;
                else
                {
                    // позже
                }
            }
        }
        public string Email { get; set; }

        private string _phonenumber;
        public string PhoneNumber
        {
            get
            {
                return _phonenumber;
            }
            set
            {
                _phonenumber = value;
            }
        }

        public RoleType Role { get; set; }


    }
}
