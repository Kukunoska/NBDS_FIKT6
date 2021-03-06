MERGE INTO [dbo].[Predmet] AS [target]
USING 
	(VALUES 
		(N'ИКТ-111', N'Дигитална техника'), 
		(N'ИКТ-112', N'Математика 2')
	) 
	AS [source] (shifraNaPredmet, ime)
ON [target].Ime = [source].ime
WHEN MATCHED THEN
	UPDATE SET [target].Shifra_Na_Predmet = [source].shifraNaPredmet, [target].Ime = [source].ime
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Shifra_Na_Predmet], [Ime]) VALUES ([source].shifraNaPredmet, [source].ime)
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;