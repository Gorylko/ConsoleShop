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
            List<Product> products = new List<Product>();
            string query = "SELECT * FROM Product p " + NewLine +
                "SELECT P.*, C.[CategoryName], L.[LocationName], PS.[State], R.[RoleName], U.[Login], U.[Email], U.[PhoneNumber] " + NewLine +
                "FROM [Product] AS P, [Category] AS C, [Location] AS L, [ProductState] AS PS, [Role] AS R, [User] AS U " + NewLine +
                "WHERE P.CategoryId = C.CategoryId AND P.LocationId = L.LocationId AND P.StateId = PS.StateId AND P.UserId = U.UserId AND U.RoleId = R.RoleId ";
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
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
                                    Category = (string)reader["CategoryName"],
                                    Author = new User
                                    {
                                        Login = (string)reader["Login"],
                                        Email = (string)reader["Email"],
                                        PhoneNumber = (string)reader["PhoneNumber"],
                                        Role = (RoleType)(reader["RoleName"])
                                    },
                                    LocationOfProduct = (string)reader["LocationName"],
                                    State = (string)reader["State"]
                                });
                            }
                            catch (Exception ex)
                            {
                                Console.WriteLine("Что-то произошло... Инфо об ошибке : ");
                                Console.WriteLine(ex.Message);
                                Console.WriteLine("Нажмите любую клавишу, чтобы пройти дальше");
                            }
                            Console.ReadKey(true);
                        }
                    }
                }
                return products;
            }
        }
    }
}
