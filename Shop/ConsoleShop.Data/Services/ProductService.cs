using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Services
{
    class ProductService
    {
        public IReadOnlyCollection<Product> GetProductsByCategoryId(int categoryId)
        {
            List<Product> products = new List<Product>();
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                using (var command = new SqlCommand(SelectProductInDbString, connection))
                {
                    using (SqlDataReader reader = command.ExecuteReader())
                    {
                        while (reader.Read())
                        {
                            if ((int)reader["CategoryId"] == categoryId)
                            {
                                try //создать отдельный метод создания объектов
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
                                            Role = ConvertToRoleType((string)reader["Role"])
                                        },
                                        LocationOfProduct = (string)reader["Location"],
                                        State = (string)reader["State"]
                                    });
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
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                List<Product> products = new List<Product>();
                var command = new SqlCommand(SelectProductInDbString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        if (reader[searchParameter].ToString().Contains(searchQuery))
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
                                        Role = ConvertToRoleType((string)reader["Role"])
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
