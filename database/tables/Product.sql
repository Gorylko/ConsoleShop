USE [ConsoleShop];
CREATE TABLE [dbo].[Product]
(
	[Id]INT IDENTITY(1,1) NOT NULL,
	[CategoryId]INT NOT NULL,
	[LocationId]INT NOT NULL,
	[StateId]INT NOT NULL,
	[Name]NVARCHAR(MAX) NOT NULL,
	[Description]NVARCHAR(MAX) NOT NULL,
	[Price]MONEY NOT NULL,
	[CreationDate]DATETIME NOT NULL,
	[LastModifiedDate]DATETIME NOT NULL,
	PRIMARY KEY CLUSTERED([Id]ASC),
	FOREIGN KEY([CategoryId]) REFERENCES [dbo].[Category]([CategoryId]),
	FOREIGN KEY([LocationId]) REFERENCES [dbo].[Location]([LocationId]),
	FOREIGN KEY([StateId]) REFERENCES [dbo].[ProductState]([StateId])
);
GO