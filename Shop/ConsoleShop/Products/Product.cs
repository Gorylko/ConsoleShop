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
        public Product(int id, string name, string description, decimal price, DateTime creationdate, DateTime modifieddate, string category, User author, string locationofproduct, string state)
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

        public int Id { get; set; }
        public string Name { get; set; }
        public string Description { get; set; }
        public decimal Price { get; set; }
        public DateTime CreationDate { get; set; }
        public DateTime LastModifiedDate { get; set; }
        public string Category { get; set; }
        public User Author { get; set; }
        public string LocationOfProduct { get; set; }
        public string State { get; set; }


        public string GetInfoAboutProduct()
        {
            return NewLine + "Название : " + this.Name + NewLine + "Описание : " + this.Description + NewLine + "Цена : " + this.Price + NewLine +
                "Дата изготовления :" + this.CreationDate + NewLine + "Дата последнего изменения : " + this.LastModifiedDate + NewLine +
                "Категория : " + Category + NewLineX2 + "Контакты производителя : " + this.Author.Login + NewLine + "Телефон : " + this.Author.PhoneNumber + NewLine +
                "Почта : " + this.Author.Email + NewLineX2 + "Местоположение товара : " + this.LocationOfProduct + NewLine + "Состояние : " + this.State + NewLineX2;
        }


    }
}
