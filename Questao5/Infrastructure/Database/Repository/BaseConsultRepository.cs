using Dapper;
using Microsoft.EntityFrameworkCore;
using Questao5.Domain.Repository;
using Questao5.Infrastructure.Database.Context;
using System.Collections.Generic;
using System.Linq.Expressions;

namespace Questao5.Infrastructure.Database.Repository
{
    public class RepositoryConsult<TEntity> : IBaseConsultRepository<TEntity> where TEntity : class
    {

        readonly AplicationContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public RepositoryConsult(AplicationContext Context)
        {
            _context = Context;
            _dbSet = _context.Set<TEntity>();
        }

        public void Dispose() => GC.SuppressFinalize(this);
        public async Task<bool> ExistsAsync(Expression<Func<TEntity, bool>> predicate) => await _dbSet.AnyAsync(predicate);
        public async Task<IEnumerable<TEntity>> GetAllAsync() => await _dbSet.ToListAsync();
        public async Task<TEntity> GetByIdAsync(Int64 id) => await _dbSet.FindAsync(id);
        public async Task<IEnumerable<TEntity>> SearchAsync(Expression<Func<TEntity, bool>> predicate, bool asnotracking = false)
            
            => asnotracking == true ? await _dbSet.Where(predicate).AsNoTracking().ToListAsync() : await _dbSet.Where(predicate).ToListAsync();
        public IQueryable<TEntity> GetQueryable() => _dbSet.AsQueryable();
        public async Task<IEnumerable<TModel>> GetAllAsync<TModel>(string sql, object par = null) 
                                                                            => await _context.Database.GetDbConnection().QueryAsync<TModel>(sql, par);
        public async Task<TModel> GetOneAsync<TModel>(string sql, object obj = null)
                                                                           => await _context.Database.GetDbConnection().QueryFirstAsync<TModel>(sql, obj);
    }
}
