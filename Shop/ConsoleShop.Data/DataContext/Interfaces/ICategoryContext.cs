using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    public interface ICategoryContext : IDataContext<string>
    {
        int GetIdByName(string name);

        string GetAllString();
    }
}
