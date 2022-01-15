CREATE PROCEDURE [dbo].[FetchCarFeaturesByCarId]
	@carId int 
AS
SET NOCOUNT ON
BEGIN
	SELECT [car].[car_id], [car_feature].[car_feature_id], [car_feature].[feature_description]	  
	FROM [car]
	  LEFT  JOIN [car_has_feature]   ON [car_has_feature].[car_id]=[car].[car_id]
	  INNER JOIN [car_feature]       ON [car_feature].[car_feature_id]=[car_has_feature].[car_feature_id]
	
	WHERE [car].[car_id]=@carId;
END
RETURN 0
