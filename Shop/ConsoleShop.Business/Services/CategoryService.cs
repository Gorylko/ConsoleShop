using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Data.Data;

namespace ConsoleShop.Business.Services
{
    public class CategoryService
    {
        private CategoryData _categoryData = new CategoryData();
        
        public string GetCategoryString()
        {
            return _categoryData.GetAllCategoriesString() + "Чтобы вернуться назад - пиши /r"; 
        }
    }
}
