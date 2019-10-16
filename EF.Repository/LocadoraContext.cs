using EF.Domain;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;

namespace EF.Repository
{
    public class LocadoraContext : DbContext
    {
        public LocadoraContext(DbContextOptions<LocadoraContext> options) : base(options) { }

        public DbSet<Filme> Filmes { get; set; }
        public DbSet<Genero> Gerenos { get; set; }
        public DbSet<Locacao> Locacoes { get; set; }
        public DbSet<Usuario> Usuarios { get; set; }
    }
}
