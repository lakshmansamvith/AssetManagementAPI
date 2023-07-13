CREATE PROCEDURE [am].[DeleteUser]
	@UserID INT
AS
BEGIN 
	DELETE FROM [am].[Users] WHERE ID = @UserID
END 
