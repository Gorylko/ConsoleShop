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

INSERT INTO [dbo].[Location]([Name]) VALUES('�����')
INSERT INTO [dbo].[Location]([Name]) VALUES('��������')
INSERT INTO [dbo].[Location]([Name]) VALUES('�����')
INSERT INTO [dbo].[Location]([Name]) VALUES('������')
INSERT INTO [dbo].[Location]([Name]) VALUES('�������')
INSERT INTO [dbo].[Location]([Name]) VALUES('�����')
INSERT INTO [dbo].[Location]([Name]) VALUES('������')
INSERT INTO [dbo].[Location]([Name]) VALUES('������')

INSERT INTO [dbo].[ProductState]([State]) VALUES('New')
INSERT INTO [dbo].[ProductState]([State]) VALUES('Old')

INSERT INTO [dbo].[User]([Login],[Password],[Email],[PhoneNumber]) VALUES('VlastelinValentin','�����','pavyk@gmail.com','+365291725099')

INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[Name],[Description],[Price])
VALUES(1,1,1,1,'�������','������� ������, � ���� ������� ����� � ��� �� ����',123)