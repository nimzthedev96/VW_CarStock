CREATE TABLE [dbo].[CarType]
(
	[car_type_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_make_id] INT NOT NULL, 
    [model] TEXT NOT NULL, 
    [engine_type_id] INT NOT NULL, 
    [price] FLOAT NOT NULL, 
    CONSTRAINT [FK_CarType_ToCarMake] FOREIGN KEY ([car_make_id]) REFERENCES [CarMake](car_make_id), 
    CONSTRAINT [FK_CarType_ToEngineType] FOREIGN KEY (engine_type_id) REFERENCES [EngineType](engine_type_id)
)

GO

CREATE INDEX [IX_CarType_id] ON [dbo].[CarType] (car_type_id)
