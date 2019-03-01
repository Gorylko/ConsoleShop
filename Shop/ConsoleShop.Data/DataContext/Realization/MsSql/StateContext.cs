using System.Data.SqlClient;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Data.DataContext.Interfaces;

namespace ConsoleShop.Data.DataContext.Realization.MsSql
{
    public class StateContext : IProductDetailsContext
    {
        public int GetIdByName(string name)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [State] WHERE [Name] = '{name}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return (int)reader["State"];
            }
        }
    }
}
