
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 05/29/2016 17:34:12
-- Generated from EDMX file: C:\Users\ouz_a\Source\Repos\SosyalKaldik\SosyalKaldık\SosyalKaldık\Models\SosyalKal.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [SosyalKal];
GO
IF SCHEMA_ID(N'dbo') IS NULL EXECUTE(N'CREATE SCHEMA [dbo]');
GO

-- --------------------------------------------------
-- Dropping existing FOREIGN KEY constraints
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[FK_ETKINLIK_KATEGORI]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ETKINLIK] DROP CONSTRAINT [FK_ETKINLIK_KATEGORI];
GO
IF OBJECT_ID(N'[dbo].[FK_ETKINLIK_KULLANICI]', 'F') IS NOT NULL
    ALTER TABLE [dbo].[ETKINLIK] DROP CONSTRAINT [FK_ETKINLIK_KULLANICI];
GO

-- --------------------------------------------------
-- Dropping existing tables
-- --------------------------------------------------

IF OBJECT_ID(N'[dbo].[ETKINLIK]', 'U') IS NOT NULL
    DROP TABLE [dbo].[ETKINLIK];
GO
IF OBJECT_ID(N'[dbo].[KATEGORI]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KATEGORI];
GO
IF OBJECT_ID(N'[dbo].[KULLANICI]', 'U') IS NOT NULL
    DROP TABLE [dbo].[KULLANICI];
GO
IF OBJECT_ID(N'[dbo].[sysdiagrams]', 'U') IS NOT NULL
    DROP TABLE [dbo].[sysdiagrams];
GO

-- --------------------------------------------------
-- Creating all tables
-- --------------------------------------------------

-- Creating table 'ETKINLIKs'
CREATE TABLE [dbo].[ETKINLIKs] (
    [ETK_ID] int IDENTITY(1,1) NOT NULL,
    [ETK_BASLIK] varchar(50)  NULL,
    [ETK_ACIKLAMA] varchar(400)  NULL,
    [ETK_SEHIR] varchar(50)  NULL,
    [ETK_ILCE] varchar(50)  NULL,
    [ETK_TARIH_SAAT] datetime  NULL,
    [KUL_ID] int  NOT NULL,
    [KAT_ID] int  NOT NULL
);
GO

-- Creating table 'KATEGORIs'
CREATE TABLE [dbo].[KATEGORIs] (
    [KAT_ID] int IDENTITY(1,1) NOT NULL,
    [KAT_ADI] varchar(50)  NULL
);
GO

-- Creating table 'KULLANICIs'
CREATE TABLE [dbo].[KULLANICIs] (
    [KUL_ID] int IDENTITY(1,1) NOT NULL,
    [KUL_EMAIL] varchar(50)  NULL,
    [KUL_PASSWORD] varchar(50)  NULL,
    [KUL_TELEFON] nchar(10)  NULL
);
GO

-- Creating table 'sysdiagrams'
CREATE TABLE [dbo].[sysdiagrams] (
    [name] nvarchar(128)  NOT NULL,
    [principal_id] int  NOT NULL,
    [diagram_id] int IDENTITY(1,1) NOT NULL,
    [version] int  NULL,
    [definition] varbinary(max)  NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [ETK_ID] in table 'ETKINLIKs'
ALTER TABLE [dbo].[ETKINLIKs]
ADD CONSTRAINT [PK_ETKINLIKs]
    PRIMARY KEY CLUSTERED ([ETK_ID] ASC);
GO

-- Creating primary key on [KAT_ID] in table 'KATEGORIs'
ALTER TABLE [dbo].[KATEGORIs]
ADD CONSTRAINT [PK_KATEGORIs]
    PRIMARY KEY CLUSTERED ([KAT_ID] ASC);
GO

-- Creating primary key on [KUL_ID] in table 'KULLANICIs'
ALTER TABLE [dbo].[KULLANICIs]
ADD CONSTRAINT [PK_KULLANICIs]
    PRIMARY KEY CLUSTERED ([KUL_ID] ASC);
GO

-- Creating primary key on [diagram_id] in table 'sysdiagrams'
ALTER TABLE [dbo].[sysdiagrams]
ADD CONSTRAINT [PK_sysdiagrams]
    PRIMARY KEY CLUSTERED ([diagram_id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [KAT_ID] in table 'ETKINLIKs'
ALTER TABLE [dbo].[ETKINLIKs]
ADD CONSTRAINT [FK_ETKINLIK_KATEGORI]
    FOREIGN KEY ([KAT_ID])
    REFERENCES [dbo].[KATEGORIs]
        ([KAT_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ETKINLIK_KATEGORI'
CREATE INDEX [IX_FK_ETKINLIK_KATEGORI]
ON [dbo].[ETKINLIKs]
    ([KAT_ID]);
GO

-- Creating foreign key on [KUL_ID] in table 'ETKINLIKs'
ALTER TABLE [dbo].[ETKINLIKs]
ADD CONSTRAINT [FK_ETKINLIK_KULLANICI]
    FOREIGN KEY ([KUL_ID])
    REFERENCES [dbo].[KULLANICIs]
        ([KUL_ID])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_ETKINLIK_KULLANICI'
CREATE INDEX [IX_FK_ETKINLIK_KULLANICI]
ON [dbo].[ETKINLIKs]
    ([KUL_ID]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------