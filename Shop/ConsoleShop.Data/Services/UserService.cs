using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Services
{
    class UserService
    {
        public User GetAuthorizedUser(string login, string password)
        {
            if(string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            using (var connection = new SqlConnection(ConnectionToConsoleShopString)) // Почитать как сделать sql command с параметрами
            {
                connection.Open();
                var command = new SqlCommand($"SELECT TOP 1 * FROM [User] WHERE [Login] = '{login}' AND [Password] = '{password}'", connection); //соединить с roles
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Role = ConvertToRoleType((int)reader["RoleId"])
                    };
                }
                else
                {
                    throw new Exception("Неверный логин или пароль"); //создать свой класс исключений
                }
            }
        }
        public User GetNewUser(string login, string password, string email, string phonenumber)
        {
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                try
                {
                    var command = new SqlCommand($"INSERT INTO User (RoleId, Login, Password, Email, PhoneNumber) VALUES (3, {login}, {password}, {email}, {phonenumber})", connection);
                    return new User
                    {
                        Login = login,
                        Password = password,
                        Email = email,
                        PhoneNumber = phonenumber,
                        Role = RoleType.User
                    };
                }
                catch (Exception)
                {
                    throw new Exception("Логин или почта уже заняты, попробуйте что-нибудь поменять :)");
                }
            }
        }
        private RoleType ConvertToRoleType(int roleid)
        {
            return (RoleType)roleid;
        }

    }
}
