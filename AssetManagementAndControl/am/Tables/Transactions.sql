CREATE TABLE [am].[Transactions] (
    [ID]              INT          NOT NULL,
    [AssetID]         INT          NOT NULL,
    [BuyerID]         INT          NOT NULL,
    [SellerID]        INT          NOT NULL,
    [TransactionType] VARCHAR (10) NOT NULL,
    [TransactionDate] DATETIME     NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([AssetID]) REFERENCES [am].[Assets] ([ID]),
    FOREIGN KEY ([BuyerID]) REFERENCES [am].[Users] ([ID]),
    FOREIGN KEY ([SellerID]) REFERENCES [am].[Users] ([ID])
);

