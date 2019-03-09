using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Shared.Entities.Enums;
using ConsoleShop.Business.Services;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;

namespace ConsoleShop.MainForShop
{
    public class Shop
    {
        #region Shop
        private List<Product> Catalog { get; set; }
        public User MainUser { get; set; }
        private ProductService _productService;
        private CategoryService _categoryService;
        private UserService _userService;

        public Shop() 
        {
            _productService = new ProductService();
            _userService = new UserService();
            _categoryService = new CategoryService();
        }

        public void OpenMainMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.Write(GetMainMenuString());
                switch (ReadCurrentLine())
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
                        MainUser = null;
                        return;
                    default:
                        break;

                }
            }
        }

        private string GetMainMenuString()
        {
            StringBuilder menuString = new StringBuilder();
            menuString.AppendLine("Напишите цифру нужного раздела:");
            menuString.AppendLine("1.Воспользоваться навигацией");
            menuString.AppendLine("2.Открыть поиск");

            if(MainUser == null)
            {
                menuString.AppendLine("Чтобы вернуться назад - пиши /r");
                return menuString.ToString();
            }

            if (MainUser.HasRole(RoleType.User))
            {
                menuString.AppendLine("3.Посмотреть список своих товаров");
                menuString.AppendLine("4.Открыть свой профиль");
            }

            if (MainUser.HasRole(RoleType.Moderator))
            {
                menuString.AppendLine("5.(!!!)Редактировать товары");
            }

            if (MainUser.HasRole(RoleType.Administrator))
            {
                menuString.AppendLine("6.(!!!)Редактировать пользователей");
            }

            menuString.AppendLine("Чтобы выйти из аккаунта - пиши /r");
            return menuString.ToString();
        }
        private string GetSearchMenuString()
        {
            StringBuilder menuString = new StringBuilder();
            menuString.AppendLine("Выберите по какому полю вы хотите начать поиск :");
            menuString.AppendLine("1.Имя");
            menuString.AppendLine("2.Описание");
            menuString.AppendLine("3.Место производства");
            menuString.AppendLine("4.Дата производства");
            menuString.AppendLine("5.Логин пользователя");
            menuString.AppendLine("6.Назад");
            return menuString.ToString();
        }

        private void OpenCategorySelectionMenu()
        {
            while (true)
            {
                Console.Clear();
                Console.WriteLine("Выберите категорию : ");
                Console.WriteLine(_categoryService.GetCategoryString());
                string key = ReadCurrentLine();

                if(key == "/r")
                {
                    return;
                }

                OpenASpecificCategory(key);
            }
        }
        private void OpenASpecificCategory(string key)
        {
            if (!int.TryParse(key, out int output)) //прогуглить что это такое
            {
                return;
            }

            IReadOnlyCollection<Product> productsInCategory = _productService.GetProductsByCategoryId(int.Parse(key));
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
                switch (ReadCurrentLine())
                {
                    case "1":
                        OpenSearchMenu("Name");
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
            IReadOnlyCollection<Product> products = _productService.GetSearchList(searchParameter, ReadCurrentLine());
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
            StringBuilder menuString = new StringBuilder();
            menuString.AppendLine("Авторизация - пиши /a");
            menuString.AppendLine("Нету аккаунта? - пиши /r");
            menuString.AppendLine("Войти как гость - пиши /g");
            menuString.AppendLine("Выйти - пиши /e");
            return menuString.ToString();
        }

        public void OpenFirstMenu()
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
                Console.Clear();
                Console.WriteLine("1.Зарегистрироваться" + Typography.NewLine + "2.Назад");
                switch (ReadCurrentLine())
                {
                    case "1":

                        try
                        {
                            Console.WriteLine("Введите логин : ");
                            string login = Console.ReadLine();
                            Console.WriteLine("Введите пароль : ");
                            string password = Console.ReadLine();
                            Console.WriteLine("Введите почту");
                            string email = Console.ReadLine();
                            Console.WriteLine("Введите ваш телефон");
                            string phonenumber = Console.ReadLine();

                            MainUser = _userService.GetRegistratedUser(login, password, email, phonenumber);
                            Console.WriteLine("Регистрация завершена успешно!");
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
                OpenMainMenu(); //вход в магаз с уже полученным юзером
            }

        }
        private void OpenAccountLoginMenu()
        {
                Console.Clear();
                try
                {
                    Console.WriteLine("Введите логин : ");
                    string login = Console.ReadLine();
                    Console.WriteLine("Введите пароль : ");
                    string password = Console.ReadLine();
                    MainUser = _userService.GetAuthorizedUser(login, password);
                    Console.WriteLine("Авторизация завершена успешно!");
                    Console.ReadKey();
                }
                catch (Exception ex)
                {
                    Console.WriteLine(ex.Message);
                    Console.ReadKey(true);
                }
                OpenMainMenu(); //вход в магаз с уже полученным юзером
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
