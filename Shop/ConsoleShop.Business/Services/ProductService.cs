using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Data;
using ConsoleShop.Shared.Helpers;

namespace ConsoleShop.Business.Services
{
    public class ProductService
    {
        private ProductData _productService = new ProductData();

        public IReadOnlyCollection<Product> GetSearchList(string searchParameter, string searchQuery)
        {
            return _productService.GetSearchListFromDb(searchParameter, searchQuery);
        }

        public IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return _productService.GetProductsByCategoryIdFromDb(categoryId);
        }

    }
}
