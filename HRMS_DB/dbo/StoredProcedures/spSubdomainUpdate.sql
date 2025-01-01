CREATE PROCEDURE [dbo].[spSubdomainUpdate]
    @SubdomainId INT = NULL,
    @SubdomainName NVARCHAR(100) = NULL,
	@CreatedBy int = Null,
    @UpdatedBy INT = NULL,
	@isActive bit =0,
	@isDelete bit =0
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblSubdomains] WHERE SubdomainId = @SubdomainId)
    BEGIN
        SELECT -1 AS SubdomainId;
        RETURN;
    END

    UPDATE [dbo].[tblSubdomains]
    SET		
        SubdomainName = @SubdomainName,
       
        UpdatedBy = @UpdatedBy,
        UpdatedAt = SYSDATETIME(),
		isActive=@isActive,
		isDelete=@isDelete
    WHERE @SubdomainId   = @SubdomainId;

    SELECT * FROM [dbo].[tblSubdomains] WHERE (@SubdomainId IS NULL OR SubdomainId = @SubdomainId);
END;
GO

