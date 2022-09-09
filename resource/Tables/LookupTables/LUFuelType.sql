CREATE TABLE [dbo].[LUFuelType] (
    [FuelTypeId]               INT             IDENTITY (1, 1) NOT NULL,
    [FuelType]                 NVARCHAR (100)  NOT NULL,
    CONSTRAINT [PK_LUFuelType] PRIMARY KEY CLUSTERED ([FuelTypeId] ASC),
);