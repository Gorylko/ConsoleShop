using ConsoleShop.Data.Repositories;
using ConsoleShop.Data.DataContext.Realization.MsSql;

namespace ConsoleShop.Business.Services
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
