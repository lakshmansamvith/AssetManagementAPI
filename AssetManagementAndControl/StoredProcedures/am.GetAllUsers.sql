CREATE PROCEDURE [am].[GetAllUsers]
   
AS
BEGIN
    SELECT [FirstName], [LastName], [Address], [Email]
    FROM [am].[Users]
END
