CREATE PROCEDURE [dbo].[spTenantAdd]
@TenantId BigInt OUTPUT,
@OrganizationId INT = NULL,
@DomainId INT = NULL,
@SubdomainId INT = NULL,
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

	INSERT INTO [dbo].[tblTenants] (OrganizationId,DomainId,SubdomainId,TenantName,CreatedBy,IsActive,IsDelete, CreatedAt, UpdatedAt)
    VALUES (@OrganizationId,@DomainId,@SubdomainId,@TenantName,@CreatedBy,@IsActive,@IsDelete, SYSDATETIME(), SYSDATETIME());

	SET @TenantId = SCOPE_IDENTITY();
END;
GO

