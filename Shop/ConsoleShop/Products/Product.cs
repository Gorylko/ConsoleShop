using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Products
{
    public class Product
    {
        public Product(int id, string name, string description, int price, string creationdate, string modifieddate, string category, User author, string locationofproduct, string state)
        {
            Id = id;
            Name = name;
            Description = description;
            Price = price;
            CreationDate = creationdate;
            LastModifiedDate = modifieddate;
            Category = category;
            Author = author;
            LocationOfProduct = locationofproduct;
            State = state;
        }

        public int Id { get; private set; }
        public string Name { get; private set; }
        public string Description { get; private set; }
        public int Price { get; private set; }
        public string CreationDate { get; private set; }
        public string LastModifiedDate { get; private set; }
        public string Category { get; private set; }
        public User Author { get; private set; }
        public string LocationOfProduct { get; private set; }
        public string State { get; private set; }


        public string GetInfoAboutProduct()
        {
            return NewLine + "Название : " + this.Name + NewLine + "Описание : " + this.Description + NewLine + "Цена : " + this.Price + NewLine +
                "Дата изготовления :" + this.CreationDate + NewLine + "Дата последнего изменения : " + this.LastModifiedDate + NewLine +
                "Категория : " + Category + NewLineX2 + "Контакты производителя : " + this.Author.Login + NewLine + "Телефон : " + this.Author.PhoneNumber + NewLine +
                "Почта : " + this.Author.Email + NewLineX2 + "Местоположение товара : " + this.LocationOfProduct + NewLine + "Состояние : " + this.State + NewLineX2;
        }


    }
}
