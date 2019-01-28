USE [ConsoleShop];
CREATE TABLE [dbo].[Category]
(
	[CategoryId] INT IDENTITY (1,1) NOT NULL,
   	[Name] NVARCHAR(20) NOT NULL,

 	PRIMARY KEY CLUSTERED([CategoryId] ASC)
);
GO