using System;
using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleShop.Shared.Entities;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Data.DataContext.Interfaces;
using ConsoleShop.Shared.Helpers;
using ConsoleShop.Shared.Entities.Enums;

namespace ConsoleShop.Data.Repositories.Interfaces
{
    public interface IUserRepository : IRepository<User>
    {
        User GetAuthorizedUser(string login, string password);

        User GetRegistratedUser(string login, string password, string email, string phonenumber);
    }
}
