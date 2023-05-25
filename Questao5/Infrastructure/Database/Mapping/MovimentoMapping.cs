using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Questao5.Domain.Entities;

namespace Questao5.Infrastructure.Database.Mapping
{
    public class MovimentoMapping : IEntityTypeConfiguration<Movimento>
    {
        public void Configure(EntityTypeBuilder<Movimento> builder)
        {
            builder.HasKey(c => c.IdMovimento);


            builder.Property(c => c.IdMovimento)
               .HasColumnName("idmovimento")
               .IsRequired();

            builder.Ignore(x => x.TipoMovimentoEnum);

            builder.Property(c => c.DataMovimento)
                .HasColumnName("datamovimento")
                .HasDefaultValue(DateTime.Now.ToShortDateString())
                .IsRequired();

            builder.Property(c => c.TipoMovimento)
                .HasColumnName("tipomovimento")
                .HasDefaultValue("C")
                .IsRequired();

            builder.Property(c => c.Valor)
               .HasColumnName("valor")
               .HasDefaultValue(0)
               .IsRequired();

            builder.HasOne(x => x.ContaCorrente)
               .WithMany(x => x.Movimentos)
               .HasForeignKey(x => x.IdMovimento);
        }
    }
}
