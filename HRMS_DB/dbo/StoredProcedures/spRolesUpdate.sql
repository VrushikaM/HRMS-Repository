
CREATE PROCEDURE [dbo].[spRolesUpdate]
    @RoleId INT = NULL,
    @RoleName NVARCHAR(50) = NULL,
    @PermissionGroupId INT = NULL,
	@UpdatedBy INT = NULL,
    @IsActive BIT = NULL,
    @IsDelete BIT = NULL
   
AS
BEGIN
    -- Validate that the RoleId exists
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblRoles] WHERE RoleId = @RoleId)
    BEGIN
        SELECT -1 AS RoleId; -- Indicate that the RoleId does not exist
        RETURN;
    END;

    -- Update the role information
    UPDATE [dbo].[tblRoles]
    SET RoleName = ISNULL(@RoleName, RoleName),
        PermissionGroupId = ISNULL(@PermissionGroupId, PermissionGroupId),
		 UpdatedBy = @UpdatedBy,
        UpdatedAt = SYSDATETIME(),
        IsActive = ISNULL(@IsActive, IsActive),
        IsDelete = ISNULL(@IsDelete, IsDelete)
       
    WHERE RoleId = @RoleId;

    -- Return the updated role information
    SELECT * FROM [dbo].[tblRoles] WHERE RoleId = @RoleId;
END;
GO

