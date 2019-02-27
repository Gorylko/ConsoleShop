using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    public interface IUserContext : IDataContext<User>
    {
        User GetAuthrizatedUser(string login, string password);

        User GetRegistratedUser(string login, string password, string email, string phonenumber);

    }
}
