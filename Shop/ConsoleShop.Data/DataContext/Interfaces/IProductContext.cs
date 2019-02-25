using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleShop.Shared.Entities;
using System.Threading.Tasks;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    public interface IProductContext
    {
         IReadOnlyCollection<Product> GetByCategoryId(int id);


    }
}
