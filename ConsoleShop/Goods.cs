using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop
{
    class Goods
    {
        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public int Price { get; private set; }
        public Goods(string name, string manuf, int price)
        {
            Name = name;
            Manufacturer = manuf;
            Price = price;
        }

        public void PrintInfo()
        {
            Console.WriteLine("\n Название : {0}",Name);
            Console.WriteLine(" Производитель : {0}",Manufacturer);
            Console.WriteLine(" Цена : {0}",Price);
            Console.ResetColor();
        }


    }
}
