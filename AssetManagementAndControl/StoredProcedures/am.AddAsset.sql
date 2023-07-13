CREATE PROCEDURE [am].[AddAsset]
	@Name VARCHAR(100),
    @Description VARCHAR(255),
    @Price DECIMAL(10, 2),
    @OwnerID INT
AS
BEGIN
    INSERT INTO [am].[Assets] ([Name], [Description], [Price], [OwnerID])
    VALUES (@Name, @Description, @Price, @OwnerID)
END
