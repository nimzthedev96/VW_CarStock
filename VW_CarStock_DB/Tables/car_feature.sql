﻿CREATE TABLE [dbo].[car_feature]
(
	[car_feature_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [feature_description] TEXT NOT NULL
)

GO

CREATE INDEX [IX_Feature_id] ON [dbo].[car_feature] ([car_feature_id])

