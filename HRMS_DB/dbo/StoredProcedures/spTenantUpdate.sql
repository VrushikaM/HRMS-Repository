CREATE PROCEDURE [dbo].[spTenantUpdate]
@TenantId BigInt OUTPUT,
@OrganizationId INT = NULL,
@DomainId INT = NULL,
@SubdomainId INT = NULL,
@TenantName NVARCHAR(55) = NULL,
@UpdatedBy INT = NULL,
@IsActive BIT = 0,
@IsDelete BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

	IF EXISTS (SELECT 1 FROM [dbo].[tblTenants] WHERE TenantId = @TenantId)
	BEGIN	
	 UPDATE [dbo].[tblTenants]
	 SET OrganizationId = @OrganizationId,
	    DomainId = @DomainId,
		SubdomainId = @SubdomainId,
	    TenantName = @TenantName,
        UpdatedBy = @UpdatedBy,
	    IsActive = @IsActive,
		IsDelete = @IsDelete,
        UpdatedAt = SYSDATETIME()
	 WHERE TenantId = @TenantId;
	END
	SELECT * FROM [dbo].tblTenants WHERE (@TenantId IS NULL OR TenantId = @TenantId);
END;
GO

