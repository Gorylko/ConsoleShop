using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.DataContext.Realization.MsSql;
using ConsoleShop.Data.DataContext.Interfaces;
using ConsoleShop.Data.Repositories.Interfaces;

namespace ConsoleShop.Data.Repositories
{
    public class ProductRepository : IRepository<Product>
    {
        private IProductContext _productContext;

        public ProductRepository(IProductContext productContext)
        {
            this._productContext = productContext;
        }

        public IReadOnlyCollection<Product> GetAll()
        {
            return _productContext.GetAll();
        }

        public void Delete(int id)
        {
            _productContext.DeleteById(id);
        }

        public Product GetById(int id)
        {
            return _productContext.GetById(id);
        }

        public 

        public void Save(Product product)
        {

        }
    }
}
