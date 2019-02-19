using System;
using System.Collections.Generic;
using ConsoleShop.Data.Data;
using ConsoleShop.Data.Repositories.Interfaces;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Repositories
{
    class CategoryRepository : ICategoryRepository
    {
        CategoryData _categoryData = new CategoryData();

        public IReadOnlyCollection<string> GetAll()
        {
            return _categoryData.GetAllCategoties();
        }

        public void Delete(int id)
        {
            _categoryData.DeleteById(id);
        }
    }
}
