using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace ConsoleShop
{
    class Shop
    {
        #region Объявления всякого
        public Shop(int bal)
        {
            balance = bal;
        }
        private int balance;
        public int Balance
        {
            get
            {
                return balance;
            }
            set
            {
                if (value >= -10)
                    balance = value;
                else
                    balance = -10;
            }
        }
        private static List<Goods> Eat = new List<Goods>();
        private static List<Goods> ForHouse = new List<Goods>();
        private static List<Goods> Dress = new List<Goods>();
        #endregion



        public void OpenMenu()
        {
            Console.Clear();
            Console.WriteLine(" Выберите раздел(/название раздела)");
            Console.WriteLine(" Еда (/eat)");
            Console.WriteLine(" Дом и быт(/forhouse)");
            Console.WriteLine(" одежда(/dress)");
            Console.WriteLine(" Выход из магазина(/exit)");
            switch(Console.ReadLine())
            {
                case "/eat":
                    PrintGoods(Eat);
                    Console.ReadKey();
                    OpenMenu();
                    break;
                case "/forhouse":
                    PrintGoods(ForHouse);
                    Console.ReadKey();
                    OpenMenu();
                    break;
                case "/dress":
                    PrintGoods(Dress);
                    Console.ReadKey();
                    OpenMenu();
                    break;
                case "/exit":
                    Environment.Exit(0);
                    break;
                default:
                    Console.Write("Некорректный ввод или разработчик дибил");
                    Thread.Sleep(2000);
                    OpenMenu();
                    break;
            }
        }
        public void PrintGoods(List<Goods> a)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("\t\tВсего товаров : {0}", a.Count);
            Console.ResetColor();
            foreach (Goods el in a)
            {
                if (el.Price > Balance)
                    Console.ForegroundColor = ConsoleColor.Red;
                el.PrintInfo();
                Console.ResetColor();
            }
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("\t\tБаланс : {0} Бульболларов", Balance);
            Console.ResetColor();
        }






        public static void FillUpTheGoods()
        {
            Goods h001 = new Goods("Zeva", "PaperIndustry", 18);
            ForHouse.Add(h001);

            Goods e001 = new Goods("Coca-Salo", "BelUkra", 45);
            Goods e002 = new Goods("Kit-Cat", "Mogilev meat processing plant", 116);
            Goods e003 = new Goods("BonChakra", "Yoga Products Industry", 36);
            Eat.Add(e001);
            Eat.Add(e002);
            Eat.Add(e003);

            Goods d001 = new Goods("Underpants", "Supreme", 999999);
            Dress.Add(d001);
        }

    }
}
