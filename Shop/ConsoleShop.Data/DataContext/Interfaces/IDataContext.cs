﻿using System.Collections.Generic;

namespace ConsoleShop.Data.DataContext.Interfaces
{
    public interface IDataContext<T>
    {
        IReadOnlyCollection<T> GetAll();

        T GetById(int id);

        void Save(T obj);

        void DeleteById(int id);
    }
}
