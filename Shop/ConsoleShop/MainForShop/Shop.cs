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
        private List<Product> Catalog { get; set; }
        public User MainUser { get; set; }
        private ProductData _dataTool = new ProductData(); //решил закинуть сюда, чтобы не объявлять в каждом методе
        private UserSystem _system = new UserSystem();

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
                        OpenSearchSelectMenu();
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
            catch (NullReferenceException)
            {
                return mainmenustring + NewLine + "Чтобы вернуться назад - пиши /r" + NewLine;
            }
        }
        private string GetSearchMenuString()
        {
            return "Выберите по какому полю вы хотите начать поиск :" + NewLineX2 +
                "1.Имя" + NewLine + "2.Описание" + NewLine + "3.Место производства" + NewLine +
                "4.Дата производства" + NewLine + "5.Логин пользователя" + NewLineX2 + "6.Назад";
        }

        private void OpenCategorySelectionMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите категорию : ");
                Console.WriteLine(_dataTool.GetAllCategories());
                OpenASpecificCategory(Console.ReadLine().Replace(" ", string.Empty));
            }
        }
        private void OpenASpecificCategory(string key)
        {
            List<Product> productsincategory = _dataTool.GetSpecificCategoryList(int.Parse(key));
            Console.Clear();
            foreach (Product product in productsincategory)
            {
                Console.Write(product.GetInfoAboutProduct());
            }
            Console.ReadKey();
        }
        private void OpenSearchSelectMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine(GetSearchMenuString());
                switch (Console.ReadLine().Replace(" ", string.Empty))
                {
                    case "1":
                        OpenSearchMenu("ProductName");
                        break;
                    case "2":
                        OpenSearchMenu("Description");
                        break;
                    case "3":
                        OpenSearchMenu("Location");
                        break;
                    case "4":
                        OpenSearchMenu("CreationDate");
                        break;
                    case "5":
                        OpenSearchMenu("Login");
                        break;
                    case "6":
                        return;
                    default:
                        break;
                }
            }
        }
        private void OpenSearchMenu(string searchParameter)
        {
            Console.Clear();
            Console.WriteLine("Введите свой запрос :");
            List<Product> products = _dataTool.GetSearchList(searchParameter, Console.ReadLine().Replace(" ", string.Empty));
            foreach (Product product in products)
            {
                Console.WriteLine(product.GetInfoAboutProduct());
            }
            if (products.Count == 0)
            {
                Console.Write("Ничего не найдено :(" + NewLine + "Нажми любую клавишу, чтобы вернуться назад...");
            }
            Console.ReadKey(true);
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
                        OpenAccountLoginMenu();
                        break;
                    case "/r":
                        OpenRegistrationMenu();
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
        private void OpenRegistrationMenu() //еще разрабатывается
        {
            while (true)
            {
                Console.WriteLine("Введите логин ");
            }
        }
        private void OpenAccountLoginMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("1.Авторизироваться" + NewLine + "2.Назад");
                switch (Console.ReadLine().Replace(" ", string.Empty))
                {
                    case "1":
                        
                        try
                        {
                            Console.WriteLine("Введите логин : ");
                            string password = Console.ReadLine().Replace(" ", string.Empty);
                            Console.WriteLine("Введите пароль : ");
                            string login = Console.ReadLine().Replace(" ", string.Empty);
                            MainUser = _system.GetAuthorizedUser(login, password);
                            Console.WriteLine("Авторизация завершена успешно!");
                            Console.ReadKey();
                        }
                        catch (Exception ex)
                        {
                            Console.WriteLine(ex.Message);
                            Console.ReadKey(true);
                        }
                        break;
                    case "2":
                        return;
                }
            }
        }
        public void LoginAsAGuest()
        {
            OpenMainMenu();
        }
        #endregion
    }
}
