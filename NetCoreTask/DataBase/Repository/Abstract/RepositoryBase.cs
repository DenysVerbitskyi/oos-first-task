using Microsoft.EntityFrameworkCore;

namespace NetCoreTask.DataBase.Repository.Abstract
{
    public abstract class RepositoryBase<TEntity, TContext> : IRepository<TEntity>
        where TEntity : class
        where TContext : DbContext
    {
        private readonly TContext _context;
        private readonly DbSet<TEntity> _dbSet;

        public RepositoryBase(TContext context)
        {
            _context = context;
            _dbSet = _context.Set<TEntity>();
        }

        public async Task<TEntity> Add(TEntity entity)
        {
            await _dbSet.AddAsync(entity).ConfigureAwait(false);
            
            await _context.SaveChangesAsync().ConfigureAwait(false);
            return entity;
        }

        public async Task<TEntity> Delete(Guid id)
        {
            var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);
            if (entity == null)
            {
                throw new ArgumentNullException();
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<TEntity> GetById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id).ConfigureAwait(false);

            return entity;
        }

        public virtual async Task<List<TEntity>> GetAll()
        {
            var entities = await _dbSet.ToListAsync().ConfigureAwait(false);

            return entities;
        }

        public async Task<TEntity> Update(TEntity entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync().ConfigureAwait(false);

            return entity;
        }
    }
}
