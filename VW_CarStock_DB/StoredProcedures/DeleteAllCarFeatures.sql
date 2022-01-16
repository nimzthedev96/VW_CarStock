CREATE PROCEDURE [dbo].[DeleteAllCarFeatures]
(
	@carId  int
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	DELETE FROM [car_has_feature] WHERE [car_has_feature].[car_id] = @carId;
COMMIT
