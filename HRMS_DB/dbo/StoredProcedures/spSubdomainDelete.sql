CREATE PROCEDURE [dbo].[spSubdomainDelete]
@SubdomainId INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblSubdomains] WHERE SubdomainId = @SubdomainId)
    BEGIN
        SELECT -1 AS SubdomainId;
        RETURN;
    END

	DELETE FROM [dbo].[tblSubdomains] WHERE SubdomainId = @SubdomainId;

	SELECT @SubdomainId AS SubdomainId;
END;
GO

