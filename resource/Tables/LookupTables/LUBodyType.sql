CREATE TABLE [dbo].[LUBodyType](
	[BodyTypeId]               INT             IDENTITY (1, 1) NOT NULL,
    [BodyType]                 NVARCHAR (MAX)  NOT NULL,
	CONSTRAINT [PK_LUBodyType] PRIMARY KEY CLUSTERED ([BodyTypeId] ASC),
);
