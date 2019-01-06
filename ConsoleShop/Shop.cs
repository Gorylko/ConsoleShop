using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using static ConsoleShop.Constants;

namespace ConsoleShop
{
    class Shop
    {
        #region Объявления всякого
        public Shop(int bal)
        {
            _balance = bal;
        }
        private int _balance;
        public int Balance
        {
            get
            {
                return _balance;
            }
            set
            {
                if (value >= -10)
                    _balance = value;
                else
                    _balance = -10;
            }
        }
        private static List<Goods> _eat = new List<Goods>();
        private static List<Goods> _forHouse = new List<Goods>();
        private static List<Goods> _dress = new List<Goods>();
        #endregion

        public void OpenMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.ForegroundColor = GreenColor;
                Console.WriteLine(" Выберите раздел(/название раздела)");
                Console.WriteLine(" Еда (/eat)");
                Console.WriteLine(" Дом и быт(/forhouse)");
                Console.WriteLine(" одежда(/dress)");
                Console.WriteLine(" Выход из магазина(/exit)");
                switch (Console.ReadLine())
                {
                    case "/eat":
                        PrintGoods(_eat);
                        Console.ReadKey();
                        break;
                    case "/forhouse":
                        PrintGoods(_forHouse);
                        Console.ReadKey();
                        break;
                    case "/dress":
                        PrintGoods(_dress);
                        Console.ReadKey();
                        break;
                    case "/exit":
                        return;
                    default:
                        Console.Write("Некорректный ввод или разработчик дибил");
                        Thread.Sleep(2000);
                        break;
                }
            }
        }
        public void PrintGoods(List<Goods> a)
        {
            Console.Clear();
            Console.ForegroundColor = GreenColor;
            Console.WriteLine("\t\tВсего товаров : {0}", a.Count);
            Console.ForegroundColor = DefaultColor;
            foreach (Goods el in a)
            {
                if (el.Price > Balance)
                {
                    Console.ForegroundColor = RedColor;
                }
                Console.Write(el.PrintInfo());
                Console.ResetColor();
            }
            Console.ForegroundColor = GreenColor;
            Console.Write("\t\tБаланс : {0} Бульболларов", Balance);
            Console.ForegroundColor = DefaultColor;
        }






        public static void FillUpTheGoods()
        {
            Goods h001 = new Goods("Zeva", "PaperIndustry", 18);
            _forHouse.Add(h001);

            Goods e001 = new Goods("Coca-Salo", "BelUkra", 45);
            Goods e002 = new Goods("Kit-Cat", "Mogilev meat processing plant", 116);
            Goods e003 = new Goods("BonChakra", "Yoga Products Industry", 36);
            _eat.Add(e001);
            _eat.Add(e002);
            _eat.Add(e003);

            Goods d001 = new Goods("Underpants", "Supreme", 999999);
            _dress.Add(d001);
        }

    }
}
