using Kaizen.Blog.DataAccess.Interfaces;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using Microsoft.Data.SqlClient;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.DataAccess.EFCore
{
    public class EfCoreArticleRepository : EfCoreRepositoryBase<Article>, IArticleRepository
    {
        private readonly KaizenContext _context;

        public EfCoreArticleRepository(KaizenContext context) : base(context)
        {
            _context = context;
        }

        public async Task<PagedList<ArticleToListDto>> GetFilterList(ArticleParams articleParams)
        {
            var articles = _context.Articles.AsQueryable();

            if (articleParams.CategoryId.HasValue)
            {
                articles = articles.Where(a => a.CategoryId == articleParams.CategoryId.Value);
            }

            if (!string.IsNullOrEmpty(articleParams.Title))
            {
                articles = articles.Where(a => EF.Functions.Like(a.Title, $"%{articleParams.Title.ToUpper()}%"));
            }

            if (!string.IsNullOrEmpty(articleParams.SortBy))
            {
                switch (articleParams.SortBy)
                {
                    case "id":
                        articles = articles.OrderBy(a => a.Id);
                        break;
                    default:
                        break;
                }
            }

            var articlesToReturn = articles.Select(a => new ArticleToListDto
            {
                Id = a.Id,
                CategoryId = a.CategoryId,
                CategoryName = a.Category.Name,
                Content = a.Content,
                Title = a.Title,
                UserId = a.UserId
            });

            return await PagedList<ArticleToListDto>.CreateAsync(articlesToReturn, articleParams.PageNumber, articleParams.PageSize);
        }
    }
}
