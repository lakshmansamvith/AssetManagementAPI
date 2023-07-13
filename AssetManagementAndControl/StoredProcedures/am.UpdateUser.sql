CREATE PROCEDURE [am].[UpdateUser]
    @UserID INT,
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Address VARCHAR(100),
    @Email VARCHAR(100),
    @Password VARCHAR(50)
AS
BEGIN
    UPDATE [am].[Users]
    SET [FirstName] = @FirstName, [LastName] = @LastName, [Address] = @Address, [Email] = @Email, [Password] = @Password
    WHERE [ID] = @UserID
END
