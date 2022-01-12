CREATE TABLE [dbo].[CarStock]
(
	[car_stock_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_type_id] INT NOT NULL, 
    [num_in_stock] INT NOT NULL DEFAULT 0, 
    CONSTRAINT [FK_CarStock_ToCarType] FOREIGN KEY ([car_type_id]) REFERENCES [CarType](car_type_id) 
)

GO

CREATE INDEX [IX_CarStock_id] ON [dbo].[CarStock] ([car_stock_id])

GO

CREATE INDEX [IX_CarStock_CarType] ON [dbo].[CarStock] ([car_type_id])


