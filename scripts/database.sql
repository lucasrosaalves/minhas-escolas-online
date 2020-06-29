IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Escolas] (
    [Id] uniqueidentifier NOT NULL,
    [Nome] varchar(100) NOT NULL,
    [Codigo] varchar(50) NOT NULL,
    CONSTRAINT [PK_Escolas] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Contatos] (
    [Id] uniqueidentifier NOT NULL,
    [Telefone] varchar(20) NOT NULL,
    [Email] varchar(100) NOT NULL,
    [Site] varchar(100) NULL,
    [EscolaId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Contatos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Contatos_Escolas_EscolaId] FOREIGN KEY ([EscolaId]) REFERENCES [Escolas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Enderecos] (
    [Id] uniqueidentifier NOT NULL,
    [Logradouro] varchar(150) NOT NULL,
    [Numero] varchar(14) NOT NULL,
    [Complemento] varchar(100) NULL,
    [Bairro] varchar(50) NOT NULL,
    [Cep] varchar(20) NOT NULL,
    [TipoLocalizacaoId] int NOT NULL,
    [EscolaId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Enderecos] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Enderecos_Escolas_EscolaId] FOREIGN KEY ([EscolaId]) REFERENCES [Escolas] ([Id]) ON DELETE CASCADE
);

GO

CREATE TABLE [Turmas] (
    [Id] uniqueidentifier NOT NULL,
    [Codigo] nvarchar(max) NULL,
    [TipoTurnoId] int NOT NULL,
    [QuantidadeAlunos] int NOT NULL,
    [EscolaId] uniqueidentifier NOT NULL,
    CONSTRAINT [PK_Turmas] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Turmas_Escolas_EscolaId] FOREIGN KEY ([EscolaId]) REFERENCES [Escolas] ([Id]) ON DELETE CASCADE
);

GO

CREATE UNIQUE INDEX [IX_Contatos_EscolaId] ON [Contatos] ([EscolaId]);

GO

CREATE UNIQUE INDEX [IX_Enderecos_EscolaId] ON [Enderecos] ([EscolaId]);

GO

CREATE INDEX [IX_Turmas_EscolaId] ON [Turmas] ([EscolaId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20200628190840_Initial', N'3.1.4');

GO

