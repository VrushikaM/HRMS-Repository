
CREATE PROCEDURE [dbo].[spOrganizationUpdate]
    @OrganizationID INT,
    @OrganizationName NVARCHAR(255),
    @UpdatedBy INT,
    @IsActive BIT = 1
AS
BEGIN
    -- Update the organization record
    UPDATE tblOrganization
    SET 
        OrganizationName = @OrganizationName,
        UpdatedAt = GETDATE(),-- Automatically set to current date and time
        UpdatedBy = @UpdatedBy,
        IsActive = @IsActive
    WHERE OrganizationID = @OrganizationID;

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

	SELECT * FROM [dbo].[tblOrganization] WHERE (OrganizationID IS NULL OR OrganizationID = @OrganizationID);
END
GO

