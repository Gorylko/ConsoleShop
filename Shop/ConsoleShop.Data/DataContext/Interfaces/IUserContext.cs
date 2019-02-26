using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    interface IUserContext : IDataContext<User>
    {
    }
}
