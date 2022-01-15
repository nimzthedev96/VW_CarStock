CREATE PROCEDURE [dbo].[InitializeList]
	@listtype varchar
AS
BEGIN
	IF (@listtype = 'Model') 
	BEGIN 
		SELECT * 
		FROM [car_model]
	END;

	IF (@listtype = 'Make' )
	BEGIN 
		SELECT * 
		FROM [car_make]
	END;

	IF (@listtype = 'TrimLevel')
	BEGIN 
		SELECT * 
		FROM [car_trim_level]
	END;

	IF (@listtype = 'Feature') 
	BEGIN 
		SELECT * 
		FROM [car_feature]
	END;
END

RETURN 0

