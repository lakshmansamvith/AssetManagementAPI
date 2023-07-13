CREATE PROCEDURE [am].[BuyAsset]
    @BuyerID INT,
    @AssetID INT
AS
BEGIN
    -- Check if the asset exists and is available for purchase
    IF EXISTS (SELECT 1 FROM [am].[Assets] WHERE [ID] = @AssetID)
    BEGIN
        DECLARE @SellerID INT, @TransactionID INT

        -- Get the seller ID and assign it to @SellerID variable
        SELECT @SellerID = [OwnerID] FROM [am].[Assets] WHERE [ID] = @AssetID

        -- Start a transaction
        BEGIN TRANSACTION

        -- Insert a new transaction record
        INSERT INTO [am].[Transactions] ([AssetID], [BuyerID], [SellerID], [TransactionType], [TransactionDate])
        VALUES (@AssetID, @BuyerID, @SellerID, 'buy', GETDATE())

        -- Update the asset's owner ID to the buyer's ID
        UPDATE [am].[Assets] SET [OwnerID] = @BuyerID WHERE [ID] = @AssetID

        -- Commit the transaction
        COMMIT TRANSACTION

        -- Return the ID of the newly inserted transaction
        SET @TransactionID = SCOPE_IDENTITY()

        -- Select the asset details and the transaction ID
        SELECT
            [am].[Assets].[ID],
            [am].[Assets].[Name],
            [am].[Assets].[Description],
            [am].[Assets].[Price],
            [am].[Users].[Username] AS [OwnerUsername],
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
        SELECT NULL AS [ID], NULL AS [Name], NULL AS [Description], NULL AS [Price], NULL AS [OwnerUsername], NULL AS [TransactionID]
    END
END

