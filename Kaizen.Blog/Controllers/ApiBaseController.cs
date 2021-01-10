using Kaizen.Blog.Utilities.Results;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Blog.Controllers
{
    [ApiController]
    public class ApiBaseController : ControllerBase
    {

        protected IActionResult ApiResult(IResult result)
        {
            if (result.Success)
            {
                return Ok(result);
            }

            return BadRequest(result);
        }

        protected IActionResult ApiResultWithHeader<T>()
        {
            return Ok();
            //if (result.Success)
            //{
            //    var data = result.Data;
            //    Response.AddPagination(data.CurrentPage, data.PageSize, data.TotalCount, data.TotalPages);

            //    return Ok(result);
            //}

            //return BadRequest(result);
        }

        
    }
}
