using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Shop.MainForShop;
using Shop.Shared.Constants;

namespace Shop
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ColorConstants.DefaultColor;
            var aglyExspress = new ConsoleShop();
            aglyExspress.OpenFirstMenu();
        }
    }
}
