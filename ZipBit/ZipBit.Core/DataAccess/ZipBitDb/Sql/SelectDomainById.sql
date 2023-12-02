--DECLARE @Id	BIGINT = 1

 SELECT 
	[Id], 
	[Created], 
	[Name]
 FROM [dbo].[Domain]
 WHERE [Id] = @Id;