CREATE TABLE [dbo].[ModelLanguage] (
    [ModelId]          INT           NOT NULL,
    [LanguageId]       INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [DisplayOrder]     INT           NOT NULL,
    CONSTRAINT [PK_ModelLanguage] PRIMARY KEY CLUSTERED ([ModelId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_ModelLanguage_ModelId] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[LUModel] ([ModelId]),
);