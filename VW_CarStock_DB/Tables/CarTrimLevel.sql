CREATE TABLE [dbo].[CarTrimLevel]
(
	[car_trim_level_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [description] TEXT NOT NULL
)

GO

CREATE INDEX [IX_CarTrimLevel_id] ON [dbo].[CarTrimLevel] ([car_trim_level_id])
