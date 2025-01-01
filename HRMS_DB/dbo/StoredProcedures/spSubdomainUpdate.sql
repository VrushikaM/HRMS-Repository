CREATE PROCEDURE [dbo].[spSubdomainUpdate]
    @SubdomainId INT = NULL,
    @DomainID INT = NULL,
    @SubdomainName NVARCHAR(100) = NULL,
    @UpdatedBy INT = NULL,
	@IsActive bit = NULL,
	@IsDelete bit = NULL
AS
BEGIN
SET NOCOUNT ON;
    
    BEGIN TRY

        -- Start transaction
        BEGIN TRANSACTION;

        -- Check if the user exists
	    IF NOT EXISTS (SELECT 1 FROM [dbo].[Subdomains] WHERE SubdomainId = @SubdomainId)
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
		IsActive = @IsActive,
		IsDelete = @IsDelete
    WHERE @SubdomainId   = @SubdomainID;

    -- Commit the transaction
    COMMIT TRANSACTION;

    -- Return the updated user details
	SELECT * FROM [dbo].[Subdomains] WHERE (@SubdomainId IS NULL OR SubdomainID = @SubdomainId);

    END TRY
        BEGIN CATCH

        -- Handle errors and roll back the transaction if needed
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        DECLARE @ErrorMessage NVARCHAR(4000), @ErrorSeverity INT, @ErrorState INT;
        SELECT 
            @ErrorMessage = ERROR_MESSAGE(), 
            @ErrorSeverity = ERROR_SEVERITY(), 
            @ErrorState = ERROR_STATE()

        PRINT 'Error: ' + @ErrorMessage;

        RAISERROR (@ErrorMessage, @ErrorSeverity, @ErrorState);
                
    END CATCH
END;
GO

