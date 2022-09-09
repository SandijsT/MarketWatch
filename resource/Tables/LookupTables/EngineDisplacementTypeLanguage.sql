CREATE TABLE [dbo].[EngineDisplacementTypeLanguage]
(
	[EngineDisplacementTypeId]       INT           NOT NULL,
    [LanguageId]       INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    [DisplayOrder]     INT           NOT NULL,
    CONSTRAINT [PK_EngineDisplacementTypeLanguage] PRIMARY KEY CLUSTERED ([EngineDisplacementTypeId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_EngineDisplacementTypeLanguage_EngineDisplacementTypeId] FOREIGN KEY ([EngineDisplacementTypeId]) REFERENCES [dbo].[LUEngineDisplacementType] ([EngineDisplacementTypeId]),
);