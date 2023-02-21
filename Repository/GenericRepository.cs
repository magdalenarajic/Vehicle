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

        public virtual async Task<ICollection<T>> GetAllAsync()
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
        public virtual async Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> expression)
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

        public virtual async Task<T> GetByIdAsync(int id)
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

        public  async Task<T> AddAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(AddAsync)} entity must not be null");
            }
            try
            {
                _dbSet.Add(entity);
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch(Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be saved: {e.Message}");
            }
           
        }

        public virtual async Task<T> UpdateAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(UpdateAsync)} entity must not be null");
            }
            try
            {
                    _dbContext.Entry(entity).State = System.Data.Entity.EntityState.Modified;
                await _dbContext.SaveChangesAsync();
                return entity;
            }
            catch (Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be updated: {e.Message}");
            }
        }
        public virtual async Task<int> DeleteAsync(T entity)
        {
            if (entity == null)
            {
                throw new ArgumentNullException($"{nameof(DeleteAsync)} entity must not be null");
            }
            try
            {
                _dbSet.Remove(entity);
               return await _dbContext.SaveChangesAsync();
            }
            catch(Exception e)
            {
                throw new Exception($"{nameof(entity)} could not be removed: {e.Message}");
            }
            
        }
    }
}
