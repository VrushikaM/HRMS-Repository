CREATE TABLE [dbo].[tblTenancyRoles] (
    [TenancyRoleID] INT           IDENTITY (1, 1) NOT NULL,
    [RoleName]      VARCHAR (255) NOT NULL,
    [CreatedBy]     INT           NOT NULL,
    [UpdatedBy]     INT           NULL,
    [CreatedAt]     DATETIME      DEFAULT (getdate()) NULL,
    [UpdatedAt]     DATETIME      DEFAULT (getdate()) NULL,
    [IsActive]      BIT           DEFAULT ((0)) NULL,
    [IsDelete]      BIT           DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([TenancyRoleID] ASC)
);
GO

