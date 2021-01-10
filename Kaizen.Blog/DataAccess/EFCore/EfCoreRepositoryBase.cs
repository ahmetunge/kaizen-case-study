using Kaizen.Blog.DataAccess.Interfaces;
using Kaizen.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore
{
    public class EfCoreRepositoryBase<TEntity> : IRepositoryBase<TEntity>
     where TEntity : class, IEntity, new()
    {
        private readonly DbContext _context;

        public EfCoreRepositoryBase(DbContext context)
        {
            _context = context;

        }
        public void Add(TEntity entity)
        {
            _context.Set<TEntity>().Add(entity);
        }

        public void Delete(TEntity entity)
        {
            _context.Set<TEntity>().Remove(entity);
        }

        public async Task<TEntity> FindAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>().Where(expression).SingleOrDefaultAsync();
        }

        public async Task<TEntity> FindAsNoTrackingAsync(Expression<Func<TEntity, bool>> expression)
        {
            return await _context.Set<TEntity>()
            .Where(expression)
            .AsNoTracking()
            .SingleOrDefaultAsync();
        }

        public async Task<IReadOnlyList<TEntity>> FindListAsync(Expression<Func<TEntity, bool>> expression = null)
        {
            return await _context.Set<TEntity>().Where(expression)
            .ToListAsync();
        }

        public async Task<IReadOnlyList<TEntity>> GetAllAsync()
        {
            return await _context.Set<TEntity>().ToListAsync();
        }

        public void Update(TEntity entity)
        {
            _context.Set<TEntity>().Update(entity);
        }


    }
}
