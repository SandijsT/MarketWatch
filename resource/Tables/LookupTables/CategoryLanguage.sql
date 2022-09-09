CREATE TABLE [dbo].[CategoryLanguage] (
    [CategoryId]       INT           NOT NULL,
    [LanguageId]       INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [DisplayOrder]     INT           NOT NULL,
    CONSTRAINT [PK_CategoryLanguage] PRIMARY KEY CLUSTERED ([CategoryId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_CategoryLanguage_CategoryId] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[LUCategory] ([CategoryId]),
);
