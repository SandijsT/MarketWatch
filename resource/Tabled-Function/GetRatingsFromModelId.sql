CREATE FUNCTION [dbo].[GetRatingsFromModelId]
(
	@modelId int
)
RETURNS TABLE
AS
RETURN
    SELECT *
           FROM Rating
           WHERE @modelId = ModelId
