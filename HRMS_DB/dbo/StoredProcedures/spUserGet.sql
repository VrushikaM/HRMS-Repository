CREATE PROCEDURE [dbo].[spUserGet]
@UserId INT = NULL
AS
BEGIN
	SELECT TOP 1 * 
    FROM [dbo].[tblUser] 
    WHERE (@UserId IS NULL OR UserId = @UserId);
END;
GO

