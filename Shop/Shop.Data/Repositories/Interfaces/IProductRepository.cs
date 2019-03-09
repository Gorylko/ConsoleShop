using System.Collections.Generic;
using Shop.Shared.Entities;

namespace Shop.Data.Repositories.Interfaces
{
    public interface IProductRepository : IRepository<Product>
    {
        IReadOnlyCollection<Product> GetAllByCategoryId(int categoryId);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);
    }
}
