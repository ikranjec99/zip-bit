--DECLARE @Id	BIGINT = 1

 SELECT [Id], [Created], [UrlOriginal], [UrlShortened] FROM [dbo].[Url]
 WHERE [Id] = @Id;