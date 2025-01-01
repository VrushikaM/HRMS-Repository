CREATE PROCEDURE [dbo].[spSubdomainGet]
    @SubdomainId INT
AS
BEGIN
   

    SELECT 
        SubdomainId,
        
        SubdomainName,
        CreatedBy,
        UpdatedBy,
        CreatedAt,
        UpdatedAt,
		isActive,
		isDelete
    FROM tblSubdomains
    WHERE SubdomainId = @SubdomainId;

END
GO

