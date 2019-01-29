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
                    int num = 1;
                    while (reader.Read())
                    {
                        allCategories += $"{num}." + (string)reader.GetValue(1) + NewLine;
                        num++;
                    }
                }
                return allCategories;
            }
        }
    }
}
