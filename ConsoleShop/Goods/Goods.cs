using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop
{
    public class Goods
    {
        public Goods(int id, string name, string manuf, string category, int price)
        {
            this.Id = id;
            this.Name = name;
            this.Manufacturer = manuf;
            this.Category = category;
            this.Price = price;
        }
        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Manufacturer { get; private set; }
        public string Category { get; private set; }
        public int Price { get; private set; }


        public string PrintInfo()
        {
            return NewLine + "Название : " + this.Name + NewLine + "Производитель : " + this.Manufacturer + NewLine + "Цена : " + this.Price+ NewLine; ;
        }


    }
}
