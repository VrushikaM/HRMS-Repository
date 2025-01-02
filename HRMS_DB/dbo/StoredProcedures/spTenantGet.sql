CREATE PROCEDURE [dbo].[spTenantGet]
@TenantId BigInt = NULL
AS
BEGIN
	SELECT TOP 1 * 
    FROM [dbo].[tblTenants] 
    WHERE (@TenantId IS NULL OR TenantId = @TenantId);
END;
GO

