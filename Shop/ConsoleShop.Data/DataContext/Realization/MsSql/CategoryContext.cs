using System.Collections.Generic;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Data.DataContext.Interfaces;

namespace ConsoleShop.Data.DataContext.Realization.MsSql
{
    public class CategoryContext : ICategoryContext
    {
        public string GetAllString()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                string allCategories = "";
                var command = new SqlCommand("SELECT * FROM Category", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        allCategories += reader.GetInt32(0) + "." + reader.GetString(1) + Typography.NewLine;
                    }
                }
                return allCategories;
            }
        }

        public IReadOnlyCollection<string> GetAll()
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<string> allCategories = new List<string>();
                var command = new SqlCommand("SELECT * FROM Category", connection);
                SqlDataReader reader = command.ExecuteReader();

                while (reader.Read())
                {
                    allCategories.Add(reader["CategoryName"].ToString());
                }
                return allCategories;
            }
        }

        public string GetById(int id)
        {
            using (var connection = new SqlConnection("Data Source=LAPTOP-P3338OQH;Initial Catalog=ConsoleShop;Integrated Security=True"))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"SELECT TOP 1 * FROM [Category] WHERE [CategoryId] = {id}", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return reader["CategoryName"].ToString();
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [Category] WHERE [CategoryId] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Save(string category)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"INSERT INTO [Category] (CategoryName) VALUES ('{category}')", connection);
                command.ExecuteNonQuery();
            }
        }

        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Category] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["Name"];
            }
        }
    }
}
