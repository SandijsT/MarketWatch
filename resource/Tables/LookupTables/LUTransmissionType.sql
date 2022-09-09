CREATE TABLE [dbo].[LUTransmissionType] (
    [TransmissionTypeId]               INT             IDENTITY (1, 1) NOT NULL,
    [TransmissionType]                 NVARCHAR (100)  NOT NULL,
    [GearCount]                        INT             NULL,
    CONSTRAINT [PK_LUTransmissionType] PRIMARY KEY CLUSTERED ([TransmissionTypeId] ASC),
);