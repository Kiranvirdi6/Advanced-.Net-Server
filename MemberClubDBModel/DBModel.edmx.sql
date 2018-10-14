
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 10/01/2018 17:41:10
-- Generated from EDMX file: C:\Users\Kiran\Documents\Study\ASP.NET\InClassCode\MemberClubDBModel\DBModel.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [Club1189];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_MemberAddress]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[Addresses] DROP CONSTRAINT [FK_MemberAddress];
GO
IF OBJECT_ID(N'[dbo].[FK_MemberGame_Game]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberGame] DROP CONSTRAINT [FK_MemberGame_Game];
GO
IF OBJECT_ID(N'[dbo].[FK_MemberGame_Member]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[MemberGame] DROP CONSTRAINT [FK_MemberGame_Member];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[Addresses]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Addresses];
GO
IF OBJECT_ID(N'[dbo].[Games]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Games];
GO
IF OBJECT_ID(N'[dbo].[MemberGame]', 'U') IS NOT NULL
    DROP TABLE [dbo].[MemberGame];
GO
IF OBJECT_ID(N'[dbo].[Members]', 'U') IS NOT NULL
    DROP TABLE [dbo].[Members];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'Members'
CREATE TABLE [dbo].[Members] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [FirstName] nvarchar(max)  NOT NULL,
    [LastName] nvarchar(max)  NOT NULL,
    [Type] nchar(10)  NOT NULL
);
GO

-- Creating table 'Games'
CREATE TABLE [dbo].[Games] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Rating] nchar(10)  NULL
);
GO

-- Creating table 'Addresses'
CREATE TABLE [dbo].[Addresses] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [City] nvarchar(max)  NOT NULL,
    [MemberId] int  NOT NULL
);
GO

-- Creating table 'LeaderBoards'
CREATE TABLE [dbo].[LeaderBoards] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Name] nvarchar(max)  NOT NULL,
    [Rank] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'MemberGame'
CREATE TABLE [dbo].[MemberGame] (
    [Members_Id] int  NOT NULL,
    [Games_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Members'
ALTER TABLE [dbo].[Members]
ADD CONSTRAINT [PK_Members]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Games'
ALTER TABLE [dbo].[Games]
ADD CONSTRAINT [PK_Games]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [PK_Addresses]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'LeaderBoards'
ALTER TABLE [dbo].[LeaderBoards]
ADD CONSTRAINT [PK_LeaderBoards]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Members_Id], [Games_Id] in table 'MemberGame'
ALTER TABLE [dbo].[MemberGame]
ADD CONSTRAINT [PK_MemberGame]
    PRIMARY KEY CLUSTERED ([Members_Id], [Games_Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [MemberId] in table 'Addresses'
ALTER TABLE [dbo].[Addresses]
ADD CONSTRAINT [FK_MemberAddress]
    FOREIGN KEY ([MemberId])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberAddress'
CREATE INDEX [IX_FK_MemberAddress]
ON [dbo].[Addresses]
    ([MemberId]);
GO

-- Creating foreign key on [Members_Id] in table 'MemberGame'
ALTER TABLE [dbo].[MemberGame]
ADD CONSTRAINT [FK_MemberGame_Member]
    FOREIGN KEY ([Members_Id])
    REFERENCES [dbo].[Members]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating foreign key on [Games_Id] in table 'MemberGame'
ALTER TABLE [dbo].[MemberGame]
ADD CONSTRAINT [FK_MemberGame_Game]
    FOREIGN KEY ([Games_Id])
    REFERENCES [dbo].[Games]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_MemberGame_Game'
CREATE INDEX [IX_FK_MemberGame_Game]
ON [dbo].[MemberGame]
    ([Games_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------