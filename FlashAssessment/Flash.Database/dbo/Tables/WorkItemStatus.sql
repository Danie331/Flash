CREATE TABLE [dbo].[WorkItemStatus] (
    [Id]                INT          IDENTITY (1, 1) NOT NULL,
    [StatusDescription] VARCHAR (15) NOT NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC)
);

