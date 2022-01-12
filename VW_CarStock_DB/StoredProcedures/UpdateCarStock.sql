CREATE PROCEDURE [dbo].[UpdateCarStock]
(
	@carId int,
	@numStock  int	
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	UPDATE [car_stock]
	SET [num_in_stock]=@numStock 
	WHERE [car_stock].[car_id] = @carId;

COMMIT

GO
