using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Repositories;
using ConsoleShop.Data.DataContext.Realization.MsSql;

namespace ConsoleShop.Business.Services
{
    public class UserService
    {
        UserRepository _userRepository = new UserRepository(new UserContext());

        public User GetAuthorizedUser(string login, string password)
        {
            return _userRepository.GetAuthorizedUser(login, password);
        }

        public User GetRegistratedUser(string login, string password, string email, string phonenumber)
        {
            return _userRepository.GetRegistratedUser(login, password, email, phonenumber);
        }

    }
}
