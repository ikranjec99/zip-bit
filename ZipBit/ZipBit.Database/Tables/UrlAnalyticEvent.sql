CREATE TABLE [dbo].[UrlAnalyticEvent]
(
	[Id]				BIGINT NOT NULL PRIMARY KEY IDENTITY,
	[Created]			DATETIME2(3) NOT NULL DEFAULT GETDATE(),
	[EventTypeId]       BIGINT NOT NULL,
	[UrlId]             BIGINT NOT NULL,
	CONSTRAINT			[FK_UrlAnalytic_UrlId] FOREIGN KEY ([UrlId]) REFERENCES Url([Id])
)
