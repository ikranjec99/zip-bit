--DECLARE @Code             VARCHAR(10) = 'm5AC5opL3z'
--DECLARE @DomainId		    BIGINT = 1
--DECLARE @UrlOriginal	    VARCHAR(2048) = 'https://stackoverflow.com/questions/6030099/does-dapper-support-the-like-operator'

INSERT INTO [dbo].[Url] 
([Code], [DomainId], [UrlOriginal])
VALUES (@Code, @DomainId, @UrlOriginal);

SELECT SCOPE_IDENTITY();