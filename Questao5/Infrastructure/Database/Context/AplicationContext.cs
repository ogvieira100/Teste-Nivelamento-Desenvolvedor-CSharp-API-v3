using Microsoft.EntityFrameworkCore;
using Questao5.Infrastructure.Database.Mapping;

namespace Questao5.Infrastructure.Database.Context
{
    public class AplicationContext : DbContext
    {
        public AplicationContext(DbContextOptions<AplicationContext> options)
         : base(options)
        {



        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.ApplyConfiguration(new ContaCorrenteMapping());
            modelBuilder.ApplyConfiguration(new MovimentoMapping());
            modelBuilder.ApplyConfiguration(new IdEmpotenciaMapping());
        }

    }
}
