IF DB_ID('SQL_PAYROLL_EXTRACT_GENERATOR') IS NULL
    CREATE DATABASE SQL_PAYROLL_EXTRACT_GENERATOR;
GO

USE [SQL_PAYROLL_EXTRACT_GENERATOR]
GO
------------------------------------------------
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory]
    (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [dbo].[Employees]
(
    [Id] bigint NOT NULL IDENTITY,
    [FirstName] nvarchar(max) NOT NULL,
    [LastName] nvarchar(max) NOT NULL,
    [Document] nvarchar(max) NOT NULL,
    [Department] nvarchar(max) NOT NULL,
    [GrossSalary] decimal(18,2) NOT NULL,
    [HireDate] datetime2 NOT NULL,
    [HasHealthPlanDiscount] bit NOT NULL,
    [HasDentalPlanDiscount] bit NOT NULL,
    [HasTransportationVoucherDiscount] bit NOT NULL,
    CONSTRAINT [PK_Employees] PRIMARY KEY ([Id])
);
GO

INSERT INTO [__EFMigrationsHistory]
    ([MigrationId], [ProductVersion])
VALUES
    (N'20240228163720_InitialDatabase', N'8.0.2');
GO

COMMIT;
GO

