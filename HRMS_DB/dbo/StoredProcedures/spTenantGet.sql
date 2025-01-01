CREATE PROCEDURE [dbo].[spTenantGet]
@TenantID BigInt = NULL
AS
BEGIN
	SELECT TOP 1 * 
    FROM [dbo].[tblTenants] 
    WHERE (@TenantID IS NULL OR TenantID = @TenantID);
END;
GO

