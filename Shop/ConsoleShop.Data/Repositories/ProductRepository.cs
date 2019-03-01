using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.DataContext.Interfaces;
using ConsoleShop.Data.Repositories.Interfaces;

namespace ConsoleShop.Data.Repositories
{
    public class ProductRepository : IProductRepository
    {
        public ProductRepository(IProductContext productContext)
        {
            this._productContext = productContext;
        }

        private IProductContext _productContext;

        public IReadOnlyCollection<Product> GetAll()
        {
            return _productContext.GetAll();
        }

        public void DeleteById(int id)
        {
            _productContext.DeleteById(id);
        }

        public Product GetById(int id)
        {
            return _productContext.GetById(id);
        }

        public IReadOnlyCollection<Product> GetAllByCategoryId(int id)
        {
            return _productContext.GetByCategoryId(id);
        }

        public IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery)
        {
            return _productContext.GetAllByName(searchParameter, searchQuery);
        }

        public void Save(Product product)
        {
            //ы
        }
    }
}
