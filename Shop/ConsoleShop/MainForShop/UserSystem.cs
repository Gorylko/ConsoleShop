using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ConsoleShop.Users;
using System.Data.SqlClient;
using static ConsoleShopLibrary.Constants.AllConst;

namespace ConsoleShop.MainForShop
{
    public class UserSystem
    {
        public User GetAuthorizedUser(string login, string password)
        {
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"SELECT * FROM [User] WHERE [Login] = '{login}' AND [Password] = '{password}'", connection);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.HasRows)
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
                    throw new Exception("Неверный логин или пароль");
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
