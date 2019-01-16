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
        static void Main()
        {
            Console.ForegroundColor = DefaultColor;
            Console.SetWindowSize(60, 30);
            Console.SetBufferSize(60, 30);
            var user1 = new User(37);
            var AglyExspress = new Shop(user1);
            Console.CursorVisible = false;
            AglyExspress.FillUpTheGoods();
            AglyExspress.OpenMenu();
            Console.ReadKey();
        }
    }
}
