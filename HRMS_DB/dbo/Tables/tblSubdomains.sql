CREATE TABLE [dbo].[tblSubdomains] (
    [SubdomainId]   INT            IDENTITY (1, 1) NOT NULL,
    [SubdomainName] NVARCHAR (100) NULL,
    [CreatedBy]     INT            NOT NULL,
    [UpdatedBy]     INT            NULL,
    [CreatedAt]     DATETIME       NULL,
    [UpdatedAt]     DATETIME       NULL,
    [isActive]      BIT            NULL,
    [isDelete]      BIT            NULL
);
GO

