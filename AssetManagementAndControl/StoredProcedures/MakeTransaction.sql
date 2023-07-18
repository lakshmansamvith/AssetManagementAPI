CREATE PROCEDURE [am].[MakeTransaction]
    @BuyerID INT,
    @SellerID INT,
    @AssetID INT,
    @Price DECIMAL(10, 2),
    @TransactionType VARCHAR(10)
AS
BEGIN
    -- Check if the asset exists and is available for purchase
    IF EXISTS (SELECT 1 FROM [am].[Assets] WHERE [ID] = @AssetID)
    BEGIN
        -- Start a transaction
        BEGIN TRANSACTION

        -- Get the next transaction ID
        DECLARE @TransactionID INT;
        SELECT @TransactionID = SCOPE_IDENTITY();

        -- Insert a new transaction record
        INSERT INTO [am].[Transactions] ([AssetID], [BuyerID], [SellerID], [TransactionType], [TransactionDate])
        VALUES (@AssetID, @BuyerID, @SellerID, @TransactionType, GETDATE());

        -- Update the asset's owner ID to the buyer's ID
        UPDATE [am].[Assets] SET [OwnerID] = @BuyerID WHERE [ID] = @AssetID

        -- Update the asset's price to the new price
        UPDATE [am].[Assets] SET [Price] = @Price WHERE [ID] = @AssetID

        -- Commit the transaction
        COMMIT TRANSACTION

        SELECT
            [am].[Assets].[ID],
            [am].[Assets].[Name],
            [am].[Assets].[Description],
            [am].[Assets].[Price],
            [am].[Users].[Username] AS [BuyerUsername],
            @TransactionID AS [TransactionID]
        FROM
            [am].[Assets]
        INNER JOIN
            [am].[Users] ON [am].[Assets].[OwnerID] = [am].[Users].[ID]
        WHERE
            [am].[Assets].[ID] = @AssetID
    END
    ELSE
    BEGIN
        -- Asset not found, return an empty result or an error message
        -- You can customize the response based on your requirements
        SELECT NULL AS [ID], NULL AS [Name], NULL AS [Description], NULL AS [Price], NULL AS [BuyerUsername], NULL AS [TransactionID]
    END
END
