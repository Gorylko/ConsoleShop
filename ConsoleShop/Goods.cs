using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleShop.PrintConstants;

namespace ConsoleShop
{
    class Goods
    {
        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public int Price { get; private set; }
        public Goods(string name, string manuf, int price)
        {
            this.Name = name;
            this.Manufacturer = manuf;
            this.Price = price;
        }

        public string PrintInfo()
        {
            return NewLine + "Название : " + this.Name + NewLine + "Производитель : " + this.Manufacturer + NewLine + "Цена : " + this.Price+ NewLine; ;
        }


    }
}
