USE [TandT]
GO

CREATE TABLE [dbo].[Trip](
	[Id] [int] PRIMARY KEY IDENTITY(1,1) NOT NULL,
	[TravelerId] [int] NOT NULL,
	[DepartureDate] [datetime] NOT NULL,
	[ReturnDate] [datetime] NOT NULL,
	CONSTRAINT FK_TravelerTrip FOREIGN KEY (TravelerId) REFERENCES Traveler(Id)
)
GO


