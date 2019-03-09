using System.Collections.Generic;
using Shop.Shared.Entities;

namespace Shop.Data.DataContext.Interfaces
{
    public interface IProductContext : IDataContext<Product>
    {
        IReadOnlyCollection<Product> GetByCategoryId(int id);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);
    }
}
