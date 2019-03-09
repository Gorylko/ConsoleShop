using System.Text;
using System;
using Typography = Shop.Shared.Constants.TypographyConstants;

namespace Shop.Shared.Entities
{
    public class Product
    {
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
            returnString.AppendLine((this.Author.Role).ToString());
            returnString.AppendLine(this.Author.Login);
            returnString.AppendLine(this.Author.PhoneNumber);
            returnString.AppendLine(this.Author.Email);
            returnString.AppendLine($"Местоположение товара : {this.LocationOfProduct}");
            returnString.AppendLine($"Состояние : {this.State}{Typography.NewLineX2}");
            return returnString.ToString();
        }

        
    }
}
