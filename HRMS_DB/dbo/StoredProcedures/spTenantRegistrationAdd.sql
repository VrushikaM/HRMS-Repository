CREATE PROCEDURE spTenantRegistrationAdd
    @SubdomainName NVARCHAR(100),
    @FirstName NVARCHAR(100),
    @LastName NVARCHAR(100),
    @UserName NVARCHAR(100),
    @Email NVARCHAR(255),
    @Password NVARCHAR(MAX),
    @UserId INT OUTPUT,
    @SubdomainId INT OUTPUT
AS
BEGIN
    SET NOCOUNT ON;

    BEGIN TRY
        BEGIN TRANSACTION;

        INSERT INTO tblUser (FirstName, LastName, UserName, Email, Password, CreatedBy, CreatedAt)
        VALUES (@FirstName, @LastName, @UserName, @Email, @Password, -1, GETDATE());

        SET @UserId = SCOPE_IDENTITY();

        UPDATE tblUser
        SET CreatedBy = @UserId
        WHERE UserId = @UserId;

        INSERT INTO tblSubdomains (SubdomainName, CreatedBy, CreatedAt)
        VALUES (@SubdomainName, @UserId, GETDATE());

        SET @SubdomainId = SCOPE_IDENTITY();

        COMMIT TRANSACTION;
    END TRY
    BEGIN CATCH
        IF @@TRANCOUNT > 0
            ROLLBACK TRANSACTION;

        THROW;
    END CATCH;
END;
GO

