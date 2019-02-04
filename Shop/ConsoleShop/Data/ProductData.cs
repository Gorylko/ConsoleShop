using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using ConsoleShop.Products;
using System.Data.SqlClient;
using ConsoleShop.Users;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Data
{
    class ProductData
    {
        public string GetAllCategories()
        {
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                string allCategories = "";
                var command = new SqlCommand("SELECT * FROM Category", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allCategories += reader.GetInt32(0) + "." + reader.GetString(1) + NewLine;
                    }
                }
                return allCategories;
            }
        }

        public List<Product> GetSpecificCategoryList(int categoryId)
        {
            string query = "USE ConsoleShop" + NewLine +
                "SELECT Product.*, [Category].[CategoryName] AS [Category], [Location].[LocationName] AS [Location], [ProductState].[State] AS [State], [Role].[RoleName] AS [Role], [User].[Login] AS [Login], [User].[Email] AS [Email], [User].[PhoneNumber] AS [PhoneNumber] " + NewLine +
                "FROM [Product]" + NewLine +
                "JOIN [Category] ON [Product].[CategoryId] = [Category].CategoryId" + NewLine +
                "JOIN [Location] ON [Product].[LocationId] = [Location].LocationId" + NewLine +
                "JOIN [ProductState] ON [Product].[StateId] = [ProductState].StateId" + NewLine +
                "JOIN [User] ON [Product].[UserId] = [User].[UserId]" + NewLine +
                "JOIN [Role] ON [User].[RoleId] = [Role].[RoleId]";
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                List<Product> products = new List<Product>();
                connection.Open();
                var productcommand = new SqlCommand(query, connection);
                SqlDataReader reader = productcommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if ((int)reader["CategoryId"] == categoryId) //Проблемное место ;(
                        {
                            try
                            {
                                products.Add(new Product
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
                                        Role = (RoleType)Enum.Parse(typeof(RoleType),(string)(reader["Role"]))
                                    },
                                    LocationOfProduct = (string)reader["Location"],
                                    State = (string)reader["State"]
                                });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Что-то произошло... Инфо об ошибке : ");
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Нажмите любую клавишу, чтобы пройти дальше");
                                Console.ReadKey(true);
                            }
                        }
                    }
                }
                return products;
            }
        }
    }
}
