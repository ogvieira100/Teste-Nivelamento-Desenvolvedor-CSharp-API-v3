using Questao5.Domain.Repository;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Uow
{
    public class UnitOfWork : IUnitOfWork
    {
  

        readonly AplicationContext _aplicationContext;
        public UnitOfWork(AplicationContext aplicationContext)
        {
            _aplicationContext = aplicationContext;
        }
        public void Dispose() => GC.SuppressFinalize(this);
        public async Task<bool> CommitAsync() => await _aplicationContext.SaveChangesAsync() > 0;
    }
}
