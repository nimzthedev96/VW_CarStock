CREATE TABLE [dbo].[car_has_feature]
(
    [car_type_feature_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_id] INT NOT NULL, 
    [car_feature_id] INT NOT NULL, 
    [is_optional] BIT NULL DEFAULT 0, 
    CONSTRAINT [FK_CarFeature_ToCarType] FOREIGN KEY ([car_id]) REFERENCES [car](car_id), 
    CONSTRAINT [FK_CarFeature_ToFeature] FOREIGN KEY ([car_feature_id]) REFERENCES [car_feature](car_feature_id), 
    
)

GO

CREATE INDEX [IX_CarFeature_Id] ON [dbo].[car_has_feature] ([car_type_feature_id])

GO

CREATE INDEX [IX_CarFeature_CarType] ON [dbo].[car_has_feature] (car_id)
