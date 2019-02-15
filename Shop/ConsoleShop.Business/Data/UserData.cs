using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Services;

namespace ConsoleShop.Business.Data
{
    public class UserData
    {
        UserService _servise = new UserService();

        public User GetAuthorizedUser(string login, string password)
        {
            return _servise.GetAuthorizedUserFromDb(login, password);
        }

        public User GetRegistratedUser(string login, string password, string email, string phonenumber)
        {
            return _servise.GetRegistratedUserFromDb(login, password, email, phonenumber);
        }

    }
}
