CREATE TABLE [dbo].[Rating]
(
    [RatingId]                 INT             IDENTITY (1, 1) NOT NULL,
    [SampleCount]              INT             NOT NULL,
    [AveragePrice]             DECIMAL (19, 2) NULL,
    [AverageMileage]           INT             NULL,
    [ModelId]                  INT             NOT NULL,
    [EngineDisplacementTypeId] INT             NOT NULL,
    [TransmissionTypeId]       INT             NOT NULL,
    [FuelTypeId]               INT             NOT NULL,
    [BodyTypeId]               INT             NOT NULL,
    [StorageDate]              DATETIME2 (7)   NOT NULL,
    CONSTRAINT [PK_Rating] PRIMARY KEY CLUSTERED ([RatingId] ASC),
    CONSTRAINT [FK_Rating_LUModel] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[LUModel] ([ModelId]),
    CONSTRAINT [FK_Rating_LUEngineDisplacementType] FOREIGN KEY ([EngineDisplacementTypeId]) REFERENCES [dbo].[LUEngineDisplacementType] ([EngineDisplacementTypeId]),
    CONSTRAINT [FK_Rating_LUTransmissionType] FOREIGN KEY ([TransmissionTypeId]) REFERENCES [dbo].[LUTransmissionType] ([TransmissionTypeId]),
    CONSTRAINT [FK_Rating_LUFuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[LUFuelType] ([FuelTypeId]),
    CONSTRAINT [FK_Rating_LUBodyType] FOREIGN KEY ([BodyTypeId]) REFERENCES [dbo].[LUBodyType] ([BodyTypeId]),
);
