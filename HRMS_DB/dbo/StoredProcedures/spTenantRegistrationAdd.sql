CREATE PROCEDURE spTenantRegistrationAdd
    @SubdomainName NVARCHAR(100),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password NVARCHAR(MAX),
    @UserId INT OUTPUT,
    @SubdomainId INT OUTPUT,
    @TenantId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        -- Step 1: Insert into Subdomain table
        INSERT INTO tblSubdomains (SubdomainName, CreatedBy, CreatedAt,isActive,isDelete)
        VALUES (@SubdomainName, -1, GETDATE(),0,0);

        -- Retrieve the SubdomainID for the inserted record
        SET @SubdomainId = SCOPE_IDENTITY();

        -- Step 2: Insert into Tenant table using SubdomainId
        INSERT INTO tblTenants (TenantName, SubdomainId,DomainId,OrganizationId, CreatedBy, CreatedAt,isActive,isDelete)
        VALUES (@SubdomainName, @SubdomainId,1,1, -1, GETDATE(),0,0);

        -- Retrieve the TenantID for the inserted record
        SET @TenantId = SCOPE_IDENTITY();

        -- Step 3: Insert into User table
        INSERT INTO tblUser (FirstName, LastName, UserName, Email, Password, TenantId, CreatedBy, CreatedAt,isActive,isDelete)
        VALUES (@FirstName, @LastName, @UserName, @Email, @Password, @TenantId, -1, GETDATE(),0,0);

        -- Retrieve the UserID for the inserted record
        SET @UserId = SCOPE_IDENTITY();

        -- Step 4: Update CreatedBy fields with the actual UserId
        UPDATE tblSubdomains
        SET CreatedBy = @UserId
        WHERE SubdomainId = @SubdomainId;

        UPDATE tblTenants
        SET CreatedBy = @UserId
        WHERE TenantId = @TenantId;

        UPDATE tblUser
        SET CreatedBy = @UserId
        WHERE UserId = @UserId;

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

