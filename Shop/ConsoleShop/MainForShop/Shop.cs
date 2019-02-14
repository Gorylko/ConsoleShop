using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Shared.Entities.Enums;
using ConsoleShop.Business.Data;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;

namespace ConsoleShop.MainForShop
{
    public class Shop
    {
        #region Shop
        private List<Product> Catalog { get; set; }
        public User MainUser { get; set; }
        private ProductData _dataTool;
        private CategoryData _categoryTool;
        private UserSystem _system;

        public Shop()
        {
            _dataTool = new ProductData();
            _system = new UserSystem();
        }

        public void OpenMainMenu()
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

        private string GetMainMenuString()
        {
            string mainmenustring = "Напишите цифру нужного раздела:" + Typography.NewLine + "1.Воспользоваться навигацией" + Typography.NewLine + "2.Открыть поиск" + Typography.NewLine;
            if (MainUser == null)
            {
                return mainmenustring + Typography.NewLine + "Чтобы вернуться назад - пиши /r" + Typography.NewLine;
            }

            if (MainUser.HasRole(RoleType.User))
            {
                mainmenustring += "3.Посмотреть список своих товаров" + Typography.NewLine + "4.Открыть свой профиль";
            }

            if (MainUser.HasRole(RoleType.Moderator))
            {
                mainmenustring += "5.(!!!)Редактировать товары";
            }

            if (MainUser.HasRole(RoleType.Administrator))
            {
                mainmenustring += "6.(!!!)Редактировать пользователей";
            }

            return mainmenustring + Typography.NewLine + "Чтобы вернуться назад - пиши /r" + Typography.NewLine;
        }
        private string GetSearchMenuString()
        {
            return "Выберите по какому полю вы хотите начать поиск :" + Typography.NewLineX2 +
                "1.Имя" + Typography.NewLine + "2.Описание" + Typography.NewLine + "3.Место производства" + Typography.NewLine +
                "4.Дата производства" + Typography.NewLine + "5.Логин пользователя" + Typography.NewLineX2 + "6.Назад";
        }

        private void OpenCategorySelectionMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите категорию : ");
                Console.WriteLine(_categoryTool.GetCategoryString());
                OpenASpecificCategory(Console.ReadLine().Replace(" ", string.Empty));
            }
        }
        private void OpenASpecificCategory(string key)
        {
            if(!int.TryParse(key, out int output)) //прогуглить что это такое
            {
                return;
            }

            IReadOnlyCollection<Product> productsInCategory = _dataTool.GetProductsByCategoryId(int.Parse(key));
            Console.Clear();
            foreach (Product product in productsInCategory)
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
            if (!products.Any())
            {
                Console.Write("Ничего не найдено :(" + Typography.NewLine + "Нажми любую клавишу, чтобы вернуться назад...");
            }
            Console.ReadKey(true);
        }
        #endregion

        #region Authorization
        public string GetAuthorizationMenuString()
        {
            return "Авторизация - пиши /a" + Typography.NewLine + "Нету аккаунта? - пиши /r" + Typography.NewLine + "Войти как гость /g" + Typography.NewLine + "Выйти - пиши /e" + Typography.NewLine;
        }

        public void OpenAuthorizationMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(GetAuthorizationMenuString());
                switch (ReadCurrentLine())
                {
                    case "/a":
                        OpenAccountLoginMenu();
                        break;
                    case "/r":
                        OpenRegistrationMenu();
                        break;
                    case "/g":
                        LoginAsGuest();
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
                Console.WriteLine("1.Авторизироваться" + Typography.NewLine + "2.Назад");
                switch (Console.ReadLine().Replace(" ", string.Empty))
                {
                    case "1":

                        try
                        {
                            Console.WriteLine("Введите логин : ");
                            string password = Console.ReadLine();
                            Console.WriteLine("Введите пароль : ");
                            string login = Console.ReadLine();
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
        public void LoginAsGuest()
        {
            OpenMainMenu();
        }
        #endregion

        private string ReadCurrentLine() //повтыкать
        {
            return Console.ReadLine().Replace(" ", string.Empty);
        }
    }
}
