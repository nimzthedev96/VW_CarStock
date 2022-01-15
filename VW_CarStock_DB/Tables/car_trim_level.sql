CREATE TABLE [dbo].[car_trim_level]
(
	[car_trim_level_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_trim_level_description] TEXT NOT NULL
)

GO

CREATE INDEX [IX_CarTrimLevel_id] ON [dbo].[car_trim_level] ([car_trim_level_id])
