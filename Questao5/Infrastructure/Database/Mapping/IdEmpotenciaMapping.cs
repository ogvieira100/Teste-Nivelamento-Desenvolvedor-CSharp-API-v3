using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Mapping
{
    public class IdEmpotenciaMapping : IEntityTypeConfiguration<IdEmpotencia>
    {
        public void Configure(EntityTypeBuilder<IdEmpotencia> builder)
        {
            builder.HasKey(c => c.Id);


            builder.Property(c => c.Id)
               .HasColumnName("chave_idempotencia")
               .IsRequired();

            builder.Property(c => c.Requisicao)
                .HasColumnName("requisicao");


            builder.Property(c => c.Resultado)
                .HasColumnName("resultado");


            builder.ToTable("idemponderancia");

        }
    }
}
