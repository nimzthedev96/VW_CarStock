CREATE PROCEDURE [dbo].[LoadData_Initial]
AS
	/* Add car makes */
	INSERT INTO CarMake(car_make_description) VALUES ('VolksWagen'); 
	INSERT INTO CarMake(car_make_description) VALUES ('Toyota');
	INSERT INTO CarMake(car_make_description) VALUES ('Hyundai');
	
	/* Add engine types */
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.0, 'Standard', 0);
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.0, 'Standard', 1);
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.0, 'Turbo', 0); 
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.2, 'Standard', 0); 
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.2, 'Standard', 1);
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.4, 'Standard', 0); 
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.4, 'Turbo', 0); 
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (1.4, 'Turbo', 1); 
	INSERT INTO EngineType(engine_power, engine_description, is_automatic)
	VALUES (2.0, 'Turbo', 1); 

	/* Add features */
	INSERT INTO Feature(feature_description) VALUES('Alloy Wheels'); 
	INSERT INTO Feature(feature_description) VALUES('Electric Windows Front Only'); 
	INSERT INTO Feature(feature_description) VALUES('Electric Windows'); 
	INSERT INTO Feature(feature_description) VALUES('ABS'); 
	INSERT INTO Feature(feature_description) VALUES('Infotainment System'); 
	INSERT INTO Feature(feature_description) VALUES('Leather seats'); 
	INSERT INTO Feature(feature_description) VALUES('Multi-function steering wheel'); 
	INSERT INTO Feature(feature_description) VALUES('Cruise control'); 
	INSERT INTO Feature(feature_description) VALUES('Fog lamps'); 

	/* Add new car types and link their features */
	/*INSERT INTO Car(car_make_id,model,engine_type_id,price) VALUES(1, 'Polo Vivo Hatch', 1, 227900.00); 
	INSERT INTO Car(car_make_id,model,engine_type_id,price) VALUES(1, 'Polo Sedan', 1, 290000.00); 
	INSERT INTO Car(car_make_id,model,engine_type_id,price) VALUES(1, 'Polo Vivo', 1, 290000.00); 
	INSERT INTO CarType(car_make_id,model,engine_type_id,price) VALUES(1, 'Polo Vivo', 1, 290000.00); */

	/* Add stock for car types */


RETURN 0
