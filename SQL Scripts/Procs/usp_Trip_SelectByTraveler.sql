USE [TandT]
GO
IF OBJECT_ID('[dbo].[usp_Trip_SelectByTraveler]') IS NULL
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[usp_Trip_SelectByTraveler] AS SELECT 1 AS JUNK')
END
GO

ALTER PROCEDURE [dbo].[usp_Trip_SelectByTraveler]
(
	@FirstName [nvarchar](50),
	@LastName [nvarchar](50)
)
AS
BEGIN
	SELECT t.Id as TripId,
			t.TravelerId,
			t.DepartureDate,
			t.ReturnDate,
			tr.FirstName,
			tr.LastName
	FROM dbo.Trip t
		join dbo.Traveler tr on t.TravelerId = tr.Id
	WHERE tr.FirstName = @FirstName
	AND tr.LastName = @LastName
END
GO
