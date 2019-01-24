USE [Goodsdb]
GO

/****** Object:  Table [dbo].[MainInfo]    Script Date: 25.01.2019 0:57:16 ******/
SET ANSI_NULLS ON
GO

SET QUOTED_IDENTIFIER ON
GO

CREATE TABLE [dbo].[MainInfo](
	[Id] [int] IDENTITY(1,1) NOT NULL,
	[Name] [nvarchar](50) NOT NULL,
	[Description] [nvarchar](50) NOT NULL,
	[Price] [money] NOT NULL,
	[DateOfCreation] [nvarchar](50) NOT NULL,
	[LastModifiedDate] [nvarchar](50) NOT NULL,
 CONSTRAINT [PK_MainInfo] PRIMARY KEY CLUSTERED 
(
	[Id] ASC
)WITH (PAD_INDEX = OFF, STATISTICS_NORECOMPUTE = OFF, IGNORE_DUP_KEY = OFF, ALLOW_ROW_LOCKS = ON, ALLOW_PAGE_LOCKS = ON) ON [PRIMARY]
) ON [PRIMARY]
GO


