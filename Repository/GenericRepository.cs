using DAL;
using Repository.Common;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Repository
{
    public class GenericRepository<T> : IGenericRepository<T> where T : class
    {
        protected readonly VehicleContext _dbContext;
        internal DbSet<T> _dbSet;

        public GenericRepository(VehicleContext context)
        {
            _dbContext = context;
            _dbSet = context.Set<T>();
        }


        public virtual IEnumerable<T> GetAll()
        {
            try
            {
                return _dbSet.AsEnumerable();
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
            
        }

        public virtual async Task<IEnumerable<T>> GetAllAsync()
        {
            try
            {
                return await _dbSet.ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
        }
        public virtual async Task<IEnumerable<T>> Find(Expression<Func<T, bool>> expression)
        {
            try
            {
                return await _dbSet.Where(expression).ToListAsync();
            }
            catch (Exception e)
            {
                throw new Exception($"Couldn't retrieve entities: {e.Message}");
            }
            
        }

        public virtual async Task<T> GetByIdAsync(Guid id)
        {
            try
            {
                return await _dbSet.FindAsync(id);
            }
            catch(Exception e)
            {
                throw new Exception($"Couldn't retrieve entity: {e.Message}");
            }
            
        }

        public virtual async Task<bool> Add(T entity)
        {
             _dbSet.Add(entity);
            await _dbContext.SaveChangesAsync();
            return true;
        }

    }
}
