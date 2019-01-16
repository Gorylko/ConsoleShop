using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;

namespace ConsoleShop
{
    class DbContext
    {
        public void ExecuteSqlQuery(string query, IDataMapper<Goods> datamapper)
        {
            string connectionString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=MyProjects;Integrated Security=True";
            using (var connection = new SqlConnection(connectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
