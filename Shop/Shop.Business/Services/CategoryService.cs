using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;

namespace Shop.Business.Services
{
    public class CategoryService
    {
        private CategoryRepository _categoryRepository = new CategoryRepository(new CategoryContext());
        
        public string GetCategoryString()
        {
            return _categoryRepository.GetAllString() + "Чтобы вернуться назад - пиши /r"; 
        }
    }
}
