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

namespace ConsoleShop.Data.Data
{
    public class ProductData
    {
        UserData _userdata = new UserData();

        public List<Product> GetSearchListFromDb(string searchParameter, string searchQuery)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    if (reader[searchParameter].ToString().Contains(searchQuery))
                    {
                        try
                        {
                            products.Add(GetProduct(reader));
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

        public IReadOnlyCollection<Product> GetProductsByCategoryIdFromDb(int categoryId)
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                using (var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((int)reader["CategoryId"] == categoryId)

                            {
                                try
                                {
                                    products.Add(GetProduct(reader));
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

        public Product GetProduct(SqlDataReader reader)
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
                Author = _userdata.GetUser(reader),
                LocationOfProduct = (string)reader["Location"],
                State = (string)reader["State"]
            };
        }

        public Product GetProductById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                string query = SqlConst.SelectAllProductInDbString + Typography.NewLine + $"WHERE [Id] = {id}";
                var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();

                reader.Read();
                return GetProduct(reader);
            }
        }

        public IReadOnlyCollection<Product> GetAllProducts()
        {
            List<Product> returnProducts = new List<Product>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                var command = new SqlCommand(SqlConst.SelectAllProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        returnProducts.Add(GetProduct(reader));
                    }
                    catch (SqlException)
                    {

                    }
                }
                return returnProducts;
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [Product] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }


    }
}
