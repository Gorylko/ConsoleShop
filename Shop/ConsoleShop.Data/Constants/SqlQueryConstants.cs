using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Constants
{
    class SqlQueryConstants
    {
        public const string SelectProductInDbString = "USE ConsoleShop" + NewLine +
        "SELECT Product.*, [Category].[CategoryName] AS [Category], [Location].[LocationName] AS [Location], [ProductState].[State] AS [State], [Role].[RoleName] AS [Role], [User].[Login] AS [Login], [User].[Email] AS [Email], [User].[PhoneNumber] AS [PhoneNumber] " + NewLine +
        "FROM [Product]" + NewLine +
        "JOIN [Category] ON [Product].[CategoryId] = [Category].CategoryId" + NewLine +
        "JOIN [Location] ON [Product].[LocationId] = [Location].LocationId" + NewLine +
        "JOIN [ProductState] ON [Product].[StateId] = [ProductState].StateId" + NewLine +
        "JOIN [User] ON [Product].[UserId] = [User].[UserId]" + NewLine +
        "JOIN [Role] ON [User].[RoleId] = [Role].[RoleId]";

        public const string ConnectionToConsoleShopString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=ConsoleShop;Integrated Security=True";

        public const string ConnectionToUsersString = "";
    }
}
