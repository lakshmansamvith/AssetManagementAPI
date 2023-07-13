CREATE PROCEDURE [am].[GetAllAssets]
AS
BEGIN
    SELECT [ID], [Name], [Description], [Price], [OwnerID]
    FROM [am].[Assets]
END

