
CREATE PROCEDURE [dbo].[spUserRolesAdd]
    @RoleId INT OUTPUT,
    @RoleName NVARCHAR(255) = NULL,
    @PermissionGroupId INT = NULL,
    @CreatedBy INT = NULL,
    @UpdatedBy INT = NULL,
    @IsActive BIT = NULL,
    @IsDelete BIT = 0 -- Default value
AS
BEGIN
    -- Check for mandatory parameters
    IF @CreatedBy IS NULL
    BEGIN
        RAISERROR ('CreatedBy cannot be NULL.', 16, 1);
        RETURN;
    END;
    
    -- Default the UpdatedBy to CreatedBy if not provided
    SET @UpdatedBy = ISNULL(@UpdatedBy, @CreatedBy);
    
    
    -- Insert the new role into the table
    INSERT INTO [dbo].[tblRoles] 
        ([RoleName], [PermissionGroupId], [CreatedBy], [UpdatedBy], [CreatedAt], [UpdatedAt], [IsActive], [IsDelete])
    VALUES 
        (@RoleName, @PermissionGroupId, @CreatedBy, @UpdatedBy, SYSDATETIME(), SYSDATETIME(), @IsActive, @IsDelete);

    -- Retrieve the newly inserted RoleId
    SET @RoleId = SCOPE_IDENTITY();
END;
GO

