USE ConsoleShop; 
SELECT P.*, C.[CategoryName], L.[LocationName], PS.[State], R.[RoleName], U.[Login], U.[Email], U.[PhoneNumber]
FROM [Product] AS P, [Category] AS C, [Location] AS L, [ProductState] AS PS, [Role] AS R, [User] AS U
WHERE P.CategoryId = C.CategoryId AND P.LocationId = L.LocationId AND P.StateId = PS.StateId AND P.UserId = U.UserId AND U.RoleId = R.RoleId