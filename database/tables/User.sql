USE [ConsoleShop];
CREATE TABLE [dbo].[User]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
   	[Login] NVARCHAR(20) NOT NULL,
	[Password] NVARCHAR(20) NOT NULL,
	[Email] NVARCHAR(20) NOT NULL
 	PRIMARY KEY CLUSTERED([Id] ASC)
);
GO