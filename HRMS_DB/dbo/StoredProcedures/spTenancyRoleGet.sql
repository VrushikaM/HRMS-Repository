
CREATE PROCEDURE [dbo].[spTenancyRoleGet]
@TenancyRoleID INT = NULL
AS
BEGIN
    SELECT TOP 1 * 
    FROM [dbo].[tblTenancyRoles] 
    WHERE (@TenancyRoleID IS NULL OR TenancyRoleID = @TenancyRoleID);
END;
GO

