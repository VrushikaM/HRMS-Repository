
CREATE PROCEDURE [dbo].[spUserRolesGet]
@UserRoleId  INT = NULL
AS
BEGIN
    -- Select a single role if RoleId is provided or all roles if RoleId is NULL
    SELECT 
        [UserRoleId], 
        [UserRoleName], 
        [PermissionGroupId], 
        [CreatedBy], 
        [UpdatedBy], 
        [CreatedAt], 
        [UpdatedAt], 
        [IsActive], 
        [IsDelete]
    FROM 
        [dbo].[tblUserRoles]
    WHERE 
        (@UserRoleId  IS NULL OR [UserRoleId] = @UserRoleId ) AND 
        [IsDelete] = 0  -- Only return records that are not deleted
    ORDER BY 
        [CreatedAt] DESC;  -- Optional: Sort by creation date (newest first)
END;
GO

