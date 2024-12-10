﻿CREATE PROCEDURE [dbo].[CollectionCipher_UpdateCollections]
    @CipherId UNIQUEIDENTIFIER,
    @UserId UNIQUEIDENTIFIER,
    @CollectionIds AS [dbo].[GuidIdArray] READONLY
AS
BEGIN
    SET NOCOUNT ON

    DECLARE @OrgId UNIQUEIDENTIFIER = (
        SELECT TOP 1
            [OrganizationId]
        FROM
            [dbo].[Cipher]
        WHERE
            [Id] = @CipherId
    )

    -- Common CTE for available collections
    ;WITH [AvailableCollectionsCTE] AS(
        SELECT
            C.[Id]
        FROM
            [dbo].[Collection] C
        INNER JOIN
            [Organization] O ON O.[Id] = C.[OrganizationId]
        INNER JOIN
            [dbo].[OrganizationUser] OU ON OU.[OrganizationId] = O.[Id] AND OU.[UserId] = @UserId
        LEFT JOIN
            [dbo].[CollectionUser] CU ON CU.[CollectionId] = C.[Id] AND CU.[OrganizationUserId] = OU.[Id]
        LEFT JOIN
            [dbo].[GroupUser] GU ON CU.[CollectionId] IS NULL AND GU.[OrganizationUserId] = OU.[Id]
        LEFT JOIN
            [dbo].[Group] G ON G.[Id] = GU.[GroupId]
        LEFT JOIN
            [dbo].[CollectionGroup] CG ON CG.[CollectionId] = C.[Id] AND CG.[GroupId] = GU.[GroupId]
        WHERE
            O.[Id] = @OrgId
            AND O.[Enabled] = 1
            AND OU.[Status] = 2 -- Confirmed
            AND (
                CU.[ReadOnly] = 0
                OR CG.[ReadOnly] = 0
            ) AND (
                CU.[HidePasswords] = 0
                OR CG.[HidePasswords] = 0
            )
    )
    -- Insert new collection assignments
    INSERT INTO [dbo].[CollectionCipher] (
        [CollectionId],
        [CipherId]
    )
    SELECT 
        [Id],
        @CipherId
    FROM @CollectionIds
    WHERE [Id] IN (SELECT [Id] FROM [AvailableCollectionsCTE])
    AND NOT EXISTS (
        SELECT 1 
        FROM [dbo].[CollectionCipher]
        WHERE [CollectionId] = [@CollectionIds].[Id]
        AND [CipherId] = @CipherId
    );

    -- Delete removed collection assignments
    DELETE CC
    FROM [dbo].[CollectionCipher] CC
    WHERE CC.[CipherId] = @CipherId
    AND CC.[CollectionId] IN (SELECT [Id] FROM [AvailableCollectionsCTE])
    AND CC.[CollectionId] NOT IN (SELECT [Id] FROM @CollectionIds);

    IF @OrgId IS NOT NULL
    BEGIN
        EXEC [dbo].[User_BumpAccountRevisionDateByOrganizationId] @OrgId
    END
END
