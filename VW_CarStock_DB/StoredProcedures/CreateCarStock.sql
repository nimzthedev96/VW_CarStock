CREATE PROCEDURE [dbo].[CreateCarStock]
(
	@carId  int,
	@numInStock  int = 0
)
AS
SET NOCOUNT ON
SET XACT_ABORT ON
BEGIN TRANSACTION
	INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(@carId, @numInStock);
COMMIT
