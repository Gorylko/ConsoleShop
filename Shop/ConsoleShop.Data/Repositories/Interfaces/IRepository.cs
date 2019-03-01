using System.Collections.Generic;

namespace ConsoleShop.Data.Repositories.Interfaces
{
    public interface IRepository<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void DeleteById(int id);
    }
}
