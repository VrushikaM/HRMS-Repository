
CREATE PROCEDURE [dbo].[spUserAdd]
@UserId INT OUTPUT,
@FirstName NVARCHAR(50) = NULL,
@MiddleName NVARCHAR(100) = NULL,
@LastName NVARCHAR(50) = NULL,
@Email NVARCHAR(50) = NULL,
@Password NVARCHAR(50) = NULL,
@Gender NVARCHAR(50) = NULL,
@DateOfBirth DATE = NULL,
@IsActive BIT = NULL,
@IsDelete BIT = NULL,
@CreatedBy INT = NULL,
@UpdatedBy INT = NULL,
@TenantID BIGINT = NULL
AS
BEGIN

    IF @CreatedBy IS NULL

        BEGIN
            RAISERROR ('CreatedBy cannot be NULL.', 16, 1);
            RETURN;
        END;
    
     SET @UpdatedBy = ISNULL(@UpdatedBy, @CreatedBy);

	INSERT INTO [dbo].[tblUser] (FirstName, MiddleName, LastName, Email, Password, Gender, DateOfBirth, CreatedBy, UpdatedBy, IsActive, IsDelete, CreatedAt, UpdatedAt, TenantID)
    VALUES (@FirstName, @MiddleName, @LastName, @Email, @Password, @Gender, @DateOfBirth, @CreatedBy, @UpdatedBy,  @IsActive, @IsDelete, SYSDATETIME(), SYSDATETIME(), @TenantID);

	SET @UserId = SCOPE_IDENTITY();
END;
GO

