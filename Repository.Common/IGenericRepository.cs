using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;

namespace Repository.Common
{
    public interface IGenericRepository<T> where T : class
    {
        IEnumerable<T> GetAll();
        Task<ICollection<T>> GetAllAsync();
        Task<ICollection<T>> FindByAsync(Expression<Func<T, bool>> expression);
        Task<T> GetByIdAsync(int id);
        Task<T> AddAsync(T entity);
        Task DeleteAsync(T entity);
        Task<T> UpdateAsync(T entity);
    }
}
