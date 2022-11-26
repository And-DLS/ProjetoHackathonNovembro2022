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

CREATE TABLE [Usuario] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(80) NOT NULL,
    [Email] VARCHAR(40) NOT NULL,
    [Cnpj] INTEGER NOT NULL,
    [Senha] VARCHAR(30) NOT NULL,
    CONSTRAINT [PK_Usuario] PRIMARY KEY ([Id])
);
GO

CREATE TABLE [Clinica] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(80) NOT NULL,
    [Email] VARCHAR(40) NOT NULL,
    [Senha] VARCHAR(30) NOT NULL,
    [UsuarioId] int NOT NULL,
    CONSTRAINT [PK_Clinica] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Clinica_Usuario] FOREIGN KEY ([UsuarioId]) REFERENCES [Usuario] ([Id]) ON DELETE CASCADE
);
GO

CREATE TABLE [Cliente] (
    [Id] int NOT NULL IDENTITY,
    [Nome] VARCHAR(150) NOT NULL,
    [Cpf] VARCHAR(11) NOT NULL,
    [Email] VARCHAR(40) NOT NULL,
    [Telefone] VARCHAR(13) NOT NULL,
    [Endereco] VARCHAR(150) NOT NULL,
    [ClinicaId] int NOT NULL,
    CONSTRAINT [PK_Cliente] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Cliente_Clinica] FOREIGN KEY ([ClinicaId]) REFERENCES [Clinica] ([Id]) ON DELETE CASCADE
);
GO

CREATE INDEX [IX_Cliente_ClinicaId] ON [Cliente] ([ClinicaId]);
GO

CREATE INDEX [IX_Clinica_UsuarioId] ON [Clinica] ([UsuarioId]);
GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20221126035526_CriacaoInicial', N'7.0.0');
GO

COMMIT;
GO

