
CREATE PROCEDURE spOrganizationGet
    @OrganizationID INT
AS
BEGIN
    -- Retrieve the organization details by ID
    SELECT 
        OrganizationID,
        OrganizationName,
        CreatedBy,
        UpdatedBy,
        CreatedAt,
        UpdatedAt,
        IsActive,
        IsDelete
    FROM tblOrganization
    WHERE OrganizationID = @OrganizationID;
END
GO

