
CREATE PROCEDURE [dbo].[spOrganizationDelete]
    @OrganizationID INT
AS
BEGIN
	IF NOT EXISTS (SELECT 1 FROM [dbo].[tblOrganization] WHERE OrganizationID = @OrganizationID)
    BEGIN
        SELECT -1 AS OrganizationID;
        RETURN;
    END

	DELETE FROM [dbo].[tblOrganization] WHERE OrganizationID = @OrganizationID;

	SELECT @OrganizationID AS OrganizationID;
END;
GO

