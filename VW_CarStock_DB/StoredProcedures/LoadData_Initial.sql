CREATE PROCEDURE [dbo].[LoadData_Initial]
	
AS
SET NOCOUNT ON
SET XACT_ABORT ON

DECLARE @rowcount int

/* Only if our DB is empty, add some records */
SELECT @rowcount = COUNT(*) FROM [car_make]
IF (@rowcount = 0) 
BEGIN
	BEGIN TRANSACTION
		/* Add car makes */
		INSERT INTO [car_make]([car_make_description]) VALUES ('VolksWagen'); 
		INSERT INTO [car_make]([car_make_description]) VALUES ('Toyota');
		INSERT INTO [car_make]([car_make_description]) VALUES ('Hyundai');
	
		/* Add engine types */
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.0, 'Standard', 0);  /*3*/
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.0, 'Standard', 1);
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.0, 'Turbo',    0); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.2, 'Standard', 0); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.2, 'Standard', 1);
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Standard', 0); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Standard', 1); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Turbo',    0); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (1.4, 'Turbo',    1); 
		INSERT INTO [car_engine_type]([engine_power], [engine_description], [is_automatic]) VALUES (2.0, 'Turbo',    1);  /*12*/

		/* Add features */
		INSERT INTO [car_feature]([feature_description]) VALUES('Alloy Wheels');   /*13*/
		INSERT INTO [car_feature]([feature_description]) VALUES('Electric Windows Front Only'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Electric Windows'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('ABS'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Infotainment System'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Leather seats'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Multi-function steering wheel'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Cruise control'); 
		INSERT INTO [car_feature]([feature_description]) VALUES('Fog lamps');  /*21*/

		/* Add new car models */
		INSERT INTO [car_model]([car_model_description]) VALUES('Polo Vivo Hatch'); /*22*/
		INSERT INTO [car_model]([car_model_description]) VALUES('Polo Sedan'); 
		INSERT INTO [car_model]([car_model_description]) VALUES('New Polo'); 
		INSERT INTO [car_model]([car_model_description]) VALUES('Golf'); 
		INSERT INTO [car_model]([car_model_description]) VALUES('T-Cross'); /*26*/

		/* Add Car Trim levels  */
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Standard');    /*27*/
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Comfortline');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Trendline');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Highline');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('R-Line');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('GTI');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Life');
		INSERT INTO [car_trim_level]([car_trim_level_description]) VALUES('Sport');  /*34*/

		/* Add cars and link their features */
		/* Polo Vivo */
		/*INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(46, 36, 58, 79, 227900.00); /* VW,Polo Vivo Hatch,Comfortline,227900 */
	
		*/
		/*INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(@SCOPE_IDENTITY(), 6);
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(1, 14); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(1, 4); */

		/*INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 22, 29, 6, 246000.00); /* VW,Polo Vivo Hatch,Trendline,246000	 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(2, 14); */
		/*INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(2, 3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(2, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(2, 5); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(2, 7); */

		/*INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price])VALUES(1, 22, 29, 6, 272800.00); /* VW,Polo Vivo Hatch,Highline,272800	 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 14); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 16); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 17); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 18); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 19); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 20);  
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(3, 21);  */

	
		/*INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(38, 1);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(44, 2);*/

		/* Polo Sedan */
		/*INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 2, 2, 4, 257500.00); /* VW,Polo Sedan,Comfortline,257500		  */ 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(4, 2); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(4, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(4, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(4, 9); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 2, 3, 6, 281300.00); /* VW,Polo Sedan,Trendline,281300		  */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(5, 3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(5, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(5, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(5, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(5, 9); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 2, 3, 7, 281300.00); /* VW,Polo Sedan,Trendline (auto), 290300 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(6, 3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(6, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(6, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(6, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(6, 9); 

		/* New Polo */
		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 3, 1, 1, 311800.00); /* VW,New Polo,Polo,311800 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 2); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 5); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 9); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 3, 7, 1, 350000.00); /* VW,New Polo,Life,350000 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 1); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 5); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(7, 9); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 3, 5, 1, 380000.00); /* VW,New Polo,R-Line,380000 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 1); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 5); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 9); 

		INSERT INTO [car]([car_make_id], [car_model_id], [car_trim_level_id], [car_engine_type_id], [price]) VALUES(1, 3, 6, 1, 489400.00); /* VW,New Polo,GTI,489400 */
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 1); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 3); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 4); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 5); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 6); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 7); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 8); 
		INSERT INTO [car_has_feature]([car_id], [car_feature_id]) VALUES(9, 9); 
		*/

		/* Add stock for cars */

		/*INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(4, 3);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(5, 0);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(6, 5);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(7, 4);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(8, 1);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(9, 1);
		INSERT INTO [car_stock]([car_id], [car_stock_id]) VALUES(10, 0);*/

	COMMIT
END

