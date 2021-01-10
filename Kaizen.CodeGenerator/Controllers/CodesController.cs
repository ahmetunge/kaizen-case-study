using Kaizen.CodeGenerator.Models;
using Kaizen.CodeGenerator.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Kaizen.CodeGenerator.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CodesController : ControllerBase
    {
        private readonly IGeneratorService _generatorService;

        public CodesController(IGeneratorService generatorService)
        {
            _generatorService = generatorService;
        }

        [HttpPost("generate")]
        public IActionResult GenerateCodes([FromBody] Coder coder)
        {
            var listOfCodes = _generatorService.GenerateCode(coder);
            return Ok(listOfCodes);
        }

        [HttpPost("validate")]
        public IActionResult GenerateCodes([FromBody] string code)
        {
            var result = _generatorService.ValidateCode(code.ToUpper());

            if (result)
            {
                return Ok("This code is valid");
            }
            else
            {
                return BadRequest("This code is invalid");
            }

        }
    }
}
