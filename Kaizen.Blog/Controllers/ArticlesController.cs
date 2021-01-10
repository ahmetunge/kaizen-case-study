using Kaizen.Blog.Business.Interfaces;
using Kaizen.Blog.Dtos;
using Kaizen.Blog.Extensions;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Serilog;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ArticlesController : ApiBaseController
    {
        private readonly IArticleService _articleService;

        private readonly ILogger _logger;

        public ArticlesController(IArticleService articleService, ILogger logger)
        {
            _articleService = articleService;
            _logger = logger;
        }

        [Authorize]
        [HttpPost]
        public async Task<IActionResult> AddArticle([FromBody]ArticleToSaveDto articleToSaveDto)
        {
            
            var userId = this.User.GetAuthenticatedUserId();

            if (userId == null)
                return Unauthorized();

            return ApiResult(await _articleService.AddArticle(articleToSaveDto,userId.Value));
        }

        [Authorize]
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteArticle(int id)
        {
            var userId = this.User.GetAuthenticatedUserId();

            if (userId == null)
                return Unauthorized();

            return ApiResult(await _articleService.DeleteArticle(id,userId.Value));
        }

        [Authorize]
        [HttpPut("{id}")]
        public async Task<IActionResult> UpdateArticle([FromBody]ArticleToSaveDto articleToSaveDto, int id)
        {
            var userId = this.User.GetAuthenticatedUserId();

            if (userId == null)
                return Unauthorized();

            return ApiResult(await _articleService.UpdateArticle(id,articleToSaveDto, userId.Value));
        }

        [HttpGet]
        public async Task<IActionResult> ListArticle([FromQuery]ArticleParams articleParams)
        {
            _logger.Information("Get Article List");
            return ApiResult(await _articleService.ListArticle(articleParams));
        }
    }
}
