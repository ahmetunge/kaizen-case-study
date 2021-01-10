using Kaizen.Blog.DataAccess.EFCore;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.Interfaces
{
    public interface IArticleRepository: IRepositoryBase<Article>
    {
        Task<PagedList<ArticleToListDto>> GetFilterList(ArticleParams articleParams);
    }
}
