CREATE TABLE [am].[Transactions] (
    [ID]              INT          NOT NULL,
    [AssetID]         INT          NULL,
    [BuyerID]         INT          NULL,
    [SellerID]        INT          NULL,
    [TransactionType] VARCHAR (10) NULL,
    [TransactionDate] DATETIME     NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([AssetID]) REFERENCES [am].[Assets] ([ID]),
    FOREIGN KEY ([BuyerID]) REFERENCES [am].[Users] ([ID]),
    FOREIGN KEY ([SellerID]) REFERENCES [am].[Users] ([ID])
);

