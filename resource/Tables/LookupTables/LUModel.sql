CREATE TABLE [dbo].[LUModel] (
    [ModelId]               INT             IDENTITY (1, 1) NOT NULL,
    [Model]                 NVARCHAR (100)  NOT NULL,
    [Manufacturer]          NVARCHAR (100)  NOT NULL,
    CONSTRAINT [PK_LUModel] PRIMARY KEY CLUSTERED ([ModelId] ASC),
);