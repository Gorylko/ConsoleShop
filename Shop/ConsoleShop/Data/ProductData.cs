using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Products;
using System.Data.SqlClient;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.Data
{
    class ProductData
    {
        public List<Product> GetProductList(string category)
        {
            List<Product> productList;
            using (SqlConnection connection = new SqlConnection(ConnectionToConsoleShopString))
            {

                return productList;
            }
        }
    }
}
