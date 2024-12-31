create PROCEDURE [dbo].[spSubdomainDelete]
@SubdomainId INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Subdomains] WHERE SubdomainId = @SubdomainId)
    BEGIN
        SELECT -1 AS SubdomainId;
        RETURN;
    END

	DELETE FROM [dbo].[Subdomains] WHERE SubdomainId = @SubdomainId;

	SELECT @SubdomainId AS SubdomainId;
END;
GO

