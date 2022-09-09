CREATE TABLE [dbo].[LUTransmissionType] (
    [TransmissionTypeId]               INT             NOT NULL,
    [TransmissionType]                 NVARCHAR (100)  NOT NULL,
    [GearCount]                        INT             NULL,
    CONSTRAINT [PK_LUTransmissionType] PRIMARY KEY CLUSTERED ([TransmissionTypeId] ASC),
);