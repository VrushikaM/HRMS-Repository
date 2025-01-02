CREATE TABLE [dbo].[tblUserRoles] (
    [UserRoleId]        INT            IDENTITY (1, 1) NOT NULL,
    [UserRoleName]      NVARCHAR (255) NULL,
    [PermissionGroupId] INT            NULL,
    [CreatedBy]         INT            NOT NULL,
    [UpdatedBy]         INT            NULL,
    [CreatedAt]         DATETIME       DEFAULT (getdate()) NULL,
    [UpdatedAt]         DATETIME       DEFAULT (getdate()) NULL,
    [IsActive]          BIT            NOT NULL,
    [IsDelete]          BIT            DEFAULT ((0)) NULL,
    PRIMARY KEY CLUSTERED ([UserRoleId] ASC)
);
GO

