using DNT.Domain;
using Microsoft.EntityFrameworkCore;

namespace DNT.Infrastructure
{
    public class BaseRepository<TEntity> : IBaseRepository<TEntity> where TEntity : class, IHasKey
    {
        protected readonly ApplicationDbContext _context;
        protected readonly DbSet<TEntity> _dbSet;

        public BaseRepository(ApplicationDbContext context)
        {
            _context = context;
            _dbSet = context.Set<TEntity>();
        }

        public async Task Create(TEntity entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
        }

        public async Task Delete(Guid id)
        {
            var entity = await FindById(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _dbSet.Remove(entity);
            await _context.SaveChangesAsync();
        }

        public async Task DeleteMany(List<Guid> ids)
        {
            var entities = await _dbSet.Where(entity => ids.Contains(entity.GetKey())).ToListAsync();

            if (entities.Count != ids.Count)
            {
                throw new Exception("Not found");
            }

            _dbSet.RemoveRange(entities);
            await _context.SaveChangesAsync();
        }

        public async Task<TEntity?> FindById(Guid id)
        {
            var entity = await _dbSet.FindAsync(id);

            return entity;
        }

        public virtual async Task<IEnumerable<TEntity>> GetAll()
        {
            var entities = await _dbSet.ToListAsync();

            return entities;
        }

        public async Task<TEntity> GetById(Guid id)
        {
            var entity = await FindById(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            return entity;
        }

        public async Task Update(Guid id, TEntity entity)
        {
            var existingEntity = await GetById(id);
            if (entity == null)
            {
                throw new Exception("Not found");
            }

            _context.Entry(existingEntity).CurrentValues.SetValues(entity);

            await _context.SaveChangesAsync();
        }
    }
}
