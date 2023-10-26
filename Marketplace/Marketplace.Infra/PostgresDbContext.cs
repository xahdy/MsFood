using Marketplace.Domain.Models;
using Microsoft.EntityFrameworkCore;
using System.Reflection.Metadata;

namespace Marketplace.Infra
{
    public class PostgresDbContext : DbContext
    {
        public PostgresDbContext(DbContextOptions<PostgresDbContext> options) : base(options) { }

        public DbSet<Restaurante> Restaurante => Set<Restaurante>();
        public DbSet<Prato> Prato => Set<Prato>();
        public DbSet<Localizacao> Localizacao => Set<Localizacao>();

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Restaurante>().HasQueryFilter(p => !p.Deletado);
            modelBuilder.Entity<Prato>().HasQueryFilter(p => !p.Deletado);
            modelBuilder.Entity<Localizacao>().HasQueryFilter(p => !p.Deletado);
        }
    }
}
