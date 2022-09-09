﻿CREATE TABLE [dbo].[Vehicle] (
	[PostId]                   INT             IDENTITY (1, 1) NOT NULL,
	[Price]                    DECIMAL (19, 2) NULL,
    [Title]                    NVARCHAR (2048) NULL,
    [Desription]               NVARCHAR (MAX)  NULL,
    [ReleaseDate]              DATETIME2 (7)   NULL,
    [TIEndDate]                DATETIME2 (7)   NULL,
    [Mileage]                  INT             NULL,
    [Color]                    NVARCHAR (50)   NULL,
    [ModelId]                  INT             NOT NULL,
    [EngineDisplacementTypeId] INT             NOT NULL,
    [TransmissionTypeId]       INT             NOT NULL,
    [FuelTypeId]               INT             NOT NULL,
    [BodyTypeId]               INT             NOT NULL,
    [PostTypeId]               INT             NOT NULL,
    [CategoryId]               INT             NOT NULL,
    [Link]                     NVARCHAR (2048) NULL,
    [Views]                    INT             NULL,
    [PublishedDate]            DATETIME2 (7)   NULL,
    [StorageDate]              DATETIME2 (7)   NOT NULL,
	CONSTRAINT [PK_Vehicle] PRIMARY KEY CLUSTERED ([PostId] ASC),
    CONSTRAINT [FK_Vehicle_LUModel] FOREIGN KEY ([ModelId]) REFERENCES [dbo].[LUModel] ([ModelId]),
    CONSTRAINT [FK_Vehicle_LUEngineDisplacementType] FOREIGN KEY ([EngineDisplacementTypeId]) REFERENCES [dbo].[LUEngineDisplacementType] ([EngineDisplacementTypeId]),
    CONSTRAINT [FK_Vehicle_LUTransmissionType] FOREIGN KEY ([TransmissionTypeId]) REFERENCES [dbo].[LUTransmissionType] ([TransmissionTypeId]),
    CONSTRAINT [FK_Vehicle_LUFuelType] FOREIGN KEY ([FuelTypeId]) REFERENCES [dbo].[LUFuelType] ([FuelTypeId]),
    CONSTRAINT [FK_Vehicle_LUBodyType] FOREIGN KEY ([BodyTypeId]) REFERENCES [dbo].[LUBodyType] ([BodyTypeId]),
    CONSTRAINT [FK_Vehicle_LUPostType] FOREIGN KEY ([PostTypeId]) REFERENCES [dbo].[LUPostType] ([PostTypeId]),
    CONSTRAINT [FK_Vehicle_LUCategory] FOREIGN KEY ([CategoryId]) REFERENCES [dbo].[LUCategory] ([CategoryId]),
);