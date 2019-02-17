using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Business.RepositoryTest
{
    public interface IRepository<T> : IDisposable
    where T : class
    {
        IEnumerable<T> GetProductList(); // получение всех объектов
        T GetProduct(int id); // получение одного объекта по id
        void Create(T item); // создание объекта
        void Update(T item); // обновление объекта
        void Delete(int id); // удаление объекта по id
        void Save();  // сохранение изменений
    }
}

