CREATE TABLE [dbo].[WorkItem] (
    [Id]              INT           IDENTITY (1, 1) NOT NULL,
    [ItemDescription] VARCHAR (255) NOT NULL,
    [StoryPoints]     INT           NOT NULL,
    [StatusId]        INT           NOT NULL,
    [UserId]          INT           NULL,
    PRIMARY KEY CLUSTERED ([Id] ASC),
    CONSTRAINT [FK_WorkItem_User] FOREIGN KEY ([UserId]) REFERENCES [dbo].[User] ([Id]),
    CONSTRAINT [FK_WorkItem_WorkItemStatus] FOREIGN KEY ([StatusId]) REFERENCES [dbo].[WorkItemStatus] ([Id])
);

