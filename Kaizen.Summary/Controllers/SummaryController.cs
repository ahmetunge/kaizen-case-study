using Kaizen.Summary.Dtos;
using Kaizen.Summary.Services;
using Kaizen.Summary.Utilities;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.Summary.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class SummaryController : ControllerBase
    {
        private readonly IHttpConnectService _httpConnectService;

        public SummaryController(IHttpConnectService httpConnectService)
        {
            _httpConnectService = httpConnectService;
        }


        [HttpPost]
        public async Task<IActionResult> Summary([FromBody]SummaryDto summary)
        {
            var strResult = await _httpConnectService.PostData(summary, "Summary");

            if (!string.IsNullOrEmpty(strResult))
            {
                return Ok(JsonConvert.DeserializeObject<SummaryHttpResponse>(strResult));
            }


            return BadRequest("An error occured");
        }
    }
}
