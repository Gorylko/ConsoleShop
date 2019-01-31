USE ConsoleShop; 
SELECT * FROM Product p 
LEFT JOIN Category c ON p.CategoryId = c.CategoryId 
LEFT JOIN ProductState s ON p.StateId = s.StateId 
LEFT JOIN Location l ON p.LocationId = l.LocationId 
LEFT JOIN [User] u ON p.UserId = u.UserId 
LEFT JOIN Role r ON u.RoleId = r.RoleId;