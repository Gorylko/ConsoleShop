using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.MainForShop;
using ConsoleShop.Shared.Constants;

namespace ConsoleShop
{
    class Program
    {
        static void Main()
        {
            Console.ForegroundColor = ColorConstants.DefaultColor;
            var aglyExspress = new Shop();
            aglyExspress.OpenFirstMenu();
        }
    }
}
