CREATE PROCEDURE [dbo].[DeleteCar]
	@carId int
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	DELETE FROM [car_has_feature] WHERE [car_has_feature].[car_id] = @carId;
	DELETE FROM [car_stock] WHERE [car_stock].[car_id] = @carId;
	DELETE FROM [car] WHERE [car].[car_id] = @carId;
COMMIT
