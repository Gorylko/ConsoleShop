using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Products;
using ConsoleShop.Users;
using ConsoleShopLibrary.Methods;

namespace ConsoleShop.Shop
{
    public class Shop
    {
        public Shop(User user)
        {
            this.MainUser = user;
        }

        private List<Product> _stock { get; set; }
        public User MainUser { get; private set; }
        public void OpenAuthorizationMenu()
        {
            Console.Write(MainUser.GetStringMenu());
        }
    }
}
