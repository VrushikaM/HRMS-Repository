CREATE PROCEDURE [dbo].[spSubdomainAdd]
	@SubdomainId bigint output,
    @SubdomainName NVARCHAR(100),
    @CreatedBy INT,
	@IsActive bit,
	@IsDelete bit
AS
BEGIN
    SET NOCOUNT ON;
    INSERT INTO tblSubdomains (  SubdomainName, CreatedBy, UpdatedBy, CreatedAt, UpdatedAt, isActive, isDelete)
    VALUES ( @SubdomainName, @CreatedBy, 1,  GETDATE(), GETDATE(),1,0);

   
   set @SubdomainId = SCOPE_IDENTITY();
END
GO

