﻿CREATE TABLE [dbo].[EngineType]
(
	[engine_type_id] INT IDENTITY(1,1) NOT NULL PRIMARY KEY, 
    [engine_power] DECIMAL(2, 2) NOT NULL, 
    [engine_description] TEXT NOT NULL, 
    [is_automatic] BIT NULL DEFAULT 0

)

GO

CREATE INDEX [IX_EngineType_id] ON [dbo].[EngineType] ([engine_type_id])
