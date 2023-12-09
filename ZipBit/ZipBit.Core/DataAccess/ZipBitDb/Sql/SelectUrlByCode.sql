--DECLARE @Code	VARCHAR(10) = '1bb06dfaae'

 SELECT 
	[Id], 
	[Code], 
	[Created], 
	[DomainId], 
	[UrlOriginal] 
 FROM [dbo].[Url]
 WHERE [Code] = @Code;