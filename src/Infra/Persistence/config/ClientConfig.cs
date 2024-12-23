using CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace CRUD_Teste_tecnico_Solfarma_AlexLiberato.src.Infra.Persistence.config
{
    public class ClientConfig : IEntityTypeConfiguration<Client>
    {
        public void Configure(EntityTypeBuilder<Client> entity)
        {
            entity.ToTable("tblCliente");
            entity.HasKey(c => c.Codigo);
            entity.Property(c => c.Nome)
                .HasMaxLength(150)
                .IsRequired();
            entity.Property(c => c.DataNascimento)
                .IsRequired();
            entity.Property(c => c.Sexo)
                .IsRequired();
            entity.Property(c => c.LimiteCompra)
                .HasColumnType("decimal(10,2)")
                .IsRequired();
        }
    }
}