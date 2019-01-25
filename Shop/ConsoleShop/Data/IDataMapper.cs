using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data
{
    public interface IDataMapper<IDataReader, T>
    {
        T GetMappedObject();
    }
}
