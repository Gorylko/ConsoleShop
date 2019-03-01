using System.Collections.Generic;
using ConsoleShop.Shared.Entities;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    public interface IProductContext : IDataContext<Product>
    {
        IReadOnlyCollection<Product> GetByCategoryId(int id);

        IReadOnlyCollection<Product> GetAllByName(string searchParameter, string searchQuery);
    }
}
