CREATE TABLE [dbo].[tblUser] (
    [UserId]      INT           IDENTITY (1, 1) NOT NULL,
    [FirstName]   NVARCHAR (50) NOT NULL,
    [LastName]    NVARCHAR (50) NOT NULL,
    [Email]       NVARCHAR (50) NOT NULL,
    [Password]    NVARCHAR (50) NOT NULL,
    [Gender]      NVARCHAR (50) NOT NULL,
    [DateOfBirth] DATE          NOT NULL,
    [CreatedAt]   DATETIME2 (3) DEFAULT (sysdatetime()) NOT NULL,
    [UpdatedAt]   DATETIME2 (3) DEFAULT (sysdatetime()) NOT NULL,
    [IsActive]    BIT           NOT NULL,
    PRIMARY KEY CLUSTERED ([UserId] ASC)
);
GO

