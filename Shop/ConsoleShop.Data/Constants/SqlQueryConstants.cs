using Typography = ConsoleShop.Shared.Constants.TypographyConstants;

namespace ConsoleShop.Data.Constants
{
    public class SqlQueryConstants
    {
        public const string SelectAllProductInDbString = "USE ConsoleShop" + Typography.NewLine +
        "SELECT Product.*, [Category].[Name] AS [Category], [Location].[Name] AS [Location], [State].[Name] AS [State], [Role].[Id] AS [RoleId], [User].[Login] AS [Login], [User].[Email] AS [Email], [User].[PhoneNumber] AS [PhoneNumber] " + Typography.NewLine +
        "FROM [Product]" + Typography.NewLine +
        "JOIN [Category] ON [Product].[CategoryId] = [Category].Id" + Typography.NewLine +
        "JOIN [Location] ON [Product].[LocationId] = [Location].Id" + Typography.NewLine +
        "JOIN [State] ON [Product].[StateId] = [State].Id" + Typography.NewLine +
        "JOIN [User] ON [Product].[UserId] = [User].[Id]" + Typography.NewLine +
        "JOIN [Role] ON [User].[RoleId] = [Role].[Id]";

        public const string ConnectionToConsoleShopString = "Data Source=LAPTOP-P3338OQH;Initial Catalog=ConsoleShop;Integrated Security=True";

        public const string ConnectionToUsersString = "";
    }
}
