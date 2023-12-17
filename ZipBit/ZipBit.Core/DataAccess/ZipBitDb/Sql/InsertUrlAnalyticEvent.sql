--DECLARE @EventTypeId          BIGINT = 1
--DECLARE @UrlId    		    BIGINT = 1

INSERT INTO [dbo].[UrlAnalyticEvent] 
([EventTypeId], [UrlId])
VALUES (@EventTypeId, @UrlId);