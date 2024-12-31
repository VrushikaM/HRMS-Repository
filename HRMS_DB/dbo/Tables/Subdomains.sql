CREATE TABLE [dbo].[Subdomains] (
    [SubdomainID]   INT            IDENTITY (1, 1) NOT NULL,
    [DomainID]      INT            NOT NULL,
    [SubdomainName] NVARCHAR (100) NULL,
    [CreatedBy]     INT            NOT NULL,
    [UpdatedBy]     INT            NOT NULL,
    [CreatedAt]     DATETIME       NULL,
    [UpdatedAt]     DATETIME       NULL,
    [isActive]      BIT            NULL,
    [isDelete]      BIT            NULL
);
GO

