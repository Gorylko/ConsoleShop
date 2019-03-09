using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.Shared.Entities;
using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;

namespace Shop.Business.Services
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
