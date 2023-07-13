CREATE PROCEDURE [am].[GetUserProfile]
    @UserID INT
AS
BEGIN
    SELECT [FirstName], [LastName], [Address], [Email]
    FROM [am].[Users]
    WHERE [ID] = @UserID
END
