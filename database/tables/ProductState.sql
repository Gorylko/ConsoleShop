USE[ConsoleShop];
CREATE TABLE [dbo].[ProductState]
(
	[StateId]INT IDENTITY(1,1) NOT NULL,
	[State]NVARCHAR(40) NOT NULL,
	PRIMARY KEY CLUSTERED([StateId]ASC)
);
GO