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

INSERT INTO [dbo].[Role]([Role]) VALUES ('Administrator')
INSERT INTO [dbo].[Role]([Role]) VALUES ('Moderator')
INSERT INTO [dbo].[Role]([Role]) VALUES ('User')

INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('VlastelinValentin',1,'�����','pavyk@gmail.com','+365291725099')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Anatolya',2,'123','pavyk@gmail.com','+365441365099')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Vadimka12',3,'343221','vadimka@gmail.com','+3653317253467')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Valentinka48',3,'345','valik@gmail.com','+365565625045')
INSERT INTO [dbo].[User]([Login],[RoleId],[Password],[Email],[PhoneNumber]) VALUES('Genka15',3,'1234','genka@gmail.com','+365171479090')

Set DateFormat MDY

INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate])
VALUES(1,1,1,1,'�������','������� ������, � ���� ������� ����� � ��� �� ����',123, 2019-02-04, 2019-02-04)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate])
VALUES(1,1,2,2,'name1','descr1',123, 2019-02-05, 2019-02-05)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate])
VALUES(2,2,1,3,'name2','descr2',13, 2019-02-06, 2019-02-06)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate])
VALUES(2,3,2,4,'name3','descr3',12, 2019-02-07, 2019-02-07)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate])
VALUES(2,4,1,5,'name4','descr4',12, 2019-02-08, 2019-02-08)
INSERT INTO [dbo].[Product]([CategoryId],[LocationId],[StateId],[UserId],[ProductName],[Description],[Price],[CreationDate],[LastModifiedDate])
VALUES(3,5,2,1,'name5','descr5',12, 2019-02-09, 2019-02-09)
