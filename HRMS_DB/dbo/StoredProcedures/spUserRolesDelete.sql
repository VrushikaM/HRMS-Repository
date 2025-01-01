
CREATE PROCEDURE [dbo].[spUserRolesDelete]
@RoleId INT = NULL
AS
BEGIN
    -- Check if the RoleId exists in the table
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblUserRoles] WHERE RoleId = @RoleId)
    BEGIN
        SELECT -1 AS RoleId; -- Return -1 if the role doesn't exist
        RETURN;
    END

    -- Delete the role with the specified RoleId
    DELETE FROM [dbo].[tblUserRoles] WHERE RoleId = @RoleId;

    -- Return the deleted RoleId as confirmation
    SELECT @RoleId AS RoleId;
END;
GO

