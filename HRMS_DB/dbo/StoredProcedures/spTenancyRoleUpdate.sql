CREATE PROCEDURE [dbo].[spTenancyRoleUpdate]
    @TenancyRoleID INT,
    @RoleName NVARCHAR(100),
    @CreatedBy NVARCHAR(50),
    @UpdatedBy NVARCHAR(50),
    @CreatedAt DATETIME,
    @UpdatedAt DATETIME,
    @IsActive BIT,
    @IsDelete BIT
AS
BEGIN
    UPDATE tblTenancyRoles
    SET 
        RoleName = @RoleName,
        CreatedBy = @CreatedBy,
        UpdatedBy = @UpdatedBy,
        CreatedAt = @CreatedAt,
        UpdatedAt = @UpdatedAt,
        IsActive = @IsActive,
        IsDelete = @IsDelete
    WHERE TenancyRoleID = @TenancyRoleID;
END;
GO

