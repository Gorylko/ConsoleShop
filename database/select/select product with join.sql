USE ConsoleShop; 
SELECT Product.*, [Category].[CategoryName] AS [Category], [Location].[LocationName] AS [Location], [ProductState].[State] AS [State], [Role].[RoleName] AS [Role], [User].[Login] AS [Login], [User].[Email] AS Email, [User].[PhoneNumber] AS PhoneNumber
FROM [Product]
JOIN [Category] ON [Product].[CategoryId] = [Category].CategoryId
JOIN [Location] ON [Product].[LocationId] = [Location].LocationId
JOIN [ProductState] ON [Product].[StateId] = [ProductState].StateId
JOIN [User] ON [Product].[UserId] = [User].[UserId]
JOIN [Role] ON [User].[RoleId] = [Role].[RoleId] 