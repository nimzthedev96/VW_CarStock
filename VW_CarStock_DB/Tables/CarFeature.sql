CREATE TABLE [dbo].[CarFeature]
(
    [car_type_feature_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_id] INT NOT NULL, 
    [feature_id] INT NOT NULL, 
    [is_optional] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_CarFeature_ToCarType] FOREIGN KEY ([car_id]) REFERENCES [Car](car_id), 
    CONSTRAINT [FK_CarFeature_ToFeature] FOREIGN KEY ([feature_id]) REFERENCES [Feature](feature_id), 
    
)

GO

CREATE INDEX [IX_CarFeature_Id] ON [dbo].[CarFeature] ([car_type_feature_id])

GO

CREATE INDEX [IX_CarFeature_CarType] ON [dbo].[CarFeature] (car_id)
