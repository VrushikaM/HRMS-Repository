
CREATE PROCEDURE [dbo].[spTenancyRoleAdd]
@TenancyRoleID INT OUTPUT,
@RoleName VARCHAR(255) = NULL,
@CreatedBy INT = NULL,
@UpdatedBy INT = NULL,
@CreatedAt DATETIME = NULL,
@IsActive BIT = NULL,
@IsDelete BIT = NULL
AS
BEGIN
    SET NOCOUNT ON;

    IF @CreatedBy IS NULL
    BEGIN
        RAISERROR ('CreatedBy cannot be NULL.', 16, 1);
        RETURN;
    END;

    SET @IsActive = ISNULL(@IsActive, 0);
    SET @IsDelete = ISNULL(@IsDelete, 0);
    SET @UpdatedBy = ISNULL(@UpdatedBy, @CreatedBy);
    SET @CreatedAt = ISNULL(@CreatedAt, SYSDATETIME());

    INSERT INTO [dbo].[tblTenancyRoles] (RoleName, CreatedBy, UpdatedBy, IsActive, IsDelete, CreatedAt, UpdatedAt)
    VALUES (@RoleName, @CreatedBy, @UpdatedBy, @IsActive, @IsDelete, @CreatedAt, SYSDATETIME());

    SET @TenancyRoleID = SCOPE_IDENTITY();
END;
GO

