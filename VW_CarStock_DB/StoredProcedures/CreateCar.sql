CREATE PROCEDURE [dbo].[CreateCar]
(
	@carMakeId  int,
	@carModelId  int,
	@carTrimLevelId  int,
	@carengineTypeId int,
	@numstock int,
	@price float
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	INSERT INTO [car]
		([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) 
		VALUES(@carMakeId, @carModelId, @carTrimLevelId, @carengineTypeId, @price);
	INSERT INTO [car_stock]
		([car_id], [num_in_stock])
		VALUES(SCOPE_IDENTITY(), @numstock);
COMMIT
