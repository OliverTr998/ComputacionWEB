
-- --------------------------------------------------
-- Entity Designer DDL Script for SQL Server 2005, 2008, 2012 and Azure
-- --------------------------------------------------
-- Date Created: 03/22/2024 09:01:48
-- Generated from EDMX file: C:\Users\oliver.obando\Desktop\Proyetos De Clase\Proyecto\CapaDato\Models\ComputacionModels.edmx
-- --------------------------------------------------

SET QUOTED_IDENTIFIER OFF;
GO
USE [IngSistemaBD];
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

-- Creating table 'Facultades'
CREATE TABLE [dbo].[Facultades] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'Carreras'
CREATE TABLE [dbo].[Carreras] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL,
    [AnioOfertada] nvarchar(max)  NOT NULL,
    [FacultadId] int  NOT NULL
);
GO

-- Creating table 'Estudiantes'
CREATE TABLE [dbo].[Estudiantes] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Carnet] nvarchar(max)  NOT NULL,
    [Nombre] nvarchar(max)  NOT NULL,
    [Apellido] nvarchar(max)  NOT NULL,
    [Edad] nvarchar(max)  NOT NULL,
    [CarreraId] int  NOT NULL
);
GO

-- Creating table 'OperadoraTelefonos'
CREATE TABLE [dbo].[OperadoraTelefonos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Codigo] nvarchar(max)  NOT NULL,
    [Descripcion] nvarchar(max)  NOT NULL
);
GO

-- Creating table 'DetalleEstudianteTelefonos'
CREATE TABLE [dbo].[DetalleEstudianteTelefonos] (
    [Id] int IDENTITY(1,1) NOT NULL,
    [Numero] nvarchar(max)  NOT NULL,
    [EstudianteId] int  NOT NULL,
    [OperadoraTelefonoId] int  NOT NULL
);
GO

-- --------------------------------------------------
-- Creating all PRIMARY KEY constraints
-- --------------------------------------------------

-- Creating primary key on [Id] in table 'Facultades'
ALTER TABLE [dbo].[Facultades]
ADD CONSTRAINT [PK_Facultades]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Carreras'
ALTER TABLE [dbo].[Carreras]
ADD CONSTRAINT [PK_Carreras]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [PK_Estudiantes]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'OperadoraTelefonos'
ALTER TABLE [dbo].[OperadoraTelefonos]
ADD CONSTRAINT [PK_OperadoraTelefonos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- Creating primary key on [Id] in table 'DetalleEstudianteTelefonos'
ALTER TABLE [dbo].[DetalleEstudianteTelefonos]
ADD CONSTRAINT [PK_DetalleEstudianteTelefonos]
    PRIMARY KEY CLUSTERED ([Id] ASC);
GO

-- --------------------------------------------------
-- Creating all FOREIGN KEY constraints
-- --------------------------------------------------

-- Creating foreign key on [FacultadId] in table 'Carreras'
ALTER TABLE [dbo].[Carreras]
ADD CONSTRAINT [FK_FacultadCarrera]
    FOREIGN KEY ([FacultadId])
    REFERENCES [dbo].[Facultades]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_FacultadCarrera'
CREATE INDEX [IX_FK_FacultadCarrera]
ON [dbo].[Carreras]
    ([FacultadId]);
GO

-- Creating foreign key on [CarreraId] in table 'Estudiantes'
ALTER TABLE [dbo].[Estudiantes]
ADD CONSTRAINT [FK_CarreraEstudiante]
    FOREIGN KEY ([CarreraId])
    REFERENCES [dbo].[Carreras]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_CarreraEstudiante'
CREATE INDEX [IX_FK_CarreraEstudiante]
ON [dbo].[Estudiantes]
    ([CarreraId]);
GO

-- Creating foreign key on [EstudianteId] in table 'DetalleEstudianteTelefonos'
ALTER TABLE [dbo].[DetalleEstudianteTelefonos]
ADD CONSTRAINT [FK_EstudianteDetalleEstudianteTelefono]
    FOREIGN KEY ([EstudianteId])
    REFERENCES [dbo].[Estudiantes]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_EstudianteDetalleEstudianteTelefono'
CREATE INDEX [IX_FK_EstudianteDetalleEstudianteTelefono]
ON [dbo].[DetalleEstudianteTelefonos]
    ([EstudianteId]);
GO

-- Creating foreign key on [OperadoraTelefonoId] in table 'DetalleEstudianteTelefonos'
ALTER TABLE [dbo].[DetalleEstudianteTelefonos]
ADD CONSTRAINT [FK_OperadoraTelefonoDetalleEstudianteTelefono]
    FOREIGN KEY ([OperadoraTelefonoId])
    REFERENCES [dbo].[OperadoraTelefonos]
        ([Id])
    ON DELETE NO ACTION ON UPDATE NO ACTION;
GO

-- Creating non-clustered index for FOREIGN KEY 'FK_OperadoraTelefonoDetalleEstudianteTelefono'
CREATE INDEX [IX_FK_OperadoraTelefonoDetalleEstudianteTelefono]
ON [dbo].[DetalleEstudianteTelefonos]
    ([OperadoraTelefonoId]);
GO

-- --------------------------------------------------
-- Script has ended
-- --------------------------------------------------