using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShopLibrary.Methods
{
    public static class Authentication // с помощью папочки Data будет производить авторизацию, регистрацию, открывать менюшку
    {
        public static T Authenticate<T>(this T user)
        {
            return;
        }
        public static T Registration<T>(this T user)
        {

        }
        public static string GetStringMenu<T>(this T user)
        {
            return "Authorization - write /a" + NewLine + "Don't have an account? - write /r" + NewLine;
        }
    }
}
