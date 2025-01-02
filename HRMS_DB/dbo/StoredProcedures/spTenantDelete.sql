CREATE PROCEDURE [dbo].[spTenantDelete]
@TenantId INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblTenants] WHERE TenantId = @TenantId)
    BEGIN
        SELECT -1 AS TenantId;
        RETURN;
    END

	DELETE FROM [dbo].[tblTenants] WHERE TenantId = @TenantId;

	SELECT @TenantId AS TenantId;
END;
GO

