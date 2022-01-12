CREATE TABLE [dbo].[car_make]
(
	[car_make_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_make_description] TEXT NOT NULL
)

GO

CREATE INDEX [IX_CarMake_id] ON [dbo].[car_make] (car_make_id)
