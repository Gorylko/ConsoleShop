﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Shared.Entities
{
    public class Product
    {
        //public Product(int id, string name, string description, decimal price, DateTime creationdate, DateTime modifieddate, string category, User author, string locationofproduct, string state)
        //{
        //    Id = id;
        //    Name = name;
        //    Description = description;
        //    Price = price;
        //    CreationDate = creationdate;
        //    LastModifiedDate = modifieddate;
        //    Category = category;
        //    Author = author;
        //    LocationOfProduct = locationofproduct;
        //    State = state;
        //}

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


        public string GetInfoAboutProduct() // Через StringBuilder
        {
            StringBuilder returnString = new StringBuilder();
            returnString.AppendLine($"Название : {this.Name}");
            returnString.AppendLine($"Описание : {this.Description}");
            returnString.AppendLine($"Цена : {this.Price}");
            returnString.AppendLine($"Дата изготовления: {this.CreationDate}");
            returnString.AppendLine($"Дата последнего изменения : {this.LastModifiedDate}");
            returnString.AppendLine($"Категория : {this.Category}");
            returnString.AppendLine($"Контакты производителя : ");
            returnString.AppendLine(this.Author.Role);
            returnString.AppendLine(this.Author.Login);
            returnString.AppendLine(this.Author.PhoneNumber);
            returnString.AppendLine(this.Author.Email);
            returnString.AppendLine($"Местоположение товара : {this.LocationOfProduct}");
            returnString.AppendLine($"Состояние : {this.State}");
            return returnString.ToString();
        }


    }
}