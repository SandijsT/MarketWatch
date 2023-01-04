CREATE TABLE [dbo].[FuelTypeLanguage] (
    [FuelTypeId]       INT           NOT NULL,
    [LanguageId]       INT           NOT NULL,
    [Description]      VARCHAR (255) NOT NULL,
    CONSTRAINT [PK_FuelTypeLanguage] PRIMARY KEY CLUSTERED ([FuelTypeId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_FuelTypeLanguage_FuelTypeId] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[LUFuelType] ([FuelTypeId]),
);