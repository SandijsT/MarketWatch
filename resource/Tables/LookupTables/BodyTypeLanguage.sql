CREATE TABLE [dbo].[BodyTypeLanguage]
(
	[BodyTypeId]       INT           NOT NULL,
    [LanguageId]       INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [DisplayOrder]     INT           NOT NULL,
    CONSTRAINT [PK_BodyTypeLanguage] PRIMARY KEY CLUSTERED ([BodyTypeId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_BodyTypeLanguage_BodyTypeId] FOREIGN KEY ([BodyTypeId]) REFERENCES [dbo].[LUBodyType] ([BodyTypeId]),
);