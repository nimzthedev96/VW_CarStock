CREATE TABLE [dbo].[car_model]
(
	[car_model_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [description] TEXT NOT NULL
)

GO

CREATE INDEX [IX_CarModel_id] ON [dbo].[car_model] ([car_model_id])
