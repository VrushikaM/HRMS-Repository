CREATE PROCEDURE [dbo].[spSubdomainAdd]
	@SubdomainID bigint output,
    @DomainID INT,
    @SubdomainName NVARCHAR(100),
    @CreatedBy INT,
	@IsActive bit,
	@IsDelete bit
AS
BEGIN
    SET NOCOUNT ON;

    -- Insert the subdomain with timestamps
    INSERT INTO Subdomains (DomainID,  SubdomainName, CreatedBy, UpdatedBy, CreatedAt, UpdatedAt, isActive, isDelete)
    VALUES (@DomainID, @SubdomainName, @CreatedBy, 1,  GETDATE(), GETDATE(),1,0);

    -- Return the created subdomain
   
   set @SubdomainID = SCOPE_IDENTITY();
END
GO

