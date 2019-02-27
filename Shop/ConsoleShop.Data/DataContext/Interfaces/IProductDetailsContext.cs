using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    public interface IProductDetailsContext
    {
        int GetIdByName(string name);
    }
}
