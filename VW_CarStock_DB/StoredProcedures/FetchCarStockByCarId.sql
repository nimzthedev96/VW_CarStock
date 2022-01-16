CREATE PROCEDURE [dbo].[FetchCarStockByCarId]
	@carId int 
AS
SET NOCOUNT ON
BEGIN
	SELECT [car].[car_id], [car].[price], [car_stock].[num_in_stock], [car].[car_model_id],
		   [car].[car_make_id], [car].[car_trim_level_id], [car].[car_engine_type_id],
		   [car_engine_type].[engine_description], [car_engine_type].[engine_power], [car_engine_type].[is_automatic]
	FROM [car]
	  LEFT  JOIN [car_stock]       ON [car].[car_id]=[car_stock].[car_id]
	  INNER JOIN car_engine_type   ON [car].[car_engine_type_id]=[car_engine_type].[car_engine_type_id]
	WHERE [car].[car_id]=@carId;
END
RETURN 0

