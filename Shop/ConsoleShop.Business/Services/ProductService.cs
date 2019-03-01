using System.Collections.Generic;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Repositories;
using ConsoleShop.Data.DataContext.Realization.MsSql;

namespace ConsoleShop.Business.Services
{
    public class ProductService
    {
        private ProductRepository _productRepository = new ProductRepository(new ProductContext()); //Тут указывается, какую бд использовать в передаваемых конструктору хернях (пока реализованно онли MsSql)

        public IReadOnlyCollection<Product> GetSearchList(string searchParameter, string searchQuery)
        {
            return _productRepository.GetAllByName(searchParameter, searchQuery);
        }

        public IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId)
        {
            return _productRepository.GetAllByCategoryId(categoryId);
        }

    }
}
