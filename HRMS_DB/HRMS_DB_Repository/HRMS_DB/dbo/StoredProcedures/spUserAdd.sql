
CREATE PROCEDURE [dbo].[spUserAdd]
@UserId INT OUTPUT,
@FirstName NVARCHAR(50) = NULL,
@LastName NVARCHAR(50) = NULL,
@Email NVARCHAR(50) = NULL,
@Password NVARCHAR(50) = NULL,
@IsActive BIT = NULL
AS
BEGIN
	INSERT INTO [dbo].[tblUser] (FirstName, LastName, Email, Password, IsActive)
    VALUES (@FirstName, @LastName, @Email, @Password, @IsActive);

	SET @UserId = SCOPE_IDENTITY();
END;
GO

