CREATE TABLE [am].[Users] (
    [ID]        INT           NOT NULL,
    [FirstName] VARCHAR (50)  NOT NULL,
    [LastName]  VARCHAR (50)  NOT NULL,
    [Username]  VARCHAR (50)  NOT NULL,
    [Password]  VARCHAR (50)  NOT NULL,
    [Address]   VARCHAR (100) NULL,
    [Email]     VARCHAR (100) NULL,
    [Role]      VARCHAR (20)  NULL,
    PRIMARY KEY CLUSTERED ([ID] ASC)
);

