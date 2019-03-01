using System.Data.SqlClient;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;

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
