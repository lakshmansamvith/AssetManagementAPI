CREATE PROCEDURE [am].[AddUser]
    @FirstName VARCHAR(50),
    @LastName VARCHAR(50),
    @Username VARCHAR(50),
    @Password VARCHAR(50),
    @Address VARCHAR(100),
    @Email VARCHAR(100),
    @Role VARCHAR(20)
AS
BEGIN
    INSERT INTO [am].[Users] ([FirstName], [LastName], 
    [Username], [Password], [Address], [Email], [Role])
    VALUES (@FirstName, @LastName, @Username, @Password, @Address, @Email, @Role)
END
