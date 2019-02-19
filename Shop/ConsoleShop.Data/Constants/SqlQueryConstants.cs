using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using Typography = ConsoleShop.Shared.Constants.TypographyConstants;
using System.Threading.Tasks;

namespace ConsoleShop.Data.Constants
{
    public class SqlQueryConstants
    {
        public const string SelectAllProductInDbString = "USE ConsoleShop" + Typography.NewLine +
        "SELECT Product.*, [Category].[CategoryName] AS [Category], [Location].[LocationName] AS [Location], [ProductState].[State] AS [State], [Role].[RoleName] AS [Role], [User].[Login] AS [Login], [User].[Email] AS [Email], [User].[PhoneNumber] AS [PhoneNumber] " + Typography.NewLine +
        "FROM [Product]" + Typography.NewLine +
        "JOIN [Category] ON [Product].[CategoryId] = [Category].CategoryId" + Typography.NewLine +
        "JOIN [Location] ON [Product].[LocationId] = [Location].LocationId" + Typography.NewLine +
        "JOIN [ProductState] ON [Product].[StateId] = [ProductState].StateId" + Typography.NewLine +
        "JOIN [User] ON [Product].[UserId] = [User].[UserId]" + Typography.NewLine +
        "JOIN [Role] ON [User].[RoleId] = [Role].[RoleId]";

        public const string ConnectionToConsoleShopString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=ConsoleShop;Integrated Security=True";

        public const string ConnectionToUsersString = "";
    }
}
