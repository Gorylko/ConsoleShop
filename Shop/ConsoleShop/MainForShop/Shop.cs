using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Products;
using ConsoleShop.Users;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.MainForShop
{
    public class Shop
    {
        private List<Product> _catalog { get; set; }
        public User MainUser { get; set; }
        public void OpenMainMenu()
        {
            bool indicator = true;
            while (indicator)
            {
                Console.Clear();
                Console.Write(GetMainMenuString());
                SelectMenu(Console.ReadLine().Replace(" ", string.Empty),ref indicator);
            }
        }
        private string GetMainMenuString()
        {
            string mainmenustring = "Напишите цифру нужного раздела:" + NewLine + "1.Воспользоваться навигацией" + NewLine + "2.Открыть поиск" + NewLine;
            if ((int)MainUser.Role > 0)
                mainmenustring += "3.Посмотреть список своих товаров" + NewLine + "4.Открыть свой профиль";
            if ((int)MainUser.Role > 1)
                mainmenustring += "5.(!!!)Редактировать товары";
            if ((int)MainUser.Role > 2)
                mainmenustring += "6.(!!!)Редактировать пользователей";
            return mainmenustring + NewLine + "Чтобы вернуться назад - пиши /r" + NewLine;
        }
        private void SelectMenu(string key, ref bool indicator)
        {
            switch(key)
            {
                case "1":
                    OpenCategoryMenu();
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
                case "/e":
                    indicator = false;
                    break;
                default:
                    break;

            }
        }

        private void OpenCategoryMenu() 
        {
            GetCategoryString();
        }
        private string GetCategoryString() //с помощью папочки Data читает все категории и выписывает их 
        {
            string categorystring = "";
            return categorystring;
        }
    }
}
