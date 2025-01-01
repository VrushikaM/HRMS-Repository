CREATE PROCEDURE [dbo].[spTenantGetAll]
AS
BEGIN
    -- Retrieve all organizations from the Organizations table
    SELECT 
        [TenantId]
      ,[OrganizationId]
      ,[TenantName]
      ,[CreatedBy]
      ,[UpdatedBy]
      ,[CreatedAt]
      ,[UpdatedAt]
      ,[IsActive]
      ,[IsDelete]
      ,[DomainId]
      ,[SubdomainId]
    FROM tblTenants
END
GO

