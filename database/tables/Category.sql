USE [ConsoleShop];
CREATE TABLE [dbo].[Category]
(
	[Id] INT IDENTITY (1,1) NOT NULL,
   	[Name] NVARCHAR(20) NOT NULL,

 	PRIMARY KEY CLUSTERED([Id] ASC)
);
GO