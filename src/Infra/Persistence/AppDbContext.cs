using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Infra.Persistence.config;
using Microsoft.EntityFrameworkCore;

namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Infra.Persistence
{
    public class AppDbContext : DbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Client> Clients { get; set; } // Mapear a tabela tblCliente

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ClientConfig());
        }
    }
}
