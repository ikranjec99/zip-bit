﻿--DECLARE @Id	BIGINT = 1

 SELECT 
	[Id], 
	[Code], 
	[Created], 
	[DomainId], 
	[UrlOriginal] 
 FROM [dbo].[Url]
 WHERE [Id] = @Id;