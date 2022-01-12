CREATE PROCEDURE [dbo].[UpdateCar]
(
	@carId int,
	@carMakeId  int,
	@carModelId  int,
	@carTrimLevelId  int,
	@engineTypeId int,
	@price float
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	UPDATE [car]
	SET [car_make_id]=@carMakeId ,
		[car_model_id]=@carModelId ,
		[car_trim_level_id]=@carTrimLevelId ,
		[car_engine_type_id]=@engineTypeId,
		[price]=@price 
	WHERE [car].[car_id] = @carId;

COMMIT

GO
