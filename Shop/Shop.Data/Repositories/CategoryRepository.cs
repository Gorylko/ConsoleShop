using System.Collections.Generic;
using Shop.Data.Repositories.Interfaces;
using Shop.Data.DataContext.Interfaces;

namespace Shop.Data.Repositories
{
    public class CategoryRepository : IRepository<string>
    {
        ICategoryContext _categoryContext;

        public CategoryRepository(ICategoryContext categoryContext)
        {
            this._categoryContext = categoryContext;
        }

        public string GetAllString()
        {
            return _categoryContext.GetAllString();
        }

        public IReadOnlyCollection<string> GetAll()
        {
            return _categoryContext.GetAll();
        }

        public string GetById(int id)
        {
            return _categoryContext.GetById(id);
        }

        public void DeleteById(int id)
        {
            _categoryContext.DeleteById(id);
        }

        public void Save(string category)
        {
            _categoryContext.Save(category);
        }
    }
}
