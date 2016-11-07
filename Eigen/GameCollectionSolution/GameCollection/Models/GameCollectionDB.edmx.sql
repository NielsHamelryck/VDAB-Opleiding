
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 11/07/2016 10:22:28
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


-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------


-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'GameSet'
CREATE TABLE [dbo].[GameSet] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Title] nvarchar(max)  NOT NULL,
    [Condition] nvarchar(max)  NOT NULL,
    [Console_Id] int  NOT NULL
);
GO

-- Creating table 'ConsoleSet'
CREATE TABLE [dbo].[ConsoleSet] (
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

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [PK_GameSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'ConsoleSet'
ALTER TABLE [dbo].[ConsoleSet]
ADD CONSTRAINT [PK_ConsoleSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'PlatformSet'
ALTER TABLE [dbo].[PlatformSet]
ADD CONSTRAINT [PK_PlatformSet]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [Console_Id] in table 'GameSet'
ALTER TABLE [dbo].[GameSet]
ADD CONSTRAINT [FK_ConsoleGame]
    FOREIGN KEY ([Console_Id])
    REFERENCES [dbo].[ConsoleSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ConsoleGame'
CREATE INDEX [IX_FK_ConsoleGame]
ON [dbo].[GameSet]
    ([Console_Id]);
GO

-- Creating foreign key on [Platform_Id] in table 'ConsoleSet'
ALTER TABLE [dbo].[ConsoleSet]
ADD CONSTRAINT [FK_PlatformConsole]
    FOREIGN KEY ([Platform_Id])
    REFERENCES [dbo].[PlatformSet]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_PlatformConsole'
CREATE INDEX [IX_FK_PlatformConsole]
ON [dbo].[ConsoleSet]
    ([Platform_Id]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------