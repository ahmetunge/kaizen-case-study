using Kaizen.Blog.Business.Interfaces;
using Kaizen.Blog.Dtos;
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
    public class IdentityController : ApiBaseController
    {
        private readonly IIdentityService _identityService;
        private readonly ILogger _logger;

        public IdentityController(IIdentityService identityService,ILogger logger)
        {
            _identityService = identityService;
           _logger = logger;
        }

        [AllowAnonymous]
        [HttpPost("register")]
        public async Task<IActionResult> Register([FromBody]UserRegisterDto userRegisterDto)
        {
            _logger.Information("User register",userRegisterDto);
            return ApiResult(await _identityService.Register(userRegisterDto));
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login([FromBody] UserLoginDto userLoginDto)
        {
            return ApiResult(await _identityService.Login(userLoginDto));
        }
    }
}
