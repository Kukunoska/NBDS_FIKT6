MERGE INTO [dbo].[Korisnik] AS[target]
USING
	(VALUES
		(
			N'jasmina', 0x52FFD3E58B513F7C3401C353D50718A0F8C8BFC3E957552E2BA25B1034196B70C8C3A8307852172024BF4A37E997AB6F,
			N'Јасмина', N'Кукуноска', N'Ж', 1, 1, N'jasminakukunoska@gmail.com', NULL, 1, 1, 1
		),
		(
			N'marija', 0x73E431A3C903B0DAF9CF9B6CE28609B8EC7088B78FA2F6DD2C12FA1E43236F29061D55122F8785652B823DEC25A96332,
			N'Марија', N'Кузмановска', N'Ж', 1, 1, N'm_kuzmanovska08@yahoo.com', NULL, 1, 1, 1
		),
		(
			N'simona', 0x3A71DAD6BC4B17421C1E96896557ACF274B2C5D758FC55FE97D0C0276060AA9E79FD40A45353E43670CEC51F6315B47E,
			N'Симона', N'Апостолоска', N'Ж', 1, 1, N'simonaapostoloska@gmail.com', NULL, 1, 1, 1
		),
		(
			N'evgenija', 0xF19FBF0E7B95623F60E5A7050EED649D6989EEAEBF64BC4FAA6015CDBDACAB11621EECF20D61E3E6C07928DE96E8C8AD,
			N'Евгенија', N'Конеска', N'Ж', 1, 1, N'koneskaevgenija@gmail.com', NULL, 1, 1, 1
		),
		(
			N'frosina', 0xA93EC1D6913B2512513DB2BCA562137BD69856BE4A5E4DCBA9218F781D3ABD40B97EE770CCB573F1FA160D916C2AF207,
			N'Фросина', N'Христоска', N'Ж', 1, 1, N'frosinahristoska@icloud.com', NULL, 1, 1, 1
		),
		(
			N'sara', 0x7C72F1BE9BB3026360EB781EF05258896FB606C823D628EF6EECF789BAE42C3BC648C0F0F0CA6F8B1632BD683B7B0F7A,
			N'Сара', N'Богоеска', N'Ж', 1, 1, N'bogoeskasara4@gmail.com', NULL, 1, 1, 1
		),
		(
			N'zoran', 0x95109179BFCA31D4BAAF4EDB2D67305186950019A6B0ADC7897A8273C8F58C7F2855E4E4D9F4F7F23805898A0DCDB2EC,
			N'Зоран', N'Котевски', N'М', 1, 1, N'zoran.kotevski@gmail.com', NULL, 1, 1, 1
		),
		(
			N'goce', 0x19C1C2C01D268827E244A5F502C22182E87ED34463582B0BB244028D14E99F82D80944F8F290CF441A6858E8F4EFD919,
			N'Гоце', N'Смилевски', N'М', 1, 1, N'g_smilevski@hotmail.com', NULL, 1, 1, 1
		),

		(
			N'admin', 0x209066918D438C08CB70A48B63A16A7D21F4C843F730917BA063D8B2CA1DC1AFB9CF1930CC307A1E5BCB8D3745CFA384,
			N'Администратор', N'Администратор', N'М', NULL, 1, N'learnbypractice@fikt.edu.mk', NULL, 1, 0, 0
		),
		(
			N'mentor', 0xA941EBD48114CC7633387086280E59A3EC8998C32B07104AA4E54BBA63C5F035402BFBE6FFF485627F4F39279CE8D336,
			N'Ментор', N'Ментор', N'М', NULL, 1, N'learnbypractice@fikt.edu.mk', NULL, 0, 0, 1
		),
		(
			N'student', 0xEB829C7DDEC89D7DAE207F519B3ADC609A61E9EE2AEDA48BEAA80B4258EF50C337FC0A0C0A86370805B28C678C5ACDB6,
			N'Студент', N'Студент', N'М', 1, 1, N'learnbypractice@fikt.edu.mk', NULL, 0, 1, 0
		)
	)
	AS [source] (korisnichkoIme, lozinka, ime, prezime, pol, studiskaProgramaID, organizacijaID,
				 email, telefonskiBroj, administrator, student, mentor)
ON [target].Korisnichko_Ime = [source].korisnichkoIme
WHEN MATCHED THEN
	UPDATE SET [target].Korisnichko_Ime = [source].korisnichkoIme,
				[target].Lozinka = [source].lozinka,
				[target].Ime = [source].ime, 
				[target].Prezime = [source].prezime,
				[target].Pol = [source].pol,
				[target].Studiska_Programa_ID = [source].studiskaProgramaID,
				[target].Organizacija_ID = [source].organizacijaID,
				[target].Email = [source].email,
				[target].Telefonski_Broj = [source].telefonskiBroj,
				[target].Administrator = [source].administrator,
				[target].Student = [source].student,
				[target].Mentor = [source].mentor
WHEN NOT MATCHED BY TARGET THEN
	INSERT ([Korisnichko_Ime], [Lozinka], [Ime], [Prezime], [Pol], [Studiska_Programa_ID],
			[Organizacija_ID], [Email], [Telefonski_Broj], [Administrator], [Student], [Mentor])
		VALUES ([source].[korisnichkoIme], [source].[lozinka], [source].[ime], [source].[prezime],
				[source].[pol], [source].[studiskaProgramaID], [source].[organizacijaID],
				[source].[email], [source].[telefonskiBroj], [source].[administrator],
				[source].[student], [source].[mentor])
WHEN NOT MATCHED BY SOURCE THEN
	DELETE;