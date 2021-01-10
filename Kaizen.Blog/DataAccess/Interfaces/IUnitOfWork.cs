using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.Interfaces
{
    public interface IUnitOfWork
    {
        Task CompleteAsync();
    }
}
