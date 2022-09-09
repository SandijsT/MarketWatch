CREATE TABLE [dbo].[PostTypeLanguage]
(
	[PostTypeId]       INT           NOT NULL,
    [LanguageId]       INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [DisplayOrder]     INT           NOT NULL,
    CONSTRAINT [PK_PostTypeLanguage] PRIMARY KEY CLUSTERED ([PostTypeId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_PostTypeLanguage_PostTypeId] FOREIGN KEY ([PostTypeId]) REFERENCES [dbo].[LUPostType] ([PostTypeId]),
);