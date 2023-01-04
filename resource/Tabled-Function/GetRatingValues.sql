CREATE FUNCTION [dbo].[GetRatingValues]
(
	@modelId int,
	@engineDisplacementTypeId int,
	@transmissionTypeId int,
	@fuelTypeId int,
	@bodyTypeId int,
	@categoryId int
)
RETURNS TABLE
AS
RETURN
    SELECT Price, Mileage
           FROM Vehicle
           WHERE @modelId = ModelId AND 
		   @engineDisplacementTypeId = EngineDisplacementTypeId AND 
		   @transmissionTypeId = TransmissionTypeId AND 
		   @fuelTypeId = FuelTypeId AND
		   @bodyTypeId = BodyTypeId AND
		   @categoryId = CategoryId
