using System.Collections.Generic;
using Shop.Shared.Entities;
using Shop.Data.Repositories;
using Shop.Data.DataContext.Realization.MsSql;

namespace Shop.Business.Services
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
