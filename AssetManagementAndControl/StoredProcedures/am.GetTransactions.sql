CREATE PROCEDURE [am].[GetTransactions]
	
AS
BEGIN 
SELECT ID, AssetID, SellerID, BuyerID, 
TransactionType, TransactionDate FROM Transactions
END