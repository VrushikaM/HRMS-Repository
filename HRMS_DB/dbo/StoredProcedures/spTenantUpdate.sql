CREATE PROCEDURE [dbo].[spTenantUpdate]
@TenantID BigInt OUTPUT,
@OrganizationID INT = NULL,
@DomainID INT = NULL,
@SubdomainID INT = NULL,
@TenantName NVARCHAR(55) = NULL,
@UpdatedBy INT = NULL,
@IsActive BIT = 0,
@IsDelete BIT = 0
AS
BEGIN
    SET NOCOUNT ON;

	IF NOT EXISTS (SELECT 1 FROM [dbo].[tblTenants] WHERE TenantID = @TenantID)
	BEGIN
	  SELECT -1 AS TenantID;
    RETURN;
	END;

	 UPDATE [dbo].[tblTenants]
	 SET OrganizationID = @OrganizationID,
	    DomainID = @DomainID,
		SubdomainID = @SubdomainID,
	    TenantName = @TenantName,
        UpdatedBy = @UpdatedBy,
	    IsActive = @IsActive,
		IsDelete = @IsDelete,
        UpdatedAt = SYSDATETIME()
	 WHERE TenantID = @TenantID;
	SELECT * FROM [dbo].tblTenants WHERE (@TenantID IS NULL OR TenantID = @TenantID);
END
GO

