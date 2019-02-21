using System;
using System.Collections.Generic;
using ConsoleShop.Data.Data;
using ConsoleShop.Data.Repositories.Interfaces;
using System.Data.SqlClient;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Repositories
{
    class CategoryRepository : IRepository<string>
    {
        CategoryData _categoryData = new CategoryData();

        public IReadOnlyCollection<string> GetAll()
        {
            return _categoryData.GetAllCategoties();
        }

        public string GetById(int id)
        {
            return _categoryData.GetCategoryById(id);
        }

        public void Delete(int id)
        {
            _categoryData.DeleteById(id);
        }

        public void Save(string category)
        {
            _categoryData.Save(category);
        }
    }
}
