using EF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Repository
{
    public class LocadoraContext : DbContext
    {

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Gerenos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            optionsBuilder.UseSqlServer("Password=123123;Persist Security Info=True;User ID=sa;Initial Catalog=locadora;Data Source=AVELL\\LOCADORA");
        }
    }
}
//SCRIPT SQL 

/*
 
IF OBJECT_ID(N'[__EFMigrationsHistory]') IS NULL
BEGIN
    CREATE TABLE [__EFMigrationsHistory] (
        [MigrationId] nvarchar(150) NOT NULL,
        [ProductVersion] nvarchar(32) NOT NULL,
        CONSTRAINT [PK___EFMigrationsHistory] PRIMARY KEY ([MigrationId])
    );
END;

GO

CREATE TABLE [Gerenos] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [DataCriacao] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    CONSTRAINT [PK_Gerenos] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Locacoes] (
    [Id] int NOT NULL IDENTITY,
    [CPF] int NOT NULL,
    [DataCriacao] datetime2 NOT NULL,
    CONSTRAINT [PK_Locacoes] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Usuarios] (
    [Id] int NOT NULL IDENTITY,
    [User] nvarchar(max) NOT NULL,
    [Passwd] nvarchar(max) NOT NULL,
    CONSTRAINT [PK_Usuarios] PRIMARY KEY ([Id])
);

GO

CREATE TABLE [Filmes] (
    [Id] int NOT NULL IDENTITY,
    [Nome] nvarchar(max) NULL,
    [DataCriacao] datetime2 NOT NULL,
    [Ativo] bit NOT NULL,
    [GeneroId] int NOT NULL,
    [LocacaoId] int NULL,
    CONSTRAINT [PK_Filmes] PRIMARY KEY ([Id]),
    CONSTRAINT [FK_Filmes_Gerenos_GeneroId] FOREIGN KEY ([GeneroId]) REFERENCES [Gerenos] ([Id]) ON DELETE CASCADE,
    CONSTRAINT [FK_Filmes_Locacoes_LocacaoId] FOREIGN KEY ([LocacaoId]) REFERENCES [Locacoes] ([Id]) ON DELETE NO ACTION
);

GO

CREATE INDEX [IX_Filmes_GeneroId] ON [Filmes] ([GeneroId]);

GO

CREATE INDEX [IX_Filmes_LocacaoId] ON [Filmes] ([LocacaoId]);

GO

INSERT INTO [__EFMigrationsHistory] ([MigrationId], [ProductVersion])
VALUES (N'20191016104802_Ini', N'2.2.6-servicing-10079');

GO

     
     
*/
