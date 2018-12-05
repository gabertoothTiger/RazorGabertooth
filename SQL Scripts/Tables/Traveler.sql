USE [TandT]
GO

CREATE TABLE [dbo].[Traveler](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[FirstName] [nvarchar](50) NULL,
	[LastName] [nvarchar](50) NULL,
	CONSTRAINT [AK_Name] UNIQUE NONCLUSTERED ([FirstName] ASC, [LastName] ASC)
)
GO


