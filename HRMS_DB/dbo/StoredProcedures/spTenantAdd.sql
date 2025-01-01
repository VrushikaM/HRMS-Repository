CREATE PROCEDURE [dbo].[spTenantAdd]
@TenantID BigInt OUTPUT,
@OrganizationID INT = NULL,
@DomainID INT = NULL,
@SubdomainID INT = NULL,
@TenantName NVARCHAR(55) = NULL,
@CreatedBy INT = NULL,
@IsActive BIT = 0,
@IsDelete BIT = 0
AS
BEGIN

    IF @CreatedBy IS NULL

        BEGIN
            RAISERROR ('CreatedBy cannot be NULL.', 16, 1);
            RETURN;
        END;
    
     --SET @UpdatedBy = ISNULL(@UpdatedBy, @CreatedBy);

	INSERT INTO [dbo].[tblTenants] (OrganizationID,DomainID,SubdomainID,TenantName,CreatedBy,IsActive,IsDelete, CreatedAt, UpdatedAt)
    VALUES (@OrganizationID,@DomainID,@SubdomainID,@TenantName,@CreatedBy,@IsActive,@IsDelete, SYSDATETIME(), SYSDATETIME());

	SET @TenantID = SCOPE_IDENTITY();
END;
GO

