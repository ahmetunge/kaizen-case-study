using Kaizen.Blog.DataAccess.Interfaces;
using Kaizen.Blog.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore
{
    public class EfCoreUserRepository : EfCoreRepositoryBase<User>, IUserRepository
    {
        public EfCoreUserRepository(KaizenContext context) : base(context)
        {
        }
    }
}
