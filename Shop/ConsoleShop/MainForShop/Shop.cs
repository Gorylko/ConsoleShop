using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Products;
using ConsoleShop.Users;
using ConsoleShop.Data;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.MainForShop
{
    public class Shop
    {
        #region Shop
        private List<Product> _catalog { get; set; }
        public User MainUser { get; set; }

        public void OpenMainMenu() //1
        {
            while (true)
            {
                Console.Clear();
                Console.Write(GetMainMenuString());
                switch (Console.ReadLine().Replace(" ", string.Empty))
                {
                    case "1":
                        OpenCategorySelectionMenu();
                        break;
                    case "2":
                        break;
                    case "3":
                        break;
                    case "4":
                        break;
                    case "5":
                        break;
                    case "6":
                        break;
                    case "/r":
                        return;
                    default:
                        break;

                }
            }
        }

        private string GetMainMenuString()//2
        {
            string mainmenustring = "Напишите цифру нужного раздела:" + NewLine + "1.Воспользоваться навигацией" + NewLine + "2.Открыть поиск" + NewLine;
            try
            {
                if ((int)MainUser.Role > 0)
                    mainmenustring += "3.Посмотреть список своих товаров" + NewLine + "4.Открыть свой профиль";
                if ((int)MainUser.Role > 1)
                    mainmenustring += "5.(!!!)Редактировать товары";
                if ((int)MainUser.Role > 2)
                    mainmenustring += "6.(!!!)Редактировать пользователей";
                return mainmenustring + NewLine + "Чтобы вернуться назад - пиши /r" + NewLine;
            }
            catch(NullReferenceException)
            {
                return mainmenustring + NewLine + "Чтобы вернуться назад - пиши /r" + NewLine;
            }
        }


        private void OpenCategorySelectionMenu() 
        {
            Console.Clear();
            var data = new ProductData();
            Console.WriteLine("Выберите категорию : ");
            Console.WriteLine(data.GetAllCategories());
            OpenASpecificCategory(Console.ReadLine().Replace(" ", string.Empty));
        }
        private void OpenASpecificCategory(string key)
        {
            var data = new ProductData();
            List<Product> productsincategory = data.GetSpecificCategoryList(int.Parse(key)); 
            foreach(Product product in productsincategory)
            {
                product.GetInfoAboutProduct();
            }
        }
        #endregion

        #region Authorization
        public string GetAuthorizationMenuString()
        {
            return "Авторизация - пиши /a" + NewLine + "Нету аккаунта? - пиши /r" + NewLine + "Войти как гость /g" + NewLine + "Выйти - пиши /e" + NewLine;
        }
        public void OpenAuthorizationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(GetAuthorizationMenuString());
                switch (Console.ReadLine().Replace(" ", string.Empty))
                {
                    case "/a":

                        break;
                    case "/r":
                        break;
                    case "/g":
                        LoginAsAGuest();
                        break;
                    case "/e":
                        return;
                    default:
                        break;
                }
            }
        }
        public void OpenRegistrationMenu() //еще разрабатывается
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
        public void LoginAsAGuest()
        {
            OpenMainMenu();
        }
        #endregion
    }
}
