-- dbo.Domain
IF (NOT EXISTS(SELECT TOP 1 * FROM [dbo].[Domain] WHERE [Name] = 'zipbit.io'))
	INSERT INTO [dbo].[Domain] ([Name]) VALUES ('zipbit.io');