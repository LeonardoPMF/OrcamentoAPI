IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;
GO

BEGIN TRANSACTION;
GO

CREATE TABLE [Despesas] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Data] datetime2 NOT NULL,
    [Categoria] int NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Despesas] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Orcamentos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NOT NULL,
    [Valor] decimal(18,2) NOT NULL,
    [Data] datetime2 NOT NULL,
    [Categoria] int NOT NULL,
    [Descricao] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Orcamentos] PRIMARY KEY ([Id])
);
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria', N'Data', N'Descricao', N'Nome', N'Valor') AND [object_id] = OBJECT_ID(N'[Despesas]'))
    SET IDENTITY_INSERT [Despesas] ON;
INSERT INTO [Despesas] ([Id], [Categoria], [Data], [Descricao], [Nome], [Valor])
VALUES (1, 1, '2024-04-28T14:56:17.6903951-03:00', N'Despesa de exemplo', N'Despesa Inicial', 100.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria', N'Data', N'Descricao', N'Nome', N'Valor') AND [object_id] = OBJECT_ID(N'[Despesas]'))
    SET IDENTITY_INSERT [Despesas] OFF;
GO

IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria', N'Data', N'Descricao', N'Nome', N'Valor') AND [object_id] = OBJECT_ID(N'[Orcamentos]'))
    SET IDENTITY_INSERT [Orcamentos] ON;
INSERT INTO [Orcamentos] ([Id], [Categoria], [Data], [Descricao], [Nome], [Valor])
VALUES (1, 1, '2024-04-28T14:56:17.6903736-03:00', N'Orcamento de exemplo', N'Orcamento Inicial', 1000.0);
IF EXISTS (SELECT * FROM [sys].[identity_columns] WHERE [name] IN (N'Id', N'Categoria', N'Data', N'Descricao', N'Nome', N'Valor') AND [object_id] = OBJECT_ID(N'[Orcamentos]'))
    SET IDENTITY_INSERT [Orcamentos] OFF;
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20240428175618_MigracaoInicial', N'8.0.4');
GO

COMMIT;
GO

