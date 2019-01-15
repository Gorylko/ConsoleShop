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
                Console.WriteLine(Tab + "Выберите раздел(/название раздела)");
                Console.WriteLine(Tab + "Еда (/eat)");
                Console.WriteLine(Tab + "Дом и быт(/forhouse)");
                Console.WriteLine(Tab + "Одежда(/dress)");
                Console.WriteLine(Tab + "Выход из магазина(/exit)" +NewLineX2 + NewLineX2 + "============================================================");
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
            Console.WriteLine(TabX2 + "Всего товаров : {0}", a.Count);
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
            Console.Write(TabX2 + "Баланс : {0} Бульболларов", Balance);
            Console.ForegroundColor = DefaultColor;
        }






        public static void FillUpTheGoods()
        {
            string connectionString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=MyProjects;Integrated Security=True";
            string commandString = "SELECT * FROM Goods";
            using (SqlConnection connection = new SqlConnection(connectionString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand(commandString, connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
                {
                    while (reader.Read())
                    {
                        switch(reader.GetValue(3))
                        {
                            case "Dress":
                                _dress.Add(new Goods((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (int)reader.GetValue(4)));
                                break;
                            case "Eat":
                                _eat.Add(new Goods((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (int)reader.GetValue(4)));
                                break;
                            case "ForHouse":
                                _forHouse.Add(new Goods((int)reader.GetValue(0), (string)reader.GetValue(1), (string)reader.GetValue(2), (int)reader.GetValue(4)));
                                break;
                            default:
                                Console.WriteLine("Ошибка в базе данных, столбец \"категория\"");
                                Thread.Sleep(1000);
                                Environment.Exit(0);
                                break;
                        }
                    }
                }
            }
        }

    }
}
