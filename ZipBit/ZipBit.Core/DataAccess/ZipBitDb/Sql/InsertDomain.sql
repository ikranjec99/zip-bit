--DECLARE @Name             VARCHAR(100) = 'zipbit.io'

INSERT INTO [dbo].[Domain] ([Name]) VALUES (@Name);

SELECT SCOPE_IDENTITY();