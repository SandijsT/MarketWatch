CREATE TABLE [dbo].[LUEngineDisplacementType] (
    [EngineDisplacementTypeId]               INT              NOT NULL,
    [EngineDisplacementType]                 NVARCHAR (100)   NOT NULL,
    [EngineDisplacement]                     DECIMAL (19, 2)  NOT NULL,
    CONSTRAINT [PK_LUEngineDisplacementType] PRIMARY KEY CLUSTERED ([EngineDisplacementTypeId] ASC),
);
