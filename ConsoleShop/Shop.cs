using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static ConsoleShop.Constants;
using System.Data.SqlClient;

namespace ConsoleShop
{
    class Shop
    {
        public Shop(User us)
        {
            Consumer = us;
        }
        private List<Goods> _goodsList = new List<Goods>();
        public User Consumer { get; private set; }


        public void OpenMenu() // Пока не пашет
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = GreenColor;
                Console.WriteLine(Tab + "Выберите раздел(/название раздела)");
                Console.WriteLine(Tab + "Еда (/eat)");
                Console.WriteLine(Tab + "Дом и быт(/forhouse)");
                Console.WriteLine(Tab + "Одежда(/dress)");
                Console.WriteLine(Tab + "Выход из магазина(/exit)" + NewLineX2 + NewLineX2 + "============================================================");
                //switch (Console.ReadLine())
                //{
                //    case "/eat":
                //        PrintGoods(_eat);
                //        Console.ReadKey();
                //        break;
                //    case "/forhouse":
                //        PrintGoods(_forHouse);
                //        Console.ReadKey();
                //        break;
                //    case "/dress":
                //        PrintGoods(_dress);
                //        Console.ReadKey();
                //        break;
                //    case "/exit":
                //        return;
                //    default:
                //        Console.Write("Некорректный ввод или разработчик дибил");
                //        Thread.Sleep(2000);
                //        break;
                //}
            }
        }

        public void PrintGoods(List<Goods> a)
        {
            Console.Clear();
            Console.ForegroundColor = GreenColor;
            Console.WriteLine(TabX2 + "Всего товаров : {0}", a.Count);
            Console.ForegroundColor = DefaultColor;
            foreach (Goods el in a)
            {
                if (el.Price > Consumer.Balance)
                {
                    Console.ForegroundColor = RedColor;
                }
                Console.Write(el.PrintInfo());
                Console.ResetColor();
            }
            Console.ForegroundColor = GreenColor;
            Console.Write(TabX2 + "Баланс : {0} Бульболларов", Consumer.Balance);
            Console.ForegroundColor = DefaultColor;
        }






        public void FillUpTheGoods()
        {
            var dbcont = new DbContext();

            for (int i = 1; i <= dbcont.GetRowsCount(); i++)
            {
                _goodsList.Add(dbcont.ExecuteSqlQuery(string.Format("Select * From Goods Where Id = {0}", i)));
            }
        }

    }
}
