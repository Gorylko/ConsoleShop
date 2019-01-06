using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleShop.Constants;

namespace ConsoleShop
{
    class Program
    {
        static void Main(string[] args)
        {
            Console.ForegroundColor = DefaultColor;
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            Shop user1 = new Shop(37);
            Console.CursorVisible = false;
            Shop.FillUpTheGoods();
            user1.OpenMenu();
            Console.ReadKey();
        }
    }
}
