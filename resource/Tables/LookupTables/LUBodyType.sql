CREATE TABLE [dbo].[LUBodyType] (
    [BodyTypeId]               INT             NOT NULL,
    [BodyType]                 NVARCHAR (MAX)  NOT NULL,
    CONSTRAINT [PK_LUBodyType] PRIMARY KEY CLUSTERED ([BodyTypeId] ASC),
);
