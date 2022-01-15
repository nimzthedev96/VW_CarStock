CREATE PROCEDURE [dbo].[FetchAllCarStock]
AS
BEGIN
	SELECT [car].[car_id], [car].[price], [car_stock].[num_in_stock], [car_model].[car_model_description], [car_trim_level].[car_trim_level_description], 
		   [car_engine_type].[engine_power], [car_engine_type].[engine_description], [car_engine_type].[is_automatic]
	FROM [car]
	  LEFT  JOIN [car_stock]       ON [car].[car_id]=[car_stock].[car_id]
	  INNER JOIN [car_model]       ON [car].[car_model_id]=[car_model].[car_model_id]
	  INNER JOIN [car_trim_level]  ON [car].[car_trim_level_id]=[car_trim_level].[car_trim_level_id]
	  INNER JOIN [car_engine_type] ON [car].[car_engine_type_id]=[car_engine_type].[car_engine_type_id]
END
RETURN 0
