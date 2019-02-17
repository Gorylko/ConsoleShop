using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Repositories
{
    interface ICategoryRepository : IRepository<string>
    {
        IReadOnlyCollection<string> GetAllCategories();
        string GetCategory(int categoryId);
    }
}
