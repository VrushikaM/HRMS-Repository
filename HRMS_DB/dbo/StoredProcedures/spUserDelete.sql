
CREATE PROCEDURE [dbo].[spUserDelete]
@UserId INT = NULL
AS
BEGIN
    IF NOT EXISTS (SELECT 1 FROM [dbo].[tblUser] WHERE UserId = @UserId)
    BEGIN
        SELECT -1 AS UserId;
        RETURN;
    END

	DELETE FROM [dbo].[tblUser] WHERE UserId = @UserId;

	SELECT @UserId AS UserId;
END;
GO

