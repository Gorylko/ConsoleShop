USE[ConsoleShop];
INSERT INTO [dbo].[Category]([Name]) VALUES('Eat')
INSERT INTO [dbo].[Category]([Name]) VALUES('Toys')
INSERT INTO [dbo].[Category]([Name]) VALUES('ForPets')
INSERT INTO [dbo].[Category]([Name]) VALUES('Laptops')
INSERT INTO [dbo].[Category]([Name]) VALUES('Phones')
INSERT INTO [dbo].[Category]([Name]) VALUES('Plants')
INSERT INTO [dbo].[Category]([Name]) VALUES('ForSchool')
INSERT INTO [dbo].[Category]([Name]) VALUES('Cars')
INSERT INTO [dbo].[Category]([Name]) VALUES('Alcohol')

INSERT INTO [dbo].[Location]([Name]) VALUES('Авган')
INSERT INTO [dbo].[Location]([Name]) VALUES('Беларусь')
INSERT INTO [dbo].[Location]([Name]) VALUES('Чечня')
INSERT INTO [dbo].[Location]([Name]) VALUES('Канада')
INSERT INTO [dbo].[Location]([Name]) VALUES('Украина')
INSERT INTO [dbo].[Location]([Name]) VALUES('Литва')
INSERT INTO [dbo].[Location]([Name]) VALUES('Латвия')
INSERT INTO [dbo].[Location]([Name]) VALUES('Россия')

INSERT INTO [dbo].[ProductState]([State]) VALUES('New')
INSERT INTO [dbo].[ProductState]([State]) VALUES('Old')

INSERT INTO [dbo].[User]([Login],[Password],[Email],[PhoneNumber]) VALUES('VlastelinValentin','павук','pavyk@gmail.com','+365291725099')

INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price])
VALUES(1,1,1,1,'СЯЛЕДКА','пожилая сельдь, с озер украины прямо к вам на стол',123)