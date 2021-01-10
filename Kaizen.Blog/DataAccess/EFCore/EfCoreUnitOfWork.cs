using Kaizen.Blog.DataAccess.Interfaces;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore
{
    public class EfCoreUnitOfWork : IUnitOfWork
    {
        private readonly KaizenContext _dbContext;

        public EfCoreUnitOfWork(KaizenContext dbContext)
        {
            _dbContext = dbContext;
        }
        public async Task CompleteAsync()
        {
            await _dbContext.SaveChangesAsync();
        }
    }
}
