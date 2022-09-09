CREATE TABLE [dbo].[LUPostType] (
    [PostTypeId]               INT             NOT NULL,
    [PostType]                 NVARCHAR (100)  NOT NULL,
    CONSTRAINT [PK_LUPostType] PRIMARY KEY CLUSTERED ([PostTypeId] ASC),
);