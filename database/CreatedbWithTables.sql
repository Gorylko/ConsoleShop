CREATE DATABASE [ConsoleShop]
GO
USE [ConsoleShop];
CREATE TABLE [dbo].[Category]
(
	[CategoryId] INT IDENTITY (1,1) NOT NULL,
   	[Name] NVARCHAR(20) NOT NULL,

 	PRIMARY KEY CLUSTERED([CategoryId] ASC)
);
GO
CREATE TABLE [dbo].[Location]
(
	[LocationId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED([LocationId]ASC)
);
GO
CREATE TABLE [dbo].[ProductState]
(
	[StateId]INT IDENTITY(1,1) NOT NULL,
	[State]NVARCHAR(40) NOT NULL,
	PRIMARY KEY CLUSTERED([StateId]ASC)
);
GO
CREATE TABLE [dbo].[Role]
(
	[RoleId] INT IDENTITY (1,1) NOT NULL,
	[Name] NVARCHAR(20) NOT NULL,
	PRIMARY KEY CLUSTERED([RoleId] ASC)
);
GO
CREATE TABLE [dbo].[User]
(
	[UserId] INT IDENTITY (1,1) NOT NULL,
	[RoleId] INT NOT NULL,
   	[Login] NVARCHAR(20) NOT NULL,
	[Password] NVARCHAR(20) NOT NULL,
	[Email] NVARCHAR(20) NOT NULL,
	[PhoneNumber] NVARCHAR(15) NULL,
 	PRIMARY KEY CLUSTERED([UserId] ASC),
	FOREIGN KEY(RoleId) REFERENCES [dbo].[Role]([RoleId])
);
GO
CREATE TABLE [dbo].[Product]
(
	[Id]INT IDENTITY(1,1) NOT NULL,
	[UserId] INT NOT NULL,
	[CategoryId]INT NOT NULL,
	[LocationId]INT NOT NULL,
	[StateId]INT NOT NULL,
	[Name]NVARCHAR(MAX) NOT NULL,
	[Description]NVARCHAR(MAX) NOT NULL,
	[Price]MONEY NOT NULL,
	[CreationDate]DATETIME NULL,
	[LastModifiedDate]DATETIME NULL,
	PRIMARY KEY CLUSTERED([Id]ASC),
	FOREIGN KEY([CategoryId]) REFERENCES [dbo].[Category]([CategoryId]),
	FOREIGN KEY([LocationId]) REFERENCES [dbo].[Location]([LocationId]),
	FOREIGN KEY([StateId]) REFERENCES [dbo].[ProductState]([StateId]),
	FOREIGN KEY([UserId]) REFERENCES [dbo].[User]([UserId])
);
GO
