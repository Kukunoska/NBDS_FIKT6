SET IDENTITY_INSERT dbo.Vid_Organizacija ON
GO

MERGE INTO [dbo].[Vid_Organizacija] AS [target]
USING
    (VALUES 
		(1, N'Образовна институција'), 
		(2, N'Приватна фирма')
	) 
	AS [source] (id, ime)
ON [target].[ID] = [source].[id]
WHEN MATCHED THEN
    UPDATE SET Ime = [source].[ime]
WHEN NOT MATCHED BY TARGET THEN
    INSERT ([ID], [Ime]) VALUES ([source].[id], [source].[ime])
WHEN NOT MATCHED BY SOURCE THEN
    DELETE
;

SET IDENTITY_INSERT dbo.Vid_Organizacija OFF
GO
