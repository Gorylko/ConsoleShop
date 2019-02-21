using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Data;

namespace ConsoleShop.Business.Services
{
    public class UserService
    {
        UserData _userData = new UserData();

        public User GetAuthorizedUser(string login, string password)
        {
            return _userData.GetAuthorizedUserFromDb(login, password);
        }

        public User GetRegistratedUser(string login, string password, string email, string phonenumber)
        {
            return _userData.GetRegistratedUserFromDb(login, password, email, phonenumber);
        }

    }
}
