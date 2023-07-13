CREATE PROCEDURE [am].[DeleteAsset]
	 @AssetID INT
AS
BEGIN
    DELETE FROM [am].[Assets]
    WHERE [ID] = @AssetID
END