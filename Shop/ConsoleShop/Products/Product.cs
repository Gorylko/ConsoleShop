using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Products
{
    public class Product
    {
        public Product(int id, string name, string manuf, string category, int price)
        {
            //this.Id = id;
            //this.Name = name;
            //this.Manufacturer = manuf;
            //this.Category = category;
            //this.Price = price;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
        public string DateOfCreation { get; private set; } = Convert.ToString(DateTime.Today);
        public string LastModifiedDate { get; private set; }
        public string Category { get; private set; }
        public AuthorOfProduct Author { get; private set; }
        public string LocationOfGoods { get; private set; }
        public string Condition { get; private set; }


        public string GetInfo()
        {
            return NewLine + "Название : " + this.Name + NewLine + "Описание : " + this.Description + NewLine + "Цена : " + this.Price + NewLine +
                "Дата изготовления :" + this.DateOfCreation + NewLine + "Дата последнего изменения : " + this.LastModifiedDate + NewLine +
                "Категория : " + Category + NewLineX2 + "Контакты производителя : " + this.Author.Name + NewLine + "Телефон : " + this.Author.PhoneNumber + NewLine +
                "Почта : " + this.Author.Email + NewLineX2 + "Местоположение товара : " + this.LocationOfGoods + NewLine + "Состояние : " + this.Condition + NewLineX2;

        }


    }
}
