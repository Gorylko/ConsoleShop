using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Data.Services;
using ConsoleShop.Shared.Helpers;

namespace ConsoleShop.Business.Data
{
    public class ProductData
    {
        private ProductService _productService = new ProductService();


        public IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                using (var command = new SqlCommand(SqlConst.SelectProductInDbString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((int)reader["CategoryId"] == categoryId)
                       
     {
                                try
                                {
                                    products.Add(_productService.GetProduct(reader));
                                }
                                catch (SqlException ex)
                                {
                                    Console.WriteLine("Что-то произошло... Инфо об ошибке : ");
                                    Console.WriteLine(ex.Message);
                                    Console.WriteLine("Нажмите любую клавишу, чтобы пройти дальше");
                                    Console.ReadKey(true);
                                }
                            }
                        }
                    }
                }

                return products;
            }
        }

        public List<Product> GetSearchList(string searchParameter, string searchQuery)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                var command = new SqlCommand(SqlConst.SelectProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[searchParameter].ToString().Contains(searchQuery))
                    {
                        try
                        {
                            products.Add(_productService.GetProduct(reader));
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

                return products;
            }
        }

    }
}
