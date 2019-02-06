using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using ConsoleShop.MainForShop;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = DefaultColor;
            var AglyExspress = new Shop();
            AglyExspress.OpenAuthorizationMenu();
        }
    }
}
