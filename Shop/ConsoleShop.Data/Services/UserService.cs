using System;
using System.Data.SqlClient;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Shared.Entities;
using ConsoleShop.Shared.Entities.Enums;
using ConsoleShop.Shared.Helpers;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Services
{
    public class UserService
    {
        public User GetAuthorizedUserFromDb(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString)) // Почитать как сделать sql command с параметрами
            {
                connection.Open();
                var command = new SqlCommand($"SELECT TOP 1 * FROM [User] WHERE [Login] = @login AND [Password] = @password", connection); //соединить с roles
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return new User
                    {
                        Login = (string)reader["Login"],
                        Password = (string)reader["Password"],
                        Email = (string)reader["Email"],
                        PhoneNumber = (string)reader["PhoneNumber"],
                        Role = RoleHelper.ConvertToRoleType((int)reader["RoleId"])
                    };
                }
                else
                {
                    throw new Exception("Неверный логин или пароль"); //создать свой класс исключений
                }
            }
        }

        public User GetRegistratedUserFromDb(string login, string password, string email, string phonenumber)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                try
                {
                    var command = new SqlCommand($"INSERT INTO [User] (RoleId, Login, Password, Email, PhoneNumber) VALUES (3, @login, @password, @email, @phonenumber)", connection);
                    command.Parameters.AddWithValue("@login", login);
                    command.Parameters.AddWithValue("@password", password);
                    command.Parameters.AddWithValue("@email", email);
                    command.Parameters.AddWithValue("@phonenumber", phonenumber);
                    command.ExecuteNonQuery();
                    return new User
                    {
                        Login = login,
                        Password = password,
                        Email = email,
                        PhoneNumber = phonenumber,
                        Role = RoleType.User
                    };
                }
                catch (SqlException)
                {
                    throw new Exception("Логин или почта уже заняты, попробуйте что-нибудь поменять :)");
                }
            }
        }
    }
}
