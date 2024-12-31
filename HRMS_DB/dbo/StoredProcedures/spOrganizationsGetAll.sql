
CREATE PROCEDURE spOrganizationsGetAll
AS
BEGIN
    -- Retrieve all organizations from the Organizations table
    SELECT 
        OrganizationID,
        OrganizationName,
        CreatedBy,
        UpdatedBy,
        CreatedAt,
        UpdatedAt,
        IsActive,
        IsDelete
    FROM tblOrganization;
END
GO

