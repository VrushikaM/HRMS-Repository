CREATE PROCEDURE [dbo].[spUserUpdate]
@UserId INT = NULL,
@FirstName NVARCHAR(50) = NULL,
@LastName NVARCHAR(50) = NULL,
@Email NVARCHAR(50) = NULL,
@Password NVARCHAR(50) = NULL,
@IsActive BIT = NULL
AS
BEGIN

	IF NOT EXISTS (SELECT 1 FROM [dbo].[tblUser] WHERE UserId = @UserId)
    BEGIN
        SELECT -1 AS UserId;
        RETURN;
    END
	
	UPDATE [dbo].[tblUser]
	SET FirstName = @FirstName,
	    LastName = @LastName,
	    Email = @Email,
	    Password = @Password,
	    IsActive = @IsActive
	WHERE UserId = @UserId;

	SELECT * FROM [dbo].[tblUser] WHERE (@UserId IS NULL OR UserId = @UserId);
END;
GO

