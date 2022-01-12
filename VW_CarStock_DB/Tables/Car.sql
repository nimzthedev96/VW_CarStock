CREATE TABLE [dbo].[Car]
(
	[car_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_make_id] INT NOT NULL, 
    [car_model_id] INT NOT NULL, 
    [engine_type_id] INT NOT NULL,
    [car_trim_level_id] INT NOT NULL,
    [price] FLOAT NOT NULL, 
    CONSTRAINT [FK_Car_ToCarMake] FOREIGN KEY (car_make_id) REFERENCES [CarMake](car_make_id), 
    CONSTRAINT [FK_Car_ToCarModel] FOREIGN KEY (car_model_id) REFERENCES [CarModel](car_model_id),
    CONSTRAINT [FK_Car_ToEngineType] FOREIGN KEY (engine_type_id) REFERENCES [EngineType](engine_type_id)
)


GO

CREATE INDEX [IX_Car_Column] ON [dbo].[Car] ([car_make_id])

GO

CREATE INDEX [IX_Car_id] ON [dbo].[Car] ([car_id])


