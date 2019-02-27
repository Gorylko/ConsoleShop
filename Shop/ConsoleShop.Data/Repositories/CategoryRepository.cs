using System;
using System.Collections.Generic;
using ConsoleShop.Data.Repositories.Interfaces;
using System.Data.SqlClient;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Data.DataContext.Interfaces;

namespace ConsoleShop.Data.Repositories
{
    class CategoryRepository : IRepository<string>
    {
        ICategoryContext _categoryContext;

        public CategoryRepository(ICategoryContext categoryContext)
        {
            this._categoryContext = categoryContext;
        }

        public IReadOnlyCollection<string> GetAll()
        {
            return _categoryContext.GetAll();
        }

        public string GetById(int id)
        {
            return _categoryContext.GetById(id);
        }

        public void Delete(int id)
        {
            _categoryContext.DeleteById(id);
        }

        public void Save(string category)
        {
            _categoryContext.Save(category);
        }
    }
}
