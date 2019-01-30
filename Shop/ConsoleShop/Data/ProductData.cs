using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
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
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                var productcommand = new SqlCommand("SELECT * FROM Product", connection);
                SqlDataReader productreader = productcommand.ExecuteReader();
                var categorycommand = new SqlCommand($"SELECT * FROM Category WHERE CategoryId = {categoryId}", connection);
                SqlDataReader categoryreader = categorycommand.ExecuteReader();
                var authorcommand = new SqlCommand($"SELECT * FROM User WHERE UserId = {productreader["UserId"]}");
                SqlDataReader authorreader = authorcommand.ExecuteReader();
                var locationcommand = new SqlCommand($"SELECT * FROM Location WHERE LocationId = {productreader["LocationId"]}");
                SqlDataReader locationreader = authorcommand.ExecuteReader();
                var statecommand = new SqlCommand($"SELECT * FROM ProductState WHERE StateId = {productreader["StateId"]}");
                SqlDataReader statereader = authorcommand.ExecuteReader();

                if (productreader.HasRows)
                {
                    while(productreader.Read())
                    {
                        if((int)productreader["CategoryId"] == categoryId)
                        {
                            products.Add(new Product(
                                (int)productreader["Id"],
                                (string)productreader["Name"],
                                (string)productreader["Description"],
                                (int)productreader["Price"],
                                (string)productreader["CreationDate"],
                                (string)productreader["LastModifiedDate"],
                                (string)categoryreader["Name"],
                                new Users.User((string)authorreader["Login"], (string)authorreader["Email"], (string)authorreader["PhoneNumber"]),
                                (string)locationreader["Location"],
                                (string)statereader["State"]
                                ));
                        }
                    }
                }
                return products;
            }
        }
    }
}
