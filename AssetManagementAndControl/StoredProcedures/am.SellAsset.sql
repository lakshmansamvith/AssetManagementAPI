CREATE PROCEDURE usp_SellAsset
    @SellerID INT,
    @AssetID INT
AS
BEGIN
    -- Check if the asset exists and is owned by the seller
    IF EXISTS (SELECT 1 FROM [am].[Assets] WHERE [ID] = @AssetID AND [OwnerID] = @SellerID)
    BEGIN
        DECLARE @BuyerID INT, @TransactionID INT

        -- Get the buyer ID and assign it to @BuyerID variable (you can implement your own logic to retrieve the buyer's ID)

        -- Start a transaction
        BEGIN TRANSACTION

        -- Insert a new transaction record
        INSERT INTO [am].[Transactions] ([AssetID], [BuyerID], [SellerID], [TransactionType], [TransactionDate])
        VALUES (@AssetID, @BuyerID, @SellerID, 'sell', GETDATE())

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
        -- Asset not found or not owned by the seller, return an empty result or an error message
        -- You can customize the response based on your requirements
        SELECT NULL AS [ID], NULL AS [Name], NULL AS [Description], NULL AS [Price], NULL AS [BuyerUsername], NULL AS [TransactionID]
    END
END
