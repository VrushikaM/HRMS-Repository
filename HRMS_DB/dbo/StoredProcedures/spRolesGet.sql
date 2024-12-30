
create   PROCEDURE [dbo].[spRolesGet]
@RoleId INT = NULL
AS
BEGIN
    -- Select a single role if RoleId is provided or all roles if RoleId is NULL
    SELECT 
        [RoleId], 
        [RoleName], 
        [PermissionGroupId], 
        [CreatedBy], 
        [UpdatedBy], 
        [CreatedAt], 
        [UpdatedAt], 
        [IsActive], 
        [IsDelete]
    FROM 
        [dbo].[tblRoles]
    WHERE 
        (@RoleId IS NULL OR [RoleId] = @RoleId) AND 
        [IsDelete] = 0  -- Only return records that are not deleted
    ORDER BY 
        [CreatedAt] DESC;  -- Optional: Sort by creation date (newest first)
END;
GO

