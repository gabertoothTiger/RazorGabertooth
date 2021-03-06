USE [TandT]
GO
IF OBJECT_ID('[dbo].[usp_Traveler_Select]') IS NULL
BEGIN
	EXEC('CREATE PROCEDURE [dbo].[usp_Traveler_Select] AS SELECT 1 AS JUNK')
END
GO
ALTER PROCEDURE [dbo].[usp_Traveler_Select]
(
	@FirstName [nvarchar](50),
	@LastName [nvarchar](50)
)
AS
BEGIN
	SELECT Id,
			FirstName,
			LastName
	FROM dbo.Traveler
	WHERE FirstName = @FirstName
	AND LastName = @LastName
END
