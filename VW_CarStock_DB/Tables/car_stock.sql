CREATE TABLE [dbo].[car_stock]
(
	[car_stock_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [car_id] INT NOT NULL, 
    [num_in_stock] INT NOT NULL DEFAULT 0, 
    [last_updated] DATE NOT NULL, 
    CONSTRAINT [FK_CarStock_ToCarType] FOREIGN KEY ([car_id]) REFERENCES [car](car_id) 
)

GO

CREATE INDEX [IX_CarStock_id] ON [dbo].[car_stock] ([car_stock_id])

GO

CREATE INDEX [IX_CarStock_CarType] ON [dbo].[car_stock] ([car_id])

GO

CREATE TRIGGER [dbo].[Trigger_SetLastUpdated]
    ON [dbo].[car_stock]
    FOR INSERT, UPDATE
    AS
    BEGIN
        SET NoCount ON
        UPDATE [dbo].[car_stock]
        SET [last_updated] = GETDATE()
        WHERE  [car_stock_id] = (SELECT [car_stock_id] FROM Inserted)
    END

