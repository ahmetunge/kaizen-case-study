using Kaizen.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.Interfaces
{
    public interface IRepositoryBase<T> where T : class, IEntity, new()
    {
        void Add(T entity);
        void Delete(T entity);
        void Update(T entity);
        Task<T> FindAsync(Expression<Func<T, bool>> expression);
        Task<T> FindAsNoTrackingAsync(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> FindListAsync(Expression<Func<T, bool>> expression);
        Task<IReadOnlyList<T>> GetAllAsync();
    }
}