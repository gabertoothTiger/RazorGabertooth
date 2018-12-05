USE [TandT]
GO
IF OBJECT_ID('[dbo].[usp_Traveler_Insert]') IS NULL
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[usp_Traveler_Insert] AS SELECT 1 AS JUNK')
END
GO
ALTER PROCEDURE [dbo].[usp_Traveler_Insert]
(
	@FirstName [nvarchar](50),
	@LastName [nvarchar](50)
)
AS
BEGIN
	INSERT INTO dbo.Traveler(FirstName, LastName)
	VALUES(@FirstName, @LastName)

	SELECT @@IDENTITY
END
GO