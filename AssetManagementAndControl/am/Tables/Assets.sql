CREATE TABLE [am].[Assets] (
    [ID]          INT             NOT NULL,
    [Name]        VARCHAR (100)   NOT NULL,
    [Description] VARCHAR (255)   NULL,
    [Price]       DECIMAL (10, 2) NOT NULL,
    [OwnerID]     INT             NOT NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC),
    FOREIGN KEY ([OwnerID]) REFERENCES [am].[Users] ([ID])
);

