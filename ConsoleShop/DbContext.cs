using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
using static ConsoleShop.Constants;

namespace ConsoleShop
{
    class DbContext
    {
        public int GetRowsCount()
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                int count = 0;
                connection.Open();
                var command = new SqlCommand("SELECT * FROM Goods", connection);
                SqlDataReader reader = command.ExecuteReader();
                if(reader.HasRows)
                {
                    while(reader.Read()) //Кастыль 
                    {
                        count++;
                    }
                }
                return count;
            }
        }
        public void ExecuteSqlQuery(string query, IDataMapper<SqlDataReader, Goods> datamapper) //пока не знаю как это использовать
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
            }
            //return datamapper.GetMappedObject();
        }
        public Goods ExecuteSqlQuery(string query)
        {
            using (var connection = new SqlConnection(ConnectionString))
            {
                connection.Open();
                var command = new SqlCommand(query, connection);
                command.ExecuteNonQuery();
                var datamapper = new GoodsDataMapper();
                return datamapper.GetMappedObject();
            }

        }
    }
}
