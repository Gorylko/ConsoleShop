USE[ConsoleShop];
CREATE TABLE [dbo].[Location]
(
	[LocationId] INT IDENTITY(1,1) NOT NULL,
	[Name] NVARCHAR(50) NOT NULL,
	PRIMARY KEY CLUSTERED([LocationId]ASC)
);
GO