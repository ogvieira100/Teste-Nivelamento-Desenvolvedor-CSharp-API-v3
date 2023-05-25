using Microsoft.EntityFrameworkCore;

namespace Questao5.Domain.Repository
{
    public interface IUnitOfWork : IDisposable
    {
        Task<bool> CommitAsync();
    }
}
