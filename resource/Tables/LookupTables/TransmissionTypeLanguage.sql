CREATE TABLE [dbo].[TransmissionTypeLanguage] (
    [TransmissionTypeId]       INT           NOT NULL,
    [LanguageId]               INT           NOT NULL,
    [Description]              VARCHAR (255) NOT NULL,
    [DisplayOrder]             INT           NOT NULL,
    CONSTRAINT [PK_TransmissionTypeLanguage] PRIMARY KEY CLUSTERED ([TransmissionTypeId] ASC, [LanguageId] ASC),
    CONSTRAINT [FK_TransmissionTypeLanguage_TransmissionTypeId] FOREIGN KEY ([TransmissionTypeId]) REFERENCES [dbo].[LUTransmissionType] ([TransmissionTypeId]),
);