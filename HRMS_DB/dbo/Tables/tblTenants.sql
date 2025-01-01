CREATE TABLE [dbo].[tblTenants] (
    [TenantID]       BIGINT        IDENTITY (1, 1) NOT NULL,
    [OrganizationID] INT           NOT NULL,
    [TenantName]     NVARCHAR (55) NOT NULL,
    [CreatedBy]      INT           NULL,
    [UpdatedBy]      INT           NULL,
    [CreatedAt]      DATETIME      DEFAULT (getdate()) NULL,
    [UpdatedAt]      DATETIME      DEFAULT (getdate()) NULL,
    [IsActive]       BIT           DEFAULT ((0)) NULL,
    [IsDelete]       BIT           DEFAULT ((0)) NULL,
    [DomainID]       BIGINT        DEFAULT ((1)) NULL,
    [SubdomainID]    BIGINT        DEFAULT ((1)) NULL,
    PRIMARY KEY CLUSTERED ([TenantID] ASC)
);
GO

