using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Repository
{
    public abstract class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; }

        public IBaseConsultRepository<TEntity> RepositoryConsult { get; protected set; }

        readonly DbSet<TEntity> DbSet;

        readonly AplicationContext _aplicationContext;
        protected BaseRepository(IUnitOfWork unitOfWork,
                                AplicationContext aplicationContext,
                                IBaseConsultRepository<TEntity> repositoryConsult

                                )
        {
            UnitOfWork = unitOfWork;
            _aplicationContext = aplicationContext;
            DbSet = _aplicationContext.Set<TEntity>();
            RepositoryConsult = repositoryConsult;
        }
        public void Add(TEntity entity) => DbSet.Add(entity);

        public void Dispose() => GC.SuppressFinalize(this);

        public void Remove(TEntity entity) => DbSet.Remove(entity);

        public void Remove<T>(T entity) where T : class => _aplicationContext.Set<T>().Remove(entity);

        public void Update(TEntity entity) => DbSet.Update(entity);

        public async Task AddAsync(TEntity entidade) => await DbSet.AddAsync(entidade);

        public async Task AddAsync<T>(T entidade) where T : class
        => await _aplicationContext.Set<T>().AddAsync(entidade);

        public void Update<T>(T entity) where T : class
        => _aplicationContext.Set<T>().Update(entity);

        public void UpdateRange<T>(IEnumerable<T> entity) where T : class
        => _aplicationContext.Set<T>().UpdateRange(entity);
    }
}
