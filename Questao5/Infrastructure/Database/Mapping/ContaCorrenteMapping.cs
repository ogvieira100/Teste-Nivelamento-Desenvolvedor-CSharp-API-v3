using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Mapping
{
    public class ContaCorrenteMapping : IEntityTypeConfiguration<ContaCorrente>
    {
        public void Configure(EntityTypeBuilder<ContaCorrente> builder)
        {
            builder.HasKey(c => c.ContaCorrenteId);


            builder.Property(c => c.ContaCorrenteId)
               .HasColumnName("idcontacorrente")
               .IsRequired();

            builder.Property(c => c.Numero)
                .HasColumnName("numero")
                .IsRequired();


            builder.Property(c => c.Nome)
                .HasColumnName("nome")
                .IsRequired();

            builder.Property(c => c.Ativo)
               .HasColumnName("ativo")
               .HasDefaultValue(true)
               .IsRequired();

            builder.ToTable("contacorrente");

        }
    }
}
