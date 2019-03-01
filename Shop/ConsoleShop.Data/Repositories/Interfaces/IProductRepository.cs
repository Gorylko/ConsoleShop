using System.Collections.Generic;
using ConsoleShop.Shared.Entities;

namespace ConsoleShop.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IReadOnlyCollection<Product> GetAllByCategoryId(int categoryId);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);
    }
}
