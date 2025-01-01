CREATE TABLE [dbo].[tblUser] (
    [UserId]        INT            IDENTITY (1, 1) NOT NULL,
    [FirstName]     NVARCHAR (50)  NOT NULL,
    [LastName]      NVARCHAR (50)  NOT NULL,
    [Email]         NVARCHAR (50)  NOT NULL,
    [Password]      NVARCHAR (50)  NOT NULL,
    [Gender]        NVARCHAR (50)  NOT NULL,
    [DateOfBirth]   DATE           NOT NULL,
    [CreatedAt]     DATETIME2 (3)  DEFAULT (sysdatetime()) NOT NULL,
    [UpdatedAt]     DATETIME2 (3)  DEFAULT (sysdatetime()) NOT NULL,
    [IsActive]      BIT            CONSTRAINT [DF_tblUser_IsActive] DEFAULT ((0)) NULL,
    [CreatedBy]     INT            CONSTRAINT [DF_tblUser_CreatedBy] DEFAULT ((1)) NOT NULL,
    [UpdatedBy]     INT            NULL,
    [TenantID]      INT            NOT NULL,
    [MiddleName]    NVARCHAR (100) NOT NULL,
    [IsDelete]      BIT            CONSTRAINT [DF_tblUser_IsDelete] DEFAULT ((0)) NULL,
    [RoleID]        INT            NOT NULL,
    [TenancyRoleID] INT            NOT NULL,
    [UserName]      NVARCHAR (50)  NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO



