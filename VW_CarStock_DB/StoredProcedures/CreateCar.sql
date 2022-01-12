CREATE PROCEDURE [dbo].[CreateCar]
(
	@carMakeId  int,
	@carModelId  int,
	@carTrimLevelId  int,
	@carengineTypeId int,
	@price float
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	INSERT INTO [car]
		([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) 
		VALUES(@carMakeId, @carModelId, @carTrimLevelId, @carengineTypeId, @price);
	
COMMIT
