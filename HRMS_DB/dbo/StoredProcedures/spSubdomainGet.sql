CREATE PROCEDURE [dbo].[spSubdomainGet]
    @SubdomainID INT
AS
BEGIN
   

    SELECT 
        SubdomainID,
        DomainID,
        
        SubdomainName,
        CreatedBy,
        UpdatedBy,
        CreatedAt,
        UpdatedAt,
		isActive,
		isDelete
    FROM Subdomains
    WHERE SubdomainID = @SubdomainID;

END
GO

