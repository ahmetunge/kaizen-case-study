using Kaizen.Blog.DataAccess.EFCore;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using Kaizen.Blog.Utilities.Results;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Business.Interfaces
{
    public interface IArticleService
    {
        Task<IResult> AddArticle(ArticleToSaveDto articleToSave, int userId);

        Task<IResult> DeleteArticle(int articleId, int userId);

        Task<IResult> UpdateArticle(int articleId,ArticleToSaveDto articleToSaveDto, int userId);

        Task<IDataResult<PagedList<ArticleToListDto>>> ListArticle(ArticleParams articleParams);

    }
}
