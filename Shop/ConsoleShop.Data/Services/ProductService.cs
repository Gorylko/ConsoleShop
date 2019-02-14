using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleShop.Shared.Entities;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Shared.Helpers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Services
{
    public class ProductService
    {


        public Product GetProduct(SqlDataReader reader) //отдельный метод создания объектов
        {
            return new Product
            {
                Id = (int)reader["Id"],
                Name = (string)reader["ProductName"],
                Description = (string)reader["Description"],
                Price = (decimal)reader["Price"],
                CreationDate = (DateTime)reader["CreationDate"],
                LastModifiedDate = (DateTime)reader["LastModifiedDate"],
                Category = (string)reader["Category"],
                Author = new User
                {
                    Login = (string)reader["Login"],
                    Email = (string)reader["Email"],
                    PhoneNumber = (string)reader["PhoneNumber"],
                    Role = RoleHelper.ConvertToRoleType((string)reader["Role"])
                },
                LocationOfProduct = (string)reader["Location"],
                State = (string)reader["State"]
            };
        }

    }
}
