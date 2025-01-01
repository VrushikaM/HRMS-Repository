CREATE PROCEDURE [dbo].[spTenantDelete]
@TenantID INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblTenants] WHERE TenantID = @TenantID)
    BEGIN
        SELECT -1 AS TenantID;
        RETURN;
    END

	DELETE FROM [dbo].[tblTenants] WHERE TenantID = @TenantID;

	SELECT @TenantID AS TenantID;
END;
GO

