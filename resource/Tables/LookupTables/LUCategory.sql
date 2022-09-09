CREATE TABLE [dbo].[LUCategory] (
    [CategoryId]               INT             NOT NULL,
    [Category]                 NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_LUCategory] PRIMARY KEY CLUSTERED ([CategoryId] ASC),
);