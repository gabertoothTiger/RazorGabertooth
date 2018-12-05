USE [TandT]
GO
IF OBJECT_ID('[dbo].[usp_Trip_Insert]') IS NULL
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[usp_Trip_Insert] AS SELECT 1 AS JUNK')
END
GO

ALTER PROCEDURE [dbo].[usp_Trip_Insert]
(
	@TravelerId int,
	@DepartureDate datetime,
	@ReturnDate datetime
)
AS
BEGIN
	INSERT INTO dbo.Trip(TravelerId, DepartureDate, ReturnDate)
	VALUES(@TravelerId, @DepartureDate, @ReturnDate)

	SELECT @@IDENTITY
END
GO
