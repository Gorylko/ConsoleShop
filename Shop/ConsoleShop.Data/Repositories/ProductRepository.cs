using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Data;
using ConsoleShop.Data.Repositories.Interfaces;

namespace ConsoleShop.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        ProductData _productData = new ProductData();

        public IReadOnlyCollection<Product> GetAll()
        {
            return _productData.GetAllProducts();
        }

        public void Delete(int id)
        {
            _productData.DeleteById(id);
        }
        
        public Product GetById(int id)
        {
            return _productData.GetProductById(id);
        }

        public void Save(Product product)
        {

        }
    }
}
