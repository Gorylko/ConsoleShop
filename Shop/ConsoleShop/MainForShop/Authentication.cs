using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.MainForShop
{
    public static class Authentication // с помощью папочки Data будет производить авторизацию, регистрацию, открывать менюшку
    {
        //public static User Authenticate(this User user)
        //{
        //    return;
        //}
        //public static T Registration<T>(this T user)
        //{

        //}
        public static string GetStringMenu<T>(this T user)
        {
            return "Авторизация - пиши /a" + NewLine + "Нету аккаунта? - пиши /r" + NewLine + "Войти как гость /g" + NewLine + "Выйти - пиши /e" + NewLine;
        }
        public static void OpenAuthorizationMenu(this Shop shop)
        {
            while (true)
            {
                Console.Clear();
                Console.Write(shop.GetStringMenu());
                switch (Console.ReadLine().Replace(" ", string.Empty))
                {
                    case "/a":

                        break;
                    case "/r":
                        break;
                    case "/g":
                        LoginAsAGuest(shop);
                        break;
                    case "/e":
                        return;
                    default:
                        break;
                }
            }
        }
        public static void OpenRegistrationMenu(this Shop shop) //еще разрабатывается
        {
            while (true)
            {
                Console.WriteLine("Введите логин ");
                if (true)
                    break;
                Console.WriteLine("Данный логин занят!");
            }
            Console.WriteLine("Введите пароль ");
            while (true)
            {
                Console.WriteLine("Введите вашу почту ");
                if (true)
                    break;
                Console.WriteLine("Данная почта занята!");
            }

        }
        public static void LoginAsAGuest(Shop shop)
        {
            User user = new User();
            shop.MainUser = user;
            shop.OpenMainMenu();
        }
    }
}
