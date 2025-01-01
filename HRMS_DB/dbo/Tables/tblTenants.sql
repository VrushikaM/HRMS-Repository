CREATE TABLE [dbo].[tblTenants] (
    [TenantID]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [OrganizationID] INT           NOT NULL,
    [TenantName]     NVARCHAR (55) NOT NULL,
    [CreatedBy]      INT           NULL,
    [UpdatedBy]      INT           NULL,
    [CreatedAt]      DATETIME      DEFAULT (getdate()) NULL,
    [UpdatedAt]      DATETIME      DEFAULT (getdate()) NULL,
    [IsActive]       BIT           DEFAULT (NULL) NULL,
    [IsDelete]       BIT           DEFAULT (NULL) NULL,
    [DomainID]       BIGINT        DEFAULT ((2)) NULL,
    [SubdomainID]    BIGINT        DEFAULT ((2)) NULL,
    PRIMARY KEY CLUSTERED ([TenantID] ASC)
);
GO

