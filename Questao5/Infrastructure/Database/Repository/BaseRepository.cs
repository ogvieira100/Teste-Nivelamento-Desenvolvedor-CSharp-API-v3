using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Database.Context;

namespace Questao5.Infrastructure.Database.Repository
{
    public  class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class
    {
        public IUnitOfWork UnitOfWork { get; }

        public IBaseConsultRepository<TEntity> RepositoryConsult { get; protected set; }

        readonly DbSet<TEntity> DbSet;

        readonly AplicationContext _aplicationContext;
        public BaseRepository(IUnitOfWork unitOfWork,
                                AplicationContext aplicationContext,
                                IBaseConsultRepository<TEntity> repositoryConsult

                                )
        {
            UnitOfWork = unitOfWork;
            _aplicationContext = aplicationContext;
            DbSet = _aplicationContext.Set<TEntity>();
            RepositoryConsult = repositoryConsult;
        }
        public void Add(TEntity entity) => _aplicationContext.Entry(entity).State = EntityState.Added;

        public void Dispose() => GC.SuppressFinalize(this);

        public void Remove(TEntity entity) => DbSet.Remove(entity);

        public void Remove<T>(T entity) where T : class => _aplicationContext.Set<T>().Remove(entity);

        public void Update(TEntity entity) => _aplicationContext.Entry(entity).State = EntityState.Modified;

        public async Task AddAsync(TEntity entidade) => await DbSet.AddAsync(entidade);

        public async Task AddAsync<T>(T entidade) where T : class
        => await _aplicationContext.Set<T>().AddAsync(entidade);

        public void Update<T>(T entity) where T : class
        => _aplicationContext.Set<T>().Update(entity);

        public void UpdateRange<T>(IEnumerable<T> entity) where T : class
        => _aplicationContext.Set<T>().UpdateRange(entity);
    }
}
