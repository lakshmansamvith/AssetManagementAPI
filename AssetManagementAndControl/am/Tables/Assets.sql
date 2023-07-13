CREATE TABLE [am].[Assets] (
    [ID]          INT             NOT NULL,
    [Name]        VARCHAR (100)   NULL,
    [Description] VARCHAR (255)   NULL,
    [Price]       DECIMAL (10, 2) NULL,
    [OwnerID]     INT             NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([OwnerID]) REFERENCES [am].[Users] ([ID])
);

