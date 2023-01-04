CREATE FUNCTION [dbo].[GetRatingDistinctCombinations] ()
RETURNS TABLE
AS
RETURN
	SELECT DISTINCT ModelId, EngineDisplacementTypeId, TransmissionTypeId, FuelTypeId, BodyTypeId, CategoryId
           FROM Vehicle