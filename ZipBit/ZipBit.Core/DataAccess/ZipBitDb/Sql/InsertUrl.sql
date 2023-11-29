--DECLARE @UrlOriginal		VARCHAR(2048) = 'https://www.google.hr'
--DECLARE @UrlShortened	    VARCHAR(2048) = 'https://zipbit.io/cbedh419'

INSERT INTO [dbo].[Url] ([UrlOriginal], [UrlShortened])
VALUES (@UrlOriginal, @UrlShortened);

SELECT SCOPE_IDENTITY();