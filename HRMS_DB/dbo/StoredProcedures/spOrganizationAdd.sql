
CREATE PROCEDURE [dbo].[spOrganizationAdd]
@OrganizationID INT OUTPUT,
@OrganizationName NVARCHAR(100) = NULL,
@CreatedBy INT = NULL,
@UpdatedBy INT = NULL,
@IsActive BIT = NULL,
@IsDelete BIT = NULL,
@CreatedAt DATETIME = NULL,
@UpdatedAt DATETIME = NULL
AS
BEGIN


	IF @CreatedBy IS NULL
    BEGIN
        RAISERROR ('CreatedBy cannot be NULL.', 16, 1);
        RETURN;
    END;

	 SET @UpdatedBy = ISNULL(@UpdatedBy, @CreatedBy);

    -- Set default values for IsActive and IsDelete if NULL
    SET @IsActive = ISNULL(@IsActive, 1); -- Default to 1 (Active) if NULL
    SET @IsDelete = ISNULL(@IsDelete, 0); -- Default to 0 (Not Deleted) if NULL
    SET @CreatedAt = ISNULL(@CreatedAt, SYSDATETIME()); -- Default to current time if NULL
    SET @UpdatedAt = ISNULL(@UpdatedAt, SYSDATETIME());

    -- Insert a new organization record
    INSERT INTO tblOrganization (OrganizationName, CreatedBy, UpdatedBy, CreatedAt, UpdatedAt, IsActive, IsDelete)
    VALUES (@OrganizationName, @CreatedBy, NULL, GETDATE(), GETDATE(), 1, 0);

   SET @OrganizationID = SCOPE_IDENTITY();
END
GO

