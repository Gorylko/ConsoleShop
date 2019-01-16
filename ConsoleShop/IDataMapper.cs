using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop
{
    public interface IDataMapper<T>
    {
        T GetMappedObject<IDataReader, T>();
    }
}
