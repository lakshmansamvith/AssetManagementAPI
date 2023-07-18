CREATE PROCEDURE [am].[GetTransactionById]
	@Id INT
AS
BEGIN 
SELECT ID, AssetID, SellerID, BuyerID, 
TransactionType, TransactionDate FROM Transactions
WHERE Id = @Id
END