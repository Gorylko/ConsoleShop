using System;
using System.Collections.Generic;
using System.Linq;
using ConsoleShop.Shared.Entities;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Data.DataContext.Interfaces;
using ConsoleShop.Shared.Helpers;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.DataContext.Realization.MsSql
{
    public class LocationContext
    {
        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [Location] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["State"];
            }
        }

    }
}
