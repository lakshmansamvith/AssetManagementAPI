CREATE PROCEDURE [am].[UpdateAsset]
	 @AssetID INT,
    @Name VARCHAR(100),
    @Description VARCHAR(255),
    @Price DECIMAL(10, 2)
AS
BEGIN
    UPDATE [am].[Assets]
    SET [Name] = @Name, [Description] = @Description, [Price] = @Price
    WHERE [ID] = @AssetID
END
