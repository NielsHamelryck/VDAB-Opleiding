
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 12/07/2016 12:15:55
-- Generated from EDMX file: C:\Users\joeri.pardon\Documents\VDAB-Opleiding\Eigen\GameCollectionSolution\GameCollection\Models\GameCollectionDB.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [GameCollectionDB];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ConsoleGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameSet] DROP CONSTRAINT [FK_ConsoleGame];
GO
IF OBJECT_ID(N'[dbo].[FK_PlatformConsole]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ConsoleSoortSet] DROP CONSTRAINT [FK_PlatformConsole];
GO
IF OBJECT_ID(N'[dbo].[FK_CollectionUser]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[CollectionSet] DROP CONSTRAINT [FK_CollectionUser];
GO
IF OBJECT_ID(N'[dbo].[FK_CollectionGame]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[GameSet] DROP CONSTRAINT [FK_CollectionGame];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[GameSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[GameSet];
GO
IF OBJECT_ID(N'[dbo].[ConsoleSoortSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ConsoleSoortSet];
GO
IF OBJECT_ID(N'[dbo].[PlatformSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[PlatformSet];
GO
IF OBJECT_ID(N'[dbo].[UserSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[UserSet];
GO
IF OBJECT_ID(N'[dbo].[CollectionSet]', 'U') IS NOT NULL
    DROP TABLE [dbo].[CollectionSet];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GameSet'
CREATE TABLE [dbo].[GameSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Condition] nvarchar(max)  NOT NULL,
    [ConsoleSoort_Id] int  NOT NULL,
    [Collection_Id] int  NOT NULL
);
GO

-- Creating table 'ConsoleSoortSet'
CREATE TABLE [dbo].[ConsoleSoortSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [ConsoleName] nvarchar(max)  NOT NULL,
    [Platform_Id] int  NOT NULL
);
GO

-- Creating table 'PlatformSet'
CREATE TABLE [dbo].[PlatformSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [PlatformName] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'UserSet'
CREATE TABLE [dbo].[UserSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [UserName] nvarchar(max)  NOT NULL,
    [Password] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'CollectionSet'
CREATE TABLE [dbo].[CollectionSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [User_Id] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [PK_GameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConsoleSoortSet'
ALTER TABLE [dbo].[ConsoleSoortSet]
ADD CONSTRAINT [PK_ConsoleSoortSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlatformSet'
ALTER TABLE [dbo].[PlatformSet]
ADD CONSTRAINT [PK_PlatformSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'UserSet'
ALTER TABLE [dbo].[UserSet]
ADD CONSTRAINT [PK_UserSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'CollectionSet'
ALTER TABLE [dbo].[CollectionSet]
ADD CONSTRAINT [PK_CollectionSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [ConsoleSoort_Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_ConsoleGame]
    FOREIGN KEY ([ConsoleSoort_Id])
    REFERENCES [dbo].[ConsoleSoortSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsoleGame'
CREATE INDEX [IX_FK_ConsoleGame]
ON [dbo].[GameSet]
    ([ConsoleSoort_Id]);
GO

-- Creating foreign key on [Platform_Id] in table 'ConsoleSoortSet'
ALTER TABLE [dbo].[ConsoleSoortSet]
ADD CONSTRAINT [FK_PlatformConsole]
    FOREIGN KEY ([Platform_Id])
    REFERENCES [dbo].[PlatformSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlatformConsole'
CREATE INDEX [IX_FK_PlatformConsole]
ON [dbo].[ConsoleSoortSet]
    ([Platform_Id]);
GO

-- Creating foreign key on [User_Id] in table 'CollectionSet'
ALTER TABLE [dbo].[CollectionSet]
ADD CONSTRAINT [FK_CollectionUser]
    FOREIGN KEY ([User_Id])
    REFERENCES [dbo].[UserSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CollectionUser'
CREATE INDEX [IX_FK_CollectionUser]
ON [dbo].[CollectionSet]
    ([User_Id]);
GO

-- Creating foreign key on [Collection_Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_CollectionGame]
    FOREIGN KEY ([Collection_Id])
    REFERENCES [dbo].[CollectionSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CollectionGame'
CREATE INDEX [IX_FK_CollectionGame]
ON [dbo].[GameSet]
    ([Collection_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------