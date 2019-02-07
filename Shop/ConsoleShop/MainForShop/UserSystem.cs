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
    public class UserSystem // с помощью папочки Data будет производить авторизацию, регистрацию, открывать менюшку
    {
        public User LoginToAccount(string login, string password)
        {
            using (var connection = new SqlConnection(ConnectionToConsoleShopString))
            {
                connection.Open();
                try
                {
                    var command = new SqlCommand($"SELECT 1 FROM User WHERE Login = {login} AND Password = {password}", connection);
                    SqlDataReader reader = command.ExecuteReader();
                    if(reader.HasRows)
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
                        return null;
                    }
                }
                catch(Exception ex)
                {
                    return null;
                }
            }
        }
        public User Register(string login, string password, string email, string phonenumber)
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
                catch(Exception ex)
                {
                    Console.WriteLine("Логин или почта уже заняты, попробуйте что-нибудь поменять :)");
                    return null;
                }
            }
        }
        private RoleType ConvertToRoleType(int roleid)
        {
            return (RoleType)roleid;
        }

    }
}
