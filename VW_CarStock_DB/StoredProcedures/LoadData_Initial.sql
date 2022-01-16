CREATE PROCEDURE [dbo].[LoadData_Initial]
	
AS
SET NOCOUNT ON
SET XACT_ABORT ON

DECLARE @rowcount int

DECLARE @makeId1 int

DECLARE @modelId1 int
DECLARE @modelId2 int
DECLARE @modelId3 int
DECLARE @modelId4 int

DECLARE @engineTypeId1 int
DECLARE @engineTypeId2 int
DECLARE @engineTypeId3 int
DECLARE @engineTypeId4 int

DECLARE @featureId1 int
DECLARE @featureId2 int
DECLARE @featureId3 int
DECLARE @featureId4 int

DECLARE @trimLevelId1 int
DECLARE @trimLevelId2 int
DECLARE @trimLevelId3 int
DECLARE @trimLevelId4 int

DECLARE @carId int


/* Only if our DB is empty, add some records */
SELECT @rowcount = COUNT(*) FROM [car_make]
IF (@rowcount = 0) 
BEGIN
	BEGIN TRANSACTION
		/* Add car makes */
		INSERT INTO [car_make]([car_make_description]) VALUES ('Volkswagen'); 
		SET @makeId1 = SCOPE_IDENTITY();
		INSERT INTO [car_make]([car_make_description]) VALUES ('Toyota');
		INSERT INTO [car_make]([car_make_description]) VALUES ('Hyundai');
	
		/* Add engine types */
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.0, 'Standard', 0);  /*3*/
		SET @engineTypeId1 = SCOPE_IDENTITY();
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.0, 'Standard', 1);
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.0, 'Turbo',    0); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.2, 'Standard', 0);
		SET @engineTypeId2 = SCOPE_IDENTITY();
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.2, 'Standard', 1);
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Standard', 0); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Standard', 1); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Turbo',    0); 
		SET @engineTypeId3 = SCOPE_IDENTITY();
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Turbo',    1); 
		SET @engineTypeId4 = SCOPE_IDENTITY();
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (2.0, 'Turbo',    1);  /*12*/

		/* Add features */
		INSERT INTO [car_feature]([feature_description]) VALUES('Alloy Wheels');   /*13*/
		SET @featureId1 = SCOPE_IDENTITY();
		INSERT INTO [car_feature]([feature_description]) VALUES('Electric Windows Front Only'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Electric Windows'); 
		SET @featureId2 = SCOPE_IDENTITY();
		INSERT INTO [car_feature]([feature_description]) VALUES('ABS'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Infotainment System'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Leather seats'); 
		SET @featureId3 = SCOPE_IDENTITY();
		INSERT INTO [car_feature]([feature_description]) VALUES('Multi-function steering wheel'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Cruise control'); 
		SET @featureId4 = SCOPE_IDENTITY();
		INSERT INTO [car_feature]([feature_description]) VALUES('Fog lamps');  /*21*/

		/* Add new car models */
		INSERT INTO [car_model]([car_model_description]) VALUES('Polo Vivo Hatch'); /*22*/
		SET @modelId1 = SCOPE_IDENTITY();
		INSERT INTO [car_model]([car_model_description]) VALUES('Polo Sedan'); 
		INSERT INTO [car_model]([car_model_description]) VALUES('New Polo'); 
		SET @modelId2 = SCOPE_IDENTITY();
		INSERT INTO [car_model]([car_model_description]) VALUES('Golf'); 
		SET @modelId3 = SCOPE_IDENTITY();
		INSERT INTO [car_model]([car_model_description]) VALUES('T-Cross'); /*26*/
		SET @modelId4 = SCOPE_IDENTITY();
		
		/* Add Car Trim levels  */
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Standard');    /*27*/
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Comfortline');
		SET @trimLevelId1 = SCOPE_IDENTITY(); 
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Trendline');
		SET @trimLevelId2 = SCOPE_IDENTITY(); 
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Highline');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('R-Line');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('GTI');
		SET @trimLevelId3 = SCOPE_IDENTITY(); 
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Life');
		SET @trimLevelId4 = SCOPE_IDENTITY(); 
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Sport');  /*34*/

		/* Add cars and link their features */
		/* Polo Vivo */
		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(@makeId1, @modelId1, @trimLevelId1, @engineTypeId1, 227900.00); /* VW,Polo Vivo Hatch,Comfortline,227900 */
		SET @carId = SCOPE_IDENTITY();
		INSERT INTO [car_stock]([car_id], [num_in_stock], [last_updated]) VALUES(@carId, 6, GETDATE());
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId1); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId2); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(@makeId1, @modelId2, @trimLevelId1, @engineTypeId3, 351900.00); /* VW,Polo Vivo Hatch,Comfortline,227900 */
		SET @carId = SCOPE_IDENTITY();
		INSERT INTO [car_stock]([car_id], [num_in_stock], [last_updated]) VALUES(@carId, 2, GETDATE());
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId2); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId4); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(@makeId1, @modelId3, @trimLevelId3, @engineTypeId4, 452900.00); /* VW,Polo Vivo Hatch,Comfortline,227900 */
		SET @carId = SCOPE_IDENTITY();
		INSERT INTO [car_stock]([car_id], [num_in_stock], [last_updated]) VALUES(@carId, 1, GETDATE());
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId1); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId2); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(@carId, @featureId4); 


	COMMIT
END

