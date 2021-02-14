using ForestAppBase.Abstract;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace ForestAppBase.Concrate
{
    public class BaseRepository<Ctx,T> : IBaseRepository<Ctx,T> where Ctx : DbContext where T : class
    {

        private readonly Ctx _context;

        protected Ctx Context { get { return _context; } }
        private DbSet<T> _dbSet;
        public BaseRepository(Ctx context)
        {
            _context = context;
            _dbSet = context.Set<T>();
        }
        public Task<int> CountAll()
        {
            return _dbSet.CountAsync();
        }

        public Task<int> CountWhere(Expression<Func<T, bool>> filter)
        {
            return _dbSet.CountAsync(filter);
        }

        public async Task<int> Delete(T entity)
        {
            _dbSet.Remove(entity);
            return await _context.SaveChangesAsync();
        }

        public async Task<int> DeleteById(int id)
        {
            var item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<List<T>> Find(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.Where(filter).ToListAsync();
        }

        public async Task<T> FindOne(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.SingleOrDefaultAsync(filter);
        }

        public async Task<IEnumerable<T>> GetAll()
        {
            return await _dbSet.ToListAsync();
        }

        public async Task<T> GetByID(int id)
        {
            return await _dbSet.FindAsync(id);
        }

        public async Task<IList<T>> GetLast(Expression<Func<T, int>> filter, int takeCount = 10)
        {
            return await _dbSet.OrderByDescending(filter).Take(takeCount).ToListAsync();
        }

        public async Task<T> Insert(T entity)
        {
            await _dbSet.AddAsync(entity);
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<bool> isExists(Expression<Func<T, bool>> filter)
        {
            return await _dbSet.AnyAsync(filter);

        }

        public async Task<T> Update(T entity)
        {
            _context.Entry(entity).State = EntityState.Modified;
            await _context.SaveChangesAsync();
            return entity;
        }

        public async Task<int> DeleteByGuidId(Guid id)
        {
            var item = await _dbSet.FindAsync(id);
            _dbSet.Remove(item);
            return await _context.SaveChangesAsync();
        }

        public async Task<T> GetByGuidId(Guid id)
        {
            return await _dbSet.FindAsync(id);
        }
    }
}
