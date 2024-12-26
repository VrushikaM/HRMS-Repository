
CREATE PROCEDURE [dbo].[spTenancyRoleDelete]
@TenancyRoleID INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblTenancyRoles] WHERE TenancyRoleID = @TenancyRoleID)
    BEGIN
        SELECT -1 AS TenancyRoleID;
        RETURN;
    END
    DELETE FROM [dbo].[tblTenancyRoles] WHERE TenancyRoleID = @TenancyRoleID;
    SELECT @TenancyRoleID AS TenancyRoleID;
END;
GO

