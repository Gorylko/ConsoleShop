USE ConsoleShop; 
SELECT p.*, c.[Name] AS [Category], l.[Name] AS [Location], s.[State] AS [State], r.[Role], u.[Login] AS [Login], u.[Email] AS Email, u.[PhoneNumber] AS PhoneNumber
FROM [Product] p
JOIN [Category] c ON p.[CategoryId] = c.CategoryId
JOIN [Location] l ON p.[LocationId] = l.LocationId
JOIN [ProductState] s ON p.[StateId] = s.StateId
JOIN [User] u ON p.[UserId] = u.[UserId]
JOIN [Role] r ON u.[RoleId] = r.[RoleId] 