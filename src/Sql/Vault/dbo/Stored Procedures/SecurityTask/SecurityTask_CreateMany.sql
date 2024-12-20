CREATE PROCEDURE [dbo].[SecurityTask_CreateMany]
    @Tasks AS [dbo].[SecurityTaskType] READONLY
AS
BEGIN
    SET NOCOUNT ON

    INSERT INTO [dbo].[SecurityTask]
    (
        [Id],
        [OrganizationId],
        [CipherId],
        [Type],
        [Status],
        [CreationDate],
        [RevisionDate]
    )
    SELECT
        ST.[Id],
        ST.[OrganizationId],
        ST.[CipherId],
        ST.[Type],
        ST.[Status],
        ST.[CreationDate],
        ST.[RevisionDate]
    FROM
        @Tasks ST
END
