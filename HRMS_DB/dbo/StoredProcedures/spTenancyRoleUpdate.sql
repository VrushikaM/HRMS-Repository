CREATE PROCEDURE [dbo].[spTenancyRoleUpdate]
    @TenancyRoleId INT,
    @TenancyRoleName NVARCHAR(100),
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
        TenancyRoleName = @TenancyRoleName,
        CreatedBy = @CreatedBy,
        UpdatedBy = @UpdatedBy,
        CreatedAt = @CreatedAt,
        UpdatedAt = @UpdatedAt,
        IsActive = @IsActive,
        IsDelete = @IsDelete
    WHERE TenancyRoleId = @TenancyRoleId;
END;
GO

