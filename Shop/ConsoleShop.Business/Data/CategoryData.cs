using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Data.Services;

namespace ConsoleShop.Business.Data
{
    public class CategoryData
    {
        private CategoryService _serviceTool = new CategoryService();
        
        public string GetCategoryString()
        {
            return _serviceTool.GetAllCategories(); 
        }
    }
}
