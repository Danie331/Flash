CREATE TABLE [dbo].[User] (
    [Id]     INT           IDENTITY (1, 1) NOT NULL,
    [Name]   VARCHAR (255) NOT NULL,
    [Email]  VARCHAR (255) NOT NULL,
    [TeamId] INT           NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_User_Team] FOREIGN KEY ([TeamId]) REFERENCES [dbo].[Team] ([Id])
);

