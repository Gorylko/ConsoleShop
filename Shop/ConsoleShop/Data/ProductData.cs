using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using ConsoleShop.Products;
using System.Data.SqlClient;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Data
{
    class ProductData
    {
        //public List<Product> GetProductList(string category)
        //{
        //    List<Product> productList;
        //    using (SqlConnection connection = new SqlConnection(ConnectionToConsoleShopString))
        //    {

        //        return productList;
        //    }
        //}
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
            string query = "USE ConsoleShop; SELECT * FROM Product p " +
                "LEFT JOIN Category c ON p.CategoryId = c.CategoryId " +
                "LEFT JOIN ProductState s ON p.StateId = s.StateId " +
                "LEFT JOIN Location l ON p.LocationId = l.LocationId " +
                "LEFT JOIN [User] u ON p.UserId = u.UserId " +
                "LEFT JOIN Role r ON u.RoleId = r.RoleId;";
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                var productcommand = new SqlCommand(query, connection);
                SqlDataReader reader = productcommand.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {


                        if ((int)reader["CategoryId"] == categoryId)
                        {

                            products.Add(new Product(
                                (int)reader["Id"],
                                (string)reader["Name"],
                                (string)reader["Description"],
                                (decimal)reader["Price"],
                                (DateTime)reader["CreationDate"],
                                (DateTime)reader["LastModifiedDate"],
                                (string)reader["Name"],

                                new User((string)reader["Login"],
                                (string)reader["Password"],
                                (string)reader["Email"],
                                (string)reader["PhoneNumber"],
                                (RoleType)reader["RoleId"] - 1),

                                (string)reader["Location"],
                                (string)reader["State"]
                                ));
                        }
                    }
                }
                return products;
            }
        }
    }
}
