using System;
using System.Collections.Generic;
using ConsoleShop.Shared.Entities;
using System.Data.SqlClient;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using SqlConst = ConsoleShop.Data.Constants.SqlQueryConstants;
using ConsoleShop.Data.DataContext.Interfaces;
using ConsoleShop.Shared.Helpers;
using ConsoleShop.Shared.Entities.Enums;

namespace ConsoleShop.Data.DataContext.Realization.MsSql
{
    public class UserContext : IUserContext
    {
        public User GetUser(SqlDataReader reader)
        {
            return new User
            {
                Login = (string)reader["Login"],
                Email = (string)reader["Email"],
                PhoneNumber = (string)reader["PhoneNumber"],
                Role = RoleHelper.ConvertToRoleType((int)reader["RoleId"])
            };
        }

        public User GetAuthorizedUser(string login, string password)
        {
            if (string.IsNullOrEmpty(login) || string.IsNullOrEmpty(password))
            {
                return null;
            }
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT TOP 1 * FROM [User] WHERE [Login] = @login AND [Password] = @password", connection); //соединить с roles
                command.Parameters.AddWithValue("@login", login);
                command.Parameters.AddWithValue("@password", password);
                SqlDataReader reader = command.ExecuteReader();
                if (reader.Read())
                {
                    return GetUser(reader);
                }
                else
                {
                    throw new Exception("Неверный логин или пароль");
                }
            }
        }

        public User GetRegistratedUser(string login, string password, string email, string phonenumber)
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

        public IReadOnlyCollection<User> GetAll()
        {
            List<User> returnList = new List<User>();
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand("SELECT * FROM [User]", connection);
                SqlDataReader reader = command.ExecuteReader();
                while (reader.Read())
                {
                    try
                    {
                        returnList.Add(GetUser(reader));
                    }
                    catch(SqlException) { }
                }
                return returnList;
            }
        }

        public User GetById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                List<User> products = new List<User>();
                string query = SqlConst.SelectAllProductInDbString + Typography.NewLine + $"WHERE [Id] = {id}";
                var command = new SqlCommand(query, connection);
                SqlDataReader reader = command.ExecuteReader();
                reader.Read();
                return GetUser(reader);
            }
        }

        public void DeleteById(int id)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                var command = new SqlCommand($"DELETE [User] WHERE [Id] = {id}", connection);
                command.ExecuteNonQuery();
            }
        }

        public void Save(User user)
        {
            using (var connection = new SqlConnection(SqlConst.ConnectionToConsoleShopString))
            {
                connection.Open();
                SqlCommand command = new SqlCommand($"INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('{user.Login}',{(int)user.Role},'{user.Password}','{user.Email}','{user.PhoneNumber}')", connection);
                command.ExecuteNonQuery();
            }
        }
    }
}
