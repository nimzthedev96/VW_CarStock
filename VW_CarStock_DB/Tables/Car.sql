CREATE TABLE [dbo].[car]
(
	[car_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_make_id] INT NOT NULL, 
    [car_model_id] INT NOT NULL, 
    [car_engine_type_id] INT NOT NULL,
    [car_trim_level_id] INT NOT NULL,
    [price] DECIMAL(18, 2) NOT NULL, 
    CONSTRAINT [FK_Car_ToCarMake] FOREIGN KEY (car_make_id) REFERENCES [car_make](car_make_id), 
    CONSTRAINT [FK_Car_ToCarModel] FOREIGN KEY (car_model_id) REFERENCES [car_model](car_model_id),
    CONSTRAINT [FK_Car_ToEngineType] FOREIGN KEY (car_engine_type_id) REFERENCES [car_engine_type](car_engine_type_id)
)


GO

CREATE INDEX [IX_Car_Column] ON [dbo].[car] ([car_make_id])

GO

CREATE INDEX [IX_Car_id] ON [dbo].[car] ([car_id])


