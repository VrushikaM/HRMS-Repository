CREATE PROCEDURE [dbo].[spSubdomainUpdate]
    @SubdomainId INT = NULL,
    @DomainID INT = NULL,
    @SubdomainName NVARCHAR(100) = NULL,
	@CreatedBy int = Null,
    @UpdatedBy INT = NULL,
	@isActive bit =0,
	@isDelete bit =0
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[Subdomains] WHERE SubdomainID = @SubdomainId)
    BEGIN
        SELECT -1 AS SubdomainId;
        RETURN;
    END

    UPDATE [dbo].[Subdomains]
    SET		
        SubdomainName = @SubdomainName,
		
        DomainID = ISNULL(@DomainID, DomainID),
       
        UpdatedBy = @UpdatedBy,
        UpdatedAt = SYSDATETIME(),
		isActive=@isActive,
		isDelete=@isDelete
    WHERE @SubdomainId   = @SubdomainID;

    SELECT * FROM [dbo].[Subdomains] WHERE (@SubdomainId IS NULL OR SubdomainID = @SubdomainId);
END;
GO

