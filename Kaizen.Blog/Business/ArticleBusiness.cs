using AutoMapper;
using Kaizen.Blog.Business.Interfaces;
using Kaizen.Blog.DataAccess.Interfaces;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Entities;
using Kaizen.Blog.Utilities.Results;
using System.Net;
using System.Security.Claims;
using System.Threading.Tasks;
using Kaizen.Blog.Extensions;
using Kaizen.Blog.Utilities.Messages;
using Kaizen.Blog.DataAccess.EFCore;
using System.Collections.Generic;

namespace Kaizen.Blog.Business
{
    public class ArticleBusiness : IArticleService
    {
        private readonly IArticleRepository _articleRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IIdentityService _identityService;

        public ArticleBusiness(IArticleRepository articleRepository, IUnitOfWork unitOfWork, IMapper mapper, IIdentityService identityService)
        {
            _articleRepository = articleRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _identityService = identityService;
        }
        public async Task<IResult> AddArticle(ArticleToSaveDto articleToSave, int userId)
        {
            var article = _mapper.Map<Article>(articleToSave);

            if (!(await _identityService.IsUserExist(userId)))
            {
                return new ErrorResult(ErrorMessages.NoAuthenticatedUser, HttpStatusCode.Forbidden);
            }

            article.UserId = userId;
            _articleRepository.Add(article);
            article.SetDateTime();
            await _unitOfWork.CompleteAsync();

            return new SuccessResult(HttpStatusCode.Created);
        }

        public async Task<IResult> DeleteArticle(int articleId, int userId)
        {
            if (!(await _identityService.IsUserExist(userId)))
            {
                return new ErrorResult(ErrorMessages.NoAuthenticatedUser, HttpStatusCode.Forbidden);
            }


            var article = await _articleRepository.FindAsync(a => a.Id == articleId);

            if (article == null)
            {
                return new ErrorResult(ErrorMessages.ArticleNotFound, HttpStatusCode.NotFound);
            }

            _articleRepository.Delete(article);

            await _unitOfWork.CompleteAsync();

            return new SuccessResult(HttpStatusCode.NoContent);
        }

        public async Task<IDataResult<PagedList<ArticleToListDto>>> ListArticle(ArticleParams articleParams)
        {
            var pagedList =await _articleRepository.GetFilterList(articleParams);

            return new SuccessDataResult<PagedList<ArticleToListDto>>(pagedList);
        }

        public async Task<IResult> UpdateArticle(int articleId, ArticleToSaveDto articleToSaveDto, int userId)
        {
            var article = await _articleRepository.FindAsync(a => a.Id == articleId);

            if (article == null)
            {
                return new ErrorResult(ErrorMessages.ArticleNotFound, HttpStatusCode.NotFound);
            }

            var articleToSave = _mapper.Map(articleToSaveDto, article);

            if (!(await _identityService.IsUserExist(userId)))
            {
                return new ErrorResult(ErrorMessages.NoAuthenticatedUser, HttpStatusCode.Forbidden);
            }

            article.SetDateTime();

            await _unitOfWork.CompleteAsync();

            return new SuccessResult(HttpStatusCode.Created);
        }
    }
}
