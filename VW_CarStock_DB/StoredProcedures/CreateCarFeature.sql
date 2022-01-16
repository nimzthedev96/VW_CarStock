CREATE PROCEDURE [dbo].[CreateCarFeature]
(
	@carId  int,
	@featureId  int
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId);
COMMIT
