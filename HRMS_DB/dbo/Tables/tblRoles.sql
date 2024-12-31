CREATE TABLE [dbo].[tblRoles] (
    [RoleId]            INT            IDENTITY (1, 1) NOT NULL,
    [RoleName]          NVARCHAR (255) NULL,
    [PermissionGroupId] INT            NULL,
    [CreatedBy]         INT            NOT NULL,
    [UpdatedBy]         INT            NULL,
    [CreatedAt]         DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAt]         DATETIME       DEFAULT (getdate()) NULL,
    [IsActive]          BIT            NOT NULL,
    [IsDelete]          BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([RoleId] ASC)
);
GO

