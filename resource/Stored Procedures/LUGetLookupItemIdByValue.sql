CREATE PROCEDURE [dbo].[LUGetLookupItemIdByValue]
    @Category VARCHAR(255),
    @LanguageId INT,
    @Description VARCHAR(255)
AS
BEGIN
    SET NOCOUNT ON;

    DECLARE @IdName VARCHAR(100)
    SET @IdName = substring(@Category, 1, len(@Category) - 8) + 'Id'
    EXEC ('SELECT  ' + @IdName + ' FROM ' + @Category
    + ' WHERE LanguageId = ' + @LanguageId + ' and Description = ''' + @Description + '''');
END;