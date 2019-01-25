using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Products;
using ConsoleShop.Users;

namespace ConsoleShop.Shop
{
    public class Shop
    {
        public Shop(User user)
        {
            this.MainUser = user;
        }

        private List<Goods> _stock { get; set; }
        public User MainUser { get; private set; }
           
    }
}
