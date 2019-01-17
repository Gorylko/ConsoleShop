using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleShop
{
    class GoodsDataMapper : IDataMapper<SqlDataReader, Goods>
    {

        public Goods GetMappedObject()
        {
            string connectionString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=MyProjects;Integrated Security=True";
            string commandString = "SELECT * FROM Goods";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    return new Goods((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (string)reader.GetValue(3), (int)reader.GetValue(4));
                }
                return null;
            }
        }
    }
}
