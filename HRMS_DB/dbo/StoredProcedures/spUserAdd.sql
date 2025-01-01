
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
@TenantID INT = NULL,
@RoleID INT = NULL,
@TenancyRoleID INT = NULL
AS
BEGIN

    IF @CreatedBy IS NULL

        BEGIN
            RAISERROR ('CreatedBy cannot be NULL.', 16, 1);
            RETURN;
        END;
    
     SET @UpdatedBy = ISNULL(@UpdatedBy, @CreatedBy);

	INSERT INTO [dbo].[tblUser] (FirstName, LastName, Email, Password, Gender, DateOfBirth, CreatedBy, UpdatedBy, IsActive, CreatedAt, UpdatedAt)
    VALUES (@FirstName, @LastName, @Email, @Password, @Gender, @DateOfBirth, @CreatedBy, @UpdatedBy,  @IsActive, SYSDATETIME(), SYSDATETIME());

	SET @UserId = SCOPE_IDENTITY();
END;
GO

